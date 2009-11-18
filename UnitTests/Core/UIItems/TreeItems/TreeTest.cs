using System.Collections.Generic;
using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems.TreeItems
{
    [TestFixture]
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
            Assert.AreEqual(false, tree.HasNode("Root", "Child", "Grand Child", "Grand Child"));
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