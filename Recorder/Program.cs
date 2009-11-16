using System;
using System.Windows.Forms;
using White.Core.Logging;
using Recorder.Controllers;

namespace Recorder
{
    internal static class Program
    {
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
                WhiteLogger.Instance.Error("Exception in Main: ", e);
            }
        }

        static void RecorderException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            WhiteLogger.Instance.Error("Thread exception: ", e.Exception);
        }
    }
}