using NUnit.Framework;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TreeItems;

namespace TestStack.White.UITests.ControlTests.TreeItems
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class TreeNodeTests : WhiteUITestBase
    {
        private Tree tree;

        public TreeNodeTests(WindowsFramework framework)
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
        public void ExpandTest()
        {
            var treeNode = tree.Node("Root");
            treeNode.Expand();
            Assert.That(treeNode.IsExpanded(), Is.True);
        }

        [Test]
        public void CollapseTest()
        {
            var treeNode = tree.Node("Root");
            treeNode.Expand();
            treeNode.Collapse();
            Assert.That(treeNode.IsExpanded(), Is.False);
        }

        [Test]
        public void DisplayStateTest()
        {
            var treeNode = tree.Node("Root");
            treeNode.Expand();
            Assert.That(treeNode.DisplayState, Is.EqualTo(ExpandCollapseState.Expanded));
            treeNode.Collapse();
            Assert.That(treeNode.DisplayState, Is.EqualTo(ExpandCollapseState.Collapsed));
        }

        [Test]
        public void DoubleClickTest()
        {
            var treeNode = tree.Node("Root");
            var state = treeNode.IsExpanded();
            treeNode.DoubleClick();
            Assert.That(treeNode.IsExpanded(), Is.Not.EqualTo(state));
            treeNode.DoubleClick();
            Assert.That(treeNode.IsExpanded(), Is.EqualTo(state));
        }

        [Test]
        public void UnSelectTest()
        {
            if (Framework != WindowsFramework.Wpf)
            {
                Assert.Ignore();
            }
            var treeNode = tree.Node("Root", "Child");
            treeNode.Select();
            Assert.That(tree.SelectedNode.Name, Is.EqualTo("Child"));
            treeNode.UnSelect();
            Assert.That(tree.SelectedNode, Is.Null);
        }
    }
}