using System.Windows;
using TestStack.White.UIA;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.ScreenMap
{
    public class NullWindowItemsMap : WindowItemsMap
    {
        public override void Add(Point point, SearchCriteria searchCriteria)
        {
        }

        public override bool LoadedFromFile
        {
            get { return false; }
        }

        public override Point CurrentWindowPosition
        {
            set { }
        }

        public override Point GetItemLocation(SearchCriteria searchCriteria)
        {
            return RectX.UnlikelyWindowPosition;
        }

        public override void Save()
        {
        }
    }
}