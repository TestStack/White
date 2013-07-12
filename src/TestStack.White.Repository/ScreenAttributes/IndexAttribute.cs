using System;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.Repository.ScreenAttributes
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