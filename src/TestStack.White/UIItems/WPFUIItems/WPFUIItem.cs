using White.Core.Logging;
using White.Core.UIItems.Finders;

namespace White.Core.UIItems.WPFUIItems
{
    public static class WPFUIItem
    {
        public static T Get<T>(this UIItem uiItem, SearchCriteria searchCriteria) where T : UIItem
        {
            UIItemContainer uiItemContainer = GetUiItemContainer(uiItem);
            return (T)uiItemContainer.Get(searchCriteria.AndControlType(typeof(T)));
        }

        private static UIItemContainer GetUiItemContainer(UIItem uiItem)
        {
            if (!uiItem.Framework.WPF) WhiteLogger.Instance.Warn("Only WPF items should be treated as container items");
            return uiItem.AsContainer();
        }

        public static IUIItem[] GetMultiple(this UIItem uiItem, SearchCriteria criteria)
        {
            UIItemContainer uiItemContainer = GetUiItemContainer(uiItem);
            return uiItemContainer.GetMultiple(criteria);
        }

        public static IUIItem Get(this UIItem uiItem, SearchCriteria searchCriteria)
        {
            UIItemContainer uiItemContainer = GetUiItemContainer(uiItem);
            return uiItemContainer.Get(searchCriteria);            
        }
    }
}