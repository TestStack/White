using System.Collections;
using System.Collections.Generic;
using System.Windows.Automation;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.Actions;

namespace White.Core
{
    public class UIItemList<T> : List<T> where T : IUIItem
    {
        private static readonly DictionaryMappedItemFactory factory = new DictionaryMappedItemFactory();

        public UIItemList() {}

        public UIItemList(ICollection tees)
        {
            foreach (T t in tees) Add(t);
        }

        public UIItemList(AutomationElementCollection collection, ActionListener actionListener) : this(collection, factory, actionListener) {}

        public UIItemList(AutomationElementCollection collection, UIItemFactory factory, ActionListener actionListener)
        {
            foreach (AutomationElement element in collection)
                Add((T) factory.Create(element, actionListener));
        }
    }
}