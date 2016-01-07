using Castle.Core.Logging;
using TestStack.White.Configuration;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UIItems.WPFUIItems
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

        public static IUIItem Get(this IUIItem uiItem, SearchCriteria searchCriteria)
        {
            return GetUiItemContainer(uiItem).Get(searchCriteria);
        }

        public static IUIItem Get(this IUIItem uiItem, string primaryIdentification)
        {
            return GetUiItemContainer(uiItem).Get(primaryIdentification);
        }

        public static IUIItem[] GetMultiple(this IUIItem uiItem, SearchCriteria criteria)
        {
            return GetUiItemContainer(uiItem).GetMultiple(criteria);
        }

        public static bool Exists<T>(this IUIItem uiItem) where T : IUIItem
        {
            return GetUiItemContainer(uiItem).Exists<T>(SearchCriteria.All);
        }

        public static bool Exists<T>(this IUIItem uiItem, string primaryIdentification) where T : IUIItem
        {
            return GetUiItemContainer(uiItem).Exists<T>(SearchCriteria.ByAutomationId(primaryIdentification));
        }

        public static bool Exists<T>(this IUIItem uiItem, SearchCriteria searchCriteria) where T : IUIItem
        {
            return GetUiItemContainer(uiItem).Exists(searchCriteria.AndControlType(typeof(T), uiItem.Framework));
        }

        public static bool Exists(this IUIItem uiItem, SearchCriteria searchCriteria)
        {
            return GetUiItemContainer(uiItem).Exists(searchCriteria);
        }

        private static UIItemContainer GetUiItemContainer(IUIItem uiItem)
        {
            if (!(uiItem is UIItem))
                throw new WhiteException("Cannot get UI Item container, uiItem must be an instance of UIItem");
            if (uiItem.Framework != WindowsFramework.Wpf) Logger.Warn("Only WPF items should be treated as container items");
            return ((UIItem)uiItem).AsContainer();
        }
    }
}