using System.Windows.Automation;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;
using White.Core.UIItems.MenuItems;

namespace White.Core.UIItems.WindowStripControls
{
    public class StatusStrip : ContainerStrip, MenuContainer
    {
        private readonly Menus topLevelMenu;
        protected StatusStrip() {}

        public StatusStrip(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
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
    }
}