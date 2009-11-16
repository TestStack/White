using System.Windows.Automation;
using White.Core.Mappings;

namespace White.Core.UIA
{
    public static class AutomationElementX
    {
        public static string Display(this AutomationElement automationElement)
        {
            AutomationElement.AutomationElementInformation elementInformation = automationElement.Current;
            return string.Format("AutomationId:{0}, Name:{1}, ControlType:{2}, FrameworkId:{3}", elementInformation.AutomationId, elementInformation.Name,
                                 elementInformation.ControlType.LocalizedControlType, elementInformation.FrameworkId);
        }

        public static bool IsPrimaryControl(this AutomationElement automationElement)
        {
            AutomationElement.AutomationElementInformation elementInformation = automationElement.Current;
            return ControlDictionary.Instance.IsPrimaryControl(elementInformation.ControlType, elementInformation.ClassName, elementInformation.Name);
        }
    }
}