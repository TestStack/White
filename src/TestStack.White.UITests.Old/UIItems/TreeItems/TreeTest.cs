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
            tree = window.Get<Tree>("ped");
        }

        [SetUp]
        public virtual void SetUp()
        {
            tree.Node("Root").Expand();
            tree.Node("Root", "Child").Expand();
        }

        [Test]
        public void Nodes()
        {
            Assert.AreEqual(true, tree.Nodes.Count >= 2);
        }

        [Test]
        public void FindNode()
        {
            Assert.AreEqual(true, tree.HasNode("Root"));
            Assert.AreEqual(false, tree.HasNode("Roo"));
            Assert.AreEqual(true, tree.HasNode("Main"));
            Assert.AreEqual(true, tree.HasNode("Root", "Child"));
            Assert.AreEqual(true, tree.HasNode("Root", "Child", "Grand Child"));
            var exception = Assert.Throws<AutomationException>(() => tree.HasNode("Root", "Child", "Grand Child", "Grand Child"));
            Assert.AreEqual(
                string.Format("Cannot expand TreeNode {0}TreeNode. AutomationId:, Name:Grand Child, ControlType:tree view item, FrameworkId:{1}, expand button not visible", 
                        TestConfiguration is WPFTestConfiguration ? "WPF" : "Win32",
                        TestConfiguration is WPFTestConfiguration ? "WPF" : "WinForm"),
                exception.Message);
        }

        [Test]
        public void SelectNodeWhichNeedsScrolling()
        {
            tree.Node("Root").Select();
            Assert.AreEqual("Root", tree.SelectedNode.Text);
            tree.Node("Main").Select();
            Assert.AreEqual("Main", tree.SelectedNode.Text);
            tree.Node("Root").Select();
            Assert.AreEqual("Root", tree.SelectedNode.Text);
            tree.Node("Main").Select();
            Assert.AreEqual("Main", tree.SelectedNode.Text);
        }

        [Test]
        public void SelectNode()
        {
            TreeNode treeNode = tree.Node("Root", "Child");
            treeNode.Select();
            Assert.AreEqual("Child", tree.SelectedNode.Name);
        }

        [Test]
        public void DynamicallyAddedNodeCanBeFound()
        {
            window.Get<Button>("addNode").Click();
            Assert.AreEqual(true, tree.HasNode("DynamicNode"));
        }

        [Test]
        public void GetPathTo()
        {
            TreeNode treeNode = tree.Node("Root", "Child");
            List<TreeNode> path = tree.GetPathTo(treeNode);
            Assert.AreEqual(2, path.Count);
        }

        [Test]
        public void GetClickedNodePathForGrandChild()
        {
            TreeNode treeNode = tree.Node("Root", "Child", "Grand Child");
            List<TreeNode> path = tree.GetPathTo(treeNode);
            Assert.AreEqual(3, path.Count);
        }

        [Test]
        public void GetClickedNodePathForRoot()
        {
            TreeNode treeNode = tree.Node("Root");
            List<TreeNode> path = tree.GetPathTo(treeNode);
            Assert.AreEqual(1, path.Count);
        }
    }
}