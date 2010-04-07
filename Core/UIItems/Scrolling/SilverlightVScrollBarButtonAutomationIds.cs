namespace White.Core.UIItems.Scrolling {
    internal class SilverlightVScrollBarButtonAutomationIds : ScrollBarButtonAutomationIds {
        public virtual string ForwardLarge {
            get { return "VerticalLargeIncrease"; }
        }

        public virtual string ForwardSmall {
            get { return "VerticalSmallIncrease"; }
        }

        public virtual string BackwardLarge {
            get { return "VerticalLargeDecrease"; }
        }

        public virtual string BackwardSmall {
            get { return "VerticalSmallDecrease"; }
        }
    }
}