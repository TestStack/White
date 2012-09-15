using System;
using White.Core.UIItemEvents;

namespace Recorder.Recording
{
    public class DuplicateEventFilter : EventFilter
    {
        public static readonly TimeSpan TimeDifferenceBetweenTwoUserEvents = new TimeSpan(0, 0, 0, 0, 400);

        public virtual bool UseEvent(UserEvent userEvent, UserEvent lastUserEvent)
        {
            if (lastUserEvent == null || userEvent is TextBoxEvent || userEvent is TreeNodeClickedEvent) return true;
            TimeSpan span = userEvent.Timestamp - lastUserEvent.Timestamp;
            return span > TimeDifferenceBetweenTwoUserEvents;
        }
    }
}