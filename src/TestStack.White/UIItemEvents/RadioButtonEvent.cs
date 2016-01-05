using TestStack.White.UIItems;
using TestStack.White.Utility;

namespace TestStack.White.UIItemEvents
{
    public class RadioButtonEvent : UserEvent
    {
        public RadioButtonEvent(IUIItem uiItem) : base(uiItem) {}

        protected override string ActionName(IEventOption eventOption)
        {
            return MethodNameResolver.NameFor<RadioButton>(r=>r.Select());
        }
    }
}