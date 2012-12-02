using System.Windows.Automation;
using White.Core.Factory;
using White.Core.UIItems.WindowItems;

namespace White.Core.UIItems
{
    internal class SplashWindow : WinFormWindow
    {
        protected SplashWindow() {}
        public SplashWindow(AutomationElement automationElement, InitializeOption option) : base(automationElement, option) {}

        public override void WaitWhileBusy() {}
    }
}