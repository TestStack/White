using System;
using TestStack.White.UIItems;

namespace TestStack.White.UIItemEvents
{
    public class ExceptionEvent : UserEvent
    {
        private readonly Exception exception;

        public ExceptionEvent(IUIItem uiItem, Exception exception) : base(uiItem)
        {
            this.exception = exception;
        }

        protected override string ActionName(IEventOption eventOption)
        {
            return exception.ToString();
        }
    }
}