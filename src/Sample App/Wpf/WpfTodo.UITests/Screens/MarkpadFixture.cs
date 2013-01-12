using System.IO;
using System.Reflection;
using NUnit.Framework;
using White.Core;

namespace WpfTodo.UITests.Screens
{
    public class UITestBase
    {
        public Application Application { get; private set; }
        public TodoWindow MainWindow { get; private set; }

        [TestFixtureSetUp]
        public void Setup()
        {
            var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var markpadLocation = Path.Combine(directoryName, @"WpfTodo.exe");
            Application = Application.Launch(markpadLocation);
            MainWindow = new TodoWindow(Application, Application.GetWindow("Wpf Todo"));
        }

        [TestFixtureTearDown]
        public void Teardown()
        {
            MainWindow.WhiteWindow.Close();
            Application.Dispose();
        }
    }
}