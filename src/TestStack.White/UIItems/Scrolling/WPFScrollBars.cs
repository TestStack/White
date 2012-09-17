using System.Collections.ObjectModel;
using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.Scrolling {
    public class WPFScrollBars : AbstractScrollBars {
        private readonly AutomationElement parentElement;
        private readonly ActionListener actionListener;

        public WPFScrollBars(AutomationElement parentElement, ActionListener actionListener) {
            this.parentElement = parentElement;
            this.actionListener = actionListener;
        }

        public override IHScrollBar Horizontal {
            get {
                var patterns = new Collection<AutomationPattern>(parentElement.GetSupportedPatterns());
                return patterns.Contains(ScrollPattern.Pattern)
                           ? (IHScrollBar) new WPFHScrollBar(parentElement, actionListener)
                           : new NullHScrollBar();
            }
        }

        public override IVScrollBar Vertical {
            get {
                var patterns = new Collection<AutomationPattern>(parentElement.GetSupportedPatterns());
                return patterns.Contains(ScrollPattern.Pattern)
                           ? (IVScrollBar) new WPFVScrollBar(parentElement, actionListener)
                           : new NullVScrollBar();
            }
        }

        public override bool CanScroll {
            get { return Horizontal.IsScrollable || Vertical.IsScrollable; }
        }
    }
}