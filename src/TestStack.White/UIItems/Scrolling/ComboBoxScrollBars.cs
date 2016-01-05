using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.Scrolling {
    public class ComboBoxScrollBars : ScrollBars {
        public ComboBoxScrollBars(AutomationElement automationElement, IActionListener actionListener)
            : base(automationElement, actionListener, new DefaultScrollBarButtonAutomationIds(), new DefaultScrollBarButtonAutomationIds()) {}

        public override IHScrollBar Horizontal {
            get { return FindHorizontalBar(finder.Descendant); }
        }

        public override IVScrollBar Vertical {
            get { return FindVerticalBar(finder.Descendant); }
        }
    }
}