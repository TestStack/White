using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.Scrolling
{
    internal class ScrollerFactory
    {
        internal static IScrollBars CreateBars(AutomationElement parentElement, ActionListener listener)
        {
            var frameworkId = parentElement.Current.FrameworkId;
            if (frameworkId == Constants.WPFFrameworkId)
                return new WPFScrollBars(parentElement, listener);
            if (frameworkId == Constants.SilverlightFrameworkId)
                return new ScrollBars(parentElement, listener, new SilverlightHScrollBarButtonAutomationIds(), new SilverlightVScrollBarButtonAutomationIds());
            return new ScrollBars(parentElement, listener, new DefaultScrollBarButtonAutomationIds(), new DefaultScrollBarButtonAutomationIds());
        }
    }
}
