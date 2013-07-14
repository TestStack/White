namespace TestStack.White.UIItems.TabItems
{
    public interface ITabPage : IUIItemContainer
    {
        bool IsSelected { get; }
        void Select();
    }
}