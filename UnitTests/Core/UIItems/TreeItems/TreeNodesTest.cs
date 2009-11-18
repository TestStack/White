using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems.TreeItems
{
    [TestFixture]
    public class TreeNodesTest : ControlsActionTest
    {
        [Test]
        public void GetItem()
        {
            var tree = window.Get<Tree>("ped");
            TreeNode treeNode = tree.Nodes.GetItem("Root", "Child");
            Assert.AreNotEqual(null, treeNode);
        }
    }
}