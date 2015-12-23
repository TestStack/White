using System;
using System.IO;
using System.Reflection;
using TestStack.White;

namespace WpfTodo.UITests.Screens
{
    public abstract class UITestBase : IDisposable
    {
        public Application Application { get; private set; }

        protected UITestBase()
        {
            var directoryName = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            var markpadLocation = Path.Combine(directoryName, @"WpfTodo.exe");
            Application = Application.Launch(markpadLocation);
        }

        public void Dispose()
        {
            Application.Dispose();
        }
    }
}