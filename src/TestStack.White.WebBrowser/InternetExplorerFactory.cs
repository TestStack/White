using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.Sessions;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.WebBrowser
{
    public class InternetExplorerFactory : ISpecializedWindowFactory
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