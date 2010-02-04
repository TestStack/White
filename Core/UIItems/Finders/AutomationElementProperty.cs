using System.Windows.Automation;

namespace White.Core.UIItems.Finders
{
    public class AutomationElementProperty
    {
        protected readonly object value;
        private readonly string displayName;
        private readonly AutomationProperty propertyType;

        public AutomationElementProperty(object value, string displayName, AutomationProperty propertyType)
        {
            this.value = value;
            this.displayName = displayName;
            this.propertyType = propertyType;
        }

        public virtual object Value
        {
            get { return value; }
        }

        public virtual string DisplayValue
        {
            get { return value.ToString(); }
        }

        public virtual string DisplayName
        {
            get { return displayName; }
        }

        public virtual Condition PropertyCondition
        {
            get { return new PropertyCondition(propertyType, value); }
        }

        private bool Equals(AutomationElementProperty other)
        {
            return Equals(other.value, value) && Equals(other.propertyType, propertyType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((AutomationElementProperty) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((value != null ? value.GetHashCode() : 0)*397) ^ (propertyType != null ? propertyType.GetHashCode() : 0);
            }
        }
    }
}