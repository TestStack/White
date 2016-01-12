using System;
using System.Collections.Generic;
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
        Dictionary<MouseButton, DateTime> lastClickTimes;
        Dictionary<MouseButton, Point> lastClickLocations;
        readonly short doubleClickTime = GetDoubleClickTime();
        const int ExtraMillisecondsBecauseOfBugInWindows = 13;

        Mouse()
        {
            lastClickTimes = new Dictionary<MouseButton, DateTime>();
            lastClickLocations = new Dictionary<MouseButton, Point>();
            foreach (MouseButton mouseButton in Enum.GetValues(typeof(MouseButton)))
            {
                lastClickTimes.Add(mouseButton, DateTime.Now);
                lastClickLocations.Add(mouseButton, new Point(0, 0));
            }
        }

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

        /// <summary>
        /// Clicks the specified mouse button. Makes sure to not accidentaly fire a double click
        /// if called multiple times
        /// </summary>
        public virtual void Click(MouseButton mouseButton)
        {
            var currentClickLocation = Location;
            // Check if the location is the same as with last click
            if (lastClickLocations[mouseButton].Equals(currentClickLocation))
            {
                // Get the timeout needed to not fire a double click
                int timeout = doubleClickTime - DateTime.Now.Subtract(lastClickTimes[mouseButton]).Milliseconds;
                // Wait the needed time to prevent the double click
                if (timeout > 0) Thread.Sleep(timeout + ExtraMillisecondsBecauseOfBugInWindows);
            }
            // Perform the click
            MouseButtonUpAndDown(mouseButton);
            // Update the time and location
            lastClickTimes[mouseButton] = DateTime.Now;
            lastClickLocations[mouseButton] = Location;
        }

        public virtual void Click(MouseButton mouseButton, Point point)
        {
            Location = point;
            Click(mouseButton);
        }

        public virtual void Click(MouseButton mouseButton, IActionListener actionListener)
        {
            Click(mouseButton);
            ActionPerformed(actionListener);
        }

        public virtual void Click(MouseButton mouseButton, Point point, IActionListener actionListener)
        {
            Location = point;
            Click(mouseButton);
            ActionPerformed(actionListener);
        }

        /// <summary>
        /// Double clicks the specified mouse button.
        /// </summary>
        public virtual void DoubleClick(MouseButton mouseButton)
        {
            MouseButtonUpAndDown(mouseButton);
            Thread.Sleep(CoreAppXmlConfiguration.Instance.DoubleClickInterval);
            MouseButtonUpAndDown(mouseButton);
        }

        public virtual void DoubleClick(MouseButton mouseButton, Point point)
        {
            Location = point;
            DoubleClick(mouseButton);
        }

        public virtual void DoubleClick(MouseButton mouseButton, IActionListener actionListener)
        {
            DoubleClick(mouseButton);
            ActionPerformed(actionListener);
        }

        public virtual void DoubleClick(MouseButton mouseButton, Point point, IActionListener actionListener)
        {
            Location = point;
            DoubleClick(mouseButton);
            ActionPerformed(actionListener);
        }

        /// <summary>
        /// Performs a down / up sequence for the specified button
        /// </summary>
        private static void MouseButtonUpAndDown(MouseButton mouseButton)
        {
            MouseButtonDown(mouseButton);
            MouseButtonUp(mouseButton);
            // Let the Raw Input Thread some time to process OS's hardware input queue.
            // As this thread works with High priority - this short wait should be enough hopefully.
            // For details see this post: http://blogs.msdn.com/b/oldnewthing/archive/2014/02/13/10499047.aspx
            Thread.Sleep(CoreAppXmlConfiguration.Instance.RawInputQueueProcessingTime);
        }

        /// <summary>
        /// Performs a down for the specified button
        /// </summary>
        private static void MouseButtonDown(MouseButton mouseButton)
        {
            SendInput(InputFactory.Mouse(GetInputForButton(mouseButton, true)));
        }

        /// <summary>
        /// Performs an up for the specified button
        /// </summary>
        private static void MouseButtonUp(MouseButton mouseButton)
        {
            SendInput(InputFactory.Mouse(GetInputForButton(mouseButton, false)));
        }

        /// <summary>
        /// Generates the input object for the button
        /// </summary>
        /// <param name="mouseButton">The button to get the input for</param>
        /// <param name="isDown">Flag if down is wanted, up otherwise</param>
        private static MouseInput GetInputForButton(MouseButton mouseButton, bool isDown)
        {
            switch (mouseButton)
            {
                case MouseButton.Left:
                    return MouseInput(isDown ? LeftMouseButtonDown : LeftMouseButtonUp);
                case MouseButton.Right:
                    return MouseInput(isDown ? RightMouseButtonDown : RightMouseButtonUp);
                case MouseButton.Middle:
                    return MouseInput(isDown ? WindowsConstants.MOUSEEVENTF_MIDDLEDOWN : WindowsConstants.MOUSEEVENTF_MIDDLEUP);
                case MouseButton.XButton1:
                    return MouseInput(isDown ? WindowsConstants.MOUSEEVENTF_XDOWN : WindowsConstants.MOUSEEVENTF_XUP, 0x0001);
                case MouseButton.XButton2:
                    return MouseInput(isDown ? WindowsConstants.MOUSEEVENTF_XDOWN : WindowsConstants.MOUSEEVENTF_XUP, 0x0002);
                default:
                    throw new ArgumentOutOfRangeException("mouseButton", "Unknown mouse button");
            }
        }

        /// <summary>
        /// Performs a left click
        /// </summary>
        public virtual void Click()
        {
            Click(MouseButton.Left);
        }

        public virtual void Click(Point point)
        {
            Click(MouseButton.Left, point);
        }

        public virtual void Click(Point point, IActionListener actionListener)
        {
            Click(MouseButton.Left, point, actionListener);
        }

        /// <summary>
        /// Performs a right click
        /// </summary>
        public virtual void RightClick()
        {
            Click(MouseButton.Right);
        }

        public virtual void RightClick(Point point)
        {
            Click(MouseButton.Right, point);
        }

        public virtual void RightClick(Point point, IActionListener actionListener)
        {
            Click(MouseButton.Right, point, actionListener);
        }

        /// <summary>
        /// Performs a left double click
        /// </summary>
        public virtual void DoubleClick(Point point)
        {
            DoubleClick(MouseButton.Left, point);
        }

        public virtual void DoubleClick(Point point, IActionListener actionListener)
        {
            DoubleClick(MouseButton.Left, point, actionListener);
        }

        public static void LeftUp()
        {
            MouseButtonUp(MouseButton.Left);
        }

        public static void LeftDown()
        {
            MouseButtonDown(MouseButton.Left);
        }

        public static void RightUp()
        {
            MouseButtonUp(MouseButton.Right);
        }

        public static void RightDown()
        {
            MouseButtonDown(MouseButton.Right);
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

        private static MouseInput MouseInput(int command, int mouseData = 0)
        {
            return new MouseInput(command, GetMessageExtraInfo(), mouseData);
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
        public virtual void DragAndDrop(MouseButton mouseButton, IUIItem draggedItem, IUIItem dropItem)
        {
            Point startPosition = draggedItem.Bounds.Center();
            Point endPosition = dropItem.Bounds.Center();
            DragAndDrop(mouseButton, draggedItem, startPosition, dropItem, endPosition);
        }

        public virtual void DragAndDrop(IUIItem draggedItem, IUIItem dropItem)
        {
            DragAndDrop(MouseButton.Left, draggedItem, dropItem);
        }

        /// <summary>
        /// Drags the dragged item and drops it on the drop item. This can be used for any two UIItems
        /// whether they are same application or different. To drop items on desktop use Desktop 
        /// class's Drop method. White starts and ends the drag from center of the UIItems.
        /// Some drag and drop operation need to wait for application to process something while item is being dragged.
        /// This can be set but configuring DragStepCount property. This is by default set to 1.
        /// </summary>
        /// <param name="mouseButton">The mouse button used for dragging</param>
        /// <param name="draggedItem"></param>
        /// <param name="startPosition">Start point of the drag. You can do uiItem.Bounds to get bounds of the UIItem and use RectX extension class in White.Core.UIA namespace to find different points</param>
        /// <param name="dropItem"></param>
        /// <param name="endPosition">End point of the drag. You can do uiItem.Bounds to get bounds of the UIItem and use RectX extension class in White.Core.UIA namespace to find different points</param>
        public virtual void DragAndDrop(MouseButton mouseButton, IUIItem draggedItem, Point startPosition, IUIItem dropItem, Point endPosition)
        {
            Location = startPosition;
            MouseButtonDown(mouseButton);
            var dragStepFraction = (float)(1.0 / CoreAppXmlConfiguration.Instance.DragStepCount);
            for (int i = 1; i <= CoreAppXmlConfiguration.Instance.DragStepCount; i++)
            {
                var newX = startPosition.X + (endPosition.X - startPosition.X) * (dragStepFraction * i);
                var newY = startPosition.Y + (endPosition.Y - startPosition.Y) * (dragStepFraction * i);
                var newPoint = new Point((int)newX, (int)newY);
                Location = newPoint;
            }
            MouseButtonUp(mouseButton);
            dropItem.ActionPerformed(Action.WindowMessage);
        }

        public virtual void DragAndDrop(IUIItem draggedItem, Point startPosition, IUIItem dropItem, Point endPosition)
        {
            DragAndDrop(MouseButton.Left, draggedItem, startPosition, dropItem, endPosition);
        }

        public virtual void DragHorizontally(MouseButton mouseButton, UIItem uiItem, int distance)
        {
            Location = uiItem.Bounds.Center();
            var currentXLocation = Location.X;
            var currentYLocation = Location.Y;
            MouseButtonDown(mouseButton);
            ActionPerformed(uiItem);
            Location = new Point(currentXLocation + distance, currentYLocation);
            MouseButtonUp(mouseButton);
        }

        public virtual void DragVertically(MouseButton mouseButton, UIItem uiItem, int distance)
        {
            Location = uiItem.Bounds.Center();
            var currentXLocation = Location.X;
            var currentYLocation = Location.Y;
            MouseButtonDown(mouseButton);
            ActionPerformed(uiItem);
            Location = new Point(currentXLocation, currentYLocation + distance);
            MouseButtonUp(mouseButton);
        }

        public virtual void DragHorizontally(UIItem uiItem, int distance)
        {
            DragHorizontally(MouseButton.Left, uiItem, distance);
        }

        public virtual void DragVertically(UIItem uiItem, int distance)
        {
            DragVertically(MouseButton.Left, uiItem, distance);
        }

        public virtual void MoveOut()
        {
            Location = new Point(0, 0);
        }
    }
}