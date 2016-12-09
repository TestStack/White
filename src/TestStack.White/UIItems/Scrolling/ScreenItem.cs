using System;
using Castle.Core.Logging;
using TestStack.White.Configuration;
using TestStack.White.Utility;

namespace TestStack.White.UIItems.Scrolling
{
    public class ScreenItem
    {
        private readonly UIItem uiItem;
        private readonly IVScrollBar verticalScroll;
        private readonly IHScrollBar horizontalScroll;
        private readonly ILogger logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(ScreenItem));

        public ScreenItem(UIItem uiItem, IScrollBars scrollBars)
        {
            this.uiItem = uiItem;
            if (scrollBars == null || scrollBars.Vertical == null) return;

            verticalScroll = scrollBars.Vertical;
            horizontalScroll = scrollBars.Horizontal;
        }

        internal virtual void MakeVisible(ISpanProvider spanProvider)
        {
            bool verticalSuccess = TryMakeVerticallyVisible(spanProvider);
            bool horizontalSuccess = TryMakeHorizontallyVisible(spanProvider);

            if (verticalSuccess && horizontalSuccess)
            {
                return;
            }

            throw new UIActionException($"Could not make the {uiItem} visible{Constants.BusyMessage}");
        }

        private bool TryMakeVerticallyVisible(ISpanProvider spanProvider)
        {
            if (verticalScroll == null || !verticalScroll.IsScrollable)
            {
                return true;
            }

            VerticalSpan verticalSpan = spanProvider.VerticalSpan;

            if (verticalSpan.Contains(uiItem.Bounds))
            {
                logger.DebugFormat("UIItem ({0}) whose bounds are ({1}) is within bounds of parent whose vertical span is {2}", uiItem,
                                                 uiItem.Bounds, verticalSpan);
                return true;
            }

            if (verticalScroll.IsNotMinimum)
            {
                verticalScroll.SetToMinimum();
                verticalSpan = spanProvider.VerticalSpan;
                logger.DebugFormat("Scroll Position set to minimum value.");
            }

            if (verticalSpan.Contains(uiItem.Bounds))
            {
                logger.DebugFormat("UIItem ({0}) whose bounds are ({1}) is within bounds of parent whose vertical span is {2}", uiItem,
                                                 uiItem.Bounds, verticalSpan);
                return true;
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

            return success;
        }

        private bool TryMakeHorizontallyVisible(ISpanProvider spanProvider)
        {
            if (horizontalScroll == null || !horizontalScroll.IsScrollable)
            {
                return true;
            }

            HorizontalSpan horizontalSpan = spanProvider.HorizontalSpan;

            if (horizontalSpan.Contains(uiItem.Bounds))
            {
                logger.DebugFormat("UIItem ({0}) whose bounds are ({1}) is within bounds of parent whose horizontal span is {2}", uiItem,
                    uiItem.Bounds, horizontalSpan);
                return true;
            }

            logger.DebugFormat("Trying to make visible {0}, item's bounds are {1} and parent's span is {2}", uiItem, uiItem.Bounds, horizontalSpan);

            if (horizontalScroll.IsNotMinimum)
            {
                horizontalScroll.SetToMinimum();
                horizontalSpan = spanProvider.HorizontalSpan;
                logger.DebugFormat("Scroll Position set to minimum value.");
            }

            if (horizontalSpan.Contains(uiItem.Bounds))
            {
                logger.DebugFormat("UIItem ({0}) whose bounds are ({1}) is within bounds of parent whose horizontal span is {2}", uiItem,
                    uiItem.Bounds, horizontalSpan);
                return true;
            }

            bool success = Retry.For(
                () =>
                {
                    horizontalScroll.ScrollRightLarge();
                    var bounds = uiItem.Bounds;
                    const string messageFormat = "Trying to make {0} visible, item's bounds are {1} and parent's span is {2}";
                    logger.DebugFormat(messageFormat, uiItem, bounds, horizontalSpan);
                    return horizontalSpan.Contains(bounds);
                }, CoreAppXmlConfiguration.Instance.BusyTimeout(), TimeSpan.FromMilliseconds(0));

            return success;
        }
    }
}