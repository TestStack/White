using System;
using System.Collections.Generic;
using White.Core;
using White.Core.Logging;
using White.Core.Recording;
using White.Core.UIItemEvents;
using White.Core.UIItems;
using Recorder.Domain;

namespace Recorder.Recording
{
    // TODO: What happens when new control is created by the application.
    public class RecorderVisitor : WindowControlVisitor, UIItemEventListener
    {
        private readonly RecordingOptions recordingOptions;
        private readonly List<EventFilter> filters = new List<EventFilter>();
        private readonly UserEventListener userEventListener;
        private readonly UserAction userAction = new UserAction();

        public RecorderVisitor(UserEventListener userEventListener, RecordingOptions recordingOptions)
        {
            this.recordingOptions = recordingOptions;
            this.userEventListener = userEventListener;
            filters.Add(new DuplicateEventFilter());
        }

        public virtual void Accept(UIItem uiItem)
        {
            uiItem.HookEvents(this);
        }

        public virtual void EventOccured(UserEvent userEvent)
        {
            try
            {
                bool useEvent = true;
                foreach (EventFilter filter in filters)
                {
                    useEvent &= filter.UseEvent(userEvent, userAction.LastEvent);
                    if (!useEvent) return;
                }
                userAction.Register(userEvent);

                EventWriter eventWriter = recordingOptions.EventWriter;
                userAction.CurrentUserEvent.WriteTo(eventWriter, recordingOptions);
                if (userAction.RepeatEvent)
                {
                    WhiteLogger.Instance.Debug("Updating last event with: " + userAction);
                    userEventListener.UpdateEvent(eventWriter.Code);
                }
                else
                {
                    WhiteLogger.Instance.Debug("Creating new event: " + userAction);
                    userEventListener.NewEvent(eventWriter.Code);
                }
            }
            catch (Exception e)
            {
                WhiteLogger.Instance.Info("Error during event callback", e);
            }
        }
    }
}