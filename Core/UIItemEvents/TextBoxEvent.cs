using Bricks;
using White.Core.UIItems;

namespace White.Core.UIItemEvents
{
    public class TextBoxEvent : UserEvent
    {
        private static readonly string textAction;
        private static readonly string bulkTextAction;

        static TextBoxEvent()
        {
            textAction = CodePath.Get(CodePath.New<TextBox>().Text);
            CodePath.New<TextBox>().BulkText = null;
            bulkTextAction = CodePath.Last;
        }

        public TextBoxEvent(IUIItem textBox) : base(textBox) {}

        protected override string ActionName(EventOption eventOption)
        {
            return eventOption.BulkText ? bulkTextAction : textAction;
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