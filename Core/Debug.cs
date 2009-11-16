using System;
using System.Text;
using System.Windows.Automation;
using White.Core.Logging;
using White.Core.UIItems;

namespace White.Core
{
    public class Debug
    {
        private const string Tab = "  ";

        public static void ProcessDetails(string processName)
        {
            try
            {
                AutomationElement element =
                    AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, processName));
                Details(element);
            }
            catch (Exception)
            {
                WhiteLogger.Instance.Warn("Error happened while creating error report");
            }
        }

        public static string Details(AutomationElement automationElement)
        {
            try
            {
                var stringBuilder = new StringBuilder();
                Details(stringBuilder, automationElement, string.Empty);
                return stringBuilder.ToString();
            }
            catch (Exception)
            {
                WhiteLogger.Instance.Warn("Error happened while creating error report");
                return string.Empty;
            }
        }

        private static void Details(StringBuilder stringBuilder, AutomationElement automationElement, string displayPadding)
        {
            WriteDetail(automationElement, stringBuilder, displayPadding);
            DisplayPattern(automationElement, stringBuilder, displayPadding);
            AutomationElementCollection children = automationElement.FindAll(TreeScope.Children, Condition.TrueCondition);
            foreach (AutomationElement child in children)
                Details(stringBuilder, child, displayPadding + Tab + Tab);
        }

        private static void WriteDetail(AutomationElement automationElement, StringBuilder stringBuilder, string displayPadding)
        {
            WriteDetail(stringBuilder, "AutomationId: " + automationElement.Current.AutomationId, displayPadding);
            WriteDetail(stringBuilder, "ControlType: " + automationElement.Current.ControlType.ProgrammaticName, displayPadding);
            WriteDetail(stringBuilder, "Name: " + automationElement.Current.Name, displayPadding);
            WriteDetail(stringBuilder, "HelpText: " + automationElement.Current.HelpText, displayPadding);
            WriteDetail(stringBuilder, "Bounding rectangle: " + automationElement.Current.BoundingRectangle, displayPadding);
            WriteDetail(stringBuilder, "ClassName: " + automationElement.Current.ClassName, displayPadding);
            WriteDetail(stringBuilder, "IsOffScreen: " + automationElement.Current.IsOffscreen, displayPadding);
            WriteDetail(stringBuilder, "FrameworkId: " + automationElement.Current.FrameworkId, displayPadding);
            WriteDetail(stringBuilder, "ProcessId: " + automationElement.Current.ProcessId, displayPadding);
            stringBuilder.AppendLine();
        }

        private static void WriteDetail(StringBuilder stringBuilder, string message, string padding)
        {
            stringBuilder.AppendLine(padding + message);
        }

        public static string GetAllWindows()
        {
            try
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine();
                GetAllWindows(stringBuilder, 0, AutomationElement.RootElement);
                return stringBuilder.ToString();
            }
            catch (Exception)
            {
                WhiteLogger.Instance.Warn("Error happened while creating error report");
            }
            return string.Empty;
        }

        private static void GetAllWindows(StringBuilder stringBuilder, int level, AutomationElement baseElement)
        {
            string padding = level == 0 ? string.Empty : Tab;
            var windowCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window);
            AutomationElementCollection allWindows = baseElement.FindAll(TreeScope.Children, windowCondition);
            foreach (AutomationElement windowElement in allWindows)
            {
                var pattern = (WindowPattern) UIItem.Pattern(windowElement, WindowPattern.Pattern);
                string modalText = pattern == null ? "(null)" : pattern.Current.IsModal.ToString();
                stringBuilder.AppendFormat("{0}Name: {1},  Bounds: {2} ProcessId: {3}, Modal: {4}", padding, windowElement.Current.Name,
                                           windowElement.Current.BoundingRectangle, windowElement.Current.ProcessId, modalText);
                stringBuilder.AppendLine();

                if (level == 0) GetAllWindows(stringBuilder, 1, windowElement);
            }
        }

        private static void DisplayPattern(AutomationElement automationElement, StringBuilder stringBuilder, string displayPadding)
        {
            AutomationPattern[] supportedPatterns = automationElement.GetSupportedPatterns();
            foreach (AutomationPattern automationPattern in supportedPatterns)
            {
                var pattern = (BasePattern) automationElement.GetCurrentPattern(automationPattern);
                stringBuilder.Append(displayPadding).AppendLine(pattern.ToString());
            }
            stringBuilder.AppendLine();
        }

        public static void LogProperties(UIItem uiItem)
        {
            LogProperties(uiItem.AutomationElement);
        }

        public static void LogProperties(AutomationElement element)
        {
            AutomationProperty[] automationProperties = element.GetSupportedProperties();
            foreach (AutomationProperty automationProperty in automationProperties)
            {
                WhiteLogger.Instance.Info(automationProperty.ProgrammaticName + ":" + element.GetCurrentPropertyValue(automationProperty));
            }
        }

        public static void LogPatterns(UIItem uiItem)
        {
            LogPatterns(uiItem.AutomationElement);
        }

        public static void LogPatterns(AutomationElement automationElement)
        {
            var builder = new StringBuilder();
            DisplayPattern(automationElement, builder, string.Empty);
            WhiteLogger.Instance.Info(builder.ToString());
        }
    }
}