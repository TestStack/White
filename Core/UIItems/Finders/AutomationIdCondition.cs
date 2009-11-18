using System.Windows.Automation;

namespace White.Core.UIItems.Finders
{
    public class AutomationIdCondition : SearchCondition
    {
        private readonly string identification;

        protected AutomationIdCondition() {}

        public AutomationIdCondition(string identification)
        {
            this.identification = identification;
        }

        public override bool Satisfies(AutomationElement element)
        {
            return element.Current.AutomationId.Equals(identification);
        }

        public override Condition AutomationCondition
        {
            get { return new PropertyCondition(AutomationElement.AutomationIdProperty, identification); }
        }

        public virtual string AutomationId
        {
            get { return identification; }
        }

        protected internal override object SearchValue
        {
            get { return identification; }
        }

        public override bool AppliesTo(AutomationElement element)
        {
            return identification.Equals(element.Current.AutomationId);
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