using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems
{
    public class SelectionItem : UIItem
    {
        protected SelectionItem() {}
        public SelectionItem(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual bool IsSelected
        {
            get { return (bool) Property(SelectionItemPattern.IsSelectedProperty); }
            set
            {
                if (IsSelected == value) return;
                if (value && !IsSelected)
                    Select();
            }
        }

        /// <exception cref="UIActionException"></exception>
        public virtual void Select()
        {
            if (!Bounds.IsEmpty) Click();
            
            var selectionItemPattern = (SelectionItemPattern) Pattern(SelectionItemPattern.Pattern);
            if (selectionItemPattern == null)
            {
                throw new UIActionException(string.Format("{0} cannot be selected as its position is unknown and doesn't support SelectionItemPattern", ToString()));
            }
            selectionItemPattern.Select();
        }
    }
}