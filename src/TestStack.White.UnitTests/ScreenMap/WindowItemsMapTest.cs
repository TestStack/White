using System.IO;
using System.Windows;
using NUnit.Framework;
using White.Core.Factory;
using White.Core.ScreenMap;
using White.Core.UIA;
using White.Core.UIItems.Finders;

namespace White.Core.UnitTests.ScreenMap
{
    [TestFixture, Category("Normal")]
    public class WindowItemsMapTest
    {
        [SetUp]
        public void SetUp()
        {
            File.Delete("foo.xml");
        }

        [Test]
        public void ReplaceExistingLocationIfExists()
        {
            WindowItemsMap windowItemsMap = WindowItemsMap.Create(InitializeOption(), RectX.UnlikelyWindowPosition);
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByAutomationId("foo"));
            var newPoint = new Point(1, 2);
            windowItemsMap.Add(newPoint, SearchCriteria.ByAutomationId("foo"));
            Assert.AreEqual(1, windowItemsMap.UIItemLocations.Count);
            Assert.AreEqual(newPoint, windowItemsMap.UIItemLocations[0].Point);
        }

        private InitializeOption InitializeOption()
        {
            return Factory.InitializeOption.NoCache.AndIdentifiedBy("foo");
        }

        [Test]
        public void ReplaceExistingLocationWhenSearchCriteriaChangesForTheSamePoint()
        {
            WindowItemsMap windowItemsMap = WindowItemsMap.Create(InitializeOption(), RectX.UnlikelyWindowPosition);
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByAutomationId("foo"));
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByText("foo"));

            Assert.AreEqual(1, windowItemsMap.UIItemLocations.Count);
        }

        [Test]
        public void GetItemLocationWhenNotPresent()
        {
            WindowItemsMap windowItemsMap = WindowItemsMap.Create(InitializeOption(), RectX.UnlikelyWindowPosition);
            Assert.AreEqual(RectX.UnlikelyWindowPosition, windowItemsMap.GetItemLocation(SearchCriteria.ByText("foo")));
        }

        [Test]
        public void GetItemLocation()
        {
            WindowItemsMap windowItemsMap = WindowItemsMap.Create(InitializeOption(), RectX.UnlikelyWindowPosition);
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByAutomationId("foo"));
            Assert.AreEqual(new Point(1, 1), windowItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")));
        }

        [Test]
        public void GetItemLocationWhenWindowPositionChanges()
        {
            WindowItemsMap windowsItemsMap = WindowItemsMap.Create(InitializeOption(), new Point(20, 20));
            windowsItemsMap.Add(new Point(27, 27), SearchCriteria.ByAutomationId("foo"));
            windowsItemsMap.Save();

            windowsItemsMap = WindowItemsMap.Create(InitializeOption(), new Point(5, 5));
            Assert.AreEqual(new Point(12, 12), windowsItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")));

            windowsItemsMap.CurrentWindowPosition = new Point(10, 10);
            Assert.AreEqual(new Point(17, 17), windowsItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")));
        }
    }
}