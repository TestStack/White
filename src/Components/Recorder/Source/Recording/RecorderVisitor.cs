using System;
using System.Collections.Generic;
using White.Core;
using White.Core.Recording;
using White.Core.UIItemEvents;
using White.Core.UIItems;
using Recorder.Domain;
using log4net;

namespace Recorder.Recording
{
    // TODO: What happens when new control is created by the application.
    public class RecorderVisitor : WindowControlVisitor, UIItemEventListener
    {
        private readonly RecordingOptions recordingOptions;
        private readonly List<EventFilter> filters = new List<EventFilter>();
        private readonly UserEventListener userEventListener;
        private readonly UserAction userAction = new UserAction();
        private ILog logger = LogManager.GetLogger(typeof(RecorderVisitor));

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
                    logger.Debug("Updating last event with: " + userAction);
                    userEventListener.UpdateEvent(eventWriter.Code);
                }
                else
                {
                    logger.Debug("Creating new event: " + userAction);
                    userEventListener.NewEvent(eventWriter.Code);
                }
            }
            catch (Exception e)
            {
                logger.Info("Error during event callback", e);
            }
        }
    }
}