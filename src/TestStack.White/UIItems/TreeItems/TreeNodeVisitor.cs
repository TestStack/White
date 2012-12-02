namespace White.Core.UIItems.TreeItems
{
    public interface TreeNodeVisitor
    {
        void Accept(TreeNode treeNode);
    }
}