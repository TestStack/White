using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.Scrolling {
    public class ComboBoxScrollBars : ScrollBars {
        public ComboBoxScrollBars(AutomationElement automationElement, ActionListener actionListener)
            : base(automationElement, actionListener, new DefaultScrollBarButtonAutomationIds(), new DefaultScrollBarButtonAutomationIds()) {}

        public override IHScrollBar Horizontal {
            get { return FindHorizontalBar(finder.Descendant); }
        }

        public override IVScrollBar Vertical {
            get { return FindVerticalBar(finder.Descendant); }
        }
    }
}