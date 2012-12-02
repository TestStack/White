using System;
using White.Core.UIItems.Finders;
using Repository.ScreenAttributes;

namespace Repository.ScreenAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class IndexAttribute : SearchCriteriaAttribute
    {
        private readonly int index;

        public IndexAttribute(int index)
        {
            this.index = index;
        }

        public override void Apply(SearchCriteria searchCriteria)
        {
            searchCriteria.AndIndex(index);
        }
    }
}