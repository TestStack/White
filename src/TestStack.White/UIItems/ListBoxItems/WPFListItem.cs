using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UIItems.ListBoxItems
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
            get { return (CheckBox) factory.Create(SearchCriteria.ByControlType(ControlType.CheckBox), actionListener); }
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