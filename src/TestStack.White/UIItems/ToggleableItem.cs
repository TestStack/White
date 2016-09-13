using System;
using System.Windows.Automation;

namespace TestStack.White.UIItems
{
    public class ToggleableItem : UIItem
    {
        public ToggleableItem(UIItem uiItem) : base(uiItem.AutomationElement, uiItem.ActionListener)
        {
        }

        public virtual ToggleState State
        {
            get { return (ToggleState) Property(TogglePattern.ToggleStateProperty); }
            set
            {
                for (int i = 0; i < Enum.GetNames(typeof (ToggleState)).Length; i++)
                {
                    if (State == value) break;
                    Toggle();
                    ActionPerformed();
                }
            }
        }

        public virtual void Toggle()
        {
            var pattern = (TogglePattern) Pattern(TogglePattern.Pattern);
            pattern.Toggle();
        }
    }
}