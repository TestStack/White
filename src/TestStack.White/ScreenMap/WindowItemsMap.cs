using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows;
using Castle.Core.Logging;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIA;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.ScreenMap
{
    [DataContract]
    public class WindowItemsMap
    {
        [DataMember]
        private readonly string fileLocation;
        [DataMember]
        private Point lastWindowPosition = RectX.UnlikelyWindowPosition;

        private bool dirty;
        private bool loadedFromFile;
        private Point currentWindowPosition;
        private static readonly ILogger Logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(WindowItemsMap));

        protected WindowItemsMap()
        {
            UIItemLocations = new List<UIItemLocation>();
        }

        private WindowItemsMap(string fileLocation, Point windowPosition)
        {
            this.fileLocation = fileLocation;
            currentWindowPosition = windowPosition;
            UIItemLocations = new List<UIItemLocation>();
        }

        [DataMember]
        public virtual List<UIItemLocation> UIItemLocations { get; private set; }

        public static WindowItemsMap Create(InitializeOption initializeOption, Point currentWindowPosition)
        {
            if (initializeOption.NoIdentification) return new NullWindowItemsMap();

            string fileLocation = FileLocation(initializeOption);
            if (File.Exists(fileLocation))
            {
                Logger.DebugFormat("[PositionBasedSearch] Loading WindowItemsMap for: {0}, from {1}", initializeOption.Identifier, fileLocation);
                WindowItemsMap windowItemsMap = null;
                try
                {
                    using (var fileStream = CreateFileStream(fileLocation))
                    {
                        windowItemsMap = (WindowItemsMap)CreateDataContractSerializer().ReadObject(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    Logger.DebugFormat("[PositionBasedSearch] Loading WindowItemsMap FAILED for: {0}, Error: {1}", initializeOption.Identifier, ex.Message);
                    Logger.DebugFormat("[PositionBasedSearch] Deleting WindowItemsMap for: {0}", initializeOption.Identifier);
                    try { File.Delete(fileLocation); }
                    catch (IOException) { }
                }

                if (windowItemsMap != null)
                {
                    windowItemsMap.currentWindowPosition = currentWindowPosition;
                    windowItemsMap.loadedFromFile = true;
                    return windowItemsMap;
                }
            }

            Logger.DebugFormat("[PositionBasedSearch] Creating new WindowItemsMap for: {0}", initializeOption.Identifier);
            return new WindowItemsMap(fileLocation, currentWindowPosition);
        }

        public virtual void Add(Point point, SearchCriteria searchCriteria)
        {
            var uiItemLocation = new UIItemLocation(point, searchCriteria);
            var existingItem = UIItemLocations.FirstOrDefault(obj => obj.Has(searchCriteria));
            var existingPoint = UIItemLocations.FirstOrDefault(obj => obj.Point.Equals(point));

            if (existingItem != null)
            {
                Logger.Debug(string.Format("[PositionBasedSearch] Found another UIItem {0} at {1}", searchCriteria, existingItem));
                UIItemLocations.Remove(existingItem);
            }
            else if (existingPoint != null)
            {
                Logger.Debug(string.Format("[PositionBasedSearch] UIItem {0} at {1} changed", searchCriteria, point));
                UIItemLocations.Remove(existingPoint);
            }

            UIItemLocations.Add(uiItemLocation);

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
                currentWindowPosition = value;
            }
        }

        public virtual Point GetItemLocation(SearchCriteria searchCriteria)
        {
            var location = UIItemLocations.Find(obj => obj.Has(searchCriteria));
            if (location == null) return RectX.UnlikelyWindowPosition;
            double xOffset = currentWindowPosition.X - lastWindowPosition.X;
            double yOffset = currentWindowPosition.Y - lastWindowPosition.Y;
            return Offset(location.Point, xOffset, yOffset);
        }

        private static Point Offset(Point point, double xOffset, double yOffset)
        {
            return new Point(point.X + xOffset, point.Y + yOffset);
        }

        private static string FileLocation(InitializeOption initializeOption)
        {
            return string.Format(@"{0}\{1}.xml", CoreAppXmlConfiguration.Instance.WorkSessionLocation, initializeOption.Identifier);
        }

        public virtual void Save()
        {
            if (!dirty) return;
            lastWindowPosition = currentWindowPosition;
            using (var fileStream = CreateFileStream(fileLocation))
            {
                var dataContractSerializer = CreateDataContractSerializer();
                dataContractSerializer.WriteObject(fileStream, this);
            }
        }

        private static DataContractSerializer CreateDataContractSerializer()
        {
            return new DataContractSerializer(
                typeof(WindowItemsMap), new[]{ typeof(ControlTypeSurrogate)}, int.MaxValue, false, false, new WindowsAutomationTypesSurrogates());
        }

        private static FileStream CreateFileStream(string fileLocation)
        {
            return new FileStream(fileLocation, FileMode.OpenOrCreate);
        }
    }
}