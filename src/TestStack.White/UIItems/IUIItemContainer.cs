using White.Core.UIItems.Finders;

namespace White.Core.UIItems
{
    public interface IUIItemContainer : IUIItem
    {
        T Get<T>() where T : UIItem;
        T Get<T>(string primaryIdentification) where T : UIItem;
        T Get<T>(SearchCriteria searchCriteria) where T : UIItem;
        ToolTip ToolTip { get; }
        ToolTip GetToolTipOn(UIItem uiItem);
    }
}