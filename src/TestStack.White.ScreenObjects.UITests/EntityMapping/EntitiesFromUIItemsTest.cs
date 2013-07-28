using System;
using TestStack.White.ScreenObjects.EntityMapping;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Infrastructure;
using TestStack.White.UnitTests.Repository.EntityMapping;
using Xunit;

namespace TestStack.White.ScreenObjects.UITests.EntityMapping
{
    public class EntitiesFromUIItemsTest : IDisposable
    {
        private readonly Application application;
        private readonly Window window;

        public EntitiesFromUIItemsTest()
        {
            application = new WinformsTestConfiguration().LaunchApplication();
            window = application.GetWindow("Form1");
        }

        [Fact]
        public void FromTable()
        {
            var table = window.Get<Table>("people");
            var entities = new Entities<Cricketer>(table);
            Assert.Equal(entities.Count, table.Rows.Count);
            Assert.Equal("Imran", entities[0].Name);
        }

        public void Dispose()
        {
            if (application != null) application.Kill();
        }
    }
}