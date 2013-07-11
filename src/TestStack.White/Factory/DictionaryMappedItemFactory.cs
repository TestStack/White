using System;
using System.Windows.Automation;
using White.Core.Mappings;
using White.Core.UIItems;
using White.Core.UIItems.Actions;

namespace White.Core.Factory
{
    public class DictionaryMappedItemFactory : UIItemFactory
    {
        public virtual IUIItem Create(AutomationElement automationElement, ActionListener actionListener)
        {
            if (automationElement == null) return null;
            return Create(automationElement, ControlDictionary.Instance.GetTestControlType(automationElement), actionListener);
        }

        public virtual IUIItem Create(AutomationElement automationElement, ActionListener actionListener, Type customItemType)
        {
            if (automationElement == null) return null;
            if (customItemType != null) return Create(automationElement, customItemType, actionListener);
            return Create(automationElement, actionListener);
        }

        private IUIItem Create(AutomationElement automationElement, Type itemType, ActionListener actionListener)
        {
            if (itemType == null) return null;
            return (IUIItem) Activator.CreateInstance(itemType, automationElement, actionListener);
        }
    }
}