using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Factory;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.TableItems
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
                return headerElement == null ? null : new TableRowHeader(headerElement, ActionListener);
            }
        }

        public override void Click()
        {
            new TooltipSafeMouse(mouse).ClickOutsideToolTip(this, ActionListener);
        }

        public override void DoubleClick()
        {
            new TooltipSafeMouse(mouse).DoubleClickOutsideToolTip(this, ActionListener);
        }

        public override void RightClick()
        {
            new TooltipSafeMouse(mouse).RightClickOutsideToolTip(this, ActionListener);
        }

        public virtual bool Select()
        {
            ActionPerforming(this);
            TableRowHeader header = Header;
            if (header != null)
            {
                header.Click();
            }
            
            return header != null;
        }
    }
}