using TestStack.White.UIItems;

namespace TestStack.White.UIItemEvents
{
    public class ComboBoxEvent : ListControlEvent
    {
        public ComboBoxEvent(IUIItem uiItem, string selectedItem) : base(uiItem, selectedItem) {}
    }
}