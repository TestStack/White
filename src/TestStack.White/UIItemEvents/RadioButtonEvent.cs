using White.Core.UIItems;
using White.Core.Utility;

namespace White.Core.UIItemEvents
{
    public class RadioButtonEvent : UserEvent
    {
        public RadioButtonEvent(IUIItem uiItem) : base(uiItem) {}

        protected override string ActionName(EventOption eventOption)
        {
            return MethodNameResolver.NameFor<RadioButton>(r=>r.Select());
        }
    }
}