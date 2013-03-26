using Castle.Core.Logging;
using White.Core.Configuration;
using White.Core.UIItems.Finders;

namespace White.Core.UIItems.WPFUIItems
{
    public static class WPFUIItem
    {
        private static readonly ILogger Logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(WPFUIItem));

        public static T Get<T>(this IUIItem uiItem, SearchCriteria searchCriteria) where T : UIItem
        {
            var uiItemContainer = GetUiItemContainer(uiItem);
            return uiItemContainer.Get<T>(searchCriteria);
        }

        public static T Get<T>(this IUIItem uiItem, string primaryIdentification) where T : UIItem
        {
            var uiItemContainer = GetUiItemContainer(uiItem);
            return uiItemContainer.Get<T>(primaryIdentification);
        }

        private static UIItemContainer GetUiItemContainer(IUIItem uiItem)
        {
            if (!(uiItem is UIItem))
                throw new WhiteException("Cannot get UI Item container, uiItem must be an instance of UIItem");
            if (!uiItem.Framework.IsWpf) Logger.Warn("Only WPF items should be treated as container items");
            return ((UIItem)uiItem).AsContainer();
        }

        public static IUIItem[] GetMultiple(this IUIItem uiItem, SearchCriteria criteria)
        {
            return GetUiItemContainer(uiItem).GetMultiple(criteria);
        }

        public static IUIItem Get(this IUIItem uiItem, SearchCriteria searchCriteria)
        {
            return GetUiItemContainer(uiItem).Get(searchCriteria);            
        }
    }
}