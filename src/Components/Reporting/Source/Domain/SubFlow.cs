using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using White.Core;
using log4net;

namespace Reporting.Domain
{
    public class SubFlow
    {
        private readonly string archiveLocation;
        private readonly IList<SubFlowStep> flowSteps = new List<SubFlowStep>();
        private int currentFlowStepSnapShot;
        private readonly string directory;
        private DateTime screenCreationTime;
        private readonly string name;
        private static readonly ILog logger = LogManager.GetLogger(typeof(SubFlow));

        public SubFlow(string subFlowName, string flowName, string archiveLocation)
        {
            this.archiveLocation = archiveLocation;
            name = subFlowName;
            directory = CreateNewDirectory(subFlowName, archiveLocation, flowName);
        }

        public virtual IList<SubFlowStep> FlowSteps
        {
            get { return flowSteps; }
        }

        public virtual void Next(Type type)
        {
            currentFlowStepSnapShot = 0;
            var subFlowStep = new SubFlowStep {Label = type.Name};
            subFlowStep.AddScreenShot(TakeScreenShot(type.Name));
            flowSteps.Add(subFlowStep);
            screenCreationTime = DateTime.Now;
        }

        public virtual void Act()
        {
            if (!IsEmpty)
            {
                SubFlowStep previousSubFlowStep = flowSteps[flowSteps.Count - 1];
                previousSubFlowStep.AddScreenShot(TakeScreenShot(previousSubFlowStep.Label));
                previousSubFlowStep.TimeSpent = (DateTime.Now - screenCreationTime).Milliseconds;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (SubFlowStep node in flowSteps)
                builder.AppendLine(node.ToString());
            return builder.ToString();
        }

        private bool IsEmpty
        {
            get { return flowSteps.Count == 0; }
        }

        public virtual string Name
        {
            get { return name; }
        }

        private ScreenShot TakeScreenShot(string typeName)
        {
            string fileName = string.Format(@"{0}\{1}-{2}.png", directory, typeName, ++currentFlowStepSnapShot);
            string thumbNailName = string.Format(@"{0}\thumbNails\{1}-{2}-tn.png", directory, typeName, currentFlowStepSnapShot);
            CaptureScreenTo(fileName, thumbNailName);
            return new ScreenShot(fileName.Replace(archiveLocation + @"\", string.Empty), thumbNailName.Replace(archiveLocation + @"\", string.Empty));
        }

        private static void CaptureScreenTo(string fileName, string thumbNailName)
        {
            using (var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format24bppRgb))
            {
                using (Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot))
                {
                    gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size,
                                                 CopyPixelOperation.SourceCopy);
                }

                try
                {
                    using (FileStream stream = File.Create(fileName))
                        bmpScreenshot.Save(stream, ImageFormat.Png);
                    using (FileStream stream = File.Create(thumbNailName))
                        bmpScreenshot.GetThumbnailImage(50, 50, () => true, IntPtr.Zero).Save(stream, ImageFormat.Png);
                }
                catch (Exception e)
                {
                    logger.Error(string.Format("Error saving : {0}", fileName), e);
                    throw new WhiteException(string.Format("Error saving image {0}", fileName), e);
                }
            }
        }

        private static string CreateNewDirectory(string subFlowName, string archiveLocation, string flowName)
        {
            string result = string.Format(@"{0}\{1}\{2}", archiveLocation, flowName, subFlowName);
            if (Directory.Exists(result))
                result = string.Format(@"{0}\{1}\{2}", archiveLocation, flowName, subFlowName + CurrentTimeStamp());
            Directory.CreateDirectory(result);
            Directory.CreateDirectory(result + @"\thumbNails");
            return result;
        }

        private static string CurrentTimeStamp()
        {
            DateTime now = DateTime.Now;
            return "" + now.Day + now.Month + now.Year + now.Hour + now.Minute + now.Second;
        }
    }
}