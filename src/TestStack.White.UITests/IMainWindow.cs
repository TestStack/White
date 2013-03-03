using White.Core.UIItems;
using White.Core.UIItems.WindowItems;

namespace TestStack.White.UITests
{
    public interface IMainWindow : IUIItemContainer
    {
        void Close();
        Window ModalWindow(string title);
    }
}