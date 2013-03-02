using System;
using System.Threading;
using System.Windows.Automation;
using White.Core.Factory;
using White.Core.Sessions;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;
using White.Core.UIItems.MenuItems;

namespace White.Core.UIItems.WindowItems
{
    [PlatformSpecificItem]
    public class SilverlightChildWindow : Window
    {
        protected SilverlightChildWindow() {}

        public SilverlightChildWindow(AutomationElement automationElement, ActionListener actionListener)
            : base(automationElement, InitializeOption.NoCache, new NullWindowSession())
        {
            // We need to sleep to make sure animation is finished
            Thread.Sleep(600);
        }

        public override Window ModalWindow(string title, InitializeOption option)
        {
            throw new NotSupportedException();
        }

        public override Window ModalWindow(SearchCriteria searchCriteria, InitializeOption option)
        {
            throw new NotSupportedException();
        }

        public override PopUpMenu Popup
        {
            get { return null; }
        }

        public override void WaitWhileBusy()
        {
            try
            {
                WaitForProcess();
                HourGlassWait();
                CustomWait();
            }
            catch (Exception e)
            {
                if (!(e is InvalidOperationException || e is ElementNotAvailableException))
                    throw new UIActionException(string.Format("Window didn't respond" + Constants.BusyMessage), e);
            }
        }
    }
}