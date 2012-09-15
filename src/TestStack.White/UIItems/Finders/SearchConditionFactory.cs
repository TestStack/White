using System;
using System.Windows.Automation;
using White.Core.Mappings;
using White.Core.UIItems.Custom;

namespace White.Core.UIItems.Finders
{
    public static class SearchConditionFactory
    {
        public static SimpleSearchCondition CreateForControlType(ControlType controlType)
        {
            return new SimpleSearchCondition(automationElement => automationElement.Current.ControlType, new ControlTypeProperty(controlType, "ControlType"));
        }

        public static SimpleSearchCondition CreateForControlType(Type testControlType)
        {
            ControlType controlType = testControlType.IsCustomType()
                                          ? CustomControlTypeMapping.ControlType(testControlType)
                                          : ControlDictionary.Instance.GetControlType(testControlType);
            return CreateForControlType(controlType);
        }

        public static SimpleSearchCondition CreateForControlType(Type testControlType, string frameworkId)
        {
            ControlType controlType = testControlType.IsCustomType()
                                          ? CustomControlTypeMapping.ControlType(testControlType)
                                          : ControlDictionary.Instance.GetControlType(testControlType, frameworkId);
            return CreateForControlType(controlType);
        }

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