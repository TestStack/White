using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.Scrolling;

namespace TestStack.White.UIItems.TableItems
{
    public class Table : UIItem, IVerticalSpanProvider, ITableVerticalScrollOffset
    {
        private TableRows rows;
        private TableHeader header;
        private readonly AutomationElementFinder finder;
        private readonly TableRowFactory tableRowFactory;
        protected Table() {}

        public Table(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener)
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
                    AutomationElement headerElement = finder.Descendant(SearchCriteria.ByText(UIItemIdConfigurationLocator.Get().TableHeader).AutomationCondition);
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

        bool ITableVerticalScrollOffset.IsOnTop
        {
            get
            {
                if (Rows.Count == 0) return true;
                return !Rows[0].IsOffScreen;
            }
        }
    }
}