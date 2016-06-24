using System;
using System.Windows.Automation;
using Castle.Core.Logging;
using TestStack.White.Configuration;
using TestStack.White.UIItemEvents;
using TestStack.White.UIItems;

namespace TestStack.White.Recording
{
    public class SafeAutomationEventHandler
    {
        private readonly IUIItem uiItem;
        private readonly Create createUserEvent;
        private readonly IUIItemEventListener eventListener;
        private readonly ILogger logger = CoreConfigurationLocator.Get().LoggerFactory.Create(typeof(SafeAutomationEventHandler));

        public delegate UserEvent Create(object[] parameters);

        public SafeAutomationEventHandler(IUIItem uiItem, IUIItemEventListener eventListener, Create createUserEvent)
        {
            this.uiItem = uiItem;
            this.eventListener = eventListener;
            this.createUserEvent = createUserEvent;
        }

        public virtual void PropertyChange(object sender, AutomationPropertyChangedEventArgs e)
        {
            UserEvent userEvent = UserEvent(e);
            if (null == userEvent) return;
            try
            {
                eventListener.EventOccured(userEvent);
            }
            catch (Exception exception)
            {
                logger.Error("", exception);
            }
        }

        private UserEvent UserEvent(AutomationPropertyChangedEventArgs e)
        {
            UserEvent userEvent;
            try
            {
                userEvent = createUserEvent.Invoke(new object[] {e});
            }
            catch (Exception exception)
            {
                userEvent = new ExceptionEvent(uiItem, exception);
            }
            return userEvent;
        }
    }
}