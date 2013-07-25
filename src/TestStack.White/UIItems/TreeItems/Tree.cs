using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Recording;
using TestStack.White.UIItemEvents;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Scrolling;

namespace TestStack.White.UIItems.TreeItems
{
    /// <summary>
    /// Tree consists of TreeNodes. TreeNodes is a collection of TreeNode. Each TreeNode in turn consists of TreeNodes.
    /// </summary>
    public class Tree : UIItem, VerticalSpanProvider
    {
        private readonly AutomationElementFinder finder;
        private AutomationPropertyChangedEventHandler clickedTreeNodeHandler;
        private AutomationPropertyChangedEventHandler selectedTreeNodeHandler;

        protected Tree() {}

        public Tree(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
        {
            finder = new AutomationElementFinder(automationElement);
        }

        public virtual TreeNode SelectedNode
        {
            get
            {
                var visitor = new SelectedNodeVisitor();
                Nodes.Visit(visitor);
                return visitor.SelectedNode;
            }
        }

        /// <summary>
        /// Editable TreeNode's value can be set using this.
        /// </summary>
        public virtual string EditableNodeText
        {
            set
            {
                AutomationElement element = finder.Child(AutomationSearchCondition.ByControlType(ControlType.Edit));
                new TextBox(element, actionListener).Text = value;
            }
        }

        /// <summary>
        /// List of all root nodes
        /// </summary>
        public virtual TreeNodes Nodes
        {
            get { return new TreeNodes(finder, this); }
        }

        /// <summary>
        /// Checks the presence on the TreeNode. If multi-level find is specified in arguments then in process of finding the TreeNode it would also expand the TreeNodes.
        /// </summary>
        /// <param name="nodePath">e.g. when arguments are ("Parent", "Child", "GrandChild") it would return the TreeNode "GrandChild" which is under "Child", which 
        /// in turn is under "Parent", root node. To get the "Parent" node one needs to just specify ("Parent") as argument.</param>
        /// <returns>true if it finds such node, false otherwise</returns>
        public virtual bool HasNode(params string[] nodePath)
        {
            return Node(nodePath) != null;
        }

        /// <summary>
        /// Gets the TreeNode. If multi-level find is specified in arguments then in process of finding the TreeNode it would also expand the TreeNodes.
        /// </summary>
        /// <param name="nodePath">e.g. when arguments are ("Parent", "Child", "GrandChild") it would return the TreeNode "GrandChild" which is under "Child", which 
        /// in turn is under "Parent", root node. To get the "Parent" node one needs to just specify ("Parent") as argument.</param>
        /// <returns>TreeNode object when found, null if otherwise</returns>
        public virtual TreeNode Node(params string[] nodePath)
        {
            return Nodes.GetItem(nodePath);
        }

        public override IScrollBars ScrollBars
        {
            get
            {
                if (Framework == WindowsFramework.Wpf)
                    return new WpfTreeViewScrollBars(AutomationElement, actionListener);
                return base.ScrollBars;
            }
        }

        public override void HookEvents(UIItemEventListener eventListener)
        {
            clickedTreeNodeHandler = delegate
                                         {
                                             TreeNode node = ClickedNode;
                                             eventListener.EventOccured((new TreeNodeClickedEvent(this, node, node.IsExpanded())));
                                         };

            selectedTreeNodeHandler = delegate
                                          {
                                              TreeNode node = SelectedNode;
                                              eventListener.EventOccured((new TreeNodeSelectEvent(this, node)));
                                          };

            Automation.AddAutomationPropertyChangedEventHandler(automationElement, TreeScope.Subtree, clickedTreeNodeHandler,
                                                                ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty);
            Automation.AddAutomationPropertyChangedEventHandler(automationElement, TreeScope.Subtree, selectedTreeNodeHandler,
                                                                SelectionItemPatternIdentifiers.IsSelectedProperty);
        }

        private TreeNode ClickedNode
        {
            get
            {
                var visitor = new ClickedNodeVisitor();
                Nodes.Visit(visitor);
                return visitor.ClickedNode;
            }
        }

        public override void UnHookEvents()
        {
            Automation.RemoveAutomationPropertyChangedEventHandler(automationElement, clickedTreeNodeHandler);
            Automation.RemoveAutomationPropertyChangedEventHandler(automationElement, selectedTreeNodeHandler);
        }

        /// <summary>
        /// Finds path to the TreeNode. It doesn't expand the nodes to find it.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public virtual List<TreeNode> GetPathTo(TreeNode node)
        {
            return Nodes.GetPathTo(node);
        }

        public override void ActionPerforming(UIItem uiItem)
        {
            new ScreenItem(uiItem, ScrollBars).MakeVisible(this);
        }

        public virtual VerticalSpan VerticalSpan
        {
            get { return new VerticalSpan(Bounds).Minus(ScrollBars.Horizontal.Bounds); }
        }

        public override void ActionPerformed(Action action)
        {
            actionListener.ActionPerformed(action);
        }
    }
}