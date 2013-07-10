using NUnit.Framework;
using White.Core.UIItems.TreeItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.TreeItems
{
    [TestFixture, WPFCategory]
    public class TestNodeWithoutHeaderTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "TreeViewItemWithoutHeader"; }
        }

        [Fact]
        public void GetNode()
        {
            var tree = Window.Get<Tree>("ped");
            TreeNode childNode = tree.Node("Root", "Child");
            Assert.NotEqual(null, childNode);
        }
    }
}