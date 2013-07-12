using System.Runtime.Serialization;
using System.Windows.Automation;

namespace TestStack.White.UIItems.Finders
{
    [DataContract]
    public class NotCondition : SearchCondition
    {
        [DataMember]
        private readonly SearchCondition condition;

        //required for xstream
        protected NotCondition() {}

        public NotCondition(SearchCondition condition)
        {
            this.condition = condition;
        }

        public override Condition AutomationCondition
        {
            get { return new System.Windows.Automation.NotCondition(condition.AutomationCondition); }
        }

        public override bool Satisfies(AutomationElement element)
        {
            return !condition.Satisfies(element);
        }

        public override string ToString()
        {
            return condition.ToString("!=");
        }

        internal override string ToString(string operation)
        {
            return condition.ToString(operation);
        }

        protected internal override object SearchValue
        {
            get { return condition == null ? null : condition.SearchValue; }
        }

        public override bool AppliesTo(AutomationElement element)
        {
            return !condition.AppliesTo(element);
        }

        public override bool OfSameType(SearchCondition otherCondition)
        {
            return base.OfSameType(otherCondition) && condition.OfSameType(((NotCondition) otherCondition).condition);
        }

        private bool Equals(NotCondition other)
        {
            return Equals(other.condition, condition);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (NotCondition)) return false;
            return Equals((NotCondition) obj);
        }

        public override int GetHashCode()
        {
            return (condition != null ? condition.GetHashCode() : 0);
        }
    }
}