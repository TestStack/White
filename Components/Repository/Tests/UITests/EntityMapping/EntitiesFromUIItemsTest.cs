using NUnit.Framework;
using Repository.EntityMapping;
using White.Core;
using White.Core.UIItems.TableItems;
using White.Core.UIItems.WindowItems;
using White.Core.UITests;
using White.Repository.UnitTests.EntityMapping;

namespace White.Repository.Tests.EntityMapping
{
    [TestFixture]
    public class EntitiesFromUIItemsTest
    {
        private Application application;
        private Window window;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            var configuration = new WinFormTestConfiguration(string.Empty);
            application = configuration.Launch();
            window = application.GetWindow("Form1");
        }

        [Test]
        public void FromTable()
        {
            var table = window.Get<Table>("people");
            var entities = new Entities<Cricketer>(table);
            Assert.AreEqual(entities.Count, table.Rows.Count);
            Assert.AreEqual("Imran", entities[0].Name);
        }

        [TearDown]
        public void TearDown()
        {
            if (application != null) application.Kill();
        }
    }
}