using NUnit.Framework;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.TreeItems
{
    [TestFixture, WinFormCategory]
    public class TreeScrollingTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "LargeTree"; }
        }

        [Fact]
        public void ScrollAndSelect()
        {
            var tree = Window.Get<Tree>("treeView1");
            TreeNode treeNode = tree.Node("Root", "Child40");
            Assert.NotEqual(null, treeNode);
            treeNode.Select();
            Assert.Equal(treeNode, tree.SelectedNode);
        }
    }
}