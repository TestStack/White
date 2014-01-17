using System;
using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.Sessions;
using TestStack.White.UIItems.Actions;
using TestStack.White.WindowsAPI;

namespace TestStack.White.UIItems
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
            return GetPattern<RangeValuePattern>();
        }

        public virtual Button LargeIncrementButton
        {
            get { return uiItemContainer.Get<Button>(IncrementButtonId()); }
        }

        protected abstract string IncrementButtonId();
        protected abstract string DecrementButtonId();

        public virtual Button LargeDecrementButton
        {
            get { return uiItemContainer.Get<Button>(DecrementButtonId()); }
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

        /// <summary>
        /// Increments the slider
        /// </summary>
        public virtual void Increment()
        {
            SmallIncrement();
        }

        /// <summary>
        /// Increments the slider to the specified position
        /// </summary>
        /// <param name="to">New position</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="to"/> is greater than the maximum value supported</exception>
        /// <exception cref="InvalidOperationException">When <paramref name="to"/> is less than the current value</exception>
        public virtual void Increment(double to)
        {
            if (to > Maximum)
                throw new ArgumentOutOfRangeException("to");

            if (to < Value)
                throw new InvalidOperationException("Can't increment to the specified value. New value should be greater than current value");

            while (Value < to)
            {
                int distance = (int) (to - Value);
                if (distance > LargeChangeAmount)
                {
                    LargeIncrementButton.Click();
                }
                else
                {
                    for (int i = 0; i < distance; i++)
                    {
                        Increment();
                    }
                }
            }
        }

        /// <summary>
        /// Decrements the slider
        /// </summary>
        public virtual void Decrement()
        {
            SmallDecrement();
        }

        /// <summary>
        /// Decrements the slider to the specified position
        /// </summary>
        /// <param name="to">New position</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="to"/> is less than the minimum value supported</exception>
        /// <exception cref="InvalidOperationException">When <paramref name="to"/> is greater than the current value</exception>
        public virtual void Decrement(double to)
        {
            if (to < Minimum)
                throw new ArgumentOutOfRangeException("to");

            if (to > Value)
                throw new InvalidOperationException("Can't decrement to the specified value. New value should be less than current value");

            while (to < Value)
            {
                int distance = (int)(Value - to);
                if (distance > LargeChangeAmount)
                {
                    LargeDecrementButton.Click();
                }
                else
                {
                    for (int i = 0; i < distance; i++)
                    {
                        Decrement();
                    }
                }
            }
        }
    }
}