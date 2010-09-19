using Bricks;
using White.Core.UIItems;

namespace White.Core.UIItemEvents
{
    public class CheckBoxEvent : UserEvent
    {
        private readonly bool checkState;
        private static readonly string actionName = CodePath.Get(CodePath.New<CheckBox>().Checked);

        public CheckBoxEvent(CheckBox checkBox) : base(checkBox)
        {
            checkState = checkBox.Checked;
        }

        protected override string ActionName(EventOption eventOption)
        {
            return actionName;
        }

        public override object[] ActionParameters
        {
            get { return new object[] {checkState}; }
        }
    }
}