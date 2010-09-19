using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems
{
    public class Thumb : UIItem
    {
        protected Thumb() {}
        public Thumb(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        /// <summary>
        /// Move horizontally
        /// </summary>
        /// <param name="distance">postive value for increasing X, negative for lesser X</param>
        public virtual void SlideHorizontally(int distance)
        {
            mouse.DragHorizontally(this, distance);
            actionListener.ActionPerformed(Action.WindowMessage);
        }

        /// <summary>
        /// Move vertically
        /// </summary>
        /// <param name="distance">postive value downwards, negative for upwards</param>
        public virtual void SlideVertically(int distance)
        {
            mouse.DragVertically(this, distance);
            actionListener.ActionPerformed(Action.WindowMessage);
        }
    }
}