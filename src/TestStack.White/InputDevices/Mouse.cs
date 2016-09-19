using System;
using System.Collections.Generic;
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
    public class Mouse : IMouseWithActionListener
    {
        protected readonly Dictionary<MouseButton, DateTime> LastClickTimes;
        protected readonly Dictionary<MouseButton, Point> LastClickLocations;
        protected readonly short DoubleClickTime = MouseWin32.GetDoubleClickTime();
        protected const int ExtraMillisecondsBecauseOfBugInWindows = 13;

        [Obsolete("Obsolete. Create an instance via new where you need it")]
        public static Mouse Instance = new Mouse();

        public Mouse()
        {
            LastClickTimes = new Dictionary<MouseButton, DateTime>();
            LastClickLocations = new Dictionary<MouseButton, Point>();
            foreach (MouseButton mouseButton in Enum.GetValues(typeof(MouseButton)))
            {
                LastClickTimes.Add(mouseButton, DateTime.Now);
                LastClickLocations.Add(mouseButton, new Point(0, 0));
            }
        }

        /// <summary>
        /// Implements <see cref="IMouse.Location"/>
        /// </summary>
        public virtual Point Location
        {
            get
            {
                var point = new System.Drawing.Point();
                MouseWin32.GetCursorPos(ref point);
                return point.ConvertToWindowsPoint();
            }
            set
            {
                if (value.IsInvalid())
                {
                    throw new WhiteException(string.Format("Trying to set location outside the screen. {0}", value));
                }
                MouseWin32.SetCursorPos((int)value.X, (int)value.Y);
            }
        }

        /// <summary>
        /// Implements <see cref="IMouse.Cursor"/>
        /// </summary>
        public virtual MouseCursor Cursor
        {
            get
            {
                var cursorInfo = CursorInfo.New();
                MouseWin32.GetCursorInfo(ref cursorInfo);
                var i = cursorInfo.handle.ToInt32();
                return new MouseCursor(i);
            }
        }

        /// <summary>
        /// Implements <see cref="IMouse.Click(MouseButton)"/>
        /// </summary>
        public virtual void Click(MouseButton mouseButton)
        {
            var currentClickLocation = Location;
            // Check if the location is the same as with last click
            if (LastClickLocations[mouseButton].Equals(currentClickLocation))
            {
                // Get the timeout needed to not fire a double click
                var timeout = DoubleClickTime - DateTime.Now.Subtract(LastClickTimes[mouseButton]).Milliseconds;
                // Wait the needed time to prevent the double click
                if (timeout > 0)
                {
                    Thread.Sleep(timeout + ExtraMillisecondsBecauseOfBugInWindows);
                }
            }
            // Perform the click
            MouseWin32.MouseButtonUpAndDown(mouseButton);
            // Update the time and location
            LastClickTimes[mouseButton] = DateTime.Now;
            LastClickLocations[mouseButton] = Location;
        }

        /// <summary>
        /// Implements <see cref="IMouseWithActionListener.Click(MouseButton, IActionListener)"/>
        /// </summary>
        public virtual void Click(MouseButton mouseButton, IActionListener actionListener)
        {
            Click(mouseButton);
            ActionPerformed(actionListener);
        }

        /// <summary>
        /// Implements <see cref="IMouse.Click(MouseButton, Point)"/>
        /// </summary>
        public virtual void Click(MouseButton mouseButton, Point point)
        {
            Move(point);
            Click(mouseButton);
        }

        /// <summary>
        /// Implements <see cref="IMouseWithActionListener.Click(MouseButton, Point, IActionListener)"/>
        /// </summary>
        public virtual void Click(MouseButton mouseButton, Point point, IActionListener actionListener)
        {
            Location = point;
            Click(mouseButton);
            ActionPerformed(actionListener);
        }

        /// <summary>
        /// Implements <see cref="IMouse.DoubleClick(MouseButton)"/>
        /// </summary>
        public virtual void DoubleClick(MouseButton mouseButton)
        {
            MouseWin32.MouseButtonUpAndDown(mouseButton);
            Thread.Sleep(CoreAppXmlConfiguration.Instance.DoubleClickInterval);
            MouseWin32.MouseButtonUpAndDown(mouseButton);
        }

        /// <summary>
        /// Implements <see cref="IMouseWithActionListener.DoubleClick(MouseButton, IActionListener)"/>
        /// </summary>
        public virtual void DoubleClick(MouseButton mouseButton, IActionListener actionListener)
        {
            DoubleClick(mouseButton);
            ActionPerformed(actionListener);
        }

        /// <summary>
        /// Implements <see cref="IMouse.DoubleClick(MouseButton, Point)"/>
        /// </summary>
        public virtual void DoubleClick(MouseButton mouseButton, Point point)
        {
            Move(point);
            DoubleClick(mouseButton);
        }

        /// <summary>
        /// Implements <see cref="IMouseWithActionListener.DoubleClick(MouseButton, Point, IActionListener)"/>
        /// </summary>
        public virtual void DoubleClick(MouseButton mouseButton, Point point, IActionListener actionListener)
        {
            Location = point;
            DoubleClick(mouseButton);
            ActionPerformed(actionListener);
        }

        /// <summary>
        /// Implements <see cref="IMouse.LeftClick()"/>
        /// </summary>
        public virtual void LeftClick()
        {
            Click(MouseButton.Left);
        }

        /// <summary>
        /// Implements <see cref="IMouse.LeftClick(Point)"/>
        /// </summary>
        public virtual void LeftClick(Point point)
        {
            Click(MouseButton.Left, point);
        }

        /// <summary>
        /// Implements <see cref="IMouseWithActionListener.LeftClick(Point, IActionListener)"/>
        /// </summary>
        public virtual void LeftClick(Point point, IActionListener actionListener)
        {
            Click(MouseButton.Left, point, actionListener);
        }

        /// <summary>
        /// Implements <see cref="IMouse.LeftDoubleClick()"/>
        /// </summary>
        public virtual void LeftDoubleClick()
        {
            DoubleClick(MouseButton.Left);
        }

        /// <summary>
        /// Implements <see cref="IMouse.LeftDoubleClick(Point)"/>
        /// </summary>
        public virtual void LeftDoubleClick(Point point)
        {
            DoubleClick(MouseButton.Left, point);
        }

        /// <summary>
        /// Implements <see cref="IMouseWithActionListener.LeftDoubleClick(Point, IActionListener)"/>
        /// </summary>
        public virtual void LeftDoubleClick(Point point, IActionListener actionListener)
        {
            DoubleClick(MouseButton.Left, point, actionListener);
        }

        /// <summary>
        /// Implements <see cref="IMouse.RightClick()"/>
        /// </summary>
        public virtual void RightClick()
        {
            Click(MouseButton.Right);
        }

        /// <summary>
        /// Implements <see cref="IMouse.RightClick(Point)"/>
        /// </summary>
        public virtual void RightClick(Point point)
        {
            Click(MouseButton.Right, point);
        }

        /// <summary>
        /// Implements <see cref="IMouseWithActionListener.RightClick(Point, IActionListener)"/>
        /// </summary>
        public virtual void RightClick(Point point, IActionListener actionListener)
        {
            Click(MouseButton.Right, point, actionListener);
        }

        /// <summary>
        /// Implements <see cref="IMouse.DragAndDrop(IUIItem, IUIItem)"/>
        /// </summary>
        public virtual void DragAndDrop(IUIItem draggedItem, IUIItem dropItem)
        {
            DragAndDrop(MouseButton.Left, draggedItem, dropItem);
        }

        /// <summary>
        /// Implements <see cref="IMouse.DragAndDrop(MouseButton, IUIItem, IUIItem)"/>
        /// </summary>
        public virtual void DragAndDrop(MouseButton mouseButton, IUIItem draggedItem, IUIItem dropItem)
        {
            var startPosition = draggedItem.Bounds.Center();
            var endPosition = dropItem.Bounds.Center();
            DragAndDrop(mouseButton, draggedItem, startPosition, dropItem, endPosition);
        }

        /// <summary>
        /// Implements <see cref="IMouse.DragAndDrop(IUIItem, Point, IUIItem, Point)"/>
        /// </summary>
        public virtual void DragAndDrop(IUIItem draggedItem, Point startPosition, IUIItem dropItem, Point endPosition)
        {
            DragAndDrop(MouseButton.Left, draggedItem, startPosition, dropItem, endPosition);
        }

        /// <summary>
        /// Implements <see cref="IMouse.DragAndDrop(MouseButton, IUIItem, Point, IUIItem, Point)"/>
        /// </summary>
        public virtual void DragAndDrop(MouseButton mouseButton, IUIItem draggedItem, Point startPosition, IUIItem dropItem, Point endPosition)
        {
            Move(startPosition);
            MouseWin32.MouseButtonDown(mouseButton);
            var dragStepFraction = (float)(1.0 / CoreAppXmlConfiguration.Instance.DragStepCount);
            for (var i = 1; i <= CoreAppXmlConfiguration.Instance.DragStepCount; i++)
            {
                var newX = startPosition.X + (endPosition.X - startPosition.X) * (dragStepFraction * i);
                var newY = startPosition.Y + (endPosition.Y - startPosition.Y) * (dragStepFraction * i);
                var newPoint = new Point((int)newX, (int)newY);
                Move(newPoint);
            }
            MouseWin32.MouseButtonUp(mouseButton);
            dropItem.ActionPerformed(Action.WindowMessage);
        }

        /// <summary>
        /// Implements <see cref="IMouse.DragHorizontally(IUIItem, int)"/>
        /// </summary>
        public virtual void DragHorizontally(IUIItem uiItem, int distance)
        {
            DragHorizontally(MouseButton.Left, uiItem, distance);
        }

        /// <summary>
        /// Implements <see cref="IMouse.DragHorizontally(MouseButton, IUIItem, int)"/>
        /// </summary>
        public virtual void DragHorizontally(MouseButton mouseButton, IUIItem uiItem, int distance)
        {
            Location = uiItem.Bounds.Center();
            var currentXLocation = Location.X;
            var currentYLocation = Location.Y;
            MouseWin32.MouseButtonDown(mouseButton);
            ActionPerformed(uiItem);
            Move(new Point(currentXLocation + distance, currentYLocation));
            MouseWin32.MouseButtonUp(mouseButton);
        }

        /// <summary>
        /// Implements <see cref="IMouse.DragVertically(IUIItem, int)"/>
        /// </summary>
        public virtual void DragVertically(IUIItem uiItem, int distance)
        {
            DragVertically(MouseButton.Left, uiItem, distance);
        }

        /// <summary>
        /// Implements <see cref="IMouse.DragVertically(MouseButton, IUIItem, int)"/>
        /// </summary>
        public virtual void DragVertically(MouseButton mouseButton, IUIItem uiItem, int distance)
        {
            Move(uiItem.Bounds.Center());
            var currentXLocation = Location.X;
            var currentYLocation = Location.Y;
            MouseWin32.MouseButtonDown(mouseButton);
            ActionPerformed(uiItem);
            Move(new Point(currentXLocation, currentYLocation + distance));
            MouseWin32.MouseButtonUp(mouseButton);
        }

        /// <summary>
        /// Implements <see cref="IMouse.MoveOut()"/>
        /// </summary>
        public virtual void MoveOut()
        {
            Move(new Point(0, 0));
        }

        /// <summary>
        /// Implements <see cref="IMouse.Move(Point)"/>
        /// </summary>
        public virtual void Move(Point position)
        {
            Location = position;
        }

        /// <summary>
        /// Implements <see cref="IMouseWithActionListener.ActionPerformed(IActionListener)"/>
        /// </summary>
        public virtual void ActionPerformed(IActionListener actionListener)
        {
            actionListener.ActionPerformed(new Action(ActionType.WindowMessage));
        }
    }
}