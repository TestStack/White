using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Bricks.RuntimeFramework;
using White.Core.Configuration;
using White.Core.Factory;
using White.Core.Logging;
using White.Core.UIA;
using White.Core.UIItems.Finders;
using Xstream.Core;

namespace White.Core.ScreenMap
{
    public class WindowItemsMap : BricksCollection<UIItemLocation>
    {
        private readonly string fileLocation;
        [XmlIgnore] private bool dirty;
        [XmlIgnore] private bool loadedFromFile;
        private Point lastWindowPosition = RectX.UnlikelyWindowPosition;
        [XmlIgnore] private Point currentWindowPosition;

        protected WindowItemsMap() {}

        private WindowItemsMap(string fileLocation, Point windowPosition)
        {
            this.fileLocation = fileLocation;
            lastWindowPosition = currentWindowPosition = windowPosition;
        }

        public virtual void Add(Point point, SearchCriteria searchCriteria)
        {
            var uiItemLocation = new UIItemLocation(point, searchCriteria);
            int searchCriteriaIndex = FindIndex(obj => obj.Has(searchCriteria));
            int pointIndex = FindIndex(obj => obj.Point.Equals(point));

            if (searchCriteriaIndex >= 0)
            {
                WhiteLogger.Instance.Info(string.Format("Found another UIItem {0} at {1}", searchCriteria, this[searchCriteriaIndex]));
                RemoveAt(searchCriteriaIndex);
            }
            else if (pointIndex >= 0)
            {
                WhiteLogger.Instance.Info(string.Format("UIItem {0} at {1} changed", searchCriteria, point));
                RemoveAt(pointIndex);
            }

            Add(uiItemLocation);

            dirty = true;
        }

        public virtual bool LoadedFromFile
        {
            get { return loadedFromFile; }
        }

        public virtual Point CurrentWindowPosition
        {
            set
            {
                if (RectX.UnlikelyWindowPosition.Equals(lastWindowPosition)) lastWindowPosition = value;
                currentWindowPosition = value;
            }
        }

        public virtual Point GetItemLocation(SearchCriteria searchCriteria)
        {
            UIItemLocation location = Find(obj => obj.Has(searchCriteria));
            if (location == null) return RectX.UnlikelyWindowPosition;
            double xOffset = currentWindowPosition.X - lastWindowPosition.X;
            double yOffset = currentWindowPosition.Y - lastWindowPosition.Y;
            return Offset(location.Point, xOffset, yOffset);
        }

        private static Point Offset(Point point, double xOffset, double yOffset)
        {
            return new Point(point.X + xOffset, point.Y + yOffset);
        }

        public static WindowItemsMap Create(InitializeOption initializeOption, Point currentWindowPosition)
        {
            string fileLocation = FileLocation(initializeOption);
            if (File.Exists(fileLocation))
            {
                var windowItemsMap = (WindowItemsMap) CreateFileXStream(fileLocation).FromFile();
                windowItemsMap.currentWindowPosition = currentWindowPosition;
                windowItemsMap.loadedFromFile = true;
                return windowItemsMap;
            }

            WhiteLogger.Instance.Info("Creating new WindowItemsMap for: " + initializeOption.Identifier);
            return new WindowItemsMap(fileLocation, currentWindowPosition);
        }

        private static string FileLocation(InitializeOption initializeOption)
        {
            return string.Format(@"{0}\{1}.xml", CoreAppXmlConfiguration.Instance.WorkSessionLocation, initializeOption.Identifier);
        }

        public virtual void Save()
        {
            if (dirty) CreateFileXStream(fileLocation).ToXml(this);
        }

        private static FileXStream CreateFileXStream(string fileLocation)
        {
            var fileXStream = new FileXStream(fileLocation);
            fileXStream.AddConverter(new ControlTypeConverter());
            fileXStream.AddIgnoreAttribute(typeof (XmlIgnoreAttribute));
            return fileXStream;
        }
    }
}