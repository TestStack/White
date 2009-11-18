using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems.TreeItems
{
    [TestFixture, WPFCategory]
    public class TestNodeWithoutHeaderTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "TreeViewItemWithoutHeader"; }
        }

        [Test]
        public void GetNode()
        {
            var tree = window.Get<Tree>("ped");
            TreeNode childNode = tree.Node("Root", "Child");
            Assert.AreNotEqual(null, childNode);
        }
    }
}