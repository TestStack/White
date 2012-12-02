using System.Windows;
using White.Core.UIItems;
using White.Core.UIItems.Actions;

namespace White.Core.InputDevices
{
    /// <summary>
    /// Any operation performed using the mouse would wait till the window is busy after this operation. Before any operation is 
    /// performed the window, from which it was retreived, is brought to focus if it is not.
    /// </summary>
    public class AttachedMouse : IMouse
    {
        private readonly ActionListener actionListener;
        private readonly Mouse mouse;

        internal AttachedMouse(Mouse mouse, ActionListener actionListener)
        {
            this.actionListener = actionListener;
            this.mouse = mouse;
        }

        public virtual void RightClick()
        {
            mouse.RightClick();
            ActionPerformed();
        }

        private void ActionPerformed()
        {
            actionListener.ActionPerformed(Action.WindowMessage);
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

        public virtual Point Location
        {
            get { return mouse.Location; }
            set { mouse.Location = value; }
        }
    }
}