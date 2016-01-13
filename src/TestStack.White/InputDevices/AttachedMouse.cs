using System.Windows;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.InputDevices
{
    /// <summary>
    /// Any operation performed using the mouse would wait till the window is busy after this operation. Before any operation is 
    /// performed the window, from which it was retreived, is brought to focus if it is not.
    /// </summary>
    public class AttachedMouse : IAttachedMouse
    {
        private readonly IActionListener actionListener;
        private readonly IMouse mouse;

        internal AttachedMouse(IMouse mouse, IActionListener actionListener)
        {
            this.actionListener = actionListener;
            this.mouse = mouse;
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.Location"/>
        /// </summary>
        public virtual Point Location
        {
            get { return mouse.Location; }
            set { mouse.Location = value; }
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.Cursor"/>
        /// </summary>
        public virtual MouseCursor Cursor
        {
            get { return mouse.Cursor; }
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.Click(MouseButton)"/>
        /// </summary>
        public virtual void Click(MouseButton mouseButton)
        {
            mouse.Click(mouseButton, actionListener);
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.Click(MouseButton, Point)"/>
        /// </summary>
        public virtual void Click(MouseButton mouseButton, Point point)
        {
            mouse.Click(mouseButton, point, actionListener);
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.DoubleClick(MouseButton)"/>
        /// </summary>
        public virtual void DoubleClick(MouseButton mouseButton)
        {
            mouse.DoubleClick(mouseButton, actionListener);
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.DoubleClick(MouseButton, Point)"/>
        /// </summary>
        public virtual void DoubleClick(MouseButton mouseButton, Point point)
        {
            mouse.DoubleClick(mouseButton, point, actionListener);
        }
        
        /// <summary>
        /// Implements <see cref="IAttachedMouse.LeftClick()"/>
        /// </summary
        public virtual void LeftClick()
        {
            mouse.LeftClick();
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.LeftClick(Point)"/>
        /// </summary
        public virtual void LeftClick(Point point)
        {
            mouse.LeftClick(point, actionListener);
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.LeftDoubleClick()"/>
        /// </summary
        public virtual void LeftDoubleClick()
        {
            mouse.LeftDoubleClick();
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.LeftDoubleClick(Point)"/>
        /// </summary
        public virtual void LeftDoubleClick(Point point)
        {
            mouse.LeftDoubleClick(point);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.RightClick(Point)"/>
        /// </summary
        public virtual void RightClick()
        {
            mouse.RightClick();
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.RightClick(Point)"/>
        /// </summary
        public virtual void RightClick(Point point)
        {
            mouse.RightClick(point, actionListener);
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.DragAndDrop(IUIItem, IUIItem)"/>
        /// </summary
        public virtual void DragAndDrop(IUIItem draggedItem, IUIItem dropItem)
        {
            mouse.DragAndDrop(draggedItem, dropItem);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.DragAndDrop(MouseButton, IUIItem, IUIItem)"/>
        /// </summary
        public virtual void DragAndDrop(MouseButton mouseButton, IUIItem draggedItem, IUIItem dropItem)
        {
            mouse.DragAndDrop(mouseButton, draggedItem, dropItem);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.DragAndDrop(IUIItem, Point, IUIItem, Point)"/>
        /// </summary
        public virtual void DragAndDrop(IUIItem draggedItem, Point startPosition, IUIItem dropItem, Point endPosition)
        {
            mouse.DragAndDrop(draggedItem, startPosition, dropItem, endPosition);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.DragAndDrop(MouseButton, IUIItem, Point, IUIItem, Point)"/>
        /// </summary
        public virtual void DragAndDrop(MouseButton mouseButton, IUIItem draggedItem, Point startPosition, IUIItem dropItem, Point endPosition)
        {
            mouse.DragAndDrop(mouseButton,  draggedItem, startPosition, dropItem, endPosition);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.DragHorizontally(IUIItem, int)"/>
        /// </summary
        public virtual void DragHorizontally(IUIItem uiItem, int distance)
        {
            mouse.DragHorizontally(uiItem, distance);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.DragHorizontally(MouseButton, IUIItem, int)"/>
        /// </summary
        public virtual void DragHorizontally(MouseButton mouseButton, IUIItem uiItem, int distance)
        {
            mouse.DragHorizontally(mouseButton, uiItem, distance);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.DragVertically(IUIItem, int)"/>
        /// </summary
        public virtual void DragVertically(IUIItem uiItem, int distance)
        {
            mouse.DragVertically(uiItem, distance);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.DragVertically(MouseButton, IUIItem, int)"/>
        /// </summary
        public virtual void DragVertically(MouseButton mouseButton, IUIItem uiItem, int distance)
        {
            mouse.DragVertically(mouseButton, uiItem, distance);
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.MoveOut()"/>
        /// </summary
        public virtual void MoveOut()
        {
            mouse.MoveOut();
            ActionPerformed();
        }

        /// <summary>
        /// Implements <see cref="IAttachedMouse.Move(Point)"/>
        /// </summary
        public virtual void Move(Point position)
        {
            mouse.Move(position);
            ActionPerformed();
        }

        protected virtual void ActionPerformed()
        {
            mouse.ActionPerformed(actionListener);
        }
    }
}