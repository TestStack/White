using System.Windows.Automation;
using White.Core.UIItems.Actions;
using White.Core.UIItems.ListViewItems;

namespace White.Core.UIItems
{
    [PlatformSpecificItem]
    public class WinFormTextBox : TextBox
    {
        public WinFormTextBox(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}
        public WinFormTextBox() {}

        public virtual SuggestionList SuggestionList
        {
            get { return SuggestionListView.WaitAndFind(actionListener); }
        }
    }
}