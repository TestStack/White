using System;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.Repository.ScreenAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class TextAttribute : SearchCriteriaAttribute
    {
        private readonly string name;

        public TextAttribute(string name)
        {
            this.name = name;
        }

        public override void Apply(SearchCriteria searchCriteria)
        {
            searchCriteria.AndByText(name);
        }
    }
}