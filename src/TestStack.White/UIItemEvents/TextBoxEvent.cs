using TestStack.White.UIItems;
using TestStack.White.Utility;

namespace TestStack.White.UIItemEvents
{
    public class TextBoxEvent : UserEvent
    {
        private static readonly string TextAction;
        private static readonly string BulkTextAction;

        static TextBoxEvent()
        {
            TextAction = PropertyResolver.NameFor((TextBox t) => t.Text);
            BulkTextAction = PropertyResolver.NameFor((TextBox t) => t.BulkText);
        }

        public TextBoxEvent(IUIItem textBox) : base(textBox) {}

        protected override string ActionName(EventOption eventOption)
        {
            return eventOption.BulkText ? BulkTextAction : TextAction;
        }

        public override object[] ActionParameters
        {
            get { return new object[] {((TextBox) uiItem).Text.TrimEnd()}; }
        }

        public override bool IsRepeatEvent(UserEvent otherEvent)
        {
            return otherEvent is TextBoxEvent && otherEvent.IsIdenfiedAs(uiItem.PrimaryIdentification);
        }
    }
}