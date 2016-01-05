using TestStack.White.UIItems;
using TestStack.White.Utility;

namespace TestStack.White.UIItemEvents
{
    public class CheckBoxEvent : UserEvent
    {
        private readonly bool checkState;
        private static readonly string CachedActionName = PropertyResolver.NameFor((CheckBox c) => c.Checked);

        public CheckBoxEvent(CheckBox checkBox) : base(checkBox)
        {
            checkState = checkBox.Checked;
        }

        protected override string ActionName(IEventOption eventOption)
        {
            return CachedActionName;
        }

        public override object[] ActionParameters
        {
            get { return new object[] {checkState}; }
        }
    }
}