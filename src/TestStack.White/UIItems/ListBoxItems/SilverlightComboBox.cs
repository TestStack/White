using System.Linq;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Scrolling;

namespace TestStack.White.UIItems.ListBoxItems
{
    [PlatformSpecificItem]
    public class SilverlightComboBox : ComboBox
    {
        protected SilverlightComboBox() {}
        public SilverlightComboBox(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener) { }

        public override IScrollBars ScrollBars
        {
            get { return scrollBars ?? (scrollBars = new WPFScrollBars(AutomationElement, ActionListener)); }
        }

        public override VerticalSpan VerticalSpan
        {
            get
            {
                var scrollPattern = GetPattern<ScrollPattern>();
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