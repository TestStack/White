using White.Core;
using White.Core.UIItems;

namespace Recorder.Recording
{
    public class UnHookEventsVisitor : WindowControlVisitor
    {
        public virtual void Accept(UIItem uiItem)
        {
            try { uiItem.UnHookEvents();} catch {}
        }
    }
}