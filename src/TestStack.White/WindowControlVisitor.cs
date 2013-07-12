using TestStack.White.UIItems;

namespace TestStack.White
{
    public interface WindowControlVisitor
    {
        void Accept(UIItem uiItem);
    }
}