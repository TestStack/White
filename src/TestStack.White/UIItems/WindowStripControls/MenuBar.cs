using System.Windows.Automation;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;

namespace TestStack.White.UIItems.WindowStripControls
{
    public class MenuBar : UIItem, IMenuContainer
    {
        protected MenuBar() {}

        public MenuBar(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener)
        {
        }

        public virtual Menu MenuItem(params string[] path)
        {
            return TopLevelMenu.Find(path);
        }

        public virtual Menu MenuItemBy(params SearchCriteria[] path)
        {
            return TopLevelMenu.Find(path);
        }

        public virtual Menus TopLevelMenu
        {
            get { return new Menus(automationElement, actionListener); }
        }
    }
}