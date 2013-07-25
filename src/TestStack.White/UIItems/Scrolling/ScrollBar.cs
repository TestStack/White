using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Factory;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UIItems.Scrolling {
    public class ScrollBar : UIItem, IScrollBar {
        private readonly ScrollBarButtonAutomationIds automationIds;
        private readonly PrimaryUIItemFactory primaryUIItemFactory;

        protected virtual Button BackSmallChangeButton {
            get { return FindButton(actionListener, automationIds.BackwardSmall); }
        }

        protected virtual Button ForwardSmallChangeButton {
            get { return FindButton(actionListener, automationIds.ForwardSmall); }
        }

        protected virtual Button BackLargeChangeButton {
            get { return FindButton(actionListener, automationIds.BackwardLarge); }
        }

        protected virtual Button ForwardLargeChangeButton {
            get { return FindButton(actionListener, automationIds.ForwardLarge); }
        }

        protected ScrollBar() {}

        protected ScrollBar(AutomationElement automationElement, ActionListener actionListener, ScrollBarButtonAutomationIds automationIds)
            : base(automationElement, actionListener) {
            this.automationIds = automationIds;
            var finder = new AutomationElementFinder(automationElement);
            primaryUIItemFactory = new PrimaryUIItemFactory(finder);
        }

        private Button FindButton(ActionListener listener, string automationId) {
            return
                (Button)
                primaryUIItemFactory.Create(SearchCriteria.ByControlType(ControlType.Button).AndAutomationId(automationId), listener);
        }

        public virtual double Value {
            get { return (double) Property(RangeValuePattern.ValueProperty); }
        }

        public virtual void SetToMinimum()
        {
            ((RangeValuePattern)Pattern(RangeValuePattern.Pattern)).SetValue(0);
            BackSmallChangeButton.Click();
        }

        public virtual void SetToMaximum() {
            ((RangeValuePattern) Pattern(RangeValuePattern.Pattern)).SetValue(MaximumValue);
            ForwardSmallChangeButton.Click();
        }

        public virtual double MinimumValue {
            get { return (double) Property(RangeValuePattern.MinimumProperty); }
        }

        public virtual double MaximumValue {
            get { return (double) Property(RangeValuePattern.MaximumProperty); }
        }
    }
}