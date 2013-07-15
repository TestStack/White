using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TreeItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.TreeItems
{
    public class TreeNodeTest : WhiteTestBase
    {
        Tree tree;

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectOtherControls();
            tree = MainWindow.Get<Tree>("TreeView");

            RunTest(NodeIsExpanded);
            RunTest(Expand);
            RunTest(Collapse);
            RunTest(Collapse);
            RunTest(DisplayState);
            RunTest(DoubleClick);
            RunTest(UnSelect, WindowsFramework.Wpf); // Winforms must have a selection
        }

        void NodeIsExpanded()
        {
            TreeNode treeNode = tree.Node("Root");
            Assert.False(treeNode.IsExpanded());
        }

        void Expand()
        {
            TreeNode treeNode = tree.Node("Root");
            treeNode.Expand();
            Assert.True(treeNode.IsExpanded());
        }

        void Collapse()
        {
            var treeNode = tree.Node("Root");
            treeNode.Expand();
            treeNode.Collapse();
            Assert.False(treeNode.IsExpanded());
        }

        void DisplayState()
        {
            var treeNode = tree.Node("Root");
            treeNode.Expand();
            Assert.Equal(ExpandCollapseState.Expanded, treeNode.DisplayState);
            treeNode.Collapse();
            Assert.Equal(ExpandCollapseState.Collapsed, treeNode.DisplayState);
        }

        void DoubleClick()
        {
            var treeNode = tree.Node("Root");
            var state = treeNode.IsExpanded();
            treeNode.DoubleClick();
            Assert.NotEqual(state, treeNode.IsExpanded());
            treeNode.DoubleClick();
            Assert.Equal(state, treeNode.IsExpanded());
        }

        void UnSelect()
        {
            var treeNode = tree.Node("Root", "Child");
            treeNode.Select();
            Assert.Equal("Child", tree.SelectedNode.Name);
            treeNode.UnSelect();
            Assert.Null(tree.SelectedNode);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}