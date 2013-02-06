using System.Runtime.Serialization;
using System.Windows.Automation;

namespace White.Core.UIItems.Finders
{
    [DataContract]
    [KnownType(typeof(ControlTypeProperty))]
    public class AutomationElementProperty
    {
        [DataMember]
        private readonly string displayName;
        [DataMember]
        private readonly AutomationProperty propertyType;

        //required for xstream
        protected AutomationElementProperty()
        {
        }

        public AutomationElementProperty(object value, string displayName, AutomationProperty propertyType)
        {
            Value = value;
            this.displayName = displayName;
            this.propertyType = propertyType;
        }

        [DataMember]
        public virtual object Value { get; private set; }

        public virtual string DisplayValue
        {
            get { return Value.ToString(); }
        }

        public virtual string DisplayName
        {
            get { return displayName; }
        }

        public virtual Condition PropertyCondition
        {
            get { return new PropertyCondition(propertyType, Value); }
        }

        private bool Equals(AutomationElementProperty other)
        {
            return Equals(other.Value, Value) && Equals(other.propertyType.Id, propertyType.Id) &&
                   Equals(other.propertyType.ProgrammaticName, other.propertyType.ProgrammaticName);
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
                return ((Value != null ? Value.GetHashCode() : 0)*397) ^ (propertyType != null ? propertyType.GetHashCode() : 0);
            }
        }
    }
}