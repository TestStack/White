using System;
using White.Core.Configuration;
using White.Core.Utility;
using log4net;

namespace White.Core.UIItems.Scrolling
{
    public class ScreenItem
    {
        private readonly UIItem uiItem;
        private readonly IVScrollBar verticalScroll;
        private readonly ILog logger = LogManager.GetLogger(typeof(ScreenItem));

        public ScreenItem(UIItem uiItem, IScrollBars scrollBars)
        {
            this.uiItem = uiItem;
            if (scrollBars == null || scrollBars.Vertical == null) return;

            verticalScroll = scrollBars.Vertical;
        }

        internal virtual void MakeVisible(VerticalSpanProvider verticalSpanProvider)
        {
            if (verticalScroll == null)
            {
                logger.DebugFormat("Vertical scrollbar not present in parent of {0}", uiItem);
                return;
            }
            if (!verticalScroll.IsScrollable)
            {
                logger.DebugFormat("Vertical scrollbar is not scrollable for parent of {0}", uiItem);
                return;
            }

            VerticalSpan verticalSpan = verticalSpanProvider.VerticalSpan;
            if (verticalScroll.IsNotMinimum)
            {
                verticalScroll.SetToMinimum();
                verticalSpan = verticalSpanProvider.VerticalSpan;
                logger.DebugFormat("Scroll Position set to minimum value.");
            }

            if (verticalSpan.Contains(uiItem.Bounds))
            {
                logger.DebugFormat("UIItem ({0}) whose bounds are ({1}) is within bounds of parent whose vertical span is {2}", uiItem,
                                                 uiItem.Bounds, verticalSpan);
                return;
            }

            logger.DebugFormat("Trying to make visible {0}, item's bounds are {1} and parent's span is {2}", uiItem, uiItem.Bounds, verticalSpan);

            var success = Retry.For(
                () =>
                {
                    verticalScroll.ScrollDownLarge();
                    var bounds = uiItem.Bounds;
                    const string messageFormat = "Trying to make {0} visible, item's bounds are {1} and parent's span is {2}";
                    logger.DebugFormat(messageFormat, uiItem, bounds, verticalSpan);
                    return verticalSpan.Contains(bounds);
                }, CoreAppXmlConfiguration.Instance.BusyTimeout(), TimeSpan.FromMilliseconds(0));

            if (!success)
            throw new UIActionException(string.Format("Could not make the {0} visible{1}", uiItem, Constants.BusyMessage));
        }
    }
}