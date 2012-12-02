using System.Windows;
using log4net;

namespace White.Core.UIItems.ListBoxItems
{
    public class WPFComboBoxVerticalSpanCalculator
    {
        private readonly Rect firstItem;
        private readonly Rect lastItem;
        private readonly Rect combo;
        private readonly double percentVisible;
        private readonly ILog logger = LogManager.GetLogger(typeof(WPFComboBoxVerticalSpanCalculator));

        public WPFComboBoxVerticalSpanCalculator(Rect combo, Rect firstItem, Rect lastItem, double percentVisible)
        {
            this.firstItem = firstItem;
            this.lastItem = lastItem;
            this.combo = combo;
            this.percentVisible = percentVisible;
        }

        public virtual VerticalSpan VerticalSpan
        {
            get
            {
                double listTop = firstItem.Top;
                double listBottom = lastItem.Bottom;

                double comboBoxBottom = combo.Bottom;

                if (DropUp())
                {
                    logger.Debug("ComboBox is dropping up");
                    return new VerticalSpan(listTop, listTop + VisibleHeight(listTop, listBottom));
                }
                return new VerticalSpan(comboBoxBottom, comboBoxBottom + VisibleHeight(listTop, listBottom));
            }
        }

        private double VisibleHeight(double listTop, double listBottom)
        {
            return (((listBottom - listTop) * percentVisible) / 100);
        }

        private bool DropUp()
        {
            return combo.Top > firstItem.Top;
        }
    }
}