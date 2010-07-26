using System.Collections.Generic;
using Bricks;
using White.Core.Logging;

namespace White.Core.Configuration
{
    public class UIItemIdAppXmlConfiguration : AssemblyConfiguration, UIItemIdConfiguration
    {
        private static UIItemIdConfiguration instance;
        private static readonly Dictionary<string, object> defaultValues = new Dictionary<string, object>();

        static UIItemIdAppXmlConfiguration()
        {
            defaultValues.Add("TableVerticalScrollBar", "Vertical Scroll Bar");
            defaultValues.Add("TableHorizontalScrollBar", "Horizontal Scroll Bar");
            defaultValues.Add("TableColumn", "Row ");
            defaultValues.Add("TableTopLeftHeaderCell", "Top Left Header Cell");
            defaultValues.Add("TableCellNullValue", "(null)");
            defaultValues.Add("TableHeader", "Top Row");
            defaultValues.Add("HorizontalScrollBar", "Horizontal ScrollBar");
            defaultValues.Add("VerticalScrollBar", "Vertical ScrollBar");
            defaultValues.Add("TableCellPrefix", " Row ");
        }

        public static UIItemIdConfiguration Instance
        {
            get
            {
                if (instance == null) instance = new UIItemIdAppXmlConfiguration();
                return instance;
            }
        }

        private UIItemIdAppXmlConfiguration() : base("White", "UIItemId", defaultValues, WhiteLogger.Instance) {}

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