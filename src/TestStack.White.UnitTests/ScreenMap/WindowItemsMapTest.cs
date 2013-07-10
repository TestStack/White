using System.IO;
using System.Windows;
using White.Core.Factory;
using White.Core.ScreenMap;
using White.Core.UIA;
using White.Core.UIItems.Finders;
using Xunit;

namespace White.Core.UnitTests.ScreenMap
{
    public class WindowItemsMapTest
    {
        public WindowItemsMapTest()
        {
            File.Delete("foo.xml");
        }

        [Fact]
        public void ReplaceExistingLocationIfExists()
        {
            WindowItemsMap windowItemsMap = WindowItemsMap.Create(InitializeOption(), RectX.UnlikelyWindowPosition);
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByAutomationId("foo"));
            var newPoint = new Point(1, 2);
            windowItemsMap.Add(newPoint, SearchCriteria.ByAutomationId("foo"));
            Assert.Equal(1, windowItemsMap.UIItemLocations.Count);
            Assert.Equal(newPoint, windowItemsMap.UIItemLocations[0].Point);
        }

        private InitializeOption InitializeOption()
        {
            return Factory.InitializeOption.NoCache.AndIdentifiedBy("foo");
        }

        [Fact]
        public void ReplaceExistingLocationWhenSearchCriteriaChangesForTheSamePoint()
        {
            WindowItemsMap windowItemsMap = WindowItemsMap.Create(InitializeOption(), RectX.UnlikelyWindowPosition);
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByAutomationId("foo"));
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByText("foo"));

            Assert.Equal(1, windowItemsMap.UIItemLocations.Count);
        }

        [Fact]
        public void GetItemLocationWhenNotPresent()
        {
            WindowItemsMap windowItemsMap = WindowItemsMap.Create(InitializeOption(), RectX.UnlikelyWindowPosition);
            Assert.Equal(RectX.UnlikelyWindowPosition, windowItemsMap.GetItemLocation(SearchCriteria.ByText("foo")));
        }

        [Fact]
        public void GetItemLocation()
        {
            WindowItemsMap windowItemsMap = WindowItemsMap.Create(InitializeOption(), RectX.UnlikelyWindowPosition);
            windowItemsMap.Add(new Point(1, 1), SearchCriteria.ByAutomationId("foo"));
            Assert.Equal(new Point(1, 1), windowItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")));
        }

        [Fact]
        public void GetItemLocationWhenWindowPositionChanges()
        {
            WindowItemsMap windowsItemsMap = WindowItemsMap.Create(InitializeOption(), new Point(20, 20));
            windowsItemsMap.Add(new Point(27, 27), SearchCriteria.ByAutomationId("foo"));
            windowsItemsMap.Save();

            windowsItemsMap = WindowItemsMap.Create(InitializeOption(), new Point(5, 5));
            Assert.Equal(new Point(12, 12), windowsItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")));

            windowsItemsMap.CurrentWindowPosition = new Point(10, 10);
            Assert.Equal(new Point(17, 17), windowsItemsMap.GetItemLocation(SearchCriteria.ByAutomationId("foo")));
        }
    }
}