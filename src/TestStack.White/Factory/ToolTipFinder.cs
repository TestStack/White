using System;
using System.Windows.Automation;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;
using TestStack.White.Utility;

namespace TestStack.White.Factory
{
    public static class ToolTipFinder
    {
        public static ToolTip FindToolTip(Func<AutomationElement> perform, AutomationElement parentAutomationElement)
        {
            var automationElement = Retry.For(perform, CoreAppXmlConfiguration.Instance.TooltipWaitTimeSpan());
            if (automationElement == null)
                throw new AutomationException("Unable to find tooltip", Debug.Details(parentAutomationElement));

            return new ToolTip(automationElement, new NullActionListener());
        }
    }
}