using System;
using System.Windows;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.InputDevices
{
    /// <summary>
    /// Any operation performed using the mouse would wait till the window is busy after this operation. Before any operation is 
    /// performed the window, from which it was retreived, is brought to focus if it is not.
    /// </summary>
    public class AttachedMouse : IBaseMouse
    {
        private readonly IActionListener actionListener;
        private readonly IMouse mouse;

        #region Constructor

        internal AttachedMouse(IMouse mouse, IActionListener actionListener)
        {
            this.actionListener = actionListener;
            this.mouse = mouse;
        }

        #endregion

        #region Mouse Properties

        /// <summary>
        /// Implements <see cref="IBaseMouse.Location"/>
        /// </summary>
        public virtual Point Location
        {
            get { return mouse.Location; }
            set { mouse.Location = value; }
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.Cursor"/>
        /// </summary>
        public virtual MouseCursor Cursor
        {
            get { return mouse.Cursor; }
        }

        #endregion

        #region Click

        /// <summary>
        /// Implements <see cref="IBaseMouse.Click(MouseButton)"/>
        /// </summary>
        public virtual void Click(MouseButton mouseButton)
        {
            mouse.Click(mouseButton, actionListener);
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.Click(MouseButton, Point)"/>
        /// </summary>
        public virtual void Click(MouseButton mouseButton, Point point)
        {
            mouse.Click(mouseButton, point, actionListener);
        }

        #endregion

        #region Double Click

        /// <summary>
        /// Implements <see cref="IBaseMouse.DoubleClick(MouseButton)"/>
        /// </summary>
        public virtual void DoubleClick(MouseButton mouseButton)
        {
            mouse.DoubleClick(mouseButton, actionListener);
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.DoubleClick(MouseButton, Point)"/>
        /// </summary>
        public virtual void DoubleClick(MouseButton mouseButton, Point point)
        {
            mouse.DoubleClick(mouseButton, point, actionListener);
        }

        #endregion

        #region Left Click

        /// <summary>
        /// Implements <see cref="IBaseMouse.Click()"/>
        /// </summary
        [Obsolete("Use LeftClick instead")]
        public virtual void Click()
        {
            mouse.Click();
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.Click(Point)"/>
        /// </summary
        [Obsolete("Use LeftClick instead")]
        public virtual void Click(Point point)
        {
            mouse.Click(point, actionListener);
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.LeftClick()"/>
        /// </summary
        public virtual void LeftClick()
        {
            mouse.LeftClick();
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.LeftClick(Point)"/>
        /// </summary
        public virtual void LeftClick(Point point)
        {
            mouse.LeftClick(point, actionListener);
        }

        #endregion

        #region Left Double Click

        /// <summary>
        /// Implements <see cref="IBaseMouse.DoubleClick()"/>
        /// </summary
        [Obsolete("Use LeftDoubleClick instead")]
        public virtual void DoubleClick()
        {
            mouse.DoubleClick();
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.DoubleClick(Point)"/>
        /// </summary
        [Obsolete("Use LeftDoubleClick instead")]
        public virtual void DoubleClick(Point point)
        {
            mouse.DoubleClick(point);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.LeftDoubleClick()"/>
        /// </summary
        public virtual void LeftDoubleClick()
        {
            mouse.LeftDoubleClick();
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.LeftDoubleClick(Point)"/>
        /// </summary
        public virtual void LeftDoubleClick(Point point)
        {
            mouse.LeftDoubleClick(point);
            ActionPerformed();
        }

        #endregion

        #region Right Click
        
        /// <summary>
        /// Implements <see cref="IBaseMouse.RightClick(Point)"/>
        /// </summary
        public virtual void RightClick()
        {
            mouse.RightClick();
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.RightClick(Point)"/>
        /// </summary
        public virtual void RightClick(Point point)
        {
            mouse.RightClick(point, actionListener);
        }

        #endregion 

        #region Drag And Drop

        /// <summary>
        /// Implements <see cref="IBaseMouse.DragAndDrop(IUIItem, IUIItem)"/>
        /// </summary
        public virtual void DragAndDrop(IUIItem draggedItem, IUIItem dropItem)
        {
            mouse.DragAndDrop(draggedItem, dropItem);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.DragAndDrop(MouseButton, IUIItem, IUIItem)"/>
        /// </summary
        public virtual void DragAndDrop(MouseButton mouseButton, IUIItem draggedItem, IUIItem dropItem)
        {
            mouse.DragAndDrop(mouseButton, draggedItem, dropItem);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.DragAndDrop(IUIItem, Point, IUIItem, Point)"/>
        /// </summary
        public virtual void DragAndDrop(IUIItem draggedItem, Point startPosition, IUIItem dropItem, Point endPosition)
        {
            mouse.DragAndDrop(draggedItem, startPosition, dropItem, endPosition);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.DragAndDrop(MouseButton, IUIItem, Point, IUIItem, Point)"/>
        /// </summary
        public virtual void DragAndDrop(MouseButton mouseButton, IUIItem draggedItem, Point startPosition, IUIItem dropItem, Point endPosition)
        {
            mouse.DragAndDrop(mouseButton,  draggedItem, startPosition, dropItem, endPosition);
            ActionPerformed();
        }

        #endregion

        #region Drag

        /// <summary>
        /// Implements <see cref="IBaseMouse.DragHorizontally(IUIItem, int)"/>
        /// </summary
        public virtual void DragHorizontally(IUIItem uiItem, int distance)
        {
            mouse.DragHorizontally(uiItem, distance);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.DragHorizontally(MouseButton, IUIItem, int)"/>
        /// </summary
        public virtual void DragHorizontally(MouseButton mouseButton, IUIItem uiItem, int distance)
        {
            mouse.DragHorizontally(mouseButton, uiItem, distance);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.DragVertically(IUIItem, int)"/>
        /// </summary
        public virtual void DragVertically(IUIItem uiItem, int distance)
        {
            mouse.DragVertically(uiItem, distance);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.DragVertically(MouseButton, IUIItem, int)"/>
        /// </summary
        public virtual void DragVertically(MouseButton mouseButton, IUIItem uiItem, int distance)
        {
            mouse.DragVertically(mouseButton, uiItem, distance);
            ActionPerformed();
        }

        #endregion

        /// <summary>
        /// Implements <see cref="IBaseMouse.MoveOut()"/>
        /// </summary
        public virtual void MoveOut()
        {
            mouse.MoveOut();
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IBaseMouse.Move(Point)"/>
        /// </summary
        public virtual void Move(Point position)
        {
            mouse.Move(position);
            ActionPerformed();
        }

        #region Protected

        protected virtual void ActionPerformed()
        {
            mouse.ActionPerformed(actionListener);
        }

        #endregion
    }
}