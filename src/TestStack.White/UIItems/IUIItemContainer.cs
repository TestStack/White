using System;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UIItems
{
    public interface IUIItemContainer : IUIItem
    {
        /// <summary>
        /// <see cref="ToolTip" /> for the UI Item
        /// </summary>
        ToolTip ToolTip { get; }

        /// <summary>
        /// <see cref="ToolTip" /> for a specific UI Item
        /// </summary>
        /// <param name="uiItem">UI Item to focus in order to get the corresponding ToolTip</param>
        /// <returns>The <see cref="ToolTip" /> belonging to the specified UI Item</returns>
        ToolTip GetToolTipOn(IUIItem uiItem);

        #region Get UI Item

        /// <summary>
        /// Finds UIItem which matches specified type. 
        /// Useful for non managed applications where controls are not identified by AutomationId, 
        /// like in Managed applications. 
        /// In case of multiple items of this type the first one found would be returned,
        /// which cannot be guaranteed to be the same across multiple invocations.
        /// </summary>
        /// <typeparam name="T">IUIItem type e.g. Button, TextBox</typeparam>
        /// <returns>First item of supplied type</returns>
        /// <exception cref="AutomationException">when item not found</exception>
        /// <exception cref="WhiteException">when any errors occured during search</exception>
        T Get<T>() where T : IUIItem;

        /// <summary>
        /// Finds UIItem which matches specified type and identification.
        /// In case of multiple items of this type the first one found would be returned,
        /// which cannot be guaranteed to be the same across multiple invocations. 
        /// For managed applications this is name given to controls in the application code.
        /// For unmanaged applications this is text of the control or label next to it if it doesn't have well defined text.
        /// <!--e.g. TextBox doesn't have any predefined text of its own as it can be changed at runtime by user, hence is identified by the label next to it.
        /// If there is no label then Get<T> or Get<T>(SearchCriteria) method can be used.-->
        /// </summary>
        /// <typeparam name="T">IUIItem implementation</typeparam>
        /// <param name="primaryIdentification">
        /// For managed application this is the name provided in application code and unmanaged application this is
        /// the text or label next to it based identification
        /// </param>
        /// <returns>First item of supplied type and identification</returns>
        /// <exception cref="AutomationException">when item not found</exception>
        /// <exception cref="WhiteException">when any errors occured during search</exception>
        T Get<T>(string primaryIdentification) where T : IUIItem;

        /// <summary>
        /// Finds UIItem which matches specified type and searchCriteria. 
        /// Type supplied need not be supplied again in SearchCondition.
        /// <!--e.g. in Get<Button>(SearchCriteria.ByAutomationId("OK").ByControlType(typeof(Button)).Indexed(1) the ByControlType(typeof(Button)) part 
        /// is redundant. Look at documentation of SearchCriteria for details on it.-->
        /// </summary>
        /// <code>
        /// </code>
        /// <typeparam name="T"></typeparam>
        /// <param name="searchCriteria">Criteria provided to search UIItem</param>
        /// <returns>First items matching the type and criteria</returns>
        /// <exception cref="AutomationException">when item not found</exception>
        /// <exception cref="WhiteException">when any errors occured during search</exception>
        T Get<T>(SearchCriteria searchCriteria) where T : IUIItem;

        /// <summary>
        /// Finds UIItem which matches specified searchCriteria using the default BusyTimeout. 
        /// Look at documentation of SearchCriteria for details on it.
        /// </summary>
        /// <param name="searchCriteria">Criteria provided to search IUIItem</param>
        /// <returns>First items matching the criteria</returns>
        /// <exception cref="AutomationException">when item not found</exception>
        /// <exception cref="WhiteException">when any errors occured during search</exception>
        IUIItem Get(SearchCriteria searchCriteria);

        /// <summary>
        /// Finds UIItem which matches specified type and searchCriteria. 
        /// Look at documentation of SearchCriteria for details on it.
        /// </summary>
        /// <param name="searchCriteria">Criteria provided to search IUIItem</param>
        /// <param name="busyTimeout">Time to wait for item to come on-screen before returning off-screen element, if found.</param>
        /// <returns>First items matching the criteria</returns>
        /// <exception cref="AutomationException">when item not found</exception>
        /// <exception cref="WhiteException">when any errors occured during search</exception>
        IUIItem Get(SearchCriteria searchCriteria, TimeSpan busyTimeout);

        #endregion

        #region Get UI Items

        /// <summary>
        /// Finds all UIItems using the default BusyTimeout. 
        /// </summary>
        /// <returns>Array of all <see cref="IUIItem"/> that can be found</returns>
        /// <exception cref="AutomationException">when item not found</exception>
        /// <exception cref="WhiteException">when any errors occured during search</exception>
        IUIItem[] GetMultiple();

        /// <summary>
        /// Finds UIItems which matche a specified searchCriteria using the default BusyTimeout. 
        /// Look at documentation of SearchCriteria for details on it.
        /// </summary>
        /// <param name="searchCriteria">Criteria provided to search IUIItem</param>
        /// <returns>Array of <see cref="IUIItem"/> matching the criteria</returns>
        /// <exception cref="AutomationException">when item not found</exception>
        /// <exception cref="WhiteException">when any errors occured during search</exception>
        IUIItem[] GetMultiple(SearchCriteria searchCriteria);

        /// <summary>
        /// Finds all UIItems of Type T using the default BusyTimeout. 
        /// </summary>
        /// <typeparam name="T">IUIItem type e.g. Button, TextBox</typeparam>
        /// <returns>An array of Items of T</returns>
        T[] GetMultiple<T>() where T : IUIItem;

        /// <summary>
        /// Finds all UIItems of type T and adhering to a specific Search Criteria using the default BusyTimeout. 
        /// Look at documentation of SearchCriteria for details on it.
        /// </summary>
        /// <typeparam name="T">IUIItem type e.g. Button, TextBox</typeparam>
        /// <param name="searchCriteria">Criteria provided to search IUIItem</param>
        /// <returns>An array of Items of T</returns>
        T[] GetMultiple<T>(SearchCriteria searchCriteria) where T : IUIItem;

        #endregion

        #region UI Item Exists

        /// <summary>
        /// Checks if an UIItem which matches specified type exists.
        /// </summary>
        /// <typeparam name="T">IUIItem type e.g. Button, TextBox</typeparam>
        /// <returns><c>true</c> if there is any; otherwise, <c>false</c>.</returns>
        bool Exists<T>() where T : IUIItem;

        /// <summary>
        /// Checks if an UIItem which matches specified type exists.
        /// </summary>
        /// <typeparam name="T">IUIItem type e.g. Button, TextBox</typeparam>
        /// <param name="primaryIdentification">
        /// For managed application this is the name provided in application code and unmanaged application this is
        /// the text or label next to it based identification
        /// </param>
        /// <returns><c>true</c> if there is any; otherwise, <c>false</c>.</returns>
        bool Exists<T>(string primaryIdentification) where T : IUIItem;

        /// <summary>
        /// Checks if an UIItem which matches specified type exists.
        /// </summary>
        /// <typeparam name="T">IUIItem type e.g. Button, TextBox</typeparam>
        /// <param name="searchCriteria">Criteria provided to search UIItem</param>
        /// <returns><c>true</c> if there is any; otherwise, <c>false</c>.</returns>
        bool Exists<T>(SearchCriteria searchCriteria) where T : IUIItem;

        /// <summary>
        /// Checks if an UIItem which matches specified search criteria exists.
        /// <param name="searchCriteria">Criteria provided to search UIItem</param>
        /// <returns><c>true</c> if there is any; otherwise, <c>false</c>.</returns>
        bool Exists(SearchCriteria searchCriteria);

        #endregion
    }
}