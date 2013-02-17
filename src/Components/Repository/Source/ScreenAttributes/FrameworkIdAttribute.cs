using System;
using White.Core.UIItems.Finders;

namespace White.Repository.ScreenAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FrameworkIdAttribute : SearchCriteriaAttribute
    {
        private readonly string id;

        public FrameworkIdAttribute(string id)
        {
            this.id = id;
        }

        public override void Apply(SearchCriteria searchCriteria)
        {
            searchCriteria.AndOfFramework(id);
        }
    }
}