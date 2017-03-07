using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace TestStack.White.AutomationElementSearch
{
    public class AutomationSearchCondition
    {
        static readonly Dictionary<string, Func<AutomationElement.AutomationElementInformation, object, bool>> ValueMatchers =
            new Dictionary<string, Func<AutomationElement.AutomationElementInformation, object, bool>>();
        readonly List<Condition> conditions = new List<Condition>();

        static AutomationSearchCondition()
        {
            ValueMatchers[AutomationElement.NameProperty.ProgrammaticName] = (information, value) => information.Name.Equals(value);
            ValueMatchers[AutomationElement.AutomationIdProperty.ProgrammaticName] = (information, value) => information.AutomationId.Equals(value);
            ValueMatchers[AutomationElement.ClassNameProperty.ProgrammaticName] = (information, value) => information.ClassName.Equals(value);
            ValueMatchers[AutomationElement.ProcessIdProperty.ProgrammaticName] =
                (information, value) => information.ProcessId.ToString().Equals(value.ToString());
            ValueMatchers[AutomationElement.ControlTypeProperty.ProgrammaticName] = (information, value) => information.ControlType.Id.Equals(value);
        }

        public AutomationSearchCondition(Condition condition)
        {
            conditions.Add(condition);
        }

        public AutomationSearchCondition()
        {
        }

        public static AutomationSearchCondition ByName(string name)
        {
            var automationSearchCondition = new AutomationSearchCondition();
            automationSearchCondition.WithName(name);
            return automationSearchCondition;
        }

        public virtual AutomationSearchCondition WithName(string name)
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
                if (conditions.Count == 0) return Condition.TrueCondition;
                return new AndCondition(conditions.ToArray());
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (PropertyCondition condition in conditions)
                stringBuilder.AppendFormat("{0}:{1}", condition.Property.ProgrammaticName, condition.Value);
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
            return Satisfies(element, conditions.ToArray(), true);
        }

        private bool Satisfies(AutomationElement element, Condition[] testConditions, bool and)
        {
            foreach (Condition condition in testConditions)
            {
                if (condition is AndCondition && !Satisfies(element, ((AndCondition) condition).GetConditions(), true)) return false;
                if (condition is OrCondition)
                {
                    bool result = Satisfies(element, ((OrCondition)condition).GetConditions(), false);
                    if (!result && and) return false;
                    if (result && !and) return true;
                }
                if (condition is PropertyCondition)
                {
                    var match = ValueMatchers[((PropertyCondition) condition).Property.ProgrammaticName](element.Current, ((PropertyCondition) condition).Value);
                    if (!match && and) return false;
                    if (match && !and) return true;
                }
            }
            return and;
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