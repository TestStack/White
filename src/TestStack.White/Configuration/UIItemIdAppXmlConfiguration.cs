using System.Collections.Generic;
using White.Core.Bricks;
using log4net;

namespace White.Core.Configuration
{
    public class UIItemIdAppXmlConfiguration : AssemblyConfiguration, UIItemIdConfiguration
    {
        private static UIItemIdConfiguration _instance;
        private static readonly Dictionary<string, object> DefaultValues = new Dictionary<string, object>();

        static UIItemIdAppXmlConfiguration()
        {
            DefaultValues.Add("TableVerticalScrollBar", "Vertical Scroll Bar");
            DefaultValues.Add("TableHorizontalScrollBar", "Horizontal Scroll Bar");
            DefaultValues.Add("TableColumn", "Row ");
            DefaultValues.Add("TableTopLeftHeaderCell", "Top Left Header Cell");
            DefaultValues.Add("TableCellNullValue", "(null)");
            DefaultValues.Add("TableHeader", "Top Row");
            DefaultValues.Add("HorizontalScrollBar", "Horizontal ScrollBar");
            DefaultValues.Add("VerticalScrollBar", "Vertical ScrollBar");
            DefaultValues.Add("TableCellPrefix", " Row ");
        }

        public static UIItemIdConfiguration Instance
        {
            get { return _instance ?? (_instance = new UIItemIdAppXmlConfiguration()); }
        }

        private UIItemIdAppXmlConfiguration() : 
            base("White", "UIItemId", DefaultValues, LogManager.GetLogger(typeof(UIItemIdAppXmlConfiguration)))
        { }

        private void SetUsedValue(string key, object value)
        {
            usedValues[key] = value.ToString();
        }

        public virtual string TableVerticalScrollBar
        {
            get { return usedValues["TableVerticalScrollBar"]; }
            set { SetUsedValue("TableVerticalScrollBar", value); }
        }

        public virtual string TableHorizontalScrollBar
        {
            get { return usedValues["TableHorizontalScrollBar"]; }
            set { SetUsedValue("TableHorizontalScrollBar", value); }
        }

        public virtual string TableColumn
        {
            get { return usedValues["TableColumn"]; }
            set { SetUsedValue("TableColumn", value); }
        }

        public virtual string TableTopLeftHeaderCell
        {
            get { return usedValues["TableTopLeftHeaderCell"]; }
            set { SetUsedValue("TableTopLeftHeaderCell", value); }
        }

        public virtual string TableCellNullValue
        {
            get { return usedValues["TableCellNullValue"]; }
            set { SetUsedValue("TableCellNullValue", value); }
        }

        public virtual string TableHeader
        {
            get { return usedValues["TableHeader"]; }
            set { SetUsedValue("TableHeader", value); }
        }

        public virtual string HorizontalScrollBar
        {
            get { return usedValues["HorizontalScrollBar"]; }
            set { SetUsedValue("HorizontalScrollBar", value); }
        }

        public virtual string VerticalScrollBar
        {
            get { return usedValues["VerticalScrollBar"]; }
            set { SetUsedValue("VerticalScrollBar", value); }
        }

        public virtual string TableCellPrefix
        {
            get { return usedValues["TableCellPrefix"]; }
            set { SetUsedValue("TableCellPrefix", value); }
        }
    }
}