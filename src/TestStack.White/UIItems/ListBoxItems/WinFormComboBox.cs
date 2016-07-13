using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.UIA;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.WPFUIItems;

namespace TestStack.White.UIItems.ListBoxItems
{
    //todo document specialized classes and their methods somehow
    [PlatformSpecificItem]
    public class WinFormComboBox : ComboBox
    {
        protected WinFormComboBox() {}

        public WinFormComboBox(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener) {}

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
            return new TextBox(Finder.Child(AutomationSearchCondition.ByControlType(ControlType.Edit)), actionListener);
        }

        public override ExpandCollapseState ExpandCollapseState
        {
            get
            {
                var itemsList = Finder.FindChildRaw(AutomationSearchCondition.ByControlType(ControlType.List));
                return itemsList == null ? ExpandCollapseState.Collapsed : ExpandCollapseState.Expanded;
            }
        }

        public override bool Expand()
        {
            if (ExpandCollapseState == ExpandCollapseState.Expanded) return false;
            var openButton = AutomationElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button));
            openButton.GetPattern<InvokePattern>().Invoke();
            return true;
        }

        public override bool Collapse()
        {
            if (ExpandCollapseState == ExpandCollapseState.Collapsed) return false;
            var openButton = AutomationElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button));
            openButton.GetPattern<InvokePattern>().Invoke();
            return true;
        }
    }
}