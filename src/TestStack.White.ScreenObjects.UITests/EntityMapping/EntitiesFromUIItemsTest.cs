using NUnit.Framework;
using System;
using TestStack.White.ScreenObjects.EntityMapping;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Infrastructure;
using TestStack.White.UnitTests.Repository.EntityMapping;

namespace TestStack.White.ScreenObjects.UITests.EntityMapping
{
    [TestFixture]
    public class EntitiesFromUIItemsTest : IDisposable
    {
        private readonly Application application;
        private readonly Window window;

        public EntitiesFromUIItemsTest()
        {
            application = new WinformsTestConfiguration().LaunchApplication();
            window = application.GetWindow("MainWindow");
        }

        [Test]
        public void FromTable()
        {
            window.Tabs[0].SelectTabPage(3);
            var table = window.Get<Table>("DataGrid");
            var entities = new Entities<Cricketer>(table);
            Assert.That(entities, Has.Count.EqualTo(table.Rows.Count));
            Assert.That(entities[0].Name, Is.EqualTo("Imran"));
        }

        public void Dispose()
        {
            if (application != null) application.Kill();
        }
    }
}