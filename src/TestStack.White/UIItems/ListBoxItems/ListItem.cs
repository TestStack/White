using System.Windows.Automation;
using White.Core.UIA;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.ListBoxItems
{
    public abstract class ListItem : UIItem
    {
        protected ListItem() {}
        protected ListItem(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual bool IsSelected
        {
            get { return (bool) Property(SelectionItemPattern.IsSelectedProperty); }
        }

        public virtual string Text
        {
            get { return Name; }
        }

        public abstract bool Checked { get; }

        public virtual void Select()
        {
            if (IsSelected) return;
            actionListener.ActionPerforming(this);

            //Bounds empty, fall back to automation element
            if (Bounds.IsEmpty)
            {
                var selectionPattern = (SelectionItemPattern)automationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                selectionPattern.Select();
            }
            else
            {
                mouse.Click(Bounds.ImmediateInteriorEast(), actionListener);                
            }
            actionListener.ActionPerformed(Action.WindowMessage);
        }

        public abstract void Check();
        public abstract void UnCheck();
    }
}