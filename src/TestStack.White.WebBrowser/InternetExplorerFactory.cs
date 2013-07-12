using System.Windows.Automation;
using White.Core.Factory;
using White.Core.Sessions;
using White.Core.UIItems.WindowItems;

namespace TestStack.White.WebBrowser
{
    public class InternetExplorerFactory : SpecializedWindowFactory
    {
        public static void Plugin()
        {
            WindowFactory.AddSpecializedWindowFactory(new InternetExplorerFactory());
        }

        public virtual bool DoesSpecializeInThis(AutomationElement windowElement)
        {
            return windowElement.Current.ClassName.Contains("IEFrame");
        }

        public virtual Window Create(AutomationElement automationElement, InitializeOption initializeOption, WindowSession session)
        {
            return new InternetExplorerWindow(automationElement, WindowFactory.Desktop, initializeOption, session);
        }
    }
}