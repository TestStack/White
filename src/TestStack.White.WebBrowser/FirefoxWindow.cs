using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.Sessions;

namespace TestStack.White.WebBrowser
{
    public class FirefoxWindow : BrowserWindow
    {
        protected FirefoxWindow() {}

        public FirefoxWindow(AutomationElement automationElement, WindowFactory windowFactory, InitializeOption option, WindowSession windowSession)
            : base(automationElement, windowFactory, option, windowSession) {}
    }
}