using System.Windows.Automation;

namespace White.Core.UIItems.Finders
{
    public class FrameworkIdCondition : SearchCondition
    {
        private readonly string identification;

        protected FrameworkIdCondition() {}

        public FrameworkIdCondition(string identification)
        {
            this.identification = identification;
        }

        public override bool Satisfies(AutomationElement element)
        {
            return element.Current.FrameworkId.Equals(identification);
        }

        public override Condition AutomationCondition
        {
            get { return new PropertyCondition(AutomationElement.FrameworkIdProperty, identification); }
        }

        protected internal override object SearchValue
        {
            get { return identification; }
        }

        public override bool AppliesTo(AutomationElement element)
        {
            return identification.Equals(element.Current.FrameworkId);
        }

        internal override string ToString(string operation)
        {
            return "AutomationId" + operation + identification;
        }

        public override string ToString()
        {
            return ToString("=");
        }
    }
}