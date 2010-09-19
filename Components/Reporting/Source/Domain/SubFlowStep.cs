using System.Collections.Generic;
using System.Text;

namespace Reporting.Domain
{
    public class SubFlowStep
    {
        private string label;
        private string logs;
        private int timeSpent;
        private readonly IList<ScreenShot> screenShots = new List<ScreenShot>();

        public virtual string Logs
        {
            get { return logs; }
            set { logs = value; }
        }

        public virtual string Label
        {
            get { return label; }
            set { label = value; }
        }

        public virtual IList<ScreenShot> ScreenShots
        {
            get { return screenShots; }
        }

        public virtual int TimeSpent
        {
            get { return timeSpent; }
            set { timeSpent = value; }
        }

        public virtual void AddScreenShot(ScreenShot screenShot)
        {
            screenShots.Add(screenShot);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Label: " + label);
            builder.AppendLine("Time spent: " + timeSpent + "ms");
            builder.AppendLine("SnapshotPaths: ");
            foreach (ScreenShot path in screenShots)
                builder.AppendLine(path.SnapShotPath);
            return builder.ToString();
        }
    }
}