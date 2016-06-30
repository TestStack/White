// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UITestBase.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the UITestBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfTodo.UITests.Screens
{
    using System;
    using System.IO;
    using System.Reflection;

    using TestStack.White;

    /// <summary>
    /// The UI test base.
    /// </summary>
    public abstract class UITestBase : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UITestBase"/> class.
        /// </summary>
        protected UITestBase()
        {
            var directoryName = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            if (directoryName != null)
            {
                var markpadLocation = Path.Combine(directoryName, @"WpfTodo.exe");
                Application = Application.Launch(markpadLocation);
            }
        }

        /// <summary>
        /// Gets the application.
        /// </summary>
        protected Application Application { get; private set; }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            Application.Dispose();
        }
    }
}