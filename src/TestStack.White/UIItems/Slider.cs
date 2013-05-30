using System.Windows.Automation;
using White.Core.Factory;
using White.Core.Sessions;
using White.Core.UIItems.Actions;
using White.Core.WindowsAPI;

namespace White.Core.UIItems
{
    public abstract class Slider : UIItem
    {
        private readonly UIItemContainer uiItemContainer;

        protected Slider() {}

        protected Slider(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
        {
            uiItemContainer = new UIItemContainer(automationElement, actionListener, InitializeOption.NoCache, new NullWindowSession());
        }

        public virtual double Value
        {
            get { return RangePattern().Current.Value; }
            set { RangePattern().SetValue(value); }
        }

        public virtual double Maximum
        {
            get { return RangePattern().Current.Maximum; }
        }

        public virtual double Minimum
        {
            get { return RangePattern().Current.Minimum; }
        }

        private RangeValuePattern RangePattern()
        {
            return ((RangeValuePattern)Pattern(RangeValuePattern.Pattern));
        }

        public virtual Button LargeIncrementButton
        {
            get
            {
                return uiItemContainer.Get<Button>(IncrementButtonId());
            }
        }

        protected abstract string IncrementButtonId();
        protected abstract string DecrementButtonId();

        public virtual Button LargeDecrementButton
        {
            get
            {
                return uiItemContainer.Get<Button>(DecrementButtonId());
            }
        }
        
        public virtual double LargeChangeAmount
        {
            get { return RangePattern().Current.LargeChange; }
        }

        public virtual double SmallChangeAmount
        {
            get { return RangePattern().Current.SmallChange; }
        }

        public virtual void SmallIncrement()
        {
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT, actionListener);
        }

        public virtual void SmallDecrement()
        {
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.LEFT, actionListener);
        }
    }
}