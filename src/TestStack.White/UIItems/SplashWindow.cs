using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.UIItems
{
    internal class SplashWindow : WinFormWindow
    {
        protected SplashWindow() {}
        public SplashWindow(AutomationElement automationElement, InitializeOption option) : base(automationElement, option) {}

        public override void WaitWhileBusy() {}
    }
}