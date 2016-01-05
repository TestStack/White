using TestStack.White.UIItemEvents;
using TestStack.White.Utility;

namespace TestStack.White.UIItems.TreeItems
{
    public class TreeNodeSelectEvent : TreeNodeEvent
    {
        private readonly TreeNode selectedNode;
        private static readonly string SelectEventName;

        static TreeNodeSelectEvent()
        {
            SelectEventName = MethodNameResolver.NameFor<TreeNode>(n => n.Select());
        }

        public TreeNodeSelectEvent(Tree tree, TreeNode node) : base(tree)
        {
            selectedNode = node;
        }

        protected override string ActionName(IEventOption eventOption)
        {
            return "Node( " + PathTo(selectedNode) + ")." + SelectEventName;
        }
    }
}