using TestStack.White.InputDevices;

namespace TestStack.White.UIItems.TreeItems
{
    internal class ClickedNodeVisitor : ITreeNodeVisitor
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