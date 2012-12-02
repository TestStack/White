namespace White.Core.UIItems.TabItems
{
    public interface ITabPage : IUIItem
    {
        bool IsSelected { get; }
        void Select();
    }
}