using NUnit.Framework;
using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Custom;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class CustomUIItemTests : WhiteUITestBase
    {
        private Window window;

        public CustomUIItemTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            window = StartScenario("CustomUIItemScenario", "CustomUIItemScenario");
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            window.Dispose();
        }

        [Test]
        public void FindCustomItemTest()
        {
            var myDateUIItem = window.Get<MyDateUIItem>("DateOfBirth");
            Assert.That(myDateUIItem, Is.Not.Null);
            myDateUIItem.EnterDate(DateTime.Today);
        }

        [Test]
        public void NoDateUIItemMappingDefinedTest()
        {
            Assert.Throws<CustomUIItemException>(() => window.Get<MyDateUIItemWithoutMappingDefined>("DateOfBirth"));
        }
    }
}