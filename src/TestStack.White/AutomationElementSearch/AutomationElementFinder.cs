using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.AutomationElementSearch
{
    /// <summary>
    /// Internal to white and should not be used unless a known issue. One should be able to find all items 
    /// </summary>
    public class AutomationElementFinder
    {
        private readonly AutomationElement automationElement;

        public AutomationElementFinder(AutomationElement automationElement)
        {
            if (automationElement == null) throw new ArgumentNullException("automationElement");
            this.automationElement = automationElement;
        }

        public virtual AutomationElement AutomationElement
        {
            get { return automationElement; }
        }

        public virtual List<AutomationElement> Children(params AutomationSearchCondition[] automationSearchConditions)
        {
            return new MultiLevelAutomationElementFinder(automationSearchConditions).FindAll(automationElement);
        }

        public virtual AutomationElement Child(params AutomationSearchCondition[] automationSearchConditions)
        {
            return new MultiLevelAutomationElementFinder(automationSearchConditions).Find(automationElement);
        }

        protected virtual AutomationElement Child(int returnLevel, AutomationSearchCondition[] automationSearchConditions)
        {
            return new MultiLevelAutomationElementFinder(automationSearchConditions).Find(returnLevel, automationElement);
        }

        public virtual List<AutomationElement> Children(AutomationSearchCondition automationSearchCondition)
        {
            return automationElement.FindAll(TreeScope.Children, automationSearchCondition.Condition).Cast<AutomationElement>().ToList();
        }

        public virtual AutomationElement Child(AutomationSearchCondition automationSearchCondition)
        {
            return automationElement.FindFirst(TreeScope.Children, automationSearchCondition.Condition);
        }

        public virtual AutomationElement Descendant(AutomationSearchCondition searchCondition)
        {
            return Descendant(searchCondition.Condition);
        }

        public virtual AutomationElement Descendant(Condition condition)
        {
            return DescendantFinderFactory.Create(automationElement).Descendant(condition);
        }

        public virtual List<AutomationElement> Descendants(AutomationSearchCondition automationSearchCondition)
        {
            return DescendantFinderFactory.Create(automationElement).Descendants(automationSearchCondition);
        }

        public virtual AutomationElement FindWindow(string title, int processId)
        {
            var windowSearchConditions = new AutomationSearchConditionFactory().GetWindowSearchConditions(processId);
            foreach (var searchCondition in windowSearchConditions)
            {
                AutomationElement windowElement = Child(searchCondition.WithName(title));
                if (windowElement != null) return windowElement;
            }

            return Child(0,
                         new[]
                             {
                                 AutomationSearchCondition.GetWindowWithTitleBarSearchCondition(processId),
                                 AutomationSearchCondition.ByControlType(ControlType.TitleBar).WithName(title)
                             });
        }

        public virtual AutomationElement FindWindow(SearchCriteria searchCriteria, int processId)
        {
            var condition = searchCriteria.AutomationConditionWith(new PropertyCondition(AutomationElement.ProcessIdProperty, processId));
            return automationElement.FindFirst(TreeScope.Children, condition);
        }

        public virtual AutomationElement FindWindow(SearchCriteria searchCriteria)
        {
            return automationElement.FindFirst(TreeScope.Children, searchCriteria.AutomationCondition);
        }

        public virtual AutomationElement FindChildRaw(AutomationSearchCondition automationSearchCondition)
        {
            return new RawAutomationElementFinder(automationElement).Child(automationSearchCondition);
        }

        /// <summary>
        /// Uses the Raw View provided by UIAutomation to find elements. RawView sometimes contains extra AutomationElements. This is internal to 
        /// white although made public. Should be used only if the standard approaches dont work. Also if you end up using it please raise an issue
        /// so that it can be fixed
        /// Please understand that calling this method on any UIItem which has a lot of child AutomationElements might result in very bad performance.
        /// </summary>
        /// <returns>null or found AutomationElement</returns>
        public virtual AutomationElement FindDescendantRaw(AutomationSearchCondition automationSearchCondition)
        {
            return new RawAutomationElementFinder(automationElement).Descendant(automationSearchCondition);
        }
    }
}
