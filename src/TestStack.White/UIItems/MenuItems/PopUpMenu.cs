using System.Windows.Automation;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UIItems.MenuItems
{
    public class PopUpMenu : UIItem
    {
        protected PopUpMenu() {}

        public PopUpMenu(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener)
        {
            this.actionListener = actionListener;
        }

        public virtual Menus Items
        {
            get { return new Menus(automationElement, actionListener); }
        }

        public virtual Menu Item(params string[] text)
        {
            return Items.Find(text);
        }

        public virtual Menu ItemBy(params SearchCriteria[] path)
        {
            return Items.Find(path);
        }
    }
}