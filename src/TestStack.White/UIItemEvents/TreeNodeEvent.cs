using System.Collections.Generic;
using System.Text;
using TestStack.White.UIItems.TreeItems;

namespace TestStack.White.UIItemEvents
{
    public abstract class TreeNodeEvent : UserEvent
    {
        protected readonly Tree tree;

        protected TreeNodeEvent(Tree uiItem) : base(uiItem)
        {
            tree = uiItem;
        }

        protected virtual string PathTo(TreeNode givenNode)
        {
            StringBuilder nodePath = new StringBuilder();
            List<TreeNode> selectedNodePath = tree.GetPathTo(givenNode);
            foreach (TreeNode currentNode in selectedNodePath)
            {
                nodePath.AppendFormat("\"{0}\"", currentNode.Name);
                if (!selectedNodePath[selectedNodePath.Count - 1].Equals(currentNode)) nodePath.Append(",");
            }
            return nodePath.ToString();
        }
    }
}