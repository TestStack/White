using System.Windows.Automation;
using Bricks.Core;
using White.Core.Configuration;
using White.Core.UIItems;
using White.Core.UIItems.Actions;

namespace White.Core.Factory
{
    public static class ToolTipFinder
    {
        public static ToolTip FindToolTip(Clock.Do perform)
        {
            var clock = new Clock(CoreAppXmlConfiguration.Instance.TooltipWaitTime);
            Clock.Matched matched = obj => obj != null;
            Clock.Expired expired = () => null;
            var automationElement = (AutomationElement) clock.Perform(perform, matched, expired);
            return automationElement == null ? null : new ToolTip(automationElement, new NullActionListener());
        }
    }
}