using NUnit.Framework;
using White.UnitTests.Core.Testing;

namespace White.Core.UIItems.TreeItems
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