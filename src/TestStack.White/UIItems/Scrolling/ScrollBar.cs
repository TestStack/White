using System;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.Factory;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;
using White.Core.Utility;

namespace White.Core.UIItems.Scrolling {
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
            var value = Retry.For(() =>
            {
                BackLargeChangeButton.PerformClick();
                return Value;
            }, v => v > 0, CoreAppXmlConfiguration.Instance.BusyTimeout(), TimeSpan.FromMilliseconds(0));

            if (value > 0)
                throw new UIActionException(string.Format("Could not set the ScrollBar to minimum visible{0}", Constants.BusyMessage));
            Logger.DebugFormat("ScrollBar position set to {0}", Value);
        }

        public virtual void SetToMaximum() {
            ((RangeValuePattern) Pattern(RangeValuePattern.Pattern)).SetValue(MaximumValue);
        }

        public virtual double MinimumValue {
            get { return (double) Property(RangeValuePattern.MinimumProperty); }
        }

        public virtual double MaximumValue {
            get { return (double) Property(RangeValuePattern.MaximumProperty); }
        }
    }
}