using System.Windows.Automation;
using TestStack.White.Factory;

namespace TestStack.White.UIItems
{
    public static class UIItemExtensions
    {
        // DictionaryMappedItemFactory does not have any state and could be shared
        private static readonly IUIItemFactory ItemFactory = new DictionaryMappedItemFactory();

        public static T GetParent<T>(this IUIItem thisItem) where T : IUIItem
        {
            var parent = TreeWalker.ControlViewWalker.GetParent(thisItem.AutomationElement);
            var uiItem = ItemFactory.Create(parent, thisItem.ActionListener);
            return (T) UIItemProxyFactory.Create(uiItem, uiItem.ActionListener);
        }
    }
}