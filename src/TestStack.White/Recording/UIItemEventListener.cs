using TestStack.White.UIItemEvents;

namespace TestStack.White.Recording
{
    public interface IUIItemEventListener
    {
        void EventOccured(UserEvent userEvent);
    }
}