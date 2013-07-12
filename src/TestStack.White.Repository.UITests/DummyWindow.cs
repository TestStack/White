using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.Sessions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.Repository.UITests
{
    public class DummyWindow : Window
    {
        public DummyWindow(AutomationElement automationElement, InitializeOption initializeOption, WindowSession windowSession)
            : base(automationElement, initializeOption, windowSession) {}

        public DummyWindow() {}

        public override PopUpMenu Popup
        {
            get { return null; }
        }

        public override Window ModalWindow(string title, InitializeOption option)
        {
            return null;
        }

        public override Window ModalWindow(SearchCriteria searchCriteria, InitializeOption option)
        {
            return null;
        }
    }
}