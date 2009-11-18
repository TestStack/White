using System;
using System.Collections.Generic;
using System.Windows.Automation;

namespace White.Core.UIItems.Finders
{
    public abstract class SearchCondition : IEquatable<SearchCondition>
    {
        public virtual List<AutomationElement> Filter(List<AutomationElement> automationElements)
        {
            return automationElements.FindAll(Satisfies);
        }

        public abstract bool Satisfies(AutomationElement element);
        public abstract Condition AutomationCondition { get; }
        internal abstract string ToString(string operation);
        protected internal abstract object SearchValue { get; }

        public virtual bool Equals(SearchCondition searchCondition)
        {
            return Equals((object) searchCondition);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as SearchCondition;
            if (other == null) return false;

            return other.GetType().Equals(GetType()) && SearchValue.Equals(other.SearchValue);
        }

        public override int GetHashCode()
        {
            try
            {
                object searchValue = SearchValue;
                return 3*GetType().GetHashCode() + (searchValue == null ? 0 : 5*searchValue.GetHashCode());
            }
            catch (NullReferenceException)
            {
                return base.GetHashCode();
            }
        }

        public abstract bool AppliesTo(AutomationElement element);
    }
}
