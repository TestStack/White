using System.Linq;
using System.Windows.Automation;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Scrolling;

namespace White.Core.UIItems.ListBoxItems
{
    [PlatformSpecificItem]
    public class WPFComboBox : ComboBox
    {
        protected WPFComboBox() {}
        public WPFComboBox(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

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
                var firstVisibleItem = (Items.FirstOrDefault(i=>!i.IsOffScreen) ?? Items[0]).Bounds;
                var lastItem = Items[Items.Count - 1].Bounds;
                var verticalViewSize = scrollPattern.Current.VerticalViewSize;
                var calculator = new WPFComboBoxVerticalSpanCalculator(bounds, firstVisibleItem, lastItem, verticalViewSize);
                return calculator.VerticalSpan;
            }
        }
    }
}