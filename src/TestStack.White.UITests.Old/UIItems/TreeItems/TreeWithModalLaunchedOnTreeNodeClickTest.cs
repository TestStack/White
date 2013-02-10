using NUnit.Framework;
using White.Core.UIItems.TreeItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.TreeItems
{
    [TestFixture]
    public class TreeWithModalLaunchedOnTreeNodeClickTest : ControlsActionTest
    {
        [Test]
        public void ModalOnExpand()
        {
            TreeNode node = Window.Get<Tree>("treeViewLaunchesModal").Node("Root");
            node.Select();
            node.Expand();
            CloseModal(Window);
        }
    }
}