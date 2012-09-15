using Bricks;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;

namespace White.Core.UIItemEvents
{
    public class ListControlEvent : UserEvent
    {
        private readonly string selectedItem;
        private static readonly string actionName;

        static ListControlEvent()
        {
            CodePath.New<ComboBox>().Select(null);
            actionName = CodePath.Last;
        }

        public ListControlEvent(IUIItem uiItem, string selectedItem) : base(uiItem)
        {
            this.selectedItem = selectedItem;
        }

        protected override string ActionName(EventOption eventOption)
        {
            return actionName;
        }

        public override object[] ActionParameters
        {
            get { return new object[] {selectedItem}; }
        }
    }
}