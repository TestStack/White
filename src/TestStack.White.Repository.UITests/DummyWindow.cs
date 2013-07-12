using System.Windows.Automation;
using White.Core.Factory;
using White.Core.Sessions;
using White.Core.UIItems.Finders;
using White.Core.UIItems.MenuItems;
using White.Core.UIItems.WindowItems;

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