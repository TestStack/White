using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.UITests
{
    public interface IMainWindow : IUIItemContainer
    {
        void Close();
        Window ModalWindow(string title);
        Window ModalWindow(SearchCriteria searchCriteria);
        Window ModalWindow(string searchCriteria, InitializeOption initializeOption);
        Window MessageBox(string title);
        AttachedKeyboard Keyboard { get; }
    }
}