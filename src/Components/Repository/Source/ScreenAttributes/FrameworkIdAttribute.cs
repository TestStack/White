using System;
using White.Core.UIItems;
using White.Core.UIItems.Finders;

namespace White.Repository.ScreenAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FrameworkIdAttribute : SearchCriteriaAttribute
    {
        private readonly WindowsFramework framework;

        public FrameworkIdAttribute(string id)
        {
            framework = new WindowsFramework(id);
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