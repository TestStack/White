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
            return new SimpleSearchCondition(information => information.ControlType, new ControlTypeProperty(controlType, "ControlType"));
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
            return new SimpleSearchCondition(information => information.FrameworkId,
                                                    new AutomationElementProperty(frameworkId, "FrameworkId", AutomationElement.FrameworkIdProperty));
        }

        public static SearchCondition CreateForAutomationId(string id)
        {
            return new SimpleSearchCondition(information => information.AutomationId,
                                                    new AutomationElementProperty(id, "AutomationId", AutomationElement.AutomationIdProperty));
        }

        public static SearchCondition CreateForName(string name)
        {
            return new SimpleSearchCondition(information => information.Name,
                                                    new AutomationElementProperty(name, "Name", AutomationElement.NameProperty));
        }

        public static SearchCondition CreateForClassName(string className)
        {
            return new SimpleSearchCondition(information => information.ClassName,
                                                    new AutomationElementProperty(className, "ClassName", AutomationElement.ClassNameProperty));
        }
    }
}