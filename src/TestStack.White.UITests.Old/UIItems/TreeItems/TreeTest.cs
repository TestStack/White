using System.Collections.Generic;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.TreeItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.TreeItems
{
    [TestFixture, WPFCategory]
    public class WpfTreeTest : TreeTest
    {
    }

    [TestFixture, WinFormCategory]
    public class WinformsTreeTest : TreeTest
    {
    }

    public class TreeTest : ControlsActionTest
    {
        protected Tree tree;

        protected override void TestFixtureSetUp()
        {
            tree = Window.Get<Tree>("ped");
        }

        [SetUp]
        public virtual void SetUp()
        {
            tree.Node("Root").Expand();
            tree.Node("Root", "Child").Expand();
        }

        [Fact]
        public void Nodes()
        {
            Assert.Equal(true, tree.Nodes.Count >= 2);
        }

        [Fact]
        public void FindNode()
        {
            Assert.Equal(true, tree.HasNode("Root"));
            Assert.Equal(false, tree.HasNode("Roo"));
            Assert.Equal(true, tree.HasNode("Main"));
            Assert.Equal(true, tree.HasNode("Root", "Child"));
            Assert.Equal(true, tree.HasNode("Root", "Child", "Grand Child"));
            var exception = Assert.Throws<AutomationException>(() => tree.HasNode("Root", "Child", "Grand Child", "Grand Child"));
            Assert.Equal(
                string.Format("Cannot expand TreeNode {0}TreeNode. AutomationId:, Name:Grand Child, ControlType:tree view item, FrameworkId:{1}, expand button not visible", 
                        TestConfiguration is WPFTestConfiguration ? "WPF" : "Win32",
                        TestConfiguration is WPFTestConfiguration ? "WPF" : "WinForm"),
                exception.Message);
        }

        [Fact]
        public void SelectNodeWhichNeedsScrolling()
        {
            tree.Node("Root").Select();
            Assert.Equal("Root", tree.SelectedNode.Text);
            tree.Node("Main").Select();
            Assert.Equal("Main", tree.SelectedNode.Text);
            tree.Node("Root").Select();
            Assert.Equal("Root", tree.SelectedNode.Text);
            tree.Node("Main").Select();
            Assert.Equal("Main", tree.SelectedNode.Text);
        }

        [Fact]
        public void SelectNode()
        {
            TreeNode treeNode = tree.Node("Root", "Child");
            treeNode.Select();
            Assert.Equal("Child", tree.SelectedNode.Name);
        }

        [Fact]
        public void DynamicallyAddedNodeCanBeFound()
        {
            Window.Get<Button>("addNode").Click();
            Assert.Equal(true, tree.HasNode("DynamicNode"));
        }

        [Fact]
        public void GetPathTo()
        {
            TreeNode treeNode = tree.Node("Root", "Child");
            List<TreeNode> path = tree.GetPathTo(treeNode);
            Assert.Equal(2, path.Count);
        }

        [Fact]
        public void GetClickedNodePathForGrandChild()
        {
            TreeNode treeNode = tree.Node("Root", "Child", "Grand Child");
            List<TreeNode> path = tree.GetPathTo(treeNode);
            Assert.Equal(3, path.Count);
        }

        [Fact]
        public void GetClickedNodePathForRoot()
        {
            TreeNode treeNode = tree.Node("Root");
            List<TreeNode> path = tree.GetPathTo(treeNode);
            Assert.Equal(1, path.Count);
        }
    }
}