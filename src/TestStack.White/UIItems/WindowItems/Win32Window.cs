using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.Sessions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;

namespace TestStack.White.UIItems.WindowItems
{
    [PlatformSpecificItem]
    public class Win32Window : Window
    {
        private readonly WindowFactory windowFactory;

        protected Win32Window() {}

        public Win32Window(AutomationElement automationElement, WindowFactory windowFactory, InitializeOption option, WindowSession windowSession)
            : base(automationElement, option, windowSession)
        {
            this.windowFactory = windowFactory;
        }

        public override T Get<T>(string primaryIdentification)
        {
            return Get<T>(SearchCriteria.ByText(primaryIdentification));
        }

        public override PopUpMenu Popup
        {
            get { return windowFactory.PopUp(this); }
        }

        public override Window ModalWindow(string title, InitializeOption option)
        {
            return windowFactory.ModalWindow(title, option, WindowSession.ModalWindowSession(option));
        }

        public override Window ModalWindow(SearchCriteria searchCriteria, InitializeOption option)
        {
            return windowFactory.ModalWindow(searchCriteria, option, WindowSession.ModalWindowSession(option));
        }
    }
}