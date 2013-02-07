using System.Windows;
using System.Windows.Automation;
using White.Core.UIA;
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
                var calculator = new WPFComboBoxVerticalSpanCalculator(Bounds, Items[0].Bounds, Items[Items.Count - 1].Bounds, scrollPattern.Current.VerticalViewSize);
                return calculator.VerticalSpan;
            }
        }

        protected override void ToggleDropDown()
        {
            Point point = IsEditable ? EditableItem.Bounds.ImmediateExteriorEast() : automationElement.Current.BoundingRectangle.Center();
            mouse.Click(point, actionListener);
        }
    }
}