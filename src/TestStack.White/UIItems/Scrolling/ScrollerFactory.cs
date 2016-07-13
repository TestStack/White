using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.Scrolling
{
    internal class ScrollerFactory
    {
        internal static IScrollBars CreateBars(AutomationElement parentElement, IActionListener listener)
        {
            var frameworkId = parentElement.Current.FrameworkId;
            if (frameworkId == WindowsFramework.Wpf.FrameworkId())
            {
                return new WPFScrollBars(parentElement, listener);
            }
            return new ScrollBars(parentElement, listener, new DefaultScrollBarButtonAutomationIds(), new DefaultScrollBarButtonAutomationIds());
        }
    }
}
