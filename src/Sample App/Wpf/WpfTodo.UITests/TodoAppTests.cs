using System;
using System.IO;
using System.Linq;
using System.Reflection;
using TestStack.White.Factory;
using TestStack.White.Repository.Services;
using TestStack.White.Repository.Sessions;
using WpfTodo.UITests.Screens;
using Xunit;

namespace WpfTodo.UITests
{
    public class TodoAppTests : UITestBase
    {
        [Fact]
        public void Automate()
        {
            using (var workSession = new WorkSession(new WorkConfiguration
            {
                ArchiveLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                Name = "WpfTodo"
            }, new NullWorkEnvironment()))
            {
                var screenRepository = workSession.Attach(Application);
                var mainWindow = screenRepository.Get<TodoWindow>("Wpf Todo", InitializeOption.NoCache);
                var newTaskScreen = mainWindow.NewTask();

                const string title = "Write some tests";
                newTaskScreen.Title = title;
                newTaskScreen.Description = "for White";
                newTaskScreen.DueDate = DateTime.Now.AddDays(3);

                newTaskScreen.Create();

                var tasks = mainWindow.Tasks.ToList();
                Assert.Equal(1, tasks.Count);
                Assert.Equal(title, tasks[0].Title);
            }
        }
    }
}