using TestStack.White.UIItems;

namespace TestStack.White
{
    public interface IWindowControlVisitor
    {
        void Accept(UIItem uiItem);
    }
}