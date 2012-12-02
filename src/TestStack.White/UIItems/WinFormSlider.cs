using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems
{
    public class WinFormSlider : Slider
    {
        protected WinFormSlider() {}
        public WinFormSlider(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        protected override string IncrementButtonId()
        {
            return "LargeIncrement";
        }

        protected override string DecrementButtonId()
        {
            return "LargeDecrement";
        }
    }

    public class WPFSlider : Slider
    {
        protected WPFSlider() {}
        public WPFSlider(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        protected override string IncrementButtonId()
        {
            return "IncreaseLarge";
        }

        protected override string DecrementButtonId()
        {
            return "DecreaseLarge";
        }
    }
}