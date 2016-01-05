using System.Threading;
using System.Windows.Automation;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UIItems.MenuItems
{
    /// <summary>
    /// Models Menu items (root or leaf). SubMenus can be retrieved from it which by themselves are Menu(s).
    /// </summary>
    public class Menu : UIItem
    {
        Menus childMenus;

        protected Menu() {}
        public Menu(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener) {}

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
                Click();
                Thread.Sleep(250);
                childMenus = new Menus(automationElement, actionListener);
                return childMenus;
            }
        }
    }
}