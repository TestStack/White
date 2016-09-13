using NUnit.Framework;
using System.IO;
using System.Windows;
using TestStack.White.Factory;
using TestStack.White.ScreenMap;
using TestStack.White.UIA;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UnitTests.ScreenMap
{
    [TestFixture]
    public class WindowItemsMapTest
    {
        public WindowItemsMapTest()
        {
            File.Delete("foo.xml");
        }

        [Test]
        public void ReplaceExistingLocationIfExists()
        {
            var windowItemsMap = WindowItemsMap.Create(InitializeOption(), RectX.UnlikelyWindowPosition);
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByAutomationId("foo"));
            var newPoint = new Point(1, 2);
            windowItemsMap.Add(newPoint, SearchCriteria.ByAutomationId("foo"));
            Assert.That(windowItemsMap.UIItemLocations, Has.Count.EqualTo(1));
            Assert.That(windowItemsMap.UIItemLocations[0].Point, Is.EqualTo(newPoint));
        }

        private InitializeOption InitializeOption()
        {
            return Factory.InitializeOption.NoCache.AndIdentifiedBy("foo");
        }

        [Test]
        public void ReplaceExistingLocationWhenSearchCriteriaChangesForTheSamePoint()
        {
            var windowItemsMap = WindowItemsMap.Create(InitializeOption(), RectX.UnlikelyWindowPosition);
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByAutomationId("foo"));
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByText("foo"));
            Assert.That(windowItemsMap.UIItemLocations, Has.Count.EqualTo(1));
        }

        [Test]
        public void GetItemLocationWhenNotPresent()
        {
            var windowItemsMap = WindowItemsMap.Create(InitializeOption(), RectX.UnlikelyWindowPosition);
            Assert.That(windowItemsMap.GetItemLocation(SearchCriteria.ByText("foo")), Is.EqualTo(RectX.UnlikelyWindowPosition));
        }

        [Test]
        public void GetItemLocation()
        {
            var windowItemsMap = WindowItemsMap.Create(InitializeOption(), RectX.UnlikelyWindowPosition);
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByAutomationId("foo"));
            Assert.That(windowItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")), Is.EqualTo(new Point(1, 1)));
        }

        [Test]
        public void GetItemLocationWhenWindowPositionChanges()
        {
            var windowsItemsMap = WindowItemsMap.Create(InitializeOption(), new Point(20, 20));
            windowsItemsMap.Add(new Point(27, 27), SearchCriteria.ByAutomationId("foo"));
            windowsItemsMap.Save();

            windowsItemsMap = WindowItemsMap.Create(InitializeOption(), new Point(5, 5));
            Assert.That(windowsItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")), Is.EqualTo(new Point(12, 12)));

            windowsItemsMap.CurrentWindowPosition = new Point(10, 10);
            Assert.That(windowsItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")), Is.EqualTo(new Point(17, 17)));
        }
    }
}