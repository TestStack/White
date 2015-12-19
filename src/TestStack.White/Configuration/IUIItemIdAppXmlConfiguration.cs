using System.Collections.Generic;
using System.Globalization;
using TestStack.White.Bricks;

namespace TestStack.White.Configuration
{
    public class IUIItemIdAppXmlConfiguration : AssemblyConfiguration, IUIItemIdConfiguration
    {
        private static IUIItemIdConfiguration instance;
        private static readonly Dictionary<string, object> DefaultValues = new Dictionary<string, object>();

        static IUIItemIdAppXmlConfiguration()
        {
            var currentOsLanguage = CultureInfo.InstalledUICulture;
            switch (currentOsLanguage.TwoLetterISOLanguageName)
            {
                case "de":
                    DefaultValues.Add("TableVerticalScrollBar", "Vertikale Schiebeleiste");
                    DefaultValues.Add("TableHorizontalScrollBar", "Horizontale Schiebeleiste");
                    DefaultValues.Add("TableColumn", "Zeile ");
                    DefaultValues.Add("TableTopLeftHeaderCell", "Obere linke Headerzelle");
                    DefaultValues.Add("TableCellNullValue", "(null)");
                    DefaultValues.Add("TableHeader", "Oberste Zeile");
                    DefaultValues.Add("HorizontalScrollBar", "Horizontale Schiebeleiste");
                    DefaultValues.Add("VerticalScrollBar", "Vertikale Schiebeleiste");
                    DefaultValues.Add("TableCellPrefix", " Zeile ");
                    break;
                default:
                    DefaultValues.Add("TableVerticalScrollBar", "Vertical Scroll Bar");
                    DefaultValues.Add("TableHorizontalScrollBar", "Horizontal Scroll Bar");
                    DefaultValues.Add("TableColumn", "Row ");
                    DefaultValues.Add("TableTopLeftHeaderCell", "Top Left Header Cell");
                    DefaultValues.Add("TableCellNullValue", "(null)");
                    DefaultValues.Add("TableHeader", "Top Row");
                    DefaultValues.Add("HorizontalScrollBar", "Horizontal ScrollBar");
                    DefaultValues.Add("VerticalScrollBar", "Vertical ScrollBar");
                    DefaultValues.Add("TableCellPrefix", " Row ");
                    break;
            }
        }

        public static IUIItemIdConfiguration Instance
        {
            get { return instance ?? (instance = new IUIItemIdAppXmlConfiguration()); }
        }

        private IUIItemIdAppXmlConfiguration() :
            base("White", "UIItemId", DefaultValues, CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(IUIItemIdAppXmlConfiguration)))
        { }

        private void SetUsedValue(string key, object value)
        {
            UsedValues[key] = value.ToString();
        }

        public virtual string TableVerticalScrollBar
        {
            get { return UsedValues["TableVerticalScrollBar"]; }
            set { SetUsedValue("TableVerticalScrollBar", value); }
        }

        public virtual string TableHorizontalScrollBar
        {
            get { return UsedValues["TableHorizontalScrollBar"]; }
            set { SetUsedValue("TableHorizontalScrollBar", value); }
        }

        public virtual string TableColumn
        {
            get { return UsedValues["TableColumn"]; }
            set { SetUsedValue("TableColumn", value); }
        }

        public virtual string TableTopLeftHeaderCell
        {
            get { return UsedValues["TableTopLeftHeaderCell"]; }
            set { SetUsedValue("TableTopLeftHeaderCell", value); }
        }

        public virtual string TableCellNullValue
        {
            get { return UsedValues["TableCellNullValue"]; }
            set { SetUsedValue("TableCellNullValue", value); }
        }

        public virtual string TableHeader
        {
            get { return UsedValues["TableHeader"]; }
            set { SetUsedValue("TableHeader", value); }
        }

        public virtual string HorizontalScrollBar
        {
            get { return UsedValues["HorizontalScrollBar"]; }
            set { SetUsedValue("HorizontalScrollBar", value); }
        }

        public virtual string VerticalScrollBar
        {
            get { return UsedValues["VerticalScrollBar"]; }
            set { SetUsedValue("VerticalScrollBar", value); }
        }

        public virtual string TableCellPrefix
        {
            get { return UsedValues["TableCellPrefix"]; }
            set { SetUsedValue("TableCellPrefix", value); }
        }
    }
}