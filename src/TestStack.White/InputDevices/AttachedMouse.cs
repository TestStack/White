using System.Windows;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.InputDevices
{
    /// <summary>
    /// Any operation performed using the mouse would wait till the window is busy after this operation. Before any operation is 
    /// performed the window, from which it was retreived, is brought to focus if it is not.
    /// </summary>
    public class AttachedMouse : IMouse
    {
        private readonly IActionListener actionListener;
        private readonly Mouse mouse;

        public virtual Point Location
        {
            get { return mouse.Location; }
            set { mouse.Location = value; }
        }

        internal AttachedMouse(Mouse mouse, IActionListener actionListener)
        {
            this.actionListener = actionListener;
            this.mouse = mouse;
        }

        public virtual void RightClick()
        {
            mouse.RightClick();
            ActionPerformed();
        }

        public virtual void Click()
        {
            mouse.Click();
            ActionPerformed();
        }

        public virtual void DoubleClick(Point point)
        {
            mouse.DoubleClick(point);
            ActionPerformed();
        }

        public virtual void Click(Point point)
        {
            mouse.Click(point);
            ActionPerformed();
        }

        public virtual void LeftDown()
        {
            mouse.LeftDown();
            ActionPerformed();
        }

        public virtual void RightDown()
        {
            mouse.RightDown();
            ActionPerformed();
        }

        public virtual void LeftUp()
        {
            mouse.LeftUp();
            ActionPerformed();
        }

        public virtual void RightUp()
        {
            mouse.RightUp();
            ActionPerformed();
        }

        public virtual void MouseMove(Point endPosition)
        {
            mouse.MouseMove(endPosition);
            ActionPerformed();
        }

        public virtual void DragAndDrop(IUIItem draggedItem, IUIItem dropItem)
        {
            mouse.DragAndDrop(draggedItem, dropItem);
            ActionPerformed();
        }

        public virtual void DragAndDrop(IUIItem draggedItem, Point startPosition, IUIItem dropItem, Point endPosition)
        {
            mouse.DragAndDrop(draggedItem, startPosition, dropItem, endPosition);
            ActionPerformed();
        }

        private void ActionPerformed()
        {
            actionListener.ActionPerformed(Action.WindowMessage);
        }
    }
}