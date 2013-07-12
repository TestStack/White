using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.Sessions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.Scrolling;

namespace TestStack.White.UIItems.WindowItems
{
    [PlatformSpecificItem]
    internal class WinFormWindow : Window
    {
        private WinFormScrollBars winFormScrollBars;
        protected WinFormWindow() {}

        public WinFormWindow(AutomationElement automationElement, InitializeOption initializeOption)
            : this(automationElement, initializeOption, new NullWindowSession()) {}

        internal WinFormWindow(AutomationElement automationElement, InitializeOption initializeOption, WindowSession windowSession)
            : base(automationElement, initializeOption, windowSession) {}

        public override PopUpMenu Popup
        {
            get
            {
                PopUpMenu popUpMenu;
                factory.TryGetPopupMenu(this, out popUpMenu);
                return popUpMenu;
            }
        }

        public override T Get<T>(string primaryIdentification)
        {
            if (typeof (T).Equals(typeof (Image)))
            {
                IUIItem image = factory.WinFormImage(primaryIdentification, this);
                return (T) image;
            }
            return base.Get<T>(primaryIdentification);
        }

        public override bool HasPopup()
        {
            PopUpMenu popUpMenu;
            return factory.TryGetPopupMenu(this, out popUpMenu);
        }

        public override Window ModalWindow(string title, InitializeOption option)
        {
            return factory.ModalWindow(title, option, WindowSession.ModalWindowSession(option));
        }

        public override Window ModalWindow(SearchCriteria searchCriteria, InitializeOption option)
        {
            return factory.ModalWindow(searchCriteria, option, WindowSession.ModalWindowSession(option));            
        }

        public override IScrollBars ScrollBars
        {
            get
            {
                if (winFormScrollBars == null) winFormScrollBars = new WinFormScrollBars(automationElement, actionListener);
                return winFormScrollBars;
            }
        }
    }
}