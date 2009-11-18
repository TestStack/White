using System.Windows;
using NUnit.Framework;
using White.Core.Factory;
using White.Core.UIA;
using White.Core.UIItems.Finders;

namespace White.Core.ScreenMap
{
    [TestFixture, Category("Normal")]
    public class WindowItemsMapTest
    {
        [Test]
        public void Replace_existing_location_if_exists()
        {
            WindowItemsMap windowItemsMap = WindowItemsMap.Create(InitializeOption.NoCache, RectX.UnlikelyWindowPosition);
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByAutomationId("foo"));
            Point newPoint = new Point(1, 2);
            windowItemsMap.Add(newPoint, SearchCriteria.ByAutomationId("foo"));
            Assert.AreEqual(1, windowItemsMap.Count);
            Assert.AreEqual(newPoint, windowItemsMap[0].Point);
        }

        [Test]
        public void Replace_existing_location_when_search_criteria_changes_for_the_same_point()
        {
            WindowItemsMap windowItemsMap = WindowItemsMap.Create(InitializeOption.NoCache, RectX.UnlikelyWindowPosition);
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByAutomationId("foo"));
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByText("foo"));

            Assert.AreEqual(1, windowItemsMap.Count);
        }

        [Test]
        public void GetItemLocation_when_not_present()
        {
            WindowItemsMap windowItemsMap = WindowItemsMap.Create(InitializeOption.NoCache, RectX.UnlikelyWindowPosition);
            Assert.AreEqual(RectX.UnlikelyWindowPosition, windowItemsMap.GetItemLocation(SearchCriteria.ByText("foo")));
        }

        [Test]
        public void GetItemLocation()
        {
            WindowItemsMap windowItemsMap = WindowItemsMap.Create(InitializeOption.NoCache, RectX.UnlikelyWindowPosition);
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByAutomationId("foo"));
            Assert.AreEqual(new Point(1, 1), windowItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")));
        }

        [Test]
        public void GetItemLocation_when_window_position_changes()
        {
            WindowItemsMap windowItemsMap = WindowItemsMap.Create(InitializeOption.NoCache, new Point(5, 5));
            windowItemsMap.Add(new Point(7, 7), SearchCriteria.ByAutomationId("foo"));
            Assert.AreEqual(new Point(7, 7), windowItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")));

            windowItemsMap.CurrentWindowPosition = new Point(10, 10);
            Assert.AreEqual(new Point(12, 12), windowItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")));

            windowItemsMap.CurrentWindowPosition = new Point(2, 3);
            Assert.AreEqual(new Point(4, 5), windowItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")));
        }
    }
}