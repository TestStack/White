using System.Threading;
using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.Sessions;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.WebBrowser.Silverlight
{
    public class SilverlightDocument : UIItemContainer
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
            base.ActionPerformed();
        }

        protected override ActionListener ChildrenActionListener
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
    }
}