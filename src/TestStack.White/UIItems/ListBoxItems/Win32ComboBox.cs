using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Scrolling;

namespace TestStack.White.UIItems.ListBoxItems
{
    [PlatformSpecificItem]
    public class Win32ComboBox : ComboBox
    {
        protected Win32ComboBox() {}
        public Win32ComboBox(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public override IScrollBars ScrollBars
        {
            get
            {
                AutomationElement scrollParentElement =
                    new AutomationElementFinder(automationElement).Child(AutomationSearchCondition.ByAutomationId("ListBox"));
                if (scrollBars == null) scrollBars = ScrollerFactory.CreateBars(scrollParentElement, actionListener);
                return scrollBars;
            }
        }
    }
}