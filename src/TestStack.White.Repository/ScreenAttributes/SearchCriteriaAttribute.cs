using System;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.Repository.ScreenAttributes
{
    public abstract class SearchCriteriaAttribute : Attribute
    {
        public abstract void Apply(SearchCriteria searchCriteria);
    }
}