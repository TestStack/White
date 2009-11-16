using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using White.Core.AutomationElementSearch.Properties;

namespace White.Core.AutomationElementSearch
{
    public class AutomationSearchCondition
    {
        private readonly List<Condition> conditions = new List<Condition>();
        private static readonly Dictionary<string, AutomationElementProperty> properties = new Dictionary<string, AutomationElementProperty>();

        static AutomationSearchCondition()
        {
            properties[AutomationElement.NameProperty.ProgrammaticName] = new NameProperty();
            properties[AutomationElement.AutomationIdProperty.ProgrammaticName] = new AutomationIdProperty();
            properties[AutomationElement.ClassNameProperty.ProgrammaticName] = new ClassNameProperty();
            properties[AutomationElement.ProcessIdProperty.ProgrammaticName] = new ProcessIdProperty();
            properties[AutomationElement.ControlTypeProperty.ProgrammaticName] = new ControlTypeProperty();
        }

        public static AutomationSearchCondition ByName(string name)
        {
            var automationSearchCondition = new AutomationSearchCondition();
            automationSearchCondition.OfName(name);
            return automationSearchCondition;
        }

        public virtual AutomationSearchCondition OfName(string name)
        {
            conditions.Add(new PropertyCondition(AutomationElement.NameProperty, name));
            return this;
        }

        public static AutomationSearchCondition ByAutomationId(string id)
        {
            var automationSearchCondition = new AutomationSearchCondition();
            automationSearchCondition.WithAutomationId(id);
            return automationSearchCondition;
        }

        public virtual AutomationSearchCondition WithAutomationId(string id)
        {
            conditions.Add(new PropertyCondition(AutomationElement.AutomationIdProperty, id));
            return this;
        }

        public static AutomationSearchCondition ByControlType(ControlType controlType)
        {
            var automationSearchCondition = new AutomationSearchCondition();
            automationSearchCondition.OfControlType(controlType);
            return automationSearchCondition;
        }

        public static AutomationSearchCondition All
        {
            get
            {
                var automationSearchCondition = new AutomationSearchCondition();
                automationSearchCondition.conditions.Add(Condition.TrueCondition);
                return automationSearchCondition;
            }
        }

        public virtual AutomationSearchCondition OfControlType(ControlType controlType)
        {
            conditions.Add(new PropertyCondition(AutomationElement.ControlTypeProperty, controlType));
            return this;
        }

        public virtual AutomationSearchCondition WithProcessId(int processId)
        {
            conditions.Add(new PropertyCondition(AutomationElement.ProcessIdProperty, processId));
            return this;
        }

        public virtual Condition Condition
        {
            get
            {
                if (conditions.Count == 1) return conditions[0];
                return new AndCondition(conditions.ToArray());
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (PropertyCondition condition in conditions)
                stringBuilder.Append(condition.Property.ProgrammaticName + ":" + condition.Value);
            return stringBuilder.ToString();
        }

        public static AutomationSearchCondition ByClassName(string className)
        {
            var automationSearchCondition = new AutomationSearchCondition();
            automationSearchCondition.conditions.Add(new PropertyCondition(AutomationElement.ClassNameProperty, className));
            return automationSearchCondition;
        }

        public static string ToString(AutomationSearchCondition[] conditions)
        {
            var builder = new StringBuilder();
            foreach (AutomationSearchCondition condition in conditions)
                builder.AppendLine(condition.ToString());
            return builder.ToString();
        }

        public virtual bool Satisfies(AutomationElement element)
        {
            foreach (PropertyCondition condition in conditions)
            {
                if (!properties[condition.Property.ProgrammaticName].HasValue(element.Current, condition.Value))
                    return false;
            }
            return true;
        }

        public virtual void Add(Condition condition)
        {
            conditions.Add(condition);
        }

        public static AutomationSearchCondition GetWindowWithTitleBarSearchCondition(int processId)
        {
            return GetWindowSearchCondition(processId, ControlType.Window);
        }

        public static AutomationSearchCondition GetWindowSearchCondition(int processId, ControlType controlType)
        {
            AutomationSearchCondition windowSearchCondition = ByControlType(controlType);
            if (processId > 0) windowSearchCondition.WithProcessId(processId);
            return windowSearchCondition;
        }
    }
}