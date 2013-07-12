using System.Windows.Automation;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UIItems.MenuItems
{
    public class PopUpMenu : UIItem
    {
        private readonly Menus topLevelMenus;
        protected PopUpMenu() {}

        public PopUpMenu(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
        {
            this.actionListener = actionListener;
            topLevelMenus = new Menus(automationElement, actionListener);
        }

        public virtual Menus Items
        {
            get { return topLevelMenus; }
        }

        public virtual Menu Item(params string[] text)
        {
            return topLevelMenus.Find(text);
        }

        public virtual Menu ItemBy(params SearchCriteria[] path)
        {
            return topLevelMenus.Find(path);
        }
    }
}