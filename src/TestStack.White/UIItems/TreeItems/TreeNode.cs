using System.Windows;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.TreeItems
{
    public abstract class TreeNode : UIItem
    {
        private readonly AutomationElementFinder finder;
        protected TreeNode() {}

        protected TreeNode(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
        {
            finder = new AutomationElementFinder(automationElement);
        }

        public virtual TreeNodes Nodes
        {
            get { return new TreeNodes(finder, ActionListener); }
        }

        public virtual bool IsSelected
        {
            get { return (bool) Property(SelectionItemPattern.IsSelectedProperty); }
        }

        public virtual bool IsExpanded()
        {
            return ValueOfEquals(ExpandCollapsePattern.ExpandCollapseStateProperty, ExpandCollapseState.Expanded);
        }

        public virtual ExpandCollapseState DisplayState
        {
            get { return (ExpandCollapseState) Property(ExpandCollapsePattern.ExpandCollapseStateProperty); }
        }

        /// <summary>
        /// Gets the TreeNode matching the path. If multi-level find is specified in arguments then in process of finding the TreeNode it would also expand the TreeNodes.
        /// </summary>
        /// <param name="path">e.g. when arguments are ("Parent", "Child", "GrandChild") it would return the TreeNode "GrandChild" which is under "Child", which 
        /// in turn is under "Parent", root node. To get the "Parent" node one needs to just specify ("Parent") as argument.</param>
        /// <returns>TreeNode object when found, null if otherwise</returns>
        public virtual TreeNode GetItem(params string[] path)
        {
            ActionPerforming(this);
            Expand();
            return Nodes.GetItem(path);
        }

        /// <summary>
        /// Selects the TreeNode by clicking on it
        /// </summary>
        public virtual void Select()
        {
            ActionPerforming(this);
            mouse.Click(SelectPoint, ActionListener);
        }

        /// <summary>
        /// Un select the node. This depends on whether the automation element backing it supports SelectionItemPattern
        /// </summary>
        public virtual bool UnSelect()
        {
            var pattern = (SelectionItemPattern) Pattern(SelectionItemPattern.Pattern);
            if (pattern != null)
            {
                pattern.RemoveFromSelection();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Expands the node by double clicking on the node in case of Non WPF applications. This might lead to some inconsistent behaviour.
        /// For WPF it performs only expand with no side effect.
        /// </summary>
        public virtual void Expand()
        {
            if (!IsExpanded())
            {
                ActionPerforming(this);
                DoExpand();
            }
        }

        /// <summary>
        /// Collapses the node by double clicking on the node in case of Non-WPF applications. This might lead to some inconsistent behaviour.
        /// For WPF it performs only collapose and side effects.
        /// </summary>
        public virtual void Collapse()
        {
            if (IsExpanded())
            {
                ActionPerforming(this);
                DoCollapse();
            }
        }

        protected abstract void DoExpand();

        protected abstract void DoCollapse();

        public virtual void Visit(TreeNodeVisitor treeNodeVisitor)
        {
            treeNodeVisitor.Accept(this);
            Nodes.Visit(treeNodeVisitor);
        }

        /// <summary>
        /// Same as Select
        /// </summary>
        public override void Click()
        {
            Select();
        }

        protected abstract Point SelectPoint { get; }

        public override void DoubleClick()
        {
            ActionPerforming(this);
            mouse.DoubleClick(SelectPoint, ActionListener);
        }

        public override void RightClick()
        {
            ActionPerforming(this);
            mouse.RightClick(SelectPoint, ActionListener);
        }

        public virtual string Text
        {
            get
            {
                var value = Name;
                if (string.IsNullOrEmpty(value) || value.Contains("System.Windows.Controls.TreeViewItem"))
                {
                    AutomationElement textElement = finder.Child(AutomationSearchCondition.ByControlType(ControlType.Text));
                    return textElement == null ? string.Empty : textElement.Current.Name;
                }
                return value;
            }
        }
    }
}