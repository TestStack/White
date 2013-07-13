using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.Repository.ScreenAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FrameworkIdAttribute : SearchCriteriaAttribute
    {
        private readonly WindowsFramework framework;

        public FrameworkIdAttribute(string id)
        {
            framework = WindowsFrameworkExtensions.FromFrameworkId(id);
        }

        public FrameworkIdAttribute(WindowsFramework framework)
        {
            this.framework = framework;
        }

        public override void Apply(SearchCriteria searchCriteria)
        {
            searchCriteria.AndOfFramework(framework);
        }
    }
}