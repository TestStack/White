using White.Core.InputDevices;

namespace White.Core.UIItems.TreeItems
{
    internal class ClickedNodeVisitor : TreeNodeVisitor
    {
        private TreeNode clickedNode;

        public virtual TreeNode ClickedNode
        {
            get { return clickedNode; }
        }

        public virtual void Accept(TreeNode treeNode)
        {
            if (treeNode.Bounds.Top <= Mouse.instance.Location.Y && treeNode.Bounds.Bottom >= Mouse.instance.Location.Y)
                clickedNode = treeNode;
        }
    }
}