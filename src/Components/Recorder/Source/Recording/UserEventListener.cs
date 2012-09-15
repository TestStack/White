namespace Recorder.Recording
{
    public interface UserEventListener
    {
        void NewEvent(string userAction);
        void UpdateEvent(string userAction);
    }
}