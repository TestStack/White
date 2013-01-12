using System;
using System.Linq;
using NUnit.Framework;
using WpfTodo.UITests.Screens;

namespace WpfTodo.UITests
{
    public class TodoAppTests : UITestBase
    {
        [Test]
        public void CodedUITestMethod1()
        {
            var newTaskScreen = MainWindow.NewTask();

            const string title = "Write some tests";
            newTaskScreen.Title = title;
            newTaskScreen.Description = "for White";
            newTaskScreen.DueDate = DateTime.Now.AddDays(3);

            newTaskScreen.Create();

            var tasks = MainWindow.Tasks.ToList();
            Assert.AreEqual(1, tasks.Count);
            Assert.AreEqual(title, tasks[0].Title);
        }
    }
}