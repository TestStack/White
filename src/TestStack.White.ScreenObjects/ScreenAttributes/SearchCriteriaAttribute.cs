using System;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.ScreenObjects.ScreenAttributes
{
    public abstract class SearchCriteriaAttribute : Attribute
    {
        public abstract void Apply(SearchCriteria searchCriteria);
    }
}