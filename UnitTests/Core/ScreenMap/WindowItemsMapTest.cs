using System.IO;
using System.Windows;
using NUnit.Framework;
using White.Core.Factory;
using White.Core.ScreenMap;
using White.Core.UIA;
using White.Core.UIItems.Finders;

namespace White.UnitTests.Core.ScreenMap
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
            Assert.AreEqual(1, windowItemsMap.Count);
            Assert.AreEqual(newPoint, windowItemsMap[0].Point);
        }

        private InitializeOption InitializeOption()
        {
            return White.Core.Factory.InitializeOption.NoCache.AndIdentifiedBy("foo");
        }

        [Test]
        public void ReplaceExistingLocationWhenSearchCriteriaChangesForTheSamePoint()
        {
            WindowItemsMap windowItemsMap = WindowItemsMap.Create(InitializeOption(), RectX.UnlikelyWindowPosition);
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByAutomationId("foo"));
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByText("foo"));

            Assert.AreEqual(1, windowItemsMap.Count);
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
            WindowItemsMap windowItemsMap = WindowItemsMap.Create(InitializeOption(), new Point(5, 5));
            windowItemsMap.Add(new Point(7, 7), SearchCriteria.ByAutomationId("foo"));
            Assert.AreEqual(new Point(7, 7), windowItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")));

            windowItemsMap.CurrentWindowPosition = new Point(10, 10);
            Assert.AreEqual(new Point(12, 12), windowItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")));

            windowItemsMap.CurrentWindowPosition = new Point(2, 3);
            Assert.AreEqual(new Point(4, 5), windowItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")));
        }
    }
}