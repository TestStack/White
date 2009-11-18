using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.Scrolling
{
    internal class ScrollerFactory
    {
        internal static IScrollBars CreateBars(AutomationElement parentElement, ActionListener listener)
        {
            var frameworkId = parentElement.Current.FrameworkId;
            if (frameworkId == Constants.WPFFrameworkId || frameworkId == Constants.SilverlightFrameworkId)
                return new WPFScrollBars(parentElement, listener);
            return new ScrollBars(parentElement, listener);
        }
    }
}
