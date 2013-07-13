using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.UITests
{
    public interface IMainWindow : IUIItemContainer
    {
        void Close();
        Window ModalWindow(string title);
        Window MessageBox(string title);
        AttachedKeyboard Keyboard { get; }
    }
}