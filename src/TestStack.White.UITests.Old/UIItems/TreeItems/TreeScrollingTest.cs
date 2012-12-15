using NUnit.Framework;
using White.Core.UIItems.TreeItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.TreeItems
{
    [TestFixture, WinFormCategory]
    public class TreeScrollingTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "LargeTree"; }
        }

        [Test]
        public void ScrollAndSelect()
        {
            var tree = window.Get<Tree>("treeView1");
            TreeNode treeNode = tree.Node("Root", "Child40");
            Assert.AreNotEqual(null, treeNode);
            treeNode.Select();
            Assert.AreEqual(treeNode, tree.SelectedNode);
        }
    }
}