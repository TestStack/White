using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace White.Core.UIItems.Finders
{
    public class SearchConditions : List<SearchCondition>
    {
        public virtual Condition AutomationCondition
        {
            get
            {
                if (Count == 0) return Condition.TrueCondition;

                var automationConditions = new List<Condition>();
                ForEach(delegate(SearchCondition condition)
                            {
                                Condition automationCondition = condition.AutomationCondition;
                                if (automationCondition != null) automationConditions.Add(automationCondition);
                            });
                return automationConditions.Count == 1 ? automationConditions[0] : new AndCondition(automationConditions.ToArray());
            }
        }

        public virtual List<AutomationElement> Filter(List<AutomationElement> elements)
        {
            var list = new List<AutomationElement>(elements);
            ForEach(delegate(SearchCondition condition) { list = condition.Filter(list); });
            return list;
        }

        public override string ToString()
        {
            return string.Join(",", this.Select(i=>i.ToString()).ToArray());
        }
    }
}