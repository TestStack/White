using System.Windows.Automation.Peers;
using Visifire.Charts;

namespace White.WPFCustomControls
{
    public class WhiteChart : Chart
    {
        private WhiteChartAutomationPeer automationPeer;

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            if (automationPeer == null) automationPeer = new WhiteChartAutomationPeer(this);
            return automationPeer;
        }
    }
}