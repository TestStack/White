using System.Windows.Automation;
using White.Core.Factory;
using White.Core.Sessions;

namespace White.WebBrowser
{
    public class InternetExplorerWindow : BrowserWindow
    {
        protected InternetExplorerWindow() {}

        public InternetExplorerWindow(AutomationElement automationElement, WindowFactory windowFactory, InitializeOption option, WindowSession windowSession)
            : base(automationElement, windowFactory, option, windowSession) {}
    }
}