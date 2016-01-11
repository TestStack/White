using System;
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
            var mouse = new Mouse();
            if (treeNode.Bounds.Top <= mouse.Location.Y && treeNode.Bounds.Bottom >= mouse.Location.Y)
                clickedNode = treeNode;
        }
    }
}