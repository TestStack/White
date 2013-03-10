using System.Windows.Automation;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;
using White.Core.UIItems.MenuItems;

namespace White.Core.UIItems.WindowStripControls
{
    public class MenuBar : UIItem, MenuContainer, IMappableUIItem
    {
        private readonly Menus topLevelMenu;
        protected MenuBar() {}

        public MenuBar(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
        {
            topLevelMenu = new Menus(automationElement, actionListener);
        }

        public virtual Menu MenuItem(params string[] path)
        {
            return topLevelMenu.Find(path);
        }

        public virtual Menu MenuItemBy(params SearchCriteria[] path)
        {
            return topLevelMenu.Find(path);
        }

        public virtual Menus TopLevelMenu
        {
            get { return topLevelMenu; }
        }
    }
}