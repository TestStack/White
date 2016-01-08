using TestStack.White.UIItems.Finders;

namespace TestStack.White.UIItems.WPFUIItems
{
    /// <summary>
    ///     Extention Methods for <see cref="IUIItem" /> available only for <see cref="WindowsFramework.Wpf" /> Framework
    /// </summary>
    public static class WPFUIItem
    {
        #region Get Single UI Item

        /// <summary>
        /// Get a single UI Item by a specific Search Criteria
        /// </summary>
        /// <param name="uiItem">The root UI Item from were to start searching</param>
        /// <param name="searchCriteria">The Search Criteria to use for the Search</param>
        /// <returns>Located UI Item</returns>
        public static IUIItem Get(this IUIItem uiItem, SearchCriteria searchCriteria)
        {
            return GetUiItemContainer(uiItem).Get(searchCriteria);
        }

        /// <summary>
        /// Get the first item of a certain type
        /// </summary>
        /// <typeparam name="T">Type of Item</typeparam>
        /// <param name="uiItem">The root UI Item from were to start searching</param>
        /// <returns>Located UI Item</returns>
        public static T Get<T>(this IUIItem uiItem) where T : IUIItem
        {
            return GetUiItemContainer(uiItem).Get<T>();
        }

        /// <summary>
        /// Get the first item of a certain type and a specific Search Criteria
        /// </summary>
        /// <typeparam name="T">Type of Item</typeparam>
        /// <param name="uiItem">The root UI Item from were to start searching</param>
        /// <param name="searchCriteria">The Search Criteria to use for the Search</param>
        /// <returns>Located UI Item</returns>
        public static T Get<T>(this IUIItem uiItem, SearchCriteria searchCriteria) where T : IUIItem
        {
            return searchCriteria == null ? uiItem.Get<T>() : GetUiItemContainer(uiItem).Get<T>(searchCriteria);
        }

        #endregion

        #region Get Multiple UI Items

        /// <summary>
        /// Get multiple UI Items
        /// </summary>
        /// <param name="uiItem">The root UI Item from were to start searching</param>
        /// <returns>Located UI Items</returns>
        public static IUIItem[] GetMultiple(this IUIItem uiItem)
        {
            return GetUiItemContainer(uiItem).GetMultiple();
        }

        /// <summary>
        ///     Get multiple UI Items by a specific Search Critera
        /// </summary>
        /// <param name="uiItem">The root UI Item from were to start searching</param>
        /// <param name="searchCriteria">The Search Criteria to use for the Search</param>
        /// <returns>Located UI Items</returns>
        public static IUIItem[] GetMultiple(this IUIItem uiItem, SearchCriteria searchCriteria)
        {
            return searchCriteria == null
                ? uiItem.GetMultiple()
                : GetUiItemContainer(uiItem).GetMultiple(searchCriteria);
        }

        /// <summary>
        /// Get multiple UI Items
        /// </summary>
        /// <typeparam name="T">Type of Item</typeparam>
        /// <param name="uiItem">The root UI Item from were to start searching</param>
        /// <returns>Located UI Items</returns>
        public static T[] GetMultiple<T>(this IUIItem uiItem) where T : IUIItem
        {
            return GetUiItemContainer(uiItem).GetMultiple<T>();
        }

        /// <summary>
        /// Get multiple UI Items
        /// </summary>
        /// <typeparam name="T">Type of Item</typeparam>
        /// <param name="uiItem">The root UI Item from were to start searching</param>
        /// <param name="searchCriteria">The Search Criteria to use for the Search</param>
        /// <returns>Located UI Items</returns>
        public static T[] GetMultiple<T>(this IUIItem uiItem, SearchCriteria searchCriteria) where T : IUIItem
        {
            return searchCriteria == null
                ? uiItem.GetMultiple<T>()
                : GetUiItemContainer(uiItem).GetMultiple<T>(searchCriteria);
        }

        #endregion

        #region Exists

        /// <summary>
        /// Check if any UI Item of a certain Type exists
        /// </summary>
        /// <typeparam name="T">Type of Item</typeparam>
        /// <param name="uiItem">The root UI Item from were to start searching</param>
        /// <returns><c>true</c> if there is any; otherwise, <c>false</c>.</returns>
        public static bool Exists<T>(this IUIItem uiItem) where T : IUIItem
        {
            return GetUiItemContainer(uiItem).Exists<T>(SearchCriteria.All);
        }

        /// <summary>
        /// Check if any UI Item of a certain Type exists
        /// </summary>
        /// <typeparam name="T">Type of Item</typeparam>
        /// <param name="uiItem">The root UI Item from were to start searching</param>
        /// <param name="searchCriteria">The Search Criteria to use for the Search</param>
        /// <returns><c>true</c> if there is any; otherwise, <c>false</c>.</returns>
        public static bool Exists<T>(this IUIItem uiItem, SearchCriteria searchCriteria) where T : IUIItem
        {
            return GetUiItemContainer(uiItem).Exists(searchCriteria.AndControlType(typeof (T), uiItem.Framework));
        }

        /// <summary>
        /// Check if any UI Item of a certain Type exists
        /// </summary>
        /// <param name="uiItem">The root UI Item from were to start searching</param>
        /// <param name="searchCriteria">The Search Criteria to use for the Search</param>
        /// <returns><c>true</c> if there is any; otherwise, <c>false</c>.</returns>
        public static bool Exists(this IUIItem uiItem, SearchCriteria searchCriteria)
        {
            return GetUiItemContainer(uiItem).Exists(searchCriteria);
        }

        #endregion

        #region Private

        private static IUIItemContainer GetUiItemContainer(IUIItem uiItem)
        {
            var item = uiItem as UIItem;
            if (item == null)
            {
                throw new WhiteException("Cannot get UI Item container, uiItem must be an instance of UIItem");
            }
            return item.AsContainer();
        }

        #endregion
    }
}