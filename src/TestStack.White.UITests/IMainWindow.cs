using System;
using System.Collections.Generic;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;

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
        bool IsCurrentlyActive { get; }
        AttachedMouse Mouse { get; }
        UIItemCollection Items { get; }
        List<Tab> Tabs { get; }
        DisplayState DisplayState { get; set; }
        string Title { get; }
        TitleBar TitleBar { get; }
        bool IsClosed { get; }
        List<UIItem> ItemsWithin(UIItem containingItem);
        ToolStrip GetToolStrip(string primaryIdentification);
        void WaitTill(Window.WaitTillDelegate waitTillDelegate);
        void WaitTill(Window.WaitTillDelegate waitTillDelegate, TimeSpan timeout);
    }
}