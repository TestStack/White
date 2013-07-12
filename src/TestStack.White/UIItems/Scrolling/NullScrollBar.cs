namespace TestStack.White.UIItems.Scrolling
{
    public class NullScrollBar
    {
        private double currentValue;

        public virtual double Value
        {
            get { return currentValue; }
        }
        public virtual double MinimumValue
        {
            get { return 0; }
        }
        public virtual double MaximumValue
        {
            get { return 100; }
        }

        public virtual void SetToMinimum()
        {
            currentValue = MinimumValue;
        }

        public virtual void SetToMaximum()
        {
            currentValue = MaximumValue;
        }
    }
}