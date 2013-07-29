using System.Windows.Automation;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.ListViewItems;

namespace TestStack.White.UIItems
{
    [PlatformSpecificItem]
    public class WinFormTextBox : TextBox
    {
        public WinFormTextBox(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}
        public WinFormTextBox() {}

        public virtual SuggestionList SuggestionList
        {
            get { return SuggestionListView.WaitAndFind(ActionListener); }
        }
    }
}