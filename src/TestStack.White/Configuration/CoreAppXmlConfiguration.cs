using System;
using System.Collections.Generic;
using System.IO;
using White.Core.Bricks;
using White.Core.Interceptors;
using White.Core.UIItems;
using log4net;

namespace White.Core.Configuration
{
    public class CoreAppXmlConfiguration : AssemblyConfiguration, ICoreConfiguration
    {
        private static ICoreConfiguration instance;
        private readonly DynamicProxyInterceptors interceptors = new DynamicProxyInterceptors();

        private static readonly Dictionary<string, object> DefaultValues = new Dictionary<string, object>();

        static CoreAppXmlConfiguration()
        {
            DefaultValues.Add("BusyTimeout", 5000);
            DefaultValues.Add("WaitBasedOnHourGlass", true);
            DefaultValues.Add("WorkSessionLocation", ".");
            DefaultValues.Add("UIAutomationZeroWindowBugTimeout", 5000);
            DefaultValues.Add("PopupTimeout", 5000);
            DefaultValues.Add("TooltipWaitTime", 0);
            DefaultValues.Add("SuggestionListTimeout", 3000);
            DefaultValues.Add("DefaultDateFormat", DateFormat.CultureDefault.ToString());
            DefaultValues.Add("DragStepCount", 1);
            DefaultValues.Add("InProc", false);
            DefaultValues.Add("ComboBoxItemsPopulatedWithoutDropDownOpen", true);
            DefaultValues.Add("RawElementBasedSearch", false);
            DefaultValues.Add("MaxElementSearchDepth", 10);
            DefaultValues.Add("DoubleClickInterval", 0);
            DefaultValues.Add("MoveMouseToGetStatusOfHourGlass", true);
        }

        public static ICoreConfiguration Instance
        {
            get { return instance ?? (instance = new CoreAppXmlConfiguration()); }
        }

        private CoreAppXmlConfiguration() : base("White", "Core", DefaultValues, LogManager.GetLogger(typeof(CoreAppXmlConfiguration)))
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
            get { return Convert.ToInt32(usedValues["BusyTimeout"]); }
            set { SetUsedValue("BusyTimeout", value); }
        }

        public virtual bool WaitBasedOnHourGlass
        {
            get { return Convert.ToBoolean(usedValues["WaitBasedOnHourGlass"]); }
            set { SetUsedValue("WaitBasedOnHourGlass", value); }
        }

        public virtual DynamicProxyInterceptors Interceptors
        {
            get { return interceptors; }
        }

        public virtual int UIAutomationZeroWindowBugTimeout
        {
            get { return Convert.ToInt32(usedValues["UIAutomationZeroWindowBugTimeout"]); }
            set { SetUsedValue("UIAutomationZeroWindowBugTimeout", value); }
        }

        public virtual int PopupTimeout
        {
            get { return Convert.ToInt32(usedValues["PopupTimeout"]); }
            set { SetUsedValue("PopupTimeout", value); }
        }

        public virtual int TooltipWaitTime
        {
            get { return Convert.ToInt32(usedValues["TooltipWaitTime"]); }
            set { SetUsedValue("TooltipWaitTime", value); }
        }

        public virtual int SuggestionListTimeout
        {
            get { return Convert.ToInt32(usedValues["SuggestionListTimeout"]); }
            set { SetUsedValue("SuggestionListTimeout", value); }
        }

        public virtual DateFormat DefaultDateFormat
        {
            get { return DateFormat.Parse(usedValues["DefaultDateFormat"]); }
            set { usedValues["DefaultDateFormat"] = value.ToString(); }
        }

        public virtual int DragStepCount
        {
            get { return Convert.ToInt32(usedValues["DragStepCount"]); }
            set { SetUsedValue("DragStepCount", value); }
        }

        public virtual bool InProc
        {
            get { return Convert.ToBoolean(usedValues["InProc"]); }
            set { SetUsedValue("InProc", value); }
        }

        public virtual bool ComboBoxItemsPopulatedWithoutDropDownOpen
        {
            get { return Convert.ToBoolean(usedValues["ComboBoxItemsPopulatedWithoutDropDownOpen"]); }
            set { SetUsedValue("ComboBoxItemsPopulatedWithoutDropDownOpen", value); }
        }

        public virtual bool MoveMouseToGetStatusOfHourGlass
        {
            get { return Convert.ToBoolean(usedValues["MoveMouseToGetStatusOfHourGlass"]); }
            set { SetUsedValue("MoveMouseToGetStatusOfHourGlass", value); }
        }

        public virtual IWaitHook AdditionalWaitHook { get; set; }

        public virtual int MaxElementSearchDepth
        {
            get { return Convert.ToInt32(usedValues["MaxElementSearchDepth"]); }
            set { SetUsedValue("MaxElementSearchDepth", value); }
        }

        public virtual bool RawElementBasedSearch
        {
            get { return Convert.ToBoolean(usedValues["RawElementBasedSearch"]); }
            set { SetUsedValue("RawElementBasedSearch", value); }
        }

        public virtual int DoubleClickInterval
        {
            get { return Convert.ToInt32(usedValues["DoubleClickInterval"]); }
            set { SetUsedValue("DoubleClickInterval", value); }
        }
    }
}