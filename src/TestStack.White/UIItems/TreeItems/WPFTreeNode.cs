using System.Windows;
using System.Windows.Automation;
using TestStack.White.UIA;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UIItems.TreeItems
{
    [PlatformSpecificItem]
    public class WPFTreeNode : TreeNode
    {
        protected WPFTreeNode() {}
        public WPFTreeNode(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener) {}

        protected override Point SelectPoint
        {
            get
            {
                return GetExpandCollapseButton().Bounds.East(10);
            }
        }

        protected override void DoExpand()
        {
            var expandCollapseButton = GetExpandCollapseButton();
            if (expandCollapseButton.IsOffScreen)
                throw new AutomationException(string.Format("Cannot expand TreeNode {0}, expand button not visible", this), Debug.Details(AutomationElement));
            expandCollapseButton.Click();
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