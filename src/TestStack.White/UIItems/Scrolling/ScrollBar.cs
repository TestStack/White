using System;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;
using TestStack.White.Utility;

namespace TestStack.White.UIItems.Scrolling {
    public abstract class ScrollBar : UIItem, IScrollBar {
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

        protected ScrollBar(AutomationElement automationElement, IActionListener actionListener, ScrollBarButtonAutomationIds automationIds)
            : base(automationElement, actionListener) {
            this.automationIds = automationIds;
            var finder = new AutomationElementFinder(automationElement);
            primaryUIItemFactory = new PrimaryUIItemFactory(finder);
        }

        private Button FindButton(IActionListener listener, string automationId) {
            return
                (Button)
                primaryUIItemFactory.Create(SearchCriteria.ByControlType(ControlType.Button).AndAutomationId(automationId), listener);
        }

        public virtual double Value {
            get { return (double) Property(RangeValuePattern.ValueProperty); }
        }

        public virtual void SetToMinimum()
        {
            var value = Retry.For(() =>
            {
                BackLargeChangeButton.Click();
                return Value;
            }, v => v > 0, CoreAppXmlConfiguration.Instance.BusyTimeout(), TimeSpan.FromMilliseconds(0));

            if (value > 0)
                throw new UIActionException(string.Format("Could not set the ScrollBar to minimum visible{0}", Constants.BusyMessage));
            Logger.DebugFormat("ScrollBar position set to {0}", Value);
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