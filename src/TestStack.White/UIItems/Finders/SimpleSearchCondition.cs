using System.Windows.Automation;

namespace White.Core.UIItems.Finders
{
    public class SimpleSearchCondition : SearchCondition
    {
        private readonly PropertyValue propertyValueDelegate;
        private readonly AutomationElementProperty automationElementProperty;

        public delegate object PropertyValue(AutomationElement automationElement);

        //required for xstream
        private SimpleSearchCondition() {}

        public SimpleSearchCondition(PropertyValue propertyValueDelegate,
                                     AutomationElementProperty automationElementProperty)
        {
            this.propertyValueDelegate = propertyValueDelegate;
            this.automationElementProperty = automationElementProperty;
        }

        public override bool Satisfies(AutomationElement element)
        {
            return ElementValue(element).Equals(automationElementProperty.Value);
        }

        private object ElementValue(AutomationElement element)
        {
            return propertyValueDelegate(element);
        }

        public override Condition AutomationCondition
        {
            get { return automationElementProperty.PropertyCondition; }
        }

        internal override string ToString(string operation)
        {
            return string.Format("{0}{1}{2}", automationElementProperty.DisplayName, operation,
                                 automationElementProperty.DisplayValue);
        }

        protected internal override object SearchValue
        {
            get { return automationElementProperty.Value; }
        }

        public override bool AppliesTo(AutomationElement element)
        {
            return automationElementProperty.Value.Equals(ElementValue(element));
        }

        public override bool OfSameType(SearchCondition otherCondition)
        {
            return base.OfSameType(otherCondition) &&
                   automationElementProperty.Equals(((SimpleSearchCondition) otherCondition).automationElementProperty);
        }

        public override string ToString()
        {
            return ToString("=");
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (SimpleSearchCondition)) return false;
            return Equals((SimpleSearchCondition) obj);
        }

        private bool Equals(SimpleSearchCondition other)
        {
            return Equals(other.automationElementProperty, automationElementProperty);
        }

        public override int GetHashCode()
        {
            return (automationElementProperty != null ? automationElementProperty.GetHashCode() : 0);
        }
    }
}