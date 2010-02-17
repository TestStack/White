using System.Windows.Automation;
using White.Core.Factory;
using White.Core.Sessions;
using White.Core.UIItems.WindowItems;

namespace White.WebBrowser
{
    public class FirefoxFactory : SpecializedWindowFactory
    {
        public static void Plugin()
        {
            WindowFactory.AddSpecializedWindowFactory(new FirefoxFactory());
        }

        public virtual bool DoesSpecializedThis(AutomationElement windowElement)
        {
            return windowElement.Current.ClassName.Contains("MozillaUIWindowClass");
        }

        public virtual Window Create(AutomationElement automationElement, InitializeOption initializeOption, WindowSession session)
        {
            return new FirefoxWindow(automationElement, WindowFactory.Desktop, initializeOption, session);
        }
    }
}