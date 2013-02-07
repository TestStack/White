using System;
using System.Windows;
using System.Windows.Automation;
using Castle.Core.Logging;
using White.Core.Configuration;
using White.Core.Mappings;

namespace White.Core.UIA
{
    public static class AutomationElementX
    {
        private static readonly ILogger Logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(AutomationElementX));

        public static string Display(this AutomationElement automationElement)
        {
            try
            {
                if (automationElement == null) return "(NULL)";
                AutomationElement.AutomationElementInformation elementInformation = automationElement.Current;
                return String.Format("AutomationId:{0}, Name:{1}, ControlType:{2}, FrameworkId:{3}", elementInformation.AutomationId, elementInformation.Name,
                                     elementInformation.ControlType.LocalizedControlType, elementInformation.FrameworkId);
            }
            catch
            {
                return "Cannot display automation element details. The UIItem might have been disposed";
            }
        }

        public static bool IsPrimaryControl(this AutomationElement automationElement)
        {
            AutomationElement.AutomationElementInformation elementInformation = automationElement.Current;
            return ControlDictionary.Instance.IsPrimaryControl(elementInformation.ControlType, elementInformation.ClassName, elementInformation.Name);
        }

        public static AutomationElement GetAutomationElementFromPoint(Point location)
        {
            try
            {
                var automationElement = AutomationElement.FromPoint(location);
                Logger.DebugFormat("[PositionBasedSearch] Found AutomationElement ({0}) at location ({1})", automationElement.Display(), location);
                return automationElement;
            }
            catch
            {
                return null;
            }
        }
    }
}