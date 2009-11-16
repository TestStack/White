using System;
using White.Core.UIItems.Finders;

namespace Repository.ScreenAttributes
{
    public abstract class SearchCriteriaAttribute : Attribute
    {
        public abstract void Apply(SearchCriteria searchCriteria);
    }
}