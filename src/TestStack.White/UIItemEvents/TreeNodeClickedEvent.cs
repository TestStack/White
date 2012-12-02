using White.Core.UIItems.TreeItems;
using White.Core.Utility;

namespace White.Core.UIItemEvents
{
    public class TreeNodeClickedEvent : TreeNodeEvent
    {
        private readonly TreeNode clickedNode;
        private readonly bool isExpanded;
        private static readonly string CollapseEventName;
        private static readonly string ExpandEventName;

        static TreeNodeClickedEvent()
        {
            CollapseEventName = MethodNameResolver.NameFor<TreeNode>(n => n.Collapse());

            ExpandEventName = MethodNameResolver.NameFor<TreeNode>(n => n.Expand());
        }

        public TreeNodeClickedEvent(Tree tree, TreeNode node, bool isExpanded) : base(tree)
        {
            clickedNode = node;
            this.isExpanded = isExpanded;
        }

        protected override string ActionName(EventOption eventOption)
        {
            string lookupNode = "Node(" + PathTo(clickedNode) + ").";
            return isExpanded ? lookupNode + ExpandEventName : lookupNode + CollapseEventName;
        }
    }
}