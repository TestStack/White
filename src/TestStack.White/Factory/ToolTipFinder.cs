using System;
using System.Windows.Automation;
using White.Core.Configuration;
using White.Core.UIItems;
using White.Core.UIItems.Actions;
using White.Core.Utility;

namespace White.Core.Factory
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