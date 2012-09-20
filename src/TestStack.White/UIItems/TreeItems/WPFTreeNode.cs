using System.Windows;
using System.Windows.Automation;
using White.Core.UIA;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;

namespace White.Core.UIItems.TreeItems
{
    [PlatformSpecificItem]
    public class WPFTreeNode : TreeNode
    {
        protected WPFTreeNode() {}
        public WPFTreeNode(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        protected override Point SelectPoint
        {
            get
            {
                return GetExpandCollapseButton().Bounds.East(10);
            }
        }

        protected override void DoExpand()
        {
            GetExpandCollapseButton().Click();
        }

        protected override void DoCollapse()
        {
            GetExpandCollapseButton().Click();
        }

        private Button GetExpandCollapseButton()
        {
            return (Button) factory.Create(SearchCriteria.ByControlType(ControlType.Button), actionListener);
        }
    }
}