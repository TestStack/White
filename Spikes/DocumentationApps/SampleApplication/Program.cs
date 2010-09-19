using System;
using System.Windows.Forms;

namespace SampleApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Dashboard dashboard = new Dashboard();
            dashboard.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(dashboard);
        }
    }
}