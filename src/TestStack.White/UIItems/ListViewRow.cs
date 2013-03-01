using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.ListViewItems;
using TestStack.White.WindowsAPI;

namespace TestStack.White.UIItems
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
            var clickablePoint = ClickablePoint;
            if (clickablePoint.X == 0 && clickablePoint.Y == 0)
            {
                throw new WhiteException(string.Format("Failed to select {0}, clickable point empty", ToString()));
            }
            mouse.Click(clickablePoint, ActionListener);
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