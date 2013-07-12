using System.Windows.Automation;
using White.Core.Factory;
using White.Core.Sessions;

namespace TestStack.White.WebBrowser
{
    public class FirefoxWindow : BrowserWindow
    {
        protected FirefoxWindow() {}

        public FirefoxWindow(AutomationElement automationElement, WindowFactory windowFactory, InitializeOption option, WindowSession windowSession)
            : base(automationElement, windowFactory, option, windowSession) {}
    }
}