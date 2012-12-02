using White.Core.UIItems;

namespace White.Core
{
    public interface WindowControlVisitor
    {
        void Accept(UIItem uiItem);
    }
}