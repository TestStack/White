using System;
using TestStack.White.Repository.EntityMapping;
using TestStack.White.Repository.UnitTests.EntityMapping;
using TestStack.White.UITests.Infrastructure;
using White.Core;
using White.Core.UIItems.TableItems;
using White.Core.UIItems.WindowItems;
using Xunit;

namespace TestStack.White.Repository.UITests.EntityMapping
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