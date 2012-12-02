using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems.TreeItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.TreeItems
{
    [TestFixture]
    public class TreeNodeTest : ControlsActionTest
    {
        private Tree tree;

        protected override void TestFixtureSetUp()
        {
            tree = window.Get<Tree>("ped");
        }

        [SetUp]
        public void SetUp()
        {
            tree.Node("Root").Collapse();
        }

        [Test]
        public void NodeIsExpanded()
        {
            TreeNode treeNode = tree.Node("Root");
            Assert.AreEqual(false, treeNode.IsExpanded());
        }

        [Test]
        public void Expand()
        {
            TreeNode treeNode = tree.Node("Root");
            treeNode.Expand();
            Assert.AreEqual(true, treeNode.IsExpanded());
        }

        [Test]
        public void Collapse()
        {
            TreeNode treeNode = tree.Node("Root");
            treeNode.Expand();
            treeNode.Collapse();
            Assert.AreEqual(false, treeNode.IsExpanded());
        }

        [Test]
        public void DisplayState()
        {
            TreeNode treeNode = tree.Node("Root");
            treeNode.Expand();
            Assert.AreEqual(ExpandCollapseState.Expanded, treeNode.DisplayState);
            treeNode.Collapse();
            Assert.AreEqual(ExpandCollapseState.Collapsed, treeNode.DisplayState);
        }

        [Test]
        public void DoubleClick()
        {
            TreeNode treeNode = tree.Node("Root");
            bool state = treeNode.IsExpanded();
            treeNode.DoubleClick();
            Assert.AreNotEqual(state, treeNode.IsExpanded());
            treeNode.DoubleClick();
            Assert.AreEqual(state, treeNode.IsExpanded());
        }

        [Test]
        public void UnSelect()
        {
            TreeNode treeNode = tree.Node("Root", "Child");
            treeNode.Select();
            Assert.AreEqual("Child", tree.SelectedNode.Name);
            treeNode.UnSelect();
            Assert.AreEqual(null, tree.SelectedNode);
        }
    }
}