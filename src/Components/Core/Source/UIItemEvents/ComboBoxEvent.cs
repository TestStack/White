using White.Core.UIItems;

namespace White.Core.UIItemEvents
{
    public class ComboBoxEvent : ListControlEvent
    {
        public ComboBoxEvent(IUIItem uiItem, string selectedItem) : base(uiItem, selectedItem) {}
    }
}