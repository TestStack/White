using System;
using System.Linq;
using System.Windows.Automation;
using TestStack.White.Mappings;
using TestStack.White.UIItems.Custom;

namespace TestStack.White.UIItems.Finders
{
    public static class SearchConditionFactory
    {
        public static SimpleSearchCondition CreateForControlType(ControlType controlType)
        {
            return new SimpleSearchCondition(automationElement => automationElement.Current.ControlType, new ControlTypeProperty(controlType, "ControlType"));
        }

        public static SearchCondition CreateForControlType(Type testControlType, WindowsFramework framework)
        {
            if (testControlType.IsCustomType())
                return CreateForControlType(CustomControlTypeMapping.ControlType(testControlType));
            var controlTypes = ControlDictionary.Instance.GetControlType(testControlType, framework);
            if (controlTypes.Length == 1)
                return CreateForControlType(controlTypes[0]);

            return new OrSearchCondition(controlTypes.Select(CreateForControlType).ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameworkId">List available from WindowsFramework class or Constants class</param>
        /// <returns></returns>
        public static SearchCondition CreateForFrameworkId(string frameworkId)
        {
            return new SimpleSearchCondition(automationElement => automationElement.Current.FrameworkId,
                                             new AutomationElementProperty(frameworkId, "FrameworkId", AutomationElement.FrameworkIdProperty));
        }

        public static SearchCondition CreateForAutomationId(string id)
        {
            return new SimpleSearchCondition(automationElement => automationElement.Current.AutomationId,
                                             new AutomationElementProperty(id, "AutomationId", AutomationElement.AutomationIdProperty));
        }

        public static SearchCondition CreateForName(string name)
        {
            return new SimpleSearchCondition(automationElement => automationElement.Current.Name, new AutomationElementProperty(name, "Name", AutomationElement.NameProperty));
        }

        public static SearchCondition CreateForClassName(string className)
        {
            return new SimpleSearchCondition(automationElement => automationElement.Current.ClassName,
                                             new AutomationElementProperty(className, "ClassName", AutomationElement.ClassNameProperty));
        }

        public static SearchCondition CreateForNativeProperty(AutomationProperty automationProperty, string value)
        {
            var automationElementProperty = new AutomationElementProperty(value, automationProperty.ProgrammaticName, automationProperty);
            return new SimpleSearchCondition(automationElement => automationElement.GetCurrentPropertyValue(automationProperty), automationElementProperty);
        }

        public static SearchCondition CreateForNativeProperty(AutomationProperty automationProperty, bool value)
        {
            var automationElementProperty = new AutomationElementProperty(value, automationProperty.ProgrammaticName, automationProperty);
            return new SimpleSearchCondition(automationElement => automationElement.GetCurrentPropertyValue(automationProperty), automationElementProperty);
        }
    }
}