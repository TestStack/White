using System.Windows;
using White.Core.UIA;
using White.Core.UIItems.Finders;

namespace White.Core.ScreenMap
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