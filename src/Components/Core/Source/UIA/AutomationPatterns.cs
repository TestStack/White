using System.Collections;
using System.Windows.Automation;
using Bricks.RuntimeFramework;

namespace White.Core.UIA
{
    public class AutomationPatterns : BricksCollection<AutomationPattern>
    {
        public AutomationPatterns(params AutomationPattern[] collection) : base(collection) {}
        public AutomationPatterns(IEnumerable entities) : base(entities) {}

        public AutomationPatterns(AutomationElement automationElement)
        {
            AddRange(automationElement.GetSupportedPatterns());
        }

        public virtual bool HasPattern(AutomationPattern automationPattern)
        {
            return Contains(delegate(AutomationPattern pattern) { return pattern.Id.Equals(automationPattern.Id); });
        }
    }
}