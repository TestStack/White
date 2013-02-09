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
            Select(!IsSelected);
        }

        public virtual void Select(bool shouldSelect)
        {
            if (!shouldSelect) return;

            actionListener.ActionPerforming(this);

            if (Bounds.IsEmpty)
            {
                Logger.Debug("Bounds empty, falling back to automation patterns");
                var selectionItemPattern = (SelectionItemPattern)automationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                selectionItemPattern.Select();
            }
            else
            {
                Logger.Debug("Selecting item with Click");
                mouse.Click(Bounds.ImmediateInteriorEast(), actionListener);                
            }

            actionListener.ActionPerformed(Action.WindowMessage);
        }

        public abstract void Check();
        public abstract void UnCheck();
    }
}