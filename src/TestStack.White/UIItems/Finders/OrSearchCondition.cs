using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Automation;

namespace White.Core.UIItems.Finders
{
    [DataContract]
    public class OrSearchCondition : SearchCondition
    {
        [DataMember]
        private readonly SimpleSearchCondition[] simpleSearchConditions;

        private OrSearchCondition(){}

        public OrSearchCondition(SimpleSearchCondition[] simpleSearchConditions)
        {
            this.simpleSearchConditions = simpleSearchConditions;
        }

        public override bool Satisfies(AutomationElement element)
        {
            return simpleSearchConditions.Any(c => c.Satisfies(element));
        }

        public override Condition AutomationCondition
        {
            get { return new OrCondition(simpleSearchConditions.Select(c => c.AutomationCondition).ToArray()); }
        }

        public override string ToString()
        {
            return string.Format("({0})", string.Join(" or ", simpleSearchConditions.Select(c => c.ToString())));
        }

        internal override string ToString(string operation)
        {
            return ToString();
        }

        protected internal override object SearchValue
        {
            get { return null; }
        }

        public override bool AppliesTo(AutomationElement element)
        {
            return simpleSearchConditions.Any(c => c.AppliesTo(element));
        }
    }
}