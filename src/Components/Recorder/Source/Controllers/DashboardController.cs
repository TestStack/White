using Recorder.Domain;

namespace Recorder.Controllers
{
    public class DashboardController
    {
        private readonly WhiteRecorder whiteRecorder;

        public DashboardController()
        {
            whiteRecorder = new WhiteRecorder();
        }

        public virtual WhiteRecorder Recorder
        {
            get { return whiteRecorder; }
        }
    }
}