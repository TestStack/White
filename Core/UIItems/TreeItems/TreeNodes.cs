using System.Collections.Generic;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Factory;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.TreeItems
{
    public class TreeNodes : UIItemList<TreeNode>
    {
        public TreeNodes(AutomationElementFinder finder, ActionListener actionListener)
            : base(finder.Children(AutomationSearchCondition.ByControlType(ControlType.TreeItem)), actionListener) {}

        /// <summary>
        /// Gets the TreeNode matching the path. If multi-level find is specified in arguments then in process of finding the TreeNode it would also expand the TreeNodes.
        /// </summary>
        /// <param name="path">e.g. when arguments are ("Parent", "Child", "GrandChild") it would return the TreeNode "GrandChild" which is under "Child", which 
        /// in turn is under "Parent", root node. To get the "Parent" node one needs to just specify ("Parent") as argument.</param>
        /// <returns>true if it finds such node, false otherwise</returns>
        public virtual TreeNode GetItem(params string[] path)
        {
            var nodePath = new List<string>(path);
            if (nodePath.Count == 0) return null;

            string nodeText = nodePath[0];
            TreeNode node = MatchingNode(nodeText);
            nodePath.RemoveAt(0);
            if (nodePath.Count == 0) return node;
            if (node == null) throw new UIItemSearchException(string.Format("Could not find node {0}", nodeText));
            node.Expand();
            return node.GetItem(nodePath.ToArray());
        }

        private TreeNode MatchingNode(string nodeText)
        {
            return Find(treeNode => treeNode.Text.Equals(nodeText));
        }

        /// <summary>
        /// Get the list of tree nodes which would be traversed to reach the node supplied
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public virtual List<TreeNode> GetPathTo(TreeNode treeNode)
        {
            var nodePath = new List<TreeNode>();
            Path(treeNode, nodePath);
            return nodePath;
        }

        private bool Path(TreeNode treeNode, List<TreeNode> treeNodes)
        {
            foreach (TreeNode currentNode in this)
            {
                if (currentNode.Equals(treeNode))
                {
                    treeNodes.Add(currentNode);
                    return true;
                }
                treeNodes.Add(currentNode);
                bool pathFound = currentNode.Nodes.Path(treeNode, treeNodes);
                if (pathFound) return true;
                treeNodes.Remove(currentNode);
            }
            return false;
        }

        public virtual void Visit(TreeNodeVisitor visitor)
        {
            foreach (TreeNode treeNode in this)
                treeNode.Visit(visitor);
        }
    }
}
