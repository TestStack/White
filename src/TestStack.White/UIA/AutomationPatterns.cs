using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace White.Core.UIA
{
    public class AutomationPatterns : List<AutomationPattern>
    {
        public AutomationPatterns(params AutomationPattern[] collection) : base(collection) {}

        public AutomationPatterns(AutomationElement automationElement)
        {
            AddRange(automationElement.GetSupportedPatterns());
        }

        public virtual bool HasPattern(AutomationPattern automationPattern)
        {
            return this.Any(pattern => pattern.Id.Equals(automationPattern.Id));
        }
    }
}