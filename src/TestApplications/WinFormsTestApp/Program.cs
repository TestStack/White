using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace WinFormsTestApp
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var forms = new Dictionary<string, Form>
                                 {
                                     {"NoTitleBar", GetFormWithNoTitleBar()},
                                     {"PropertyGrid", new FormWithPropertyGrid()},
                                     {"LargeTree", new FormContainingLargeTree()},
                                     {"ReverseTab", new TabControlsWithSpecialProperties()},
                                     {"ListView", new ListViewScenarios()},
                                 };


            if (Environment.CommandLine.Contains("splash"))
            {
                var screen = new SplashScreen();
                screen.Show();
                MessageBox.Show("Bar", "Foo");
                screen.Close();
                return;
            }

            try
            {
                KeyValuePair<string, Form> keyValuePair = forms.First(pair => Environment.CommandLine.Contains(pair.Key));
                Application.Run(keyValuePair.Value);
                return;
            }
            catch (InvalidOperationException)
            {
            }

            var form = new Form1(Environment.CommandLine.Contains("ModalAtClose"));
            if (Environment.CommandLine.Contains("ampersand"))
                form.Text = "Form&1";
            if (Environment.CommandLine.Contains("notitle"))
                form.FormBorderStyle = FormBorderStyle.None;
            if (Environment.CommandLine.Contains("notableheader"))
                form.NoTableHeader();
            Application.Run(form);
        }

        private static Form1 GetFormWithNoTitleBar()
        {
            return new Form1(false) {ControlBox = false, FormBorderStyle = FormBorderStyle.None};
        }
    }
}