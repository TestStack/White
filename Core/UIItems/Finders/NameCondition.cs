using System.Windows.Automation;

namespace White.Core.UIItems.Finders
{
    public class NameCondition : SearchCondition
    {
        private readonly string name;

        protected NameCondition() {}

        public NameCondition(string name)
        {
            this.name = name;
        }

        public override Condition AutomationCondition
        {
            get { return new PropertyCondition(AutomationElement.NameProperty, name); }
        }

        public override bool Satisfies(AutomationElement element)
        {
            return element.Current.Name.Equals(name);
        }

        public override string ToString()
        {
            return ToString("=");
        }

        internal override string ToString(string operation)
        {
            return "Name" + operation + name;
        }

        protected internal override object SearchValue
        {
            get { return name; }
        }

        public override bool AppliesTo(AutomationElement element)
        {
            return name.Equals(element.Current.Name);
        }
    }
}