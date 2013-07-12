using System;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.Repository.ScreenAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class AutomationIdAttribute : SearchCriteriaAttribute
    {
        private readonly string name;

        public AutomationIdAttribute(string name)
        {
            this.name = name;
        }

        public override void Apply(SearchCriteria searchCriteria)
        {
            searchCriteria.AndAutomationId(name);
        }
    }
}