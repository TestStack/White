using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.ListBoxItems
{
    //todo document specialized classes and their methods somehow
    [PlatformSpecificItem]
    public class WinFormComboBox : ComboBox
    {
        protected WinFormComboBox() {}

        public WinFormComboBox(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        //todo implement this for Win32ComboBox as well
        /// <summary>
        /// Set the text in the TextBox inside the combobox.
        /// </summary>
        public virtual string Text
        {
            get { return GetTextBox().Text; }
            set { GetTextBox().Text = value; }
        }

        private TextBox GetTextBox()
        {
            return new TextBox(finder.Child(AutomationSearchCondition.ByControlType(ControlType.Edit)), actionListener);
        }
    }
}