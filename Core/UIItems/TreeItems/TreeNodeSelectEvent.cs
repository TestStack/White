using Bricks;
using White.Core.UIItemEvents;

namespace White.Core.UIItems.TreeItems
{
    public class TreeNodeSelectEvent : TreeNodeEvent
    {
        private readonly TreeNode selectedNode;
        private static readonly string selectEventName;

        static TreeNodeSelectEvent()
        {
            CodePath.New<TreeNode>().Select();
            selectEventName = CodePath.Last;
        }

        public TreeNodeSelectEvent(Tree tree, TreeNode node) : base(tree)
        {
            selectedNode = node;
        }

        protected override string ActionName(EventOption eventOption)
        {
            return "Node( " + PathTo(selectedNode) + ")." + selectEventName;
        }
    }
}