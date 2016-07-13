using System;
using System.Windows.Automation;
using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TreeItems;

namespace TestStack.White.UITests.ControlTests.TreeItems
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class TreeTests : WhiteUITestBase
    {
        private Tree tree;

        public TreeTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectOtherControls();
            tree = MainWindow.Get<Tree>("TreeView");
        }

        [Test]
        public void NodesTest()
        {
            Assert.That(tree.Nodes, Has.Count.GreaterThanOrEqualTo(2));
        }

        [Test]
        public void FindNodeTest()
        {
            Assert.That(tree.HasNode("Root"), Is.True);
            Assert.That(tree.HasNode("Roo"), Is.False);
            Assert.That(tree.HasNode("Main"), Is.True);
            Assert.That(tree.HasNode("Root", "Child"), Is.True);
            Assert.That(tree.HasNode("Root", "Child", "Grand Child"), Is.True);
            Assert.That(() => { tree.HasNode("Root", "Child", "Grand Child", "Grand Child"); },
                    Throws.TypeOf<AutomationException>().With.
                    Message.EqualTo(String.Format(
                        "Cannot expand TreeNode {0}TreeNode. AutomationId:, Name:Grand Child, " +
                        "ControlType:{2}, FrameworkId:{1}, expand button not visible",
                        Framework == WindowsFramework.Wpf ? "WPF" : "Win32",
                        Framework.FrameworkId(),
                        ControlType.TreeItem.LocalizedControlType)));
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void SelectNodeWhichNeedsScrollingTest()
        {
            tree.Node("Root").Select();
            Assert.That(tree.SelectedNode.Text, Is.EqualTo("Root"));
            tree.Node("Main").Select();
            Assert.That(tree.SelectedNode.Text, Is.EqualTo("Main"));
            tree.Node("Root").Select();
            Assert.That(tree.SelectedNode.Text, Is.EqualTo("Root"));
            tree.Node("Main").Select();
            Assert.That(tree.SelectedNode.Text, Is.EqualTo("Main"));
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void SelectNodeTest()
        {
            var treeNode = tree.Node("Root", "Child");
            treeNode.Select();
            Assert.That(tree.SelectedNode.Name, Is.EqualTo("Child"));
        }

        [Test]
        public void DynamicallyAddedNodeCanBeFoundTest()
        {
            MainWindow.Get<Button>("AddNode").Click();
            Assert.That(tree.HasNode("AddedNode"), Is.True);
        }

        [Test]
        public void GetPathToTest()
        {
            var treeNode = tree.Node("Root", "Child");
            var path = tree.GetPathTo(treeNode);
            Assert.That(path, Has.Count.EqualTo(2));
        }

        [Test]
        public void GetClickedNodePathForGrandChildTest()
        {
            var treeNode = tree.Node("Root", "Child", "Grand Child");
            var path = tree.GetPathTo(treeNode);
            Assert.That(path, Has.Count.EqualTo(3));
        }

        [Test]
        public void GetClickedNodePathForRootTest()
        {
            var treeNode = tree.Node("Root");
            var path = tree.GetPathTo(treeNode);
            Assert.That(path, Has.Count.EqualTo(1));
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void ScrollAndSelectTest()
        {
            var treeNode = tree.Node("Lots Of Children", "Child40");
            Assert.That(treeNode, Is.Not.Null);
            treeNode.Select();
            Assert.That(tree.SelectedNode, Is.EqualTo(treeNode));
        }
    }
}