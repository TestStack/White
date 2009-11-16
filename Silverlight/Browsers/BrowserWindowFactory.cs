using System.Windows.Automation;
using Core.Factory;
using Core.Sessions;
using Core.UIItems.WindowItems;

namespace White.Web.Browsers
{
    public class BrowserWindowFactory : SpecializedWindowFactory
    {
        public virtual bool DoesSpecializedThis(AutomationElement windowElement)
        {
            return "MozillaUIWindowClass".Equals(windowElement.Current.ClassName);
        }

        public virtual Window Create(AutomationElement automationElement, InitializeOption initializeOption, WindowSession session)
        {
            return new Firefox(automationElement, WindowFactory.Desktop, initializeOption, session);
        }
    }
}