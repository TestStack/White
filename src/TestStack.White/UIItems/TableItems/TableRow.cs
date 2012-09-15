using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Factory;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.TableItems
{
    public class TableRow : UIItem
    {
        private readonly TableHeader tableHeader;
        private readonly TableCellFactory tableCellFactory;
        private TableCells cells;

        protected TableRow() {}

        public TableRow(AutomationElement automationElement, ActionListener actionListener, TableHeader tableHeader, TableCellFactory tableCellFactory)
            : base(automationElement, actionListener)
        {
            this.tableHeader = tableHeader;
            this.tableCellFactory = tableCellFactory;
        }

        public virtual TableCells Cells
        {
            get
            {
                if (cells == null) cells = tableCellFactory.CreateCells(tableHeader, automationElement);
                return cells;
            }
        }

        private TableRowHeader Header
        {
            get
            {
                AutomationElement headerElement = new AutomationElementFinder(automationElement).Child(AutomationSearchCondition.ByControlType(ControlType.Header));
                return headerElement == null ? null : new TableRowHeader(headerElement, actionListener);
            }
        }

        public override void Click()
        {
            new TooltipSafeMouse(mouse).ClickOutsideToolTip(this, actionListener);
        }

        public override void DoubleClick()
        {
            new TooltipSafeMouse(mouse).DoubleClickOutsideToolTip(this, actionListener);
        }

        public override void RightClick()
        {
            new TooltipSafeMouse(mouse).RightClickOutsideToolTip(this, actionListener);
        }

        public virtual bool Select()
        {
            actionListener.ActionPerforming(this);
            TableRowHeader header = Header;
            if (header != null)
            {
                header.Click();
            }
            
            return header != null;
        }
    }
}