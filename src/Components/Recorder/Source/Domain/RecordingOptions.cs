using White.Core.UIItemEvents;
using Recorder.Recording;

namespace Recorder.Domain
{
    //TODO: Provide option for not recording stuff like GroupBox, label etc
    public class RecordingOptions : EventOption
    {
        private bool core;
        private bool bulkText = true;

        public virtual bool Core
        {
            get { return core; }
            set { core = value; }
        }

        public virtual bool ScreenRepository
        {
            get { return !Core; }
            set { core = !value; }
        }

        public virtual bool BulkText
        {
            get { return bulkText; }
            set { bulkText = value; }
        }

        public virtual EventWriter EventWriter
        {
            get { return core ? (EventWriter) new CoreCodeWriter() : new RepositoryCodeWriter();}
        }
    }
}