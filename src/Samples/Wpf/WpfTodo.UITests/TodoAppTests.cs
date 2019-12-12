// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TodoAppTests.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the TodoAppTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfTodo.UITests
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using NUnit.Framework;

    using TestStack.White.Configuration;
    using TestStack.White.Factory;
    using TestStack.White.ScreenObjects.Services;
    using TestStack.White.ScreenObjects.Sessions;

    using WpfTodo.UITests.Screens;

    /// <summary>
    ///     The to-do app tests.
    /// </summary>
    [TestFixture]
    [Ignore("For passing CI build.")]
    public class TodoAppTests : UITestBase
    {
        /// <summary>
        ///     The automate test.
        /// </summary>
        [Test]
        public void AutomateTest()
        {
            var workPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            var workConfiguration = new WorkConfiguration { ArchiveLocation = workPath, Name = "WpfTodo" };

            if (workPath != null)
            {
                CoreAppXmlConfiguration.Instance.WorkSessionLocation = new DirectoryInfo(workPath);
            }

            using (var workSession = new WorkSession(workConfiguration, new NullWorkEnvironment()))
            {
                var screenRepository = workSession.Attach(Application);
                var mainWindow = screenRepository.Get<TodoWindow>("Wpf Todo", InitializeOption.NoCache);
                var newTaskScreen = mainWindow.NewTask();

                const string Title = "Write some tests";
                newTaskScreen.Title = Title;
                newTaskScreen.Description = "for White";
                newTaskScreen.DueDate = DateTime.Now.AddDays(3);

                newTaskScreen.Create();

                var tasks = mainWindow.Tasks.ToList();
                Assert.That(tasks, Has.Count.EqualTo(1));
                Assert.That(tasks[0].Title, Is.EqualTo(Title));
            }
        }
    }
}
