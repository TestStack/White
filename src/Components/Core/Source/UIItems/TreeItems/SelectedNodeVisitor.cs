namespace White.Core.UIItems.TreeItems
{
    public class SelectedNodeVisitor : TreeNodeVisitor
    {
        private TreeNode selectedNode;

        public virtual TreeNode SelectedNode
        {
            get { return selectedNode; }
        }

        public virtual void Accept(TreeNode treeNode)
        {
            if (treeNode.IsSelected) selectedNode = treeNode;
        }
    }
}