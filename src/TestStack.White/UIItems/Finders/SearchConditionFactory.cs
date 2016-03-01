using System;
using System.Linq;
using System.Windows.Automation;
using System.Xml;
using System.Xml.XPath;
using TestStack.White.Mappings;
using TestStack.White.UIItems.Custom;
using TestStack.White.UIItems.WindowItems;

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
                return CreateForControlType(CustomControlTypeMapping.ControlType(testControlType, framework));
            var controlTypes = ControlDictionary.Instance.GetControlType(testControlType, framework.FrameworkId());
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

        /// <summary>
        /// Getting the objects (AutomationElement) hierarchy of the given window
        /// Create SimpleSearchCondition with AutomationId for given xpath
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="window"></param>
        /// <returns></returns>
        public static SearchCondition CreateForXPath(string xpath, Window window)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string hierarchy = window.GetHierarchy(window.AutomationElement);

            xmlDoc.LoadXml(hierarchy);
            XmlNodeList nodeList = xmlDoc.SelectNodes(xpath);
            if (nodeList.Count == 0)
            {
                throw new Exception("No element found for given XPath: " + xpath);
            }
            else if (nodeList.Count > 1)
            {
                throw new Exception("Multiple elements found for given XPath: " + xpath);
            }
            else
            {
                foreach (XmlNode node in nodeList)
                {
                    var automationId = node.Attributes["AutomationId"].Value;
                    var className = node.Attributes["ClassName"].Value;
                    //var controlType = node.Attributes["ControlType"].Value;
                    var frameworkId = node.Attributes["FrameworkId"].Value;
                    var name = node.Attributes["Name"].Value;

                    return new SimpleSearchCondition(automationElement => automationElement.Current.AutomationId,
                                             new AutomationElementProperty(automationId, "AutomationId", AutomationElement.AutomationIdProperty));
                }
            }

            throw new Exception("Invalid Xpath");
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

        public static SearchCondition CreateForNativeProperty(AutomationProperty automationProperty, object value)
        {
            var automationElementProperty = new AutomationElementProperty(value, automationProperty.ProgrammaticName, automationProperty);
            return new SimpleSearchCondition(automationElement => automationElement.GetCurrentPropertyValue(automationProperty), automationElementProperty);
        }
    }
}