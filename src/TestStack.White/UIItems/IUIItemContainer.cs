using White.Core.UIItems.Finders;

namespace White.Core.UIItems
{
    public interface IUIItemContainer : IUIItem
    {
        /// <summary>
        /// Finds UIItem which matches specified type. Useful for non managed applications where controls are not identified by AutomationId, like in 
        /// Managed applications. In case of multiple items of this type the first one found would be returned which cannot be guaranteed to be the same 
        /// across multiple invocations.
        /// </summary>
        /// <typeparam name="T">IUIItem type e.g. Button, TextBox</typeparam>
        /// <returns>First item of supplied type</returns>
        /// <exception cref="AutomationException">when item not found</exception>
        /// <exception cref="WhiteException">when any errors occured during search</exception>
        T Get<T>() where T : IUIItem, IMappableUIItem;

        /// <summary>
        /// Finds UIItem which matches specified type and identification. 
        /// In case of multiple items of this type the first one found would be returned which cannot be guaranteed to be the same across multiple 
        /// invocations. For managed applications this is name given to controls in the application code.
        /// For unmanaged applications this is text of the control or label next to it if it doesn't have well defined text.
        /// <!--e.g. TextBox doesn't have any predefined text of its own as it can be changed at runtime by user, hence is identified by the label next to it.
        /// If there is no label then Get<T> or Get<T>(SearchCriteria) method can be used.-->
        /// </summary>
        /// <typeparam name="T">IUIItem implementation</typeparam>
        /// <param name="primaryIdentification">For managed application this is the name provided in application code and unmanaged application this is 
        /// the text or label next to it based identification</param>
        /// <returns>First item of supplied type and identification</returns>
        /// <exception cref="AutomationException">when item not found</exception>
        /// <exception cref="WhiteException">when any errors occured during search</exception>
        T Get<T>(string primaryIdentification) where T : IUIItem, IMappableUIItem;

        /// <summary>
        /// Finds UIItem which matches specified type and searchCriteria. Type supplied need not be supplied again in SearchCondition.
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
        T Get<T>(SearchCriteria searchCriteria) where T : IUIItem, IMappableUIItem;

        /// <summary>
        /// Finds UIItem which matches specified type and searchCriteria using the default BusyTimeout. Look at documentation of SearchCriteria for details on it.
        /// </summary>
        /// <param name="searchCriteria">Criteria provided to search IUIItem</param>
        /// <returns>First items matching the criteria</returns>
        /// <exception cref="AutomationException">when item not found</exception>
        /// <exception cref="WhiteException">when any errors occured during search</exception>
        IUIItem Get(SearchCriteria searchCriteria);
    }
}