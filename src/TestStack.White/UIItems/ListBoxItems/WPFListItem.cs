using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;

namespace White.Core.UIItems.ListBoxItems
{
    [PlatformSpecificItem]
    public class WPFListItem : ListItem
    {
        private readonly AutomationElementFinder finder;
        
        protected WPFListItem() {}
        public WPFListItem(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
        {
            finder = new AutomationElementFinder(automationElement);
        }

        private CheckBox CheckBox
        {
            get { return (CheckBox) factory.Create(SearchCriteria.ByControlType(ControlType.CheckBox), ActionListener); }
        }

        public override bool Checked
        {
            get { return CheckBox.Checked; }
        }

        public override void Check()
        {
            if (!Checked)
                CheckBox.Click();
        }

        public override void UnCheck()
        {
            if (Checked)
                CheckBox.Click();
        }

        public override string Text
        {
            get
            {
                AutomationElement element = finder.FindChildRaw(AutomationSearchCondition.ByControlType(ControlType.Text));
                if (element == null) return base.Text;
                return element.Current.Name;
            }
        }
    }
}