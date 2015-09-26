namespace TestStack.White.UIItems.Scrolling {
    internal class DefaultScrollBarButtonAutomationIds : ScrollBarButtonAutomationIds {
        public virtual string ForwardLarge {
            get { return "DownPageButton"; }
        }

        public virtual string ForwardSmall {
            get { return "DownButton"; }
        }

        public virtual string BackwardLarge {
            get { return "UpPageButton"; }
        }

        public virtual string BackwardSmall {
            get { return "UpButton"; }
        }
    }
}