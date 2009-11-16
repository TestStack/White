using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems
{
    public class Spinner : UIItem
    {
        private readonly AutomationElementFinder finder;
        protected Spinner() {}

        public Spinner(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
        {
            finder = new AutomationElementFinder(automationElement);
        }

        public virtual double Value
        {
            get
            {
                ValuePattern valuePattern = GetValuePattern();
                string value = valuePattern.Current.Value;
                return double.Parse(value);
            }
            set { GetValuePattern().SetValue(value.ToString()); }
        }

        private ValuePattern GetValuePattern()
        {
            AutomationElement spinnerElementContainingValue =
                finder.FindChildRaw(AutomationSearchCondition.ByAutomationId(automationElement.Current.AutomationId).OfControlType(ControlType.Spinner));
            if (spinnerElementContainingValue == null) throw new WhiteAssertionException("Could not find Raw Spinner Element containing the value");
            return (ValuePattern) spinnerElementContainingValue.GetCurrentPattern(ValuePattern.Pattern);
        }

        public virtual void Increment()
        {
            Button button = GetButton("SmallIncrement");
            button.PerformClick();
        }

        private Button GetButton(string buttonName)
        {
            return new Button(finder.Child(AutomationSearchCondition.ByControlType(ControlType.Button).WithAutomationId(buttonName)), actionListener);
        }

        public virtual void Decrement()
        {
            GetButton("SmallDecrement").PerformClick();
        }
    }
}