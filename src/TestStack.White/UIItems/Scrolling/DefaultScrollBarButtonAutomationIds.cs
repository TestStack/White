namespace TestStack.White.UIItems.Scrolling {
    internal class DefaultScrollBarButtonAutomationIds : ScrollBarButtonAutomationIds {
        public virtual string ForwardLarge {
            get { return "LargeIncrement"; }
        }

        public virtual string ForwardSmall {
            get { return "SmallIncrement"; }
        }

        public virtual string BackwardLarge {
            get { return "LargeDecrement"; }
        }

        public virtual string BackwardSmall {
            get { return "SmallDecrement"; }
        }
    }
}