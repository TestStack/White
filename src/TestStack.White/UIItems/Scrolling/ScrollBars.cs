using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.Scrolling {
    public class ScrollBars : AbstractScrollBars {
        private readonly IActionListener actionListener;
        private readonly ScrollBarButtonAutomationIds hScrollBarButtonAutomationIds;
        private readonly ScrollBarButtonAutomationIds vScrollBarButtonAutomationIds;
        protected readonly AutomationElementFinder finder;

        protected delegate AutomationElement FindElement(AutomationSearchCondition condition);

        public ScrollBars(AutomationElement automationElement, IActionListener actionListener,
            ScrollBarButtonAutomationIds hScrollBarButtonAutomationIds, ScrollBarButtonAutomationIds vScrollBarButtonAutomationIds) {
            this.actionListener = actionListener;
            this.hScrollBarButtonAutomationIds = hScrollBarButtonAutomationIds;
            this.vScrollBarButtonAutomationIds = vScrollBarButtonAutomationIds;
            finder = new AutomationElementFinder(automationElement);
        }

        public override IHScrollBar Horizontal {
            get { return FindHorizontalBar(finder.Child); }
        }

        protected virtual IHScrollBar FindHorizontalBar(FindElement findElement) {
            AutomationElement horizontalScrollElement =
                findElement(
                    AutomationSearchCondition.ByAutomationId(UIItemIdConfigurationLocator.Get().HorizontalScrollBar).OfControlType(
                        ControlType.ScrollBar));
            if (horizontalScrollElement == null) {
                return new NullHScrollBar();
            }
            return new HScrollBar(horizontalScrollElement, actionListener, hScrollBarButtonAutomationIds);
        }

        public override IVScrollBar Vertical {
            get { return FindVerticalBar(finder.Child); }
        }

        protected virtual IVScrollBar FindVerticalBar(FindElement findElement) {
            AutomationElement verticalScrollElement =
                findElement(
                    AutomationSearchCondition.ByAutomationId(UIItemIdConfigurationLocator.Get().VerticalScrollBar).OfControlType(
                        ControlType.ScrollBar));
            if (verticalScrollElement == null) {
                return new NullVScrollBar();
            }
            return new VScrollBar(verticalScrollElement, actionListener, vScrollBarButtonAutomationIds);
        }
    }
}