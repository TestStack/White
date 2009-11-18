using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems.TreeItems
{
    [TestFixture]
    public class TreeWithModalLaunchedOnTreeNodeClickTest : ControlsActionTest
    {
        [Test]
        public void ModalOnExpand()
        {
            TreeNode node = window.Get<Tree>("treeViewLaunchesModal").Node("Root");
            node.Select();
            node.Expand();
            CloseModal(window);
        }
    }
}