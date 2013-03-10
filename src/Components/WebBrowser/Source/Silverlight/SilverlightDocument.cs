using System.Threading;
using System.Windows.Automation;
using White.Core;
using White.Core.Factory;
using White.Core.Sessions;
using White.Core.UIItems;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;

namespace White.WebBrowser.Silverlight
{
    public class SilverlightDocument : UIItemContainer, IMappableUIItem
    {
        protected SilverlightDocument()
        {
        }

        public SilverlightDocument(AutomationElement automationElement, ActionListener actionListener,
                                   InitializeOption initializeOption,
                                   WindowSession windowSession)
            : base(automationElement, actionListener, initializeOption, windowSession)
        {
        }

        public SilverlightDocument(AutomationElement automationElement, ActionListener actionListener)
            : base(automationElement, actionListener)
        {
        }

        public override void ActionPerformed(Action action)
        {
            if (action == Action.Scroll) Thread.Sleep(500);
            CustomWait();
        }

        protected override ActionListener ChildrenActionListener
        {
            get { return this; }
        }

        public override WindowsFramework Framework
        {
            get { return new WindowsFramework(Constants.SilverlightFrameworkId); }
        }

        public virtual Window ChildWindow(string title)
        {
            var childWindow = Get<Window>(SearchCriteria.ByText(title));
            return childWindow;
        }
    }
}