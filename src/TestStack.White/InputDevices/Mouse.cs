using System;
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
        public static Mouse Instance = new Mouse();
        DateTime lastClickTime = DateTime.Now;
        readonly short doubleClickTime = Native.GetDoubleClickTime();
        Point lastClickLocation;
        const int ExtraMillisecondsBecauseOfBugInWindows = 13;

        Mouse() { }

        public virtual Point Location
        {
            get
            {
                var point = new System.Drawing.Point();
                Native.GetCursorPos(ref point);
                return point.ConvertToWindowsPoint();
            }
            set
            {
                if (value.IsInvalid())
                {
                    throw new WhiteException(string.Format("Trying to set location outside the screen. {0}", value));
                }
                Native.SetCursorPos((int)value.X, (int)value.Y);
            }
        }

        public virtual MouseCursor Cursor
        {
            get
            {
                CursorInfo cursorInfo = CursorInfo.New();
                Native.GetCursorInfo(ref cursorInfo);
                int i = cursorInfo.handle.ToInt32();
                return new MouseCursor(i);
            }
        }

        private static int RightMouseButtonDown
        {
            get { return Native.GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) == 0 ? WindowsConstants.MOUSEEVENTF_RIGHTDOWN : WindowsConstants.MOUSEEVENTF_LEFTDOWN; }
        }

        private static int RightMouseButtonUp
        {
            get { return Native.GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) == 0 ? WindowsConstants.MOUSEEVENTF_RIGHTUP : WindowsConstants.MOUSEEVENTF_LEFTUP; }
        }

        private static int LeftMouseButtonDown
        {
            get { return Native.GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) == 0 ? WindowsConstants.MOUSEEVENTF_LEFTDOWN : WindowsConstants.MOUSEEVENTF_RIGHTDOWN; }
        }

        private static int LeftMouseButtonUp
        {
            get { return Native.GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) == 0 ? WindowsConstants.MOUSEEVENTF_LEFTUP : WindowsConstants.MOUSEEVENTF_RIGHTUP; }
        }

        public virtual void RightClick()
        {
            Native.SendInput(InputFactory.Mouse(MouseInput(RightMouseButtonDown)));
            Native.SendInput(InputFactory.Mouse(MouseInput(RightMouseButtonUp)));

            // Let the Raw Input Thread some time to process OS's hardware input queue.
            // As this thread works with High priority - this short wait should be enough hopefully.
            // For details see this post: http://blogs.msdn.com/b/oldnewthing/archive/2014/02/13/10499047.aspx
            Thread.Sleep(CoreAppXmlConfiguration.Instance.RawInputQueueProcessingTime);
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
            Native.SendInput(InputFactory.Mouse(MouseInput(LeftMouseButtonUp)));
        }

        public static void LeftDown()
        {
            Native.SendInput(InputFactory.Mouse(MouseInput(LeftMouseButtonDown)));
        }

        public virtual void DoubleClick(Point point)
        {
            DoubleClick(point, new NullActionListener());
        }

        public virtual void DoubleClick(Point point, IActionListener actionListener)
        {
            Location = point;
            LeftDown();
            LeftUp();
            Thread.Sleep(CoreAppXmlConfiguration.Instance.DoubleClickInterval);
            LeftDown();
            LeftUp();

            // Let the Raw Input Thread some time to process OS's hardware input queue.
            // As this thread works with High priority - this short wait should be enough hopefully.
            // For details see this post: http://blogs.msdn.com/b/oldnewthing/archive/2014/02/13/10499047.aspx
            Thread.Sleep(CoreAppXmlConfiguration.Instance.RawInputQueueProcessingTime);
            
            ActionPerformed(actionListener);
        }

        private static MouseInput MouseInput(int command)
        {
            return new MouseInput(command, Native.GetMessageExtraInfo());
        }

        public virtual void RightClick(Point point, IActionListener actionListener)
        {
            Location = point;
            RightClickHere(actionListener);
        }

        public virtual void RightClick(Point point)
        {
            RightClick(point, new NullActionListener());
        }

        internal virtual void RightClickHere(IActionListener actionListener)
        {
            RightClick();
            actionListener.ActionPerformed(Action.WindowMessage);
        }

        public virtual void Click(Point point)
        {
            Click(point, new NullActionListener());
        }

        public virtual void Click(Point point, IActionListener actionListener)
        {
            Location = point;
            Click();
            ActionPerformed(actionListener);
        }

        private static void ActionPerformed(IActionListener actionListener)
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

        private void HoldForDrag()
        {
            LeftDown();
        }

        public static void MouseLeftButtonUpAndDown()
        {
            LeftDown();
            LeftUp();

            // Let the Raw Input Thread some time to process OS's hardware input queue.
            // As this thread works with High priority - this short wait should be enough hopefully.
            // For details see this post: http://blogs.msdn.com/b/oldnewthing/archive/2014/02/13/10499047.aspx
            Thread.Sleep(CoreAppXmlConfiguration.Instance.RawInputQueueProcessingTime);
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