using System;
using TestStack.White.UIItems;

namespace TestStack.White.UIItemEvents
{
    public abstract class UserEvent
    {
        protected readonly IUIItem uiItem;
        private readonly DateTime timestamp;

        public UserEvent(IUIItem uiItem)
        {
            this.uiItem = uiItem;
            timestamp = DateTime.Now;
        }

        public virtual DateTime Timestamp
        {
            get { return timestamp; }
        }

        public virtual Type UIItemType
        {
            get { return uiItem.GetType(); }
        }

        protected abstract string ActionName(EventOption eventOption);

        public virtual object[] ActionParameters
        {
            get { return new object[0]; }
        }

        public virtual void WriteTo(EventWriter eventWriter, EventOption eventOption)
        {
            eventWriter.Write(UIItemType, ActionName(eventOption), uiItem.PrimaryIdentification, ActionParameters);
        }

        public virtual bool IsRepeatEvent(UserEvent otherEvent)
        {
            return false;
        }

        public virtual bool IsIdenfiedAs(string identification)
        {
            return uiItem.PrimaryIdentification.Equals(identification);
        }
    }
}