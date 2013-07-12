using System.Windows.Automation;
using NUnit.Framework;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.TreeItems
{
    public class TreeNodeTest : ControlsActionTest
    {
        private Tree tree;

        protected override void TestFixtureSetUp()
        {
            tree = Window.Get<Tree>("ped");
        }

        [SetUp]
        public void SetUp()
        {
            tree.Node("Root").Collapse();
        }

        [Fact]
        public void NodeIsExpanded()
        {
            TreeNode treeNode = tree.Node("Root");
            Assert.Equal(false, treeNode.IsExpanded());
        }

        [Fact]
        public void Expand()
        {
            TreeNode treeNode = tree.Node("Root");
            treeNode.Expand();
            Assert.Equal(true, treeNode.IsExpanded());
        }

        [Fact]
        public void Collapse()
        {
            TreeNode treeNode = tree.Node("Root");
            treeNode.Expand();
            treeNode.Collapse();
            Assert.Equal(false, treeNode.IsExpanded());
        }

        [Fact]
        public void DisplayState()
        {
            TreeNode treeNode = tree.Node("Root");
            treeNode.Expand();
            Assert.Equal(ExpandCollapseState.Expanded, treeNode.DisplayState);
            treeNode.Collapse();
            Assert.Equal(ExpandCollapseState.Collapsed, treeNode.DisplayState);
        }

        [Fact]
        public void DoubleClick()
        {
            TreeNode treeNode = tree.Node("Root");
            bool state = treeNode.IsExpanded();
            treeNode.DoubleClick();
            Assert.NotEqual(state, treeNode.IsExpanded());
            treeNode.DoubleClick();
            Assert.Equal(state, treeNode.IsExpanded());
        }

        [Fact]
        public void UnSelect()
        {
            TreeNode treeNode = tree.Node("Root", "Child");
            treeNode.Select();
            Assert.Equal("Child", tree.SelectedNode.Name);
            treeNode.UnSelect();
            Assert.Equal(null, tree.SelectedNode);
        }
    }
}