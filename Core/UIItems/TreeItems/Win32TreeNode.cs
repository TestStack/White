using System.Windows;
using System.Windows.Automation;
using White.Core.UIA;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.TreeItems
{
    [PlatformSpecificItem]
    public class Win32TreeNode : TreeNode
    {
        protected Win32TreeNode() {}
        public Win32TreeNode(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        //TODO Expand and Collapse also Select the node because it uses DoubleClick. Even the pattern does the same. Clicking to the left of node,
        // would not work when there is an icon to left of the node.
        protected override void DoExpand()
        {
            DoubleClick();
        }

        protected override void DoCollapse()
        {
            DoubleClick();
        }

        protected override Point SelectPoint
        {
            get { return automationElement.Current.BoundingRectangle.Center(); }
        }
    }
}