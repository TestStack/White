using System.Threading;
using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.Sessions;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.WebBrowser.Silverlight
{
    public class SilverlightDocument : Window
    {
        private readonly BrowserWindow ieWindow;

        protected SilverlightDocument()
        {
        }

        public SilverlightDocument(AutomationElement automationElement, BrowserWindow actionListener,
                                   InitializeOption initializeOption,
                                   WindowSession windowSession)
            : base(automationElement, actionListener, initializeOption, windowSession)
        {
            ieWindow = actionListener;
        }

        public SilverlightDocument(AutomationElement automationElement, BrowserWindow actionListener,
                                   WindowSession windowSession)
            : base(automationElement, actionListener, InitializeOption.NoCache, windowSession)
        {
            ieWindow = actionListener;
        }

        public override void ActionPerformed(Action action)
        {
            if (action == Action.Scroll) Thread.Sleep(500);
            CustomWait();
            base.ActionPerformed();
        }

        public override Window ModalWindow(string title, InitializeOption option)
        {
            var childWindow = Get<Window>(SearchCriteria.ByText(title));
            return childWindow;
        }

        public override Window ModalWindow(SearchCriteria searchCriteria, InitializeOption option)
        {
            var childWindow = Get<Window>(searchCriteria);
            return childWindow;
        }

        public override PopUpMenu Popup
        {
            get { throw new System.NotSupportedException(); }
        }

        protected override IActionListener ChildrenActionListener
        {
            get { return this; }
        }

        public override WindowsFramework Framework
        {
            get { return WindowsFramework.Silverlight; }
        }

        public virtual Window ChildWindow(string title)
        {
            var childWindow = Get<Window>(SearchCriteria.ByText(title));
            return childWindow;
        }

        public override void Close()
        {
            ieWindow.Close();
        }
    }
}