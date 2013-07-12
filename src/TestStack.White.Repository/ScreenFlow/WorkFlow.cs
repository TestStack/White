using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Castle.Core.Logging;
using White.Core.Configuration;

namespace TestStack.White.Repository.ScreenFlow
{
    //TODO: Add the ability to run the tests at different speeds
    //TODO: Dump of the screen shot when the test fails
    //TODO: Taking screenshot and automationelement dump from VisualStudio class code
    //TODO: Class diagram for Session, Work* etc classes
    public class WorkFlow
    {
        private int step;
        private int snapshots;
        private Type currentScreenType = typeof (Nullable);
        private readonly GraphWriter graph;
        private readonly FlowWriter flow;
        private readonly string directory;
        private static readonly ILogger Logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(WorkFlow));

        public WorkFlow(string name, string archiveLocation)
        {
            Log("Starting flow " + name);
            directory = CreateNewDirectory(name, archiveLocation);
            graph = new GraphWriter(string.Format(@"{0}\graph.dot", directory));
            flow = new FlowWriter(string.Format(@"{0}\flow.dot", directory));
        }

        private static void Log(string format, params object[] args)
        {
            Logger.DebugFormat("± " + format, args);
        }

        private void TakeSnapShot()
        {
            string fileName = string.Format(@"{0}\{1}.png", directory, snapshots++);
            CaptureScreenTo(fileName);
        }

        private static void CaptureScreenTo(string fileName)
        {
            using (var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format24bppRgb))
            {
                using (Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot))
                {
                    gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size,
                                                 CopyPixelOperation.SourceCopy);
                }

                bmpScreenshot.Save(fileName, ImageFormat.Png);
            }
        }

        private string CreateNewDirectory(string flowName, string archiveLocation)
        {
            string result = string.Format(@"{0}\{1}", archiveLocation, flowName);
            if (Directory.Exists(result)) Directory.Delete(result,true);
            Directory.CreateDirectory(result);
            return result;
        }

        public virtual void Stop()
        {
            TakeSnapShot();
            Log("End of flow " + currentScreenType);
            graph.Stop(currentScreenType);
            flow.Stop(step, currentScreenType);
        }

        public virtual void Move(Type fromType, Type toType)
        {
            if(step == 0)
            {
                graph.Start(fromType);
                flow.Start(step, fromType);
            }
            Log("[{0}] -> [{1}]", fromType, toType);
            graph.AppendFlow(fromType, toType);
            flow.AppendFlow(step, fromType, toType);
            step++;
            currentScreenType = toType;
        }

        public virtual void Error()
        {
            graph.AppendError();
            flow.AppendError();
        }

        public virtual void Track()
        {
            TakeSnapShot();
        }
    }
}