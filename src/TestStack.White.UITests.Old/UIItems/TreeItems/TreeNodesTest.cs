using NUnit.Framework;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.TreeItems
{
    public class TreeNodesTest : ControlsActionTest
    {
        [Fact]
        public void GetItem()
        {
            var tree = Window.Get<Tree>("ped");
            TreeNode treeNode = tree.Nodes.GetItem("Root", "Child");
            Assert.NotEqual(null, treeNode);
        }
    }
}