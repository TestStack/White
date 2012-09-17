using White.Core.UIItems;
using White.Core.Utility;

namespace White.Core.UIItemEvents
{
    public class UIItemClickEvent : UserEvent
    {
        private static readonly string CachedActionName;

        static UIItemClickEvent()
        {
            CachedActionName = MethodNameResolver.NameFor<UIItem>(i => i.Click());
        }

        public UIItemClickEvent(IUIItem uiItem) : base(uiItem) {}

        protected override string ActionName(EventOption eventOption)
        {
            return CachedActionName;
        }
    }
}