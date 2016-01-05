using System.Collections;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;

namespace TestStack.White
{
    public class UIItemList<T> : List<T> where T : IUIItem
    {
        private static readonly DictionaryMappedItemFactory factory = new DictionaryMappedItemFactory();

        public UIItemList() {}

        public UIItemList(ICollection tees)
        {
            foreach (T t in tees) Add(t);
        }

        public UIItemList(List<AutomationElement> collection, IActionListener actionListener) : this(collection, factory, actionListener) { }

        public UIItemList(List<AutomationElement> collection, IUIItemFactory factory, IActionListener actionListener)
        {
            foreach (AutomationElement element in collection)
                Add((T) factory.Create(element, actionListener));
        }
    }
}