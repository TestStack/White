using System.Windows;
using Bricks.Core;
using White.Core.Configuration;
using White.Core.Logging;

namespace White.Core.UIItems.Scrolling
{
    public class ScreenItem
    {
        private readonly UIItem uiItem;
        private readonly IVScrollBar verticalScroll;

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
                WhiteLogger.Instance.DebugFormat("Vertical scrollbar not present in parent of {0}", uiItem);
                return;
            }
            if (!verticalScroll.IsScrollable)
            {
                WhiteLogger.Instance.DebugFormat("Vertical scrollbar is not scrollable for parent of {0}", uiItem);
                return;
            }

            VerticalSpan verticalSpan = verticalSpanProvider.VerticalSpan;
            if (verticalScroll.IsNotMinimum)
            {
                verticalScroll.SetToMinimum();
                verticalSpan = verticalSpanProvider.VerticalSpan;
                WhiteLogger.Instance.DebugFormat("Scroll Position set to minimum value.");
            }

            if (verticalSpan.Contains(uiItem.Bounds))
            {
                WhiteLogger.Instance.DebugFormat("UIItem ({0}) whose bounds are ({1}) is within bounds of parent whose vertical span is {2}", uiItem,
                                                 uiItem.Bounds, verticalSpan);
                return;
            }

            WhiteLogger.Instance.DebugFormat("Trying to make visible {0}, item's bounds are {1} and parent's span is {2}", uiItem, uiItem.Bounds,
                                             verticalSpan);
            var clock = new Clock(CoreAppXmlConfiguration.Instance.BusyTimeout, 0);
            clock.RunWhile(() => verticalScroll.ScrollDownLarge(), delegate
                                                                       {
                                                                           Rect bounds = uiItem.Bounds;
                                                                           WhiteLogger.Instance.DebugFormat(
                                                                               "Trying to make     visible {0}, item's bounds are {1} and parent's span is {2}",
                                                                               uiItem, bounds, verticalSpan);
                                                                           return verticalSpan.DoesntContain(bounds);
                                                                       },
                           delegate { throw new UIActionException(string.Format("Could not make the {0} visible{1}", uiItem, Constants.BusyMessage)); });
        }
    }
}