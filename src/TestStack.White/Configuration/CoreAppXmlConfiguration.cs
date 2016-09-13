using System;
using System.Collections.Generic;
using System.IO;
using Castle.Core.Logging;
using TestStack.White.Bricks;
using TestStack.White.Interceptors;
using TestStack.White.UIItems;
using TestStack.White.Utility;

namespace TestStack.White.Configuration
{
    public class CoreAppXmlConfiguration : AssemblyConfiguration, ICoreConfiguration
    {
        private static ICoreConfiguration instance;
        private readonly DynamicProxyInterceptors interceptors = new DynamicProxyInterceptors();
        private static readonly Dictionary<string, object> DefaultValues = new Dictionary<string, object>();

        static CoreAppXmlConfiguration()
        {
            DefaultValues.Add("BusyTimeout", 5000);
            DefaultValues.Add("FindWindowTimeout", 30000);
            DefaultValues.Add("WaitBasedOnHourGlass", true);
            DefaultValues.Add("WorkSessionLocation", ".");
            DefaultValues.Add("UIAutomationZeroWindowBugTimeout", 5000);
            DefaultValues.Add("PopupTimeout", 5000);
            DefaultValues.Add("TooltipWaitTime", 3000);
            DefaultValues.Add("SuggestionListTimeout", 3000);
            DefaultValues.Add("HighlightTimeout", 1000);
            DefaultValues.Add("DefaultDateFormat", DateFormat.CultureDefault.ToString());
            DefaultValues.Add("DragStepCount", 1);
            DefaultValues.Add("InProc", false);
            DefaultValues.Add("ComboBoxItemsPopulatedWithoutDropDownOpen", true);
            DefaultValues.Add("RawElementBasedSearch", false);
            DefaultValues.Add("MaxElementSearchDepth", 10);
            DefaultValues.Add("DoubleClickInterval", 0);
            DefaultValues.Add("MoveMouseToGetStatusOfHourGlass", true);
            DefaultValues.Add("KeepOpenOnDispose", false);
        }

        public static ICoreConfiguration Instance
        {
            get { return instance ?? (instance = new CoreAppXmlConfiguration()); }
        }

        private CoreAppXmlConfiguration()
            : base("White", "Core", DefaultValues, new TraceLogger(typeof(CoreAppXmlConfiguration).Name))
        {
            interceptors.Add(new FocusInterceptor());
            interceptors.Add(new ScrollInterceptor());
            LoggerFactory = new WhiteDefaultLoggerFactory(LoggerLevel.Info);
        }

        public virtual ILoggerFactory LoggerFactory { get; set; }

        public virtual IDisposable ApplyTemporarySetting(Action<ICoreConfiguration> changes)
        {
            var existing = new Dictionary<string, string>(UsedValues);
            changes(this);

            return new DelegateDisposable(() =>
            {
                foreach (var value in existing)
                {
                    SetUsedValue(value.Key, value.Value);
                }
            });
        }

        private void SetUsedValue(string key, object value)
        {
            UsedValues[key] = value.ToString();
        }

        public virtual IWaitHook AdditionalWaitHook { get; set; }

        public virtual DynamicProxyInterceptors Interceptors
        {
            get { return interceptors; }
        }

        public virtual int BusyTimeout
        {
            get { return Convert.ToInt32(UsedValues["BusyTimeout"]); }
            set { SetUsedValue("BusyTimeout", value); }
        }

        public virtual int FindWindowTimeout
        {
            get { return Convert.ToInt32(UsedValues["FindWindowTimeout"]); }
            set { SetUsedValue("FindWindowTimeout", value); }
        }

        public virtual bool WaitBasedOnHourGlass
        {
            get { return Convert.ToBoolean(UsedValues["WaitBasedOnHourGlass"]); }
            set { SetUsedValue("WaitBasedOnHourGlass", value); }
        }

        public virtual DirectoryInfo WorkSessionLocation
        {
            get { return new DirectoryInfo(UsedValues["WorkSessionLocation"]); }
            set { SetUsedValue("WorkSessionLocation", value); }
        }

        public virtual int UIAutomationZeroWindowBugTimeout
        {
            get { return Convert.ToInt32(UsedValues["UIAutomationZeroWindowBugTimeout"]); }
            set { SetUsedValue("UIAutomationZeroWindowBugTimeout", value); }
        }

        public virtual int PopupTimeout
        {
            get { return Convert.ToInt32(UsedValues["PopupTimeout"]); }
            set { SetUsedValue("PopupTimeout", value); }
        }

        public virtual int TooltipWaitTime
        {
            get { return Convert.ToInt32(UsedValues["TooltipWaitTime"]); }
            set { SetUsedValue("TooltipWaitTime", value); }
        }

        public virtual int SuggestionListTimeout
        {
            get { return Convert.ToInt32(UsedValues["SuggestionListTimeout"]); }
            set { SetUsedValue("SuggestionListTimeout", value); }
        }

        public virtual int HighlightTimeout
        {
            get { return Convert.ToInt32(UsedValues["HighlightTimeout"]); }
            set { SetUsedValue("HighlightTimeout", value); }
        }

        public virtual DateFormat DefaultDateFormat
        {
            get { return DateFormat.Parse(UsedValues["DefaultDateFormat"]); }
            set { UsedValues["DefaultDateFormat"] = value.ToString(); }
        }

        public virtual int DragStepCount
        {
            get { return Convert.ToInt32(UsedValues["DragStepCount"]); }
            set { SetUsedValue("DragStepCount", value); }
        }

        public virtual bool InProc
        {
            get { return Convert.ToBoolean(UsedValues["InProc"]); }
            set { SetUsedValue("InProc", value); }
        }

        public virtual bool ComboBoxItemsPopulatedWithoutDropDownOpen
        {
            get { return Convert.ToBoolean(UsedValues["ComboBoxItemsPopulatedWithoutDropDownOpen"]); }
            set { SetUsedValue("ComboBoxItemsPopulatedWithoutDropDownOpen", value); }
        }

        public virtual bool RawElementBasedSearch
        {
            get { return Convert.ToBoolean(UsedValues["RawElementBasedSearch"]); }
            set { SetUsedValue("RawElementBasedSearch", value); }
        }

        public virtual int MaxElementSearchDepth
        {
            get { return Convert.ToInt32(UsedValues["MaxElementSearchDepth"]); }
            set { SetUsedValue("MaxElementSearchDepth", value); }
        }

        public virtual int DoubleClickInterval
        {
            get { return Convert.ToInt32(UsedValues["DoubleClickInterval"]); }
            set { SetUsedValue("DoubleClickInterval", value); }
        }

        public virtual bool MoveMouseToGetStatusOfHourGlass
        {
            get { return Convert.ToBoolean(UsedValues["MoveMouseToGetStatusOfHourGlass"]); }
            set { SetUsedValue("MoveMouseToGetStatusOfHourGlass", value); }
        }

        /// <summary>
        /// Implements <see cref="ICoreConfiguration.KeepOpenOnDispose"/>
        /// </summary>
        public virtual bool KeepOpenOnDispose
        {
            get { return Convert.ToBoolean(UsedValues["KeepOpenOnDispose"]); }
            set { SetUsedValue("KeepOpenOnDispose", value); }
        }
    }
}