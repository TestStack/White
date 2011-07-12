using System.Collections.Generic;
using System.IO;
using Bricks;
using Bricks.Core;
using Bricks.DynamicProxy;
using White.Core.Interceptors;
using White.Core.Logging;
using White.Core.UIItems;

namespace White.Core.Configuration
{
    public class CoreAppXmlConfiguration : AssemblyConfiguration, CoreConfiguration
    {
        private static CoreConfiguration instance;
        private readonly DynamicProxyInterceptors interceptors = new DynamicProxyInterceptors();

        private static readonly Dictionary<string, object> defaultValues = new Dictionary<string, object>();

        static CoreAppXmlConfiguration()
        {
            defaultValues.Add("BusyTimeout", 5000);
            defaultValues.Add("WaitBasedOnHourGlass", true);
            defaultValues.Add("WorkSessionLocation", ".");
            defaultValues.Add("UIAutomationZeroWindowBugTimeout", 5000);
            defaultValues.Add("PopupTimeout", 5000);
            defaultValues.Add("TooltipWaitTime", 0);
            defaultValues.Add("SuggestionListTimeout", 3000);
            defaultValues.Add("DefaultDateFormat", DateFormat.CultureDefault.ToString());
            defaultValues.Add("DragStepCount", 1);
            defaultValues.Add("InProc", false);
            defaultValues.Add("ComboBoxItemsPopulatedWithoutDropDownOpen", true);
            defaultValues.Add("RawElementBasedSearch", false);
            defaultValues.Add("MaxElementSearchDepth", 10);
            defaultValues.Add("DoubleClickInterval", 0);
            defaultValues.Add("MoveMouseToGetStatusOfHourGlass", true);
        }

        public static CoreConfiguration Instance
        {
            get { return instance ?? (instance = new CoreAppXmlConfiguration()); }
        }

        private CoreAppXmlConfiguration() : base("White", "Core", defaultValues, WhiteLogger.Instance)
        {
            interceptors.Add(new FocusInterceptor());
            interceptors.Add(new ScrollInterceptor());
        }

        private void SetUsedValue(string key, object value)
        {
            usedValues[key] = value.ToString();
        }

        public virtual DirectoryInfo WorkSessionLocation
        {
            get { return new DirectoryInfo(usedValues["WorkSessionLocation"]); }
            set { SetUsedValue("WorkSessionLocation", value); }
        }

        public virtual int BusyTimeout
        {
            get { return S.ToInt(usedValues["BusyTimeout"]); }
            set { SetUsedValue("BusyTimeout", value); }
        }

        public virtual bool WaitBasedOnHourGlass
        {
            get { return S.ToBool(usedValues["WaitBasedOnHourGlass"]); }
            set { SetUsedValue("WaitBasedOnHourGlass", value); }
        }

        public virtual DynamicProxyInterceptors Interceptors
        {
            get { return interceptors; }
        }

        public virtual int UIAutomationZeroWindowBugTimeout
        {
            get { return S.ToInt(usedValues["UIAutomationZeroWindowBugTimeout"]); }
            set { SetUsedValue("UIAutomationZeroWindowBugTimeout", value); }
        }

        public virtual int PopupTimeout
        {
            get { return S.ToInt(usedValues["PopupTimeout"]); }
            set { SetUsedValue("PopupTimeout", value); }
        }

        public virtual int TooltipWaitTime
        {
            get { return S.ToInt(usedValues["TooltipWaitTime"]); }
            set { SetUsedValue("TooltipWaitTime", value); }
        }

        public virtual int SuggestionListTimeout
        {
            get { return S.ToInt(usedValues["SuggestionListTimeout"]); }
            set { SetUsedValue("SuggestionListTimeout", value); }
        }

        public virtual DateFormat DefaultDateFormat
        {
            get { return DateFormat.Parse(usedValues["DefaultDateFormat"]); }
            set { usedValues["DefaultDateFormat"] = value.ToString(); }
        }

        public virtual int DragStepCount
        {
            get { return S.ToInt(usedValues["DragStepCount"]); }
            set { SetUsedValue("DragStepCount", value); }
        }

        public virtual bool InProc
        {
            get { return S.ToBool(usedValues["InProc"]); }
            set { SetUsedValue("InProc", value); }
        }

        public virtual bool ComboBoxItemsPopulatedWithoutDropDownOpen
        {
            get { return S.ToBool(usedValues["ComboBoxItemsPopulatedWithoutDropDownOpen"]); }
            set { SetUsedValue("ComboBoxItemsPopulatedWithoutDropDownOpen", value); }
        }

        public virtual bool MoveMouseToGetStatusOfHourGlass
        {
            get { return S.ToBool(usedValues["MoveMouseToGetStatusOfHourGlass"]); }
            set { SetUsedValue("MoveMouseToGetStatusOfHourGlass", value); }
        }

        public virtual IWaitHook AdditionalWaitHook { get; set; }

        public virtual int MaxElementSearchDepth
        {
            get { return S.ToInt(usedValues["MaxElementSearchDepth"]); }
            set { SetUsedValue("MaxElementSearchDepth", value); }
        }

        public virtual bool RawElementBasedSearch
        {
            get { return S.ToBool(usedValues["RawElementBasedSearch"]); }
            set { SetUsedValue("RawElementBasedSearch", value); }
        }

        public virtual int DoubleClickInterval
        {
            get { return S.ToInt(usedValues["DoubleClickInterval"]); }
            set { SetUsedValue("DoubleClickInterval", value); }
        }
    }
}