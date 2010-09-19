using White.Core.UIItemEvents;

namespace Recorder.Recording
{
    internal interface EventFilter
    {
        bool UseEvent(UserEvent userEvent, UserEvent lastUserEvent);
    }
}