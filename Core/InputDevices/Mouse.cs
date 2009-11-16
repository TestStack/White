using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using White.Core.Drawing;
using White.Core.UIA;
using White.Core.Configuration;
using White.Core.Logging;
using White.Core.UIItems;
using White.Core.UIItems.Actions;
using White.Core.WindowsAPI;
using Action=White.Core.UIItems.Actions.Action;

namespace White.Core.InputDevices
{
    public class Mouse : IMouse
    {
        [DllImport("user32", EntryPoint = "SendInput")]
        private static extern int SendInput(int numberOfInputs, ref Input input, int structSize);

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(ref System.Drawing.Point cursorInfo);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(System.Drawing.Point cursorInfo);

        [DllImport("user32.dll")]
        private static extern bool GetCursorInfo(ref CursorInfo cursorInfo);

        [DllImport("user32.dll")]
        private static extern short GetDoubleClickTime();

        public static Mouse Instance = new Mouse();
        private DateTime lastClickTime = DateTime.Now;
        private readonly short doubleClickTime = GetDoubleClickTime();
        private Point lastClickLocation;
        private const int extraMillisecondsBecauseOfBugInWindows = 13;

        private Mouse() {}

        public virtual Point Location
        {
            get
            {
                var point = new System.Drawing.Point();
                GetCursorPos(ref point);
                return point.ConvertToWindowsPoint();
            }
            set
            {
                if (value.IsInvalid())
                {
                    throw new WhiteException(string.Format("Trying to set location outside the screen. {0}", value));
                }
                SetCursorPos(value.ToDrawingPoint());
            }
        }

        public virtual MouseCursor Cursor
        {
            get
            {
                CursorInfo cursorInfo = CursorInfo.New();
                GetCursorInfo(ref cursorInfo);
                int i = cursorInfo.handle.ToInt32();
                return (MouseCursor) Enum.ToObject(typeof (MouseCursor), i);
            }
        }

        public virtual void RightClick()
        {
            SendInput(Input.Mouse(MouseInput(WindowsConstants.MOUSEEVENTF_RIGHTDOWN)));
            SendInput(Input.Mouse(MouseInput(WindowsConstants.MOUSEEVENTF_RIGHTUP)));
        }

        public virtual void Click()
        {
            Point clickLocation = Location;
            if (lastClickLocation.Equals(clickLocation))
            {
                int timeout = doubleClickTime - DateTime.Now.Subtract(lastClickTime).Milliseconds;
                if (timeout > 0) Thread.Sleep(timeout + extraMillisecondsBecauseOfBugInWindows);
            }
            MouseLeftButtonUpAndDown();
            lastClickTime = DateTime.Now;
            lastClickLocation = Location;
        }

        public static void LeftUp()
        {
            SendInput(Input.Mouse(MouseInput(WindowsConstants.MOUSEEVENTF_LEFTUP)));
        }

        public static void LeftDown()
        {
            SendInput(Input.Mouse(MouseInput(WindowsConstants.MOUSEEVENTF_LEFTDOWN)));
        }

        public virtual void DoubleClick(Point point)
        {
            DoubleClick(point, new NullActionListener());
        }

        public virtual void DoubleClick(Point point, ActionListener actionListener)
        {
            Location = point;
            MouseLeftButtonUpAndDown();
            MouseLeftButtonUpAndDown();
            ActionPerformed(actionListener);
        }

        private static void SendInput(Input input)
        {
            SendInput(1, ref input, Marshal.SizeOf(typeof (Input)));
        }

        private static MouseInput MouseInput(int command)
        {
            return new MouseInput(command, GetMessageExtraInfo());
        }

        public virtual void RightClick(Point point, ActionListener actionListener)
        {
            Location = point;
            RightClickHere(actionListener);
        }

        public virtual void RightClick(Point point)
        {
            RightClick(point, new NullActionListener());
        }

        internal virtual void RightClickHere(ActionListener actionListener)
        {
            RightClick();
            actionListener.ActionPerformed(Action.WindowMessage);
        }

        public virtual void Click(Point point)
        {
            Click(point, new NullActionListener());
        }

        public virtual void Click(Point point, ActionListener actionListener)
        {
            Location = point;
            Click();
            ActionPerformed(actionListener);
        }

        private static void ActionPerformed(ActionListener actionListener)
        {
            actionListener.ActionPerformed(new Action(ActionType.WindowMessage));
        }

        /// <summary>
        /// Drags the dragged item and drops it on the drop item. This can be used for any two UIItems
        /// whether they are same application or different. To drop items on desktop use Desktop 
        /// class's Drop method. White starts and ends the drag from center of the UIItems.
        /// Some drag and drop operation need to wait for application to process something while item is being dragged.
        /// This can be set but configuring DragStepCount property. This is by default set to 1.
        /// </summary>
        /// <param name="draggedItem"></param>
        /// <param name="dropItem"></param>
        public virtual void DragAndDrop(IUIItem draggedItem, IUIItem dropItem)
        {
            Point startPosition = draggedItem.Bounds.Center();
            Point endPosition = dropItem.Bounds.Center();
            DragAndDrop(draggedItem, startPosition, dropItem, endPosition);
        }

        /// <summary>
        /// Drags the dragged item and drops it on the drop item. This can be used for any two UIItems
        /// whether they are same application or different. To drop items on desktop use Desktop 
        /// class's Drop method. White starts and ends the drag from center of the UIItems.
        /// Some drag and drop operation need to wait for application to process something while item is being dragged.
        /// This can be set but configuring DragStepCount property. This is by default set to 1.
        /// </summary>
        /// <param name="draggedItem"></param>
        /// <param name="startPosition">Start point of the drag. You can do uiItem.Bounds to get bounds of the UIItem and use RectX extension class in White.Core.UIA namespace to find different points</param>
        /// <param name="dropItem"></param>
        /// <param name="endPosition">End point of the drag. You can do uiItem.Bounds to get bounds of the UIItem and use RectX extension class in White.Core.UIA namespace to find different points</param>
        public void DragAndDrop(IUIItem draggedItem, Point startPosition, IUIItem dropItem, Point endPosition)
        {
            Location = startPosition;
            HoldForDrag();
            draggedItem.ActionPerformed(Action.WindowMessage);
            var dragStepFraction = (float)(1.0 / CoreAppXmlConfiguration.Instance.DragStepCount);
            WhiteLogger.Instance.Info(CoreAppXmlConfiguration.Instance.DragStepCount + ":" + dragStepFraction);
            for (int i = 1; i <= CoreAppXmlConfiguration.Instance.DragStepCount; i++)
            {
                double newX = startPosition.X + (endPosition.X - startPosition.X) * (dragStepFraction * i);
                double newY = startPosition.Y + (endPosition.Y - startPosition.Y) * (dragStepFraction * i);
                var newPoint = new Point((int)newX, (int)newY);
                Location = newPoint;
                draggedItem.ActionPerformed(Action.WindowMessage);
            }
            LeftUp();
            dropItem.ActionPerformed(Action.WindowMessage);
        }

        private void HoldForDrag()
        {
            LeftDown();
            LeftUp();
            LeftDown();
        }

        public static void MouseLeftButtonUpAndDown()
        {
            LeftDown();
            LeftUp();
        }

        public virtual void MoveOut()
        {
            Location = new Point(0, 0);
        }

        public virtual void DragHorizontally(UIItem uiItem, int distance)
        {
            Location = uiItem.Location;
            double currentXLocation = Location.X;
            double currentYLocation = Location.Y;
            HoldForDrag();
            ActionPerformed(uiItem);
            Location = new Point(currentXLocation + distance, currentYLocation);
            LeftUp();
        }

        public virtual void DragVertically(UIItem uiItem, int distance)
        {
            Location = uiItem.Location;
            double currentXLocation = Location.X;
            double currentYLocation = Location.Y;
            HoldForDrag();
            ActionPerformed(uiItem);
            Location = new Point(currentXLocation, currentYLocation + distance);
            LeftUp();
        }
    }
}