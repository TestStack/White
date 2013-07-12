using System.Runtime.Serialization;
using System.Windows;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.ScreenMap
{
    [DataContract]
    public class UIItemLocation
    {
        [DataMember]
        private readonly Point point;
        [DataMember]
        private readonly SearchCriteria searchCriteria;

        private UIItemLocation() {}

        public UIItemLocation(Point point, SearchCriteria searchCriteria)
        {
            this.point = point;
            this.searchCriteria = searchCriteria;
        }

        public virtual bool Has(SearchCriteria criteria)
        {
            return criteria.Equals(searchCriteria);
        }

        public virtual Point Point
        {
            get { return point; }
        }

        public virtual SearchCriteria SearchCriteria
        {
            get { return searchCriteria; }
        }

        public override string ToString()
        {
            return string.Format("{0} at point {1}", searchCriteria, point);
        }
    }
}