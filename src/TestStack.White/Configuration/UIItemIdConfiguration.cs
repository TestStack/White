using System.Collections.Generic;
using TestStack.White.Utility;

namespace TestStack.White.Configuration
{
    public class UIItemIdConfiguration : ConfigurationBase<UIItemIdConfiguration>
    {
        private const string TableVerticalScrollBarKey = "TableVerticalScrollBar";
        private const string TableHorizontalScrollBarKey = "TableHorizontalScrollBar";
        private const string TableColumnKey = "TableColumn";
        private const string TableTopLeftHeaderCellKey = "TableTopLeftHeaderCell";
        private const string TableCellNullValueKey = "TableCellNullValue";
        private const string TableHeaderKey = "TableHeader";
        private const string HorizontalScrollBarKey = "HorizontalScrollBar";
        private const string VerticalScrollBarKey = "VerticalScrollBar";
        private const string TableCellPrefixKey = "TableCellPrefix";
        private const string BrowseTextKey = "BrowseText";
        private const string OpenFileDialogTitleKey = "OpenFileDialogTitle";
        private const string PropertyGridMiscTextKey = "PropertyGridMiscText";

        public override Dictionary<string, object> DefaultValues
        {
            get
            {
                switch (SystemLanguageRetreiver.GetCurrentOsCulture().TwoLetterISOLanguageName)
                {
                    case "de":
                        return new Dictionary<string, object>
                        {
                            {TableVerticalScrollBarKey, "Vertikale Schiebeleiste"},
                            {TableHorizontalScrollBarKey, "Horizontale Schiebeleiste"},
                            {TableColumnKey, "Zeile "},
                            {TableTopLeftHeaderCellKey, "Obere linke Headerzelle"},
                            {TableCellNullValueKey, "(null)"},
                            {TableHeaderKey, "Oberste Zeile"},
                            {HorizontalScrollBarKey, "Horizontale Schiebeleiste"},
                            {VerticalScrollBarKey, "Vertikale Schiebeleiste"},
                            {TableCellPrefixKey, " Zeile "},
                            {BrowseTextKey, "Durchsuchen..."},
                            {OpenFileDialogTitleKey, "Datei öffnen"},
                            {PropertyGridMiscTextKey, "Sonstiges"}
                        };
                    default:
                        return new Dictionary<string, object>
                        {
                            {TableVerticalScrollBarKey, "Vertical Scroll Bar"},
                            {TableHorizontalScrollBarKey, "Horizontal Scroll Bar"},
                            {TableColumnKey, "Row "},
                            {TableTopLeftHeaderCellKey, "Top Left Header Cell"},
                            {TableCellNullValueKey, "(null)"},
                            {TableHeaderKey, "Top Row"},
                            {HorizontalScrollBarKey, "Horizontal ScrollBar"},
                            {VerticalScrollBarKey, "Vertical ScrollBar"},
                            {TableCellPrefixKey, " Row "},
                            {BrowseTextKey, "Browse..."},
                            {OpenFileDialogTitleKey, "Open File"},
                            {PropertyGridMiscTextKey, "Misc"}
                        };
                }
            }
        }

        public virtual string TableVerticalScrollBar
        {
            get { return GetValue(TableVerticalScrollBarKey); }
            set { SetValue(TableVerticalScrollBarKey, value); }
        }

        public virtual string TableHorizontalScrollBar
        {
            get { return GetValue(TableHorizontalScrollBarKey); }
            set { SetValue(TableHorizontalScrollBarKey, value); }
        }

        public virtual string TableColumn
        {
            get { return GetValue(TableColumnKey); }
            set { SetValue(TableColumnKey, value); }
        }

        public virtual string TableTopLeftHeaderCell
        {
            get { return GetValue(TableTopLeftHeaderCellKey); }
            set { SetValue(TableTopLeftHeaderCellKey, value); }
        }

        public virtual string TableCellNullValue
        {
            get { return GetValue(TableCellNullValueKey); }
            set { SetValue(TableCellNullValueKey, value); }
        }

        public virtual string TableHeader
        {
            get { return GetValue(TableHeaderKey); }
            set { SetValue(TableHeaderKey, value); }
        }

        public virtual string HorizontalScrollBar
        {
            get { return GetValue(HorizontalScrollBarKey); }
            set { SetValue(HorizontalScrollBarKey, value); }
        }

        public virtual string VerticalScrollBar
        {
            get { return GetValue(VerticalScrollBarKey); }
            set { SetValue(VerticalScrollBarKey, value); }
        }

        public virtual string TableCellPrefix
        {
            get { return GetValue(TableCellPrefixKey); }
            set { SetValue(TableCellPrefixKey, value); }
        }

        /// <summary>
        /// The text for the "browse"-button
        /// </summary>
        public virtual string BrowseText
        {
            get { return GetValue(BrowseTextKey); }
            set { SetValue(BrowseTextKey, value); }
        }

        /// <summary>
        /// The dialog title of the open browse dialog
        /// </summary>
        public virtual string OpenFileDialogTitle
        {
            get { return GetValue(OpenFileDialogTitleKey); }
            set { SetValue(OpenFileDialogTitleKey, value); }
        }

        /// <summary>
        /// Text of the misc category on a property grid
        /// </summary>
        public virtual string PropertyGridMiscText
        {
            get { return GetValue(PropertyGridMiscTextKey); }
            set { SetValue(PropertyGridMiscTextKey, value); }
        }
    }
}
