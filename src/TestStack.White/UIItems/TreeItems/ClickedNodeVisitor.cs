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
            if (treeNode.Bounds.Top <= Mouse.Instance.Location.Y && treeNode.Bounds.Bottom >= Mouse.Instance.Location.Y)
                clickedNode = treeNode;
        }
    }
}