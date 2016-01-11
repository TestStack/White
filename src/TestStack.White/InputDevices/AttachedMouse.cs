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

        /// <summary>
        /// Implements <see cref="IBaseMouse.Location"/>
        /// </summary>
        public virtual Point Location
        {
            get { return mouse.Location; }
            set { mouse.Location = value; }
        }

        public MouseCursor Cursor
        {
            get { return mouse.Cursor; }
        }

        #region Mouse Click

        public void Click()
        {
            mouse.Click();
            ActionPerformed();
        }

        public void Click(Point point)
        {
            mouse.Click(point, actionListener);
        }

        public void Click(MouseButton mouseButton)
        {
            mouse.Click(mouseButton, actionListener);
        }

        public void Click(MouseButton mouseButton, Point point)
        {
            mouse.Click(mouseButton, point, actionListener);
        }

        #endregion

        #region Double Click

        public void DoubleClick(Point point)
        {
            mouse.DoubleClick(point, actionListener);
        }

        public void DoubleClick(MouseButton mouseButton)
        {
            mouse.DoubleClick(mouseButton, actionListener);
        }

        public void DoubleClick(MouseButton mouseButton, Point point)
        {
            mouse.DoubleClick(mouseButton, point, actionListener);
        }

        #endregion

        #region Right Click

        public void RightClick()
        {
            mouse.RightClick();
            ActionPerformed();
        }

        public void RightClick(Point point)
        {
            mouse.RightClick(point, actionListener);
        }

        #endregion 

        #region Drag And Drop

        public void DragAndDrop(IUIItem draggedItem, IUIItem dropItem)
        {
            mouse.DragAndDrop(draggedItem, dropItem);
            ActionPerformed();
        }

        public void DragAndDrop(MouseButton mouseButton, IUIItem draggedItem, IUIItem dropItem)
        {
            mouse.DragAndDrop(mouseButton, draggedItem, dropItem);
            ActionPerformed();
        }

        public void DragAndDrop(IUIItem draggedItem, Point startPosition, IUIItem dropItem, Point endPosition)
        {
            mouse.DragAndDrop(draggedItem, startPosition, dropItem, endPosition);
            ActionPerformed();
        }

        public void DragAndDrop(MouseButton mouseButton, IUIItem draggedItem, Point startPosition, IUIItem dropItem, Point endPosition)
        {
            mouse.DragAndDrop(mouseButton,  draggedItem, startPosition, dropItem, endPosition);
            ActionPerformed();
        }

        #endregion

        #region Drag

        public void DragHorizontally(IUIItem uiItem, int distance)
        {
            mouse.DragHorizontally(uiItem, distance);
            ActionPerformed();
        }

        public void DragHorizontally(MouseButton mouseButton, IUIItem uiItem, int distance)
        {
            mouse.DragHorizontally(mouseButton, uiItem, distance);
            ActionPerformed();
        }

        public void DragVertically(IUIItem uiItem, int distance)
        {
            mouse.DragVertically(uiItem, distance);
            ActionPerformed();
        }

        public void DragVertically(MouseButton mouseButton, IUIItem uiItem, int distance)
        {
            mouse.DragVertically(mouseButton, uiItem, distance);
            ActionPerformed();
        }

        #endregion

        public void MoveOut()
        {
            mouse.MoveOut();
            ActionPerformed();
        }

        public void Move(Point position)
        {
            mouse.Move(position);
            ActionPerformed();
        }

        #region Protected

        protected void ActionPerformed()
        {
            mouse.ActionPerformed(actionListener);
        }

        #endregion
    }
}