using System.Linq;
using System.Windows;
using System.Windows.Automation;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Scrolling;

namespace White.Core.UIItems.ListBoxItems
{
    [PlatformSpecificItem]
    public class SilverlightComboBox : ComboBox
    {
        protected SilverlightComboBox() {}
        public SilverlightComboBox(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) { }

        public override IScrollBars ScrollBars
        {
            get { return scrollBars ?? (scrollBars = new WPFScrollBars(AutomationElement, ActionListener)); }
        }

        public override VerticalSpan VerticalSpan
        {
            get
            {
                var scrollPattern = (ScrollPattern) Pattern(ScrollPattern.Pattern);
                var bounds = Bounds;
                var firstVisibleItem = Items.First(i=>!i.IsOffScreen).Bounds;
                var lastItem = Items.Last(i=>i.Bounds != Rect.Empty).Bounds;
                var verticalViewSize = scrollPattern.Current.VerticalViewSize;
                var calculator = new SilverlightComboBoxVerticalSpanCalculator(bounds, firstVisibleItem, lastItem, verticalViewSize);
                return calculator.VerticalSpan;
            }
        }
    }
}