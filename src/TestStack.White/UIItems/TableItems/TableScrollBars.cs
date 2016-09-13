using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Scrolling;

namespace TestStack.White.UIItems.TableItems
{
    public class TableScrollBars : AbstractScrollBars
    {
        private readonly IVScrollBar verticalScrollBar;
        private readonly IHScrollBar horizontalScrollBar;

        public TableScrollBars(AutomationElementFinder finder, IActionListener actionListener, ITableVerticalScrollOffset tableVerticalScrollOffset)
        {
            AutomationElement verticalScrollElement = finder.Child(AutomationSearchCondition.ByControlType(ControlType.ScrollBar).WithName(UIItemIdAppXmlConfiguration.Instance.TableVerticalScrollBar));
            verticalScrollBar = (verticalScrollElement == null)
                                    ? (IVScrollBar) new NullVScrollBar()
                                    : new TableVerticalScrollBar(verticalScrollElement, actionListener, tableVerticalScrollOffset);
            AutomationElement horizontalScrollElement = finder.Child(AutomationSearchCondition.ByControlType(ControlType.ScrollBar).WithName(UIItemIdAppXmlConfiguration.Instance.TableHorizontalScrollBar));
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
