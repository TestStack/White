using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;

namespace TestStack.White.UIItems.WindowStripControls
{
    public interface IMenuContainer
    {
        Menu MenuItem(params string[] path);
        Menu MenuItemBy(params SearchCriteria[] path);
    }
}