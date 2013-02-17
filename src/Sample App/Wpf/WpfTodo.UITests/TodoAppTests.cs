using System;
using System.Linq;
using NUnit.Framework;
using Repository;
using White.Core.Factory;
using WpfTodo.UITests.Screens;

namespace WpfTodo.UITests
{
    public class TodoAppTests : UITestBase
    {
        [Test]
        public void TestMethod1()
        {
            var mainWindow = new ScreenRepository(Application).Get<TodoWindow>("Wpf Todo", InitializeOption.NoCache);
            var newTaskScreen = mainWindow.NewTask();

            const string title = "Write some tests";
            newTaskScreen.Title = title;
            newTaskScreen.Description = "for White";
            newTaskScreen.DueDate = DateTime.Now.AddDays(3);

            newTaskScreen.Create();

            var tasks = mainWindow.Tasks.ToList();
            Assert.AreEqual(1, tasks.Count);
            Assert.AreEqual(title, tasks[0].Title);
        }
    }
}