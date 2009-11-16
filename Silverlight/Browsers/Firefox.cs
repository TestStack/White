using System.Windows.Automation;
using Core.Factory;
using Core.Sessions;
using Core.UIItems.WindowItems;

namespace White.Web.Browsers
{
    public class Firefox : Win32Window
    {
        protected Firefox() {}
        public Firefox(AutomationElement automationElement, WindowFactory windowFactory, InitializeOption option, WindowSession windowSession) : 
            base(automationElement, windowFactory, option, windowSession) {}
    }
}