using White.Core.UIItems.Finders;
using White.Core.UIItems.MenuItems;

namespace White.Core.UIItems.WindowStripControls
{
    public interface MenuContainer
    {
        Menu MenuItem(params string[] path);
        Menu MenuItemBy(params SearchCriteria[] path);
    }
}