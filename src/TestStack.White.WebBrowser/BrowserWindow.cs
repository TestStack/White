using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.Sessions;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.WebBrowser
{
    public class BrowserWindow : Win32Window
    {
        protected BrowserWindow() { }

        public BrowserWindow(AutomationElement automationElement, WindowFactory windowFactory, InitializeOption option, WindowSession windowSession)
            : base(automationElement, windowFactory, option, windowSession) { }
    }
}
