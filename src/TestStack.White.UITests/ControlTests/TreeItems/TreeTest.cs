using System.Collections.Generic;
using System.Threading;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TreeItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.TreeItems
{
    public class TreeTest : WhiteTestBase
    {
        Tree tree;

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectOtherControls();
            tree = MainWindow.Get<Tree>("TreeView");

            RunTest(Nodes);
            RunTest(() => FindNode(framework));
            RunTest(SelectNodeWhichNeedsScrolling);
            RunTest(SelectNode);
            RunTest(DynamicallyAddedNodeCanBeFound);
            RunTest(GetPathTo);
            RunTest(GetClickedNodePathForGrandChild);
            RunTest(GetClickedNodePathForRoot);
            RunTest(ScrollAndSelect);
        }

        void Nodes()
        {
            Assert.True(tree.Nodes.Count >= 2);
        }

        void FindNode(WindowsFramework framework)
        {
            Assert.True(tree.HasNode("Root"));
            Assert.False(tree.HasNode("Roo"));
            Assert.True(tree.HasNode("Main"));
            Assert.True(tree.HasNode("Root", "Child"));
            Assert.True(tree.HasNode("Root", "Child", "Grand Child"));
            var exception = Assert.Throws<AutomationException>(() => tree.HasNode("Root", "Child", "Grand Child", "Grand Child"));
            string expected = string.Format(
                "Cannot expand TreeNode {0}TreeNode. AutomationId:, Name:Grand Child, " +
                "ControlType:tree view item, FrameworkId:{1}, expand button not visible",
                framework == WindowsFramework.Wpf ? "WPF" : "Win32",
                framework.FrameworkId());
            Assert.Equal(expected, exception.Message);
        }

        void SelectNodeWhichNeedsScrolling()
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

        void SelectNode()
        {
            TreeNode treeNode = tree.Node("Root", "Child");
            treeNode.Select();
            Assert.Equal("Child", tree.SelectedNode.Name);
        }

        void DynamicallyAddedNodeCanBeFound()
        {
            MainWindow.Get<Button>("AddNode").Click();
            Assert.True(tree.HasNode("AddedNode"));
        }

        void GetPathTo()
        {
            TreeNode treeNode = tree.Node("Root", "Child");
            List<TreeNode> path = tree.GetPathTo(treeNode);
            Assert.Equal(2, path.Count);
        }

        void GetClickedNodePathForGrandChild()
        {
            TreeNode treeNode = tree.Node("Root", "Child", "Grand Child");
            List<TreeNode> path = tree.GetPathTo(treeNode);
            Assert.Equal(3, path.Count);
        }

        void GetClickedNodePathForRoot()
        {
            TreeNode treeNode = tree.Node("Root");
            List<TreeNode> path = tree.GetPathTo(treeNode);
            Assert.Equal(1, path.Count);
        }

        void ScrollAndSelect()
        {
            TreeNode treeNode = tree.Node("Lots Of Children", "Child40");
            Assert.NotNull(treeNode);
            treeNode.Select();
            Assert.Equal(treeNode, tree.SelectedNode);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}