using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Scrolling;

namespace White.Core.UIItems.TableItems
{
    public class TableScrollBars : AbstractScrollBars
    {
        private readonly IVScrollBar verticalScrollBar;
        private readonly IHScrollBar horizontalScrollBar;

        public TableScrollBars(AutomationElementFinder finder, ActionListener actionListener, TableVerticalScrollOffset tableVerticalScrollOffset)
        {
            AutomationElement verticalScrollElement = finder.Child(AutomationSearchCondition.ByControlType(ControlType.Pane).OfName(UIItemIdAppXmlConfiguration.Instance.TableVerticalScrollBar));
            verticalScrollBar = (verticalScrollElement == null)
                                    ? (IVScrollBar) new NullVScrollBar()
                                    : new TableVerticalScrollBar(verticalScrollElement, actionListener, tableVerticalScrollOffset);
            AutomationElement horizontalScrollElement = finder.Child(AutomationSearchCondition.ByControlType(ControlType.Pane).OfName(UIItemIdAppXmlConfiguration.Instance.TableHorizontalScrollBar));
            horizontalScrollBar = (horizontalScrollElement == null)
                                      ? (IHScrollBar) new NullHScrollBar()
                                      : new TableHorizontalScrollBar(horizontalScrollElement, actionListener);
        }

        public override IHScrollBar Horizontal
        {
            get { return horizontalScrollBar; }
        }

        public override IVScrollBar Vertical
        {
            get { return verticalScrollBar; }
        }
    }
}
