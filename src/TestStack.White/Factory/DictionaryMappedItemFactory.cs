using System;
using System.Windows.Automation;
using TestStack.White.Mappings;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.Factory
{
    public class DictionaryMappedItemFactory : IUIItemFactory
    {
        public virtual IUIItem Create(AutomationElement automationElement, IActionListener actionListener)
        {
            if (automationElement == null) return null;
            return Create(automationElement, ControlDictionary.Instance.GetTestControlType(automationElement), actionListener);
        }

        public virtual IUIItem Create(AutomationElement automationElement, IActionListener actionListener, Type customItemType)
        {
            if (automationElement == null) return null;
            if (customItemType != null) return Create(automationElement, customItemType, actionListener);
            return Create(automationElement, actionListener);
        }

        private IUIItem Create(AutomationElement automationElement, Type itemType, IActionListener actionListener)
        {
            if (itemType == null) return null;
            return (IUIItem) Activator.CreateInstance(itemType, automationElement, actionListener);
        }
    }
}