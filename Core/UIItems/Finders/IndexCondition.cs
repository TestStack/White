using System;
using System.Collections.Generic;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Finder;

namespace White.Core.UIItems.Finders
{
    public class IndexCondition : SearchCondition
    {
        private readonly int index;
        public static readonly IndexCondition NotSpecified = new IndexCondition(-1);

        protected IndexCondition() {}

        public IndexCondition(int index)
        {
            this.index = index;
        }

        public override Condition AutomationCondition
        {
            get { return null; }
        }

        public override List<AutomationElement> Filter(List<AutomationElement> automationElements)
        {
            if (automationElements.Count <= index)
                throw new AutomationElementSearchException(
                    string.Format("No item with index {0}. Number of items available {1}", index, automationElements.Count));

            var automationElementAutomationElementPositionComparer = new AutomationElementPositionComparer();
            automationElements.Sort(automationElementAutomationElementPositionComparer);

            var list = new List<AutomationElement> {automationElements[index]};
            return list;
        }

        public override bool Satisfies(AutomationElement element)
        {
            throw new NotImplementedException();
        }

        public virtual IUIItem Filter(UIItemCollection collection)
        {
            var list = new List<IUIItem>(collection);
            list.Sort(new UIItemPositionComparer());
            return list.Count < (index + 1) ? null : list[index];
        }

        internal override string ToString(string operation)
        {
            return "Index" + operation + index;
        }

        protected internal override object SearchValue
        {
            get { return index; }
        }

        public override bool AppliesTo(AutomationElement element)
        {
            return true;
        }

        public override string ToString()
        {
            return ToString("=");
        }
    }
}