using System.Collections.Generic;
using TestStack.White.Bricks;
using TestStack.White.Utility;

namespace TestStack.White.Configuration
{
    public class UIItemIdAppXmlConfiguration : AssemblyConfiguration, IUIItemIdConfiguration
    {
        private static IUIItemIdConfiguration instance;
        private static readonly Dictionary<string, object> DefaultValues = new Dictionary<string, object>();

        static UIItemIdAppXmlConfiguration()
        {
            switch (SystemLanguageRetreiver.GetCurrentOsCulture().TwoLetterISOLanguageName)
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
                    DefaultValues.Add("BrowseText", "Durchsuchen...");
                    DefaultValues.Add("OpenFileDialogTitle", "Datei öffnen");
                    DefaultValues.Add("PropertyGridMiscText", "Sonstiges");
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
                    DefaultValues.Add("BrowseText", "Browse...");
                    DefaultValues.Add("OpenFileDialogTitle", "Open File");
                    DefaultValues.Add("PropertyGridMiscText", "Misc");
                    break;
            }
        }

        public static IUIItemIdConfiguration Instance
        {
            get { return instance ?? (instance = new UIItemIdAppXmlConfiguration()); }
        }

        private UIItemIdAppXmlConfiguration() :
            base("White", "UIItemId", DefaultValues, CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(UIItemIdAppXmlConfiguration)))
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

        public virtual string BrowseText
        {
            get { return UsedValues["BrowseText"]; }
            set { SetUsedValue("BrowseText", value); }
        }

        public virtual string OpenFileDialogTitle
        {
            get { return UsedValues["OpenFileDialogTitle"]; }
            set { SetUsedValue("OpenFileDialogTitle", value); }
        }

        public virtual string PropertyGridMiscText
        {
            get { return UsedValues["PropertyGridMiscText"]; }
            set { SetUsedValue("PropertyGridMiscText", value); }
        }        
    }
}