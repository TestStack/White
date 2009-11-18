using System;
using System.Windows.Automation;
using Bricks.Core;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.Factory;
using White.Core.Logging;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;

namespace White.Core.UIItems.Scrolling
{
    public class ScrollBar : UIItem, IScrollBar
    {
        private readonly PrimaryUIItemFactory primaryUIItemFactory;

        protected virtual Button BackSmallChangeButton
        {
            get { return FindButton(actionListener, "Back by small amount"); }
        }

        protected virtual Button ForwardSmallChangeButton
        {
            get { return FindButton(actionListener, "Forward by small amount"); }
        }

        protected virtual Button BackLargeChangeButton
        {
            get {return FindButton(actionListener, "Back by large amount");}
        }

        protected virtual Button ForwardLargeChangeButton
        {
            get { return FindButton(actionListener, "Forward by large amount"); }
        }

        protected ScrollBar() {}

        protected ScrollBar(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
        {
            var finder = new AutomationElementFinder(automationElement);
            primaryUIItemFactory = new PrimaryUIItemFactory(finder);
        }

        private Button FindButton(ActionListener listener, string text)
        {
            return (Button) primaryUIItemFactory.Create(SearchCriteria.ByControlType(ControlType.Button).AndByText(text), listener);
        }

        public virtual double Value
        {
            get { return (double) Property(RangeValuePattern.ValueProperty); }
        }

        public virtual void SetToMinimum()
        {
            var clock = new Clock(CoreAppXmlConfiguration.Instance.BusyTimeout, 0);
            clock.RunWhile(() => BackLargeChangeButton.PerformClick(), () => Value > 0,
                           delegate { throw new UIActionException(string.Format("Could not set the ScrollBar to minimum visible{0}", Constants.BusyMessage)); });
            WhiteLogger.Instance.DebugFormat("ScrollBar position set to {0}", Value);
        }

        public virtual void SetToMaximum()
        {
            ((RangeValuePattern) Pattern(RangeValuePattern.Pattern)).SetValue(MaximumValue);
        }

        public virtual double MinimumValue
        {
            get { return (double) Property(RangeValuePattern.MinimumProperty); }
        }

        public virtual double MaximumValue
        {
            get { return (double) Property(RangeValuePattern.MaximumProperty); }
        }
    }
}