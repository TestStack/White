using System;
using System.Windows;
using System.Windows.Automation;
using White.Core.Logging;
using White.Core.Mappings;

namespace White.Core.UIA
{
    public static class AutomationElementX
    {
        public static string Display(this AutomationElement automationElement)
        {
            AutomationElement.AutomationElementInformation elementInformation = automationElement.Current;
            return String.Format("AutomationId:{0}, Name:{1}, ControlType:{2}, FrameworkId:{3}", elementInformation.AutomationId, elementInformation.Name,
                                 elementInformation.ControlType.LocalizedControlType, elementInformation.FrameworkId);
        }

        public static bool IsPrimaryControl(this AutomationElement automationElement)
        {
            AutomationElement.AutomationElementInformation elementInformation = automationElement.Current;
            return ControlDictionary.Instance.IsPrimaryControl(elementInformation.ControlType, elementInformation.ClassName, elementInformation.Name);
        }

        public static AutomationElement GetAutomationElementFromPoint(Point location)
        {
            AutomationElement automationElement;
            try
            {
                automationElement = AutomationElement.FromPoint(location);
                WhiteLogger.Instance.DebugFormat("Found AutomationElement {0} based on position", automationElement.Display());
                return automationElement;
            }
            catch
            {
                return null;
            }
        }
    }
}