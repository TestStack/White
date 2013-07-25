using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.Scrolling
{
    public class WpfTreeViewScrollBars : AbstractScrollBars
    {
        private readonly AutomationElement parentElement;
        private readonly ActionListener actionListener;

        public WpfTreeViewScrollBars(AutomationElement parentElement, ActionListener actionListener)
        {
            this.parentElement = parentElement;
            this.actionListener = actionListener;
        }

        public override IHScrollBar Horizontal
        {
            get
            {
                return new WpfTreeViewHScrollBar(parentElement, actionListener);
            }
        }

        public override IVScrollBar Vertical
        {
            get
            {
                return new WpfTreeViewVScrollBar(parentElement, actionListener);
            }
        }

        public override bool CanScroll
        {
            get { return Horizontal.IsScrollable || Vertical.IsScrollable; }
        }
    }
}