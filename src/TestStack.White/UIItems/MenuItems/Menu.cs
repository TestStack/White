using System.Windows.Automation;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;

namespace White.Core.UIItems.MenuItems
{
    /// <summary>
    /// Models Menu items (root or leaf). SubMenus can be retrieved from it which by themselves are Menu(s).
    /// </summary>
    public class Menu : UIItem, IMappableUIItem
    {
        private Menus childMenus;
        protected Menu() {}
        public Menu(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        /// <summary>
        /// Get a child menu based on the text. Text in UIA translates too Name property
        /// </summary>
        /// <param name="text">Visible text of the child menu</param>
        /// <returns></returns>
        public virtual Menu SubMenu(string text)
        {
            return SubMenu(SearchCriteria.ByText(text));
        }

        /// <summary>
        /// Get a child menu based on any search criteria. Use SubMenu(string) for searching based on visible text
        /// </summary>
        /// <param name="searchCriteria">Search criteria for the child menu</param>
        /// <returns></returns>
        public virtual Menu SubMenu(SearchCriteria searchCriteria)
        {
            return ChildMenus.Find(searchCriteria);
        }

        /// <summary>
        /// Returns all the ChildMenus belonging to this Menu.
        /// </summary>
        public virtual Menus ChildMenus
        {
            get
            {
                if (childMenus != null) return childMenus;
                childMenus = new Menus(automationElement, actionListener);
                return childMenus;
            }
        }
    }
}