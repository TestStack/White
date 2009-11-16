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
            defaultValues.Add(CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableVerticalScrollBar), "Vertical Scroll Bar");
            defaultValues.Add(CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableHorizontalScrollBar), "Horizontal Scroll Bar");
            defaultValues.Add(CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableColumn), "Row ");
            defaultValues.Add(CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableTopLeftHeaderCell), "Top Left Header Cell");
            defaultValues.Add(CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableCellNullValue), "(null)");
            defaultValues.Add(CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableHeader), "Top Row");
            defaultValues.Add(CodePath.Get(CodePath.New<UIItemIdConfiguration>().HorizontalScrollBar), "Horizontal ScrollBar");
            defaultValues.Add(CodePath.Get(CodePath.New<UIItemIdConfiguration>().VerticalScrollBar), "Vertical ScrollBar");
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
            get { return usedValues[CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableVerticalScrollBar)]; }
            set { SetUsedValue(CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableVerticalScrollBar), value); }
        }

        public virtual string TableHorizontalScrollBar
        {
            get { return usedValues[CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableHorizontalScrollBar)]; }
            set { SetUsedValue(CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableHorizontalScrollBar), value); }
        }

        public virtual string TableColumn
        {
            get { return usedValues[CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableColumn)]; }
            set { SetUsedValue(CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableColumn), value); }
        }

        public virtual string TableTopLeftHeaderCell
        {
            get { return usedValues[CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableTopLeftHeaderCell)]; }
            set { SetUsedValue(CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableTopLeftHeaderCell), value); }
        }

        public virtual string TableCellNullValue
        {
            get { return usedValues[CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableCellNullValue)]; }
            set { SetUsedValue(CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableCellNullValue), value); }
        }

        public virtual string TableHeader
        {
            get { return usedValues[CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableHeader)]; }
            set { SetUsedValue(CodePath.Get(CodePath.New<UIItemIdConfiguration>().TableHeader), value); }
        }

        public virtual string HorizontalScrollBar
        {
            get { return usedValues[CodePath.Get(CodePath.New<UIItemIdConfiguration>().HorizontalScrollBar)]; }
            set { SetUsedValue(CodePath.Get(CodePath.New<UIItemIdConfiguration>().HorizontalScrollBar), value); }
        }

        public virtual string VerticalScrollBar
        {
            get { return usedValues[CodePath.Get(CodePath.New<UIItemIdConfiguration>().VerticalScrollBar)]; }
            set { SetUsedValue(CodePath.Get(CodePath.New<UIItemIdConfiguration>().VerticalScrollBar), value); }
        }
    }
}