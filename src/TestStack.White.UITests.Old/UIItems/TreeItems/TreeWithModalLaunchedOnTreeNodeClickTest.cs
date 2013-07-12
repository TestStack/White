using NUnit.Framework;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.TreeItems
{
    public class TreeWithModalLaunchedOnTreeNodeClickTest : ControlsActionTest
    {
        [Fact]
        public void ModalOnExpand()
        {
            TreeNode node = Window.Get<Tree>("treeViewLaunchesModal").Node("Root");
            node.Select();
            node.Expand();
            CloseModal(Window);
        }
    }
}