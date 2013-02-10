using NUnit.Framework;
using White.Core.UIItems.TreeItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.TreeItems
{
    [TestFixture]
    public class TreeNodesTest : ControlsActionTest
    {
        [Test]
        public void GetItem()
        {
            var tree = Window.Get<Tree>("ped");
            TreeNode treeNode = tree.Nodes.GetItem("Root", "Child");
            Assert.AreNotEqual(null, treeNode);
        }
    }
}