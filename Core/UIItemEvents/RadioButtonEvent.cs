using Bricks;
using White.Core.UIItems;

namespace White.Core.UIItemEvents
{
    public class RadioButtonEvent : UserEvent
    {
        public RadioButtonEvent(IUIItem uiItem) : base(uiItem) {}

        protected override string ActionName(EventOption eventOption)
        {
            CodePath.New<RadioButton>().Select();
            return CodePath.Last;
        }
    }
}