using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using TestStack.White.Configuration;
using TestStack.White.Drawing;
using TestStack.White.UIA;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;
using TestStack.White.WindowsAPI;
using Action = TestStack.White.UIItems.Actions.Action;

namespace TestStack.White.InputDevices
{
    public class Mouse : IMouse
    {
        [DllImport("user32", EntryPoint = "SendInput")]
        static extern int SendInput(uint numberOfInputs, ref Input input, int structSize);

        [DllImport("user32", EntryPoint = "SendInput")]
        static extern int SendInput64(int numberOfInputs, ref Input64 input, int structSize);

        [DllImport("user32.dll")]
        static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]

        static extern bool GetCursorPos(ref System.Drawing.Point cursorInfo);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(ref CursorInfo cursorInfo);

        [DllImport("user32.dll")]
        static extern short GetDoubleClickTime();

        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(SystemMetric smIndex);

        public static Mouse Instance = new Mouse();
        DateTime lastClickTime = DateTime.Now;
        readonly short doubleClickTime = GetDoubleClickTime();
        Point lastClickLocation;
        const int ExtraMillisecondsBecauseOfBugInWindows = 13;

        Mouse() { }

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
                SetCursorPos((int)value.X, (int)value.Y);
            }
        }

        public virtual MouseCursor Cursor
        {
            get
            {
                CursorInfo cursorInfo = CursorInfo.New();
                GetCursorInfo(ref cursorInfo);
                int i = cursorInfo.handle.ToInt32();
                return new MouseCursor(i);
            }
        }

        private static int RightMouseButtonDown
        {
            get { return GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) == 0 ? WindowsConstants.MOUSEEVENTF_RIGHTDOWN : WindowsConstants.MOUSEEVENTF_LEFTDOWN; }
        }

        private static int RightMouseButtonUp
        {
            get { return GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) == 0 ? WindowsConstants.MOUSEEVENTF_RIGHTUP : WindowsConstants.MOUSEEVENTF_LEFTUP; }
        }

        private static int LeftMouseButtonDown
        {
            get { return GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) == 0 ? WindowsConstants.MOUSEEVENTF_LEFTDOWN : WindowsConstants.MOUSEEVENTF_RIGHTDOWN; }
        }

        private static int LeftMouseButtonUp
        {
            get { return GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) == 0 ? WindowsConstants.MOUSEEVENTF_LEFTUP : WindowsConstants.MOUSEEVENTF_RIGHTUP; }
        }

        public virtual void RightClick()
        {
            SendInput(InputFactory.Mouse(MouseInput(RightMouseButtonDown)));
            SendInput(InputFactory.Mouse(MouseInput(RightMouseButtonUp)));
        }

        public virtual void Click()
        {
            Point clickLocation = Location;
            if (lastClickLocation.Equals(clickLocation))
            {
                int timeout = doubleClickTime - DateTime.Now.Subtract(lastClickTime).Milliseconds;
                if (timeout > 0) Thread.Sleep(timeout + ExtraMillisecondsBecauseOfBugInWindows);
            }
            MouseLeftButtonUpAndDown();
            lastClickTime = DateTime.Now;
            lastClickLocation = Location;
        }

        public static void LeftUp()
        {
            SendInput(InputFactory.Mouse(MouseInput(LeftMouseButtonUp)));
        }

        public static void LeftDown()
        {
            SendInput(InputFactory.Mouse(MouseInput(LeftMouseButtonDown)));
        }
        //SU - Added for RightDragandDrop
        public static void RightUp()
        {
            SendInput(InputFactory.Mouse(MouseInput(RightMouseButtonUp)));
        }

        public static void RightDown()
        {
            SendInput(InputFactory.Mouse(MouseInput(RightMouseButtonDown)));
        }

        public virtual void DoubleClick(Point point)
        {
            DoubleClick(point, new NullActionListener());
        }

        public virtual void DoubleClick(Point point, ActionListener actionListener)
        {
            Location = point;
            MouseLeftButtonUpAndDown();
            Thread.Sleep(CoreAppXmlConfiguration.Instance.DoubleClickInterval);
            MouseLeftButtonUpAndDown();
            ActionPerformed(actionListener);
        }

        private static void SendInput(Input input)
        {
            // Added check for 32/64 bit  
            if (IntPtr.Size == 4)
                SendInput(1, ref input, Marshal.SizeOf(typeof(Input)));
            else
            {
                var input64 = new Input64(input);
                SendInput64(1, ref input64, Marshal.SizeOf(typeof(Input)));
            }
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
        public virtual void DragAndDrop(IUIItem draggedItem, Point startPosition, IUIItem dropItem, Point endPosition)
        {
            Location = startPosition;
            HoldForDrag();
            var dragStepFraction = (float)(1.0 / CoreAppXmlConfiguration.Instance.DragStepCount);
            for (int i = 1; i <= CoreAppXmlConfiguration.Instance.DragStepCount; i++)
            {
                double newX = startPosition.X + (endPosition.X - startPosition.X) * (dragStepFraction * i);
                double newY = startPosition.Y + (endPosition.Y - startPosition.Y) * (dragStepFraction * i);
                var newPoint = new Point((int)newX, (int)newY);
                Location = newPoint;
            }
            LeftUp();
            dropItem.ActionPerformed(Action.WindowMessage);
        }

        public virtual void DragAndDrop_RMB(IUIItem draggedItem, Point startPosition, IUIItem dropItem, Point endPosition)
        {
            Location = startPosition;
            RightDown();
            var dragStepFraction = (float)(1.0 / CoreAppXmlConfiguration.Instance.DragStepCount);
            for (int i = 1; i <= CoreAppXmlConfiguration.Instance.DragStepCount; i++)
            {
                double newX = startPosition.X + (endPosition.X - startPosition.X) * (dragStepFraction * i);
                double newY = startPosition.Y + (endPosition.Y - startPosition.Y) * (dragStepFraction * i);
                var newPoint = new Point((int)newX, (int)newY);
                Location = newPoint;
            }
            RightUp();
            dropItem.ActionPerformed(Action.WindowMessage);
        }

        private void HoldForDrag()
        {
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
            Location = uiItem.Bounds.Center();
            double currentXLocation = Location.X;
            double currentYLocation = Location.Y;
            HoldForDrag();
            ActionPerformed(uiItem);
            Location = new Point(currentXLocation + distance, currentYLocation);
            LeftUp();
        }

        public virtual void DragVertically(UIItem uiItem, int distance)
        {
            Location = uiItem.Bounds.Center();
            double currentXLocation = Location.X;
            double currentYLocation = Location.Y;
            HoldForDrag();
            ActionPerformed(uiItem);
            Location = new Point(currentXLocation, currentYLocation + distance);
            LeftUp();
        }
    }
}