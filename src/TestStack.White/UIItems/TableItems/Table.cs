using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.Factory;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;
using White.Core.UIItems.Scrolling;

namespace White.Core.UIItems.TableItems
{
    public class Table : UIItem, VerticalSpanProvider, TableVerticalScrollOffset
    {
        private TableRows rows;
        private TableHeader header;
        private readonly AutomationElementFinder finder;
        private readonly TableRowFactory tableRowFactory;
        protected Table() {}

        public Table(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
        {
            finder = new AutomationElementFinder(automationElement);
            tableRowFactory = new TableRowFactory(finder);
        }

        public virtual TableRows Rows
        {
            get { return rows ?? (rows = tableRowFactory.CreateRows(this, Header ?? new NullTableHeader())); }
        }

        public virtual TableHeader Header
        {
            get
            {
                if (header == null)
                {
                    AutomationElement headerElement = finder.Descendant(SearchCriteria.ByText(UIItemIdAppXmlConfiguration.Instance.TableHeader).AutomationCondition);
                    if (headerElement == null) return null;
                    header = (TableHeader) new TableHeaderFactory().Create(headerElement, actionListener);
                }
                return header;
            }
        }

        public virtual TableRow Row(string column, string value)
        {
            return Rows.Get(column, value);
        }

        public virtual TableRows FindAll(string column, string value)
        {
            return Rows.GetMultipleRows(column, value);
        }

        public virtual void Refresh()
        {
            rows = null;
        }

        public override void ActionPerforming(UIItem uiItem)
        {
            if (uiItem is Table) return;
            new ScreenItem(uiItem, ScrollBars).MakeVisible(this);
        }

        public override IScrollBars ScrollBars
        {
            get { return scrollBars ?? (scrollBars = new TableScrollBars(finder, ActionListener, this)); }
        }

        public override void RightClick()
        {
            new TooltipSafeMouse(mouse).RightClickOutsideToolTip(this, actionListener);
        }

        public virtual VerticalSpan VerticalSpan
        {
            get { return new VerticalSpan(Bounds); }
        }

        bool TableVerticalScrollOffset.IsOnTop
        {
            get
            {
                if (Rows.Count == 0) return true;
                return !Rows[0].IsOffScreen;
            }
        }
    }
}