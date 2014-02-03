using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Automation;
using Castle.Core.Logging;
using TestStack.White.Configuration;
using TestStack.White.Mappings;

namespace TestStack.White.UIA
{
    public static class AutomationElementX
    {
        private static readonly ILogger Logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof (AutomationElementX));
        private static readonly Dictionary<Type, AutomationPattern> AutomationPatterns = new Dictionary<Type, AutomationPattern>();

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

        public static T GetPattern<T>(this AutomationElement automationElement)
            where T : class
        {
            T result;
            try
            {
                object patternObj;
                var gotIt = automationElement.TryGetCurrentPattern(GetAutomationPattern<T>(), out patternObj);
                result = gotIt ? (T) patternObj : null;
            }
            catch (COMException)
            {
                return null;
            }
            catch (ElementNotAvailableException)
            {
                return null;
            }
            return result;
        }

        private static AutomationPattern GetAutomationPattern<T>()
        {
            AutomationPattern automationPattern;
            var patternType = typeof (T);
            if (!AutomationPatterns.TryGetValue(patternType, out automationPattern))
            {
                var f = patternType.GetField("Pattern", BindingFlags.Static | BindingFlags.Public);
                automationPattern = (AutomationPattern) f.GetValue(null);
                AutomationPatterns[patternType] = automationPattern;
            }
            return automationPattern;
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