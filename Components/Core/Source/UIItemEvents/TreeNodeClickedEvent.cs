using Bricks;
using White.Core.UIItems.TreeItems;

namespace White.Core.UIItemEvents
{
    public class TreeNodeClickedEvent : TreeNodeEvent
    {
        private readonly TreeNode clickedNode;
        private readonly bool isExpanded;
        private static readonly string collapseEventName;
        private static readonly string expandEventName;

        static TreeNodeClickedEvent()
        {
            CodePath.New<TreeNode>().Collapse();
            collapseEventName = CodePath.Last;

            CodePath.New<TreeNode>().Expand();
            expandEventName = CodePath.Last;
        }

        public TreeNodeClickedEvent(Tree tree, TreeNode node, bool isExpanded) : base(tree)
        {
            clickedNode = node;
            this.isExpanded = isExpanded;
        }

        protected override string ActionName(EventOption eventOption)
        {
            string lookupNode = "Node(" + PathTo(clickedNode) + ").";
            return isExpanded ? lookupNode + expandEventName : lookupNode + collapseEventName;
        }
    }
}