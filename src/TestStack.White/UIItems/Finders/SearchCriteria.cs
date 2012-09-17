using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.UIItems.Custom;
using White.Core.UIItems.WindowStripControls;

namespace White.Core.UIItems.Finders
{
    /// <summary>
    /// SearchCritera can be used when UIItem identification is not satisfied by standard Get methods on UIItemContainer (Window is subclass of 
    /// UIItemContainer). Multiple criterias can be supplied together based on which the UIItem would be searched. All the conditions would put together as
    /// AND condition
    /// e.g. SearchCriteria.ByAutomationId("foo").ByControlType(typeof(TextBox)).Indexed(1)
    /// </summary>
    public class SearchCriteria
    {
        private readonly SearchConditions conditions = new SearchConditions();
        private IndexCondition indexCondition = IndexCondition.NotSpecified;
        private Type customItemType;

        private SearchCriteria() {}

        private SearchCriteria(SearchCondition searchCondition)
        {
            conditions.Add(searchCondition);
        }

        private SearchCriteria(IndexCondition searchCondition)
        {
            conditions.Add(searchCondition);
            indexCondition = searchCondition;
        }

        public static SearchCriteria All
        {
            get { return new SearchCriteria(); }
        }

        /// <summary>
        /// Create a SearchCriteria with text
        /// </summary>
        /// <param name="text">For managed applications this is name given to controls in the application code. 
        /// For unmanaged applications this is text of the control or label next to it if it doesn't have well defined text.</param>
        /// <returns></returns>
        public static SearchCriteria ByText(string text)
        {
            return new SearchCriteria(SearchConditionFactory.CreateForName(text));
        }

        /// <summary>
        /// Create criteria with specified index
        /// </summary>
        /// <param name="zeroBasedIndex"></param>
        /// <returns></returns>
        public static SearchCriteria Indexed(int zeroBasedIndex)
        {
            var indexCondition = new IndexCondition(zeroBasedIndex);
            var criteria = new SearchCriteria(indexCondition);
            return criteria;
        }

        public static SearchCriteria ByAutomationId(string identification)
        {
            return new SearchCriteria(SearchConditionFactory.CreateForAutomationId(identification));
        }

        public static SearchCriteria ByFramework(string framework)
        {
            return new SearchCriteria(SearchConditionFactory.CreateForFrameworkId(framework));
        }

        public static SearchCriteria ByControlType(ControlType controlType)
        {
            return new SearchCriteria(SearchConditionFactory.CreateForControlType(controlType));
        }

        public static SearchCriteria ByNativeProperty(AutomationProperty automationProperty, string value)
        {
            return new SearchCriteria(SearchConditionFactory.CreateForNativeProperty(automationProperty, value));
        }

        public static SearchCriteria ByNativeProperty(AutomationProperty automationProperty, bool value)
        {
            return new SearchCriteria(SearchConditionFactory.CreateForNativeProperty(automationProperty, value));
        }

        public static SearchCriteria ByControlType(Type testControlType)
        {
            var searchCriteria = new SearchCriteria(SearchConditionFactory.CreateForControlType(testControlType));
            searchCriteria.InferCustomItemType(testControlType);
            return searchCriteria;
        }

        internal virtual Condition AutomationCondition
        {
            get { return conditions.AutomationCondition; }
        }

        internal virtual Condition AutomationConditionWith(PropertyCondition propertyCondition)
        {
            Condition condition = conditions.AutomationCondition;
            return new AndCondition(condition, propertyCondition);
        }

        public virtual bool IsIndexed
        {
            get { return indexCondition != IndexCondition.NotSpecified; }
        }

        public virtual Type CustomItemType
        {
            get { return customItemType; }
        }

        internal virtual AutomationSearchCondition AutomationSearchCondition
        {
            get
            {
                var automationSearchCondition = new AutomationSearchCondition();
                foreach (SearchCondition searchCondition in conditions)
                {
                    Condition condition = searchCondition.AutomationCondition;
                    if (condition != null) automationSearchCondition.Add(condition);
                }
                return automationSearchCondition;
            }
        }

        public virtual SearchCriteria AndIndex(int zeroBasedIndex)
        {
            indexCondition = new IndexCondition(zeroBasedIndex);
            conditions.Add(indexCondition);
            return this;
        }

        public virtual SearchCriteria AndByText(string text)
        {
            conditions.Insert(0, SearchConditionFactory.CreateForName(text));
            return this;
        }

        public virtual SearchCriteria AndOfFramework(string frameworkId)
        {
            conditions.Insert(0, SearchConditionFactory.CreateForFrameworkId(frameworkId));
            return this;
        }

        public virtual SearchCriteria NotIdentifiedByText(string name)
        {
            conditions.Insert(0, new NotCondition(SearchConditionFactory.CreateForName(name)));
            return this;
        }

        public virtual SearchCriteria AndControlType(Type testControlType)
        {
            InferCustomItemType(testControlType);
            conditions.Insert(0, SearchConditionFactory.CreateForControlType(testControlType));
            return this;
        }

        public virtual SearchCriteria AndControlType(ControlType controlType)
        {
            conditions.Insert(0, SearchConditionFactory.CreateForControlType(controlType));
            return this;
        }

        public virtual SearchCriteria AndAutomationId(string id)
        {
            conditions.Insert(0, SearchConditionFactory.CreateForAutomationId(id));
            return this;
        }

        public virtual SearchCriteria AndNativeProperty(AutomationProperty automationProperty, string value)
        {
            conditions.Insert(0, SearchConditionFactory.CreateForNativeProperty(automationProperty, value));
            return this;
        }

        public virtual SearchCriteria AndNativeProperty(AutomationProperty automationProperty, bool value)
        {
            conditions.Insert(0, SearchConditionFactory.CreateForNativeProperty(automationProperty, value));
            return this;
        }

        public virtual List<AutomationElement> Filter(List<AutomationElement> automationElements)
        {
            return conditions.Filter(automationElements);
        }

        public virtual IUIItem IndexedItem(UIItemCollection collection)
        {
            return indexCondition.Filter(collection);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(conditions.ToString());
            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var other = obj as SearchCriteria;
            if (other == null) return false;

            foreach (SearchCondition searchCondition in conditions)
                if (!other.conditions.Contains(searchCondition)) return false;

            return indexCondition.Equals(other.indexCondition);
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (SearchCondition condition in conditions)
                hashCode += condition.GetHashCode();
            return indexCondition.GetHashCode() + hashCode;
        }

        public virtual bool AppliesTo(AutomationElement automationElement)
        {
            foreach (SearchCondition condition in conditions)
            {
                if (!condition.AppliesTo(automationElement))
                    return false;
            }
            return true;
        }

        private void InferCustomItemType(Type testControlType)
        {
            customItemType = typeof (CustomUIItem).IsAssignableFrom(testControlType) ? testControlType : null;
        }

        internal static SearchCriteria ForMenuBar(WindowsFramework framework)
        {
            var searchCriteria =
                new SearchCriteria(SearchConditionFactory.CreateForControlType(typeof (MenuBar), framework.ToString()));
            return searchCriteria.NotIdentifiedByText("System Menu Bar");
        }

        public virtual SearchCriteria Merge(SearchCriteria other)
        {
            foreach (var searchCondition in other.conditions)
            {
                if (!conditions.Any(condition => condition.OfSameType(searchCondition)))
                {
                    conditions.Add(searchCondition);
                }
            }
            return this;
        }
    }
}