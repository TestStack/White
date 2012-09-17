using System;
using System.Windows.Forms;
using Recorder;
using Recorder.Controllers;
using log4net;

namespace White.Recorder
{
    internal static class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += RecorderException;
                Application.Run(new DashBoard(new DashboardController()));
            }
            catch (Exception e)
            {
                Logger.Error("Exception in Main: ", e);
            }
        }

        static void RecorderException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Logger.Error("Thread exception: ", e.Exception);
        }
    }
}