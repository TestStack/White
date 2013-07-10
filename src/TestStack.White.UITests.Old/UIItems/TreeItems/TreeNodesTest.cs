using NUnit.Framework;
using White.Core.UIItems.TreeItems;
using White.Core.UITests.Testing;

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