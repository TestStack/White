using System.Threading;
using System.Windows.Automation;
using Bricks.Core;
using White.Core.AutomationElementSearch;
using White.Core.Factory;
using White.Core.Sessions;
using White.Core.UIA;
using White.Core.UIItems;
using White.Core.UIItems.Actions;

namespace White.WebBrowser.Silverlight
{
    public class SilverlightDocument : UIItemContainer
    {
        protected SilverlightDocument() {}

        public SilverlightDocument(AutomationElement automationElement, ActionListener actionListener, InitializeOption initializeOption,
                                   WindowSession windowSession) : base(automationElement, actionListener, initializeOption, windowSession) {}

        public SilverlightDocument(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual ToolTip GetToolTipOn(UIItem uiItem)
        {
            Mouse.Location = uiItem.Bounds.Center();
            var finder = new AutomationElementFinder(automationElement);
            Clock.Do perform = () => finder.Descendant(AutomationSearchCondition.ByControlType(ControlType.ToolTip));
            return ToolTipFinder.FindToolTip(perform);
        }

        public override void ActionPerformed(Action action)
        {
            if (action == Action.Scroll) Thread.Sleep(500);
            base.ActionPerformed();
        }

        protected override ActionListener ChildrenActionListener
        {
            get { return this; }
        }
    }
}
