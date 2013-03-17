using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.UIItems.Actions;
using White.Core.UIItems.ListViewItems;
using White.Core.WindowsAPI;

namespace White.Core.UIItems
{
    public class ListViewRow : UIItem
    {
        private readonly ListViewHeader header;
        private readonly AutomationElementFinder finder;
        protected ListViewRow() {}

        public ListViewRow(AutomationElement automationElement, ActionListener actionListener, ListViewHeader header)
            : base(automationElement, actionListener)
        {
            this.header = header;
            finder = new AutomationElementFinder(automationElement);
        }

        public virtual bool IsSelected
        {
            get
            {

                ActionPerforming(this);
                return IsSelectedValue;
            }
        }

        internal virtual bool IsSelectedValue
        {
            get { return (bool) Property(SelectionItemPattern.IsSelectedProperty); }
        }

        public virtual ListViewCells Cells
        {
            get
            {
                ActionPerforming(this);
                var collection = finder.Descendants(AutomationSearchCondition.ByControlType(ControlType.Text));
                return new ListViewCells(collection, ActionListener, header);
            }
        }

        /// <summary>
        /// Unselects previously selected row and selects this row. If this row is already selected it doesn't have any effect.
        /// </summary>
        public virtual void Select()
        {
            ActionPerforming(this);
            mouse.Click(ClickablePoint, ActionListener);
        }

        /// <summary>
        /// Keeps the old row selected and selects this row. If this row is already selected it doesn't have any effect.
        /// </summary>
        public virtual void MultiSelect()
        {

            ActionPerforming(this);
            keyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL, ActionListener);
            Select();
            keyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL, ActionListener);
        }
    }
}