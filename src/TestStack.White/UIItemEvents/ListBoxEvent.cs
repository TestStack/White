using TestStack.White.UIItems;

namespace TestStack.White.UIItemEvents
{
    public class ListBoxEvent : ListControlEvent
    {
        public ListBoxEvent(IUIItem uiItem, string selectedItem) : base(uiItem, selectedItem) {}
    }
}