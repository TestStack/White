using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using TestStack.White.Bricks;
using TestStack.White.Interceptors;
using TestStack.White.UIItems;

namespace TestStack.White.Configuration
{
    /// <summary>
    /// Represents all the configuration at core level. These configuration can be set from the configuration file as well as programmatically.
    /// </summary>
    public class CoreConfiguration : ConfigurationBase<CoreConfiguration>
    {
        private const string BusyTimeoutKey = "BusyTimeout";
        private const string FindWindowTimeoutKey = "FindWindowTimeout";
        private const string WaitBasedOnHourGlassKey = "WaitBasedOnHourGlass";
        private const string WorkSessionLocationKey = "WorkSessionLocation";
        private const string UIAutomationZeroWindowBugTimeoutKey = "UIAutomationZeroWindowBugTimeout";
        private const string PopupTimeoutKey = "PopupTimeout";
        private const string TooltipWaitTimeKey = "TooltipWaitTime";
        private const string SuggestionListTimeoutKey = "SuggestionListTimeout";
        private const string HighlightTimeoutKey = "HighlightTimeout";
        private const string DefaultDateFormatKey = "DefaultDateFormat";
        private const string DragStepCountKey = "DragStepCount";
        private const string InProcKey = "InProc";
        private const string ComboBoxItemsPopulatedWithoutDropDownOpenKey = "ComboBoxItemsPopulatedWithoutDropDownOpen";
        private const string ComboBoxItemSelectionTimeoutKey = "ComboBoxItemSelectionTimeout";
        private const string RawInputQueueProcessingTimeKey = "RawInputQueueProcessingTime";
        private const string RawElementBasedSearchKey = "RawElementBasedSearch";
        private const string MaxElementSearchDepthKey = "MaxElementSearchDepth";
        private const string DoubleClickIntervalKey = "DoubleClickInterval";
        private const string MoveMouseToGetStatusOfHourGlassKey = "MoveMouseToGetStatusOfHourGlass";
        private const string KeepOpenOnDisposeKey = "KeepOpenOnDispose";

        private readonly DynamicProxyInterceptors interceptors = new DynamicProxyInterceptors();

        public CoreConfiguration()
        {
            interceptors.Add(new FocusInterceptor());
            interceptors.Add(new ScrollInterceptor());
            LoggerFactory = new WhiteDefaultLoggerFactory(LoggerLevel.Info);
        }

        public virtual ILoggerFactory LoggerFactory { get; set; }

        public virtual IWaitHook AdditionalWaitHook { get; set; }

        public virtual DynamicProxyInterceptors Interceptors
        {
            get { return interceptors; }
        }

        public override Dictionary<string, object> DefaultValues
        {
            get
            {
                return new Dictionary<string, object>
                {
                    {BusyTimeoutKey, 5000},
                    {FindWindowTimeoutKey, 30000},
                    {WaitBasedOnHourGlassKey, true},
                    {WorkSessionLocationKey, "."},
                    {UIAutomationZeroWindowBugTimeoutKey, 5000},
                    {PopupTimeoutKey, 5000},
                    {TooltipWaitTimeKey, 3000},
                    {SuggestionListTimeoutKey, 3000},
                    {HighlightTimeoutKey, 1000},
                    {DefaultDateFormatKey, DateFormat.CultureDefault.ToString()},
                    {DragStepCountKey, 1},
                    {InProcKey, false},
                    {ComboBoxItemsPopulatedWithoutDropDownOpenKey, false},
                    {ComboBoxItemSelectionTimeoutKey, 1000},
                    {RawInputQueueProcessingTimeKey, 50},
                    {RawElementBasedSearchKey, false},
                    {MaxElementSearchDepthKey, 10},
                    {DoubleClickIntervalKey, 0},
                    {MoveMouseToGetStatusOfHourGlassKey, true},
                    {KeepOpenOnDisposeKey, false}
                };
            }
        }

        public virtual int BusyTimeout
        {
            get { return GetValueInt32(BusyTimeoutKey); }
            set { SetValue(BusyTimeoutKey, value); }
        }

        public virtual int FindWindowTimeout
        {
            get { return GetValueInt32(FindWindowTimeoutKey); }
            set { SetValue(FindWindowTimeoutKey, value); }
        }

        public virtual bool WaitBasedOnHourGlass
        {
            get { return GetValueBoolean(WaitBasedOnHourGlassKey); }
            set { SetValue(WaitBasedOnHourGlassKey, value); }
        }

        public virtual DirectoryInfo WorkSessionLocation
        {
            get { return new DirectoryInfo(GetValue(WorkSessionLocationKey)); }
            set { SetValue(WorkSessionLocationKey, value); }
        }

        public virtual int UIAutomationZeroWindowBugTimeout
        {
            get { return GetValueInt32(UIAutomationZeroWindowBugTimeoutKey); }
            set { SetValue(UIAutomationZeroWindowBugTimeoutKey, value); }
        }

        public virtual int PopupTimeout
        {
            get { return GetValueInt32(PopupTimeoutKey); }
            set { SetValue(PopupTimeoutKey, value); }
        }

        public virtual int TooltipWaitTime
        {
            get { return GetValueInt32(TooltipWaitTimeKey); }
            set { SetValue(TooltipWaitTimeKey, value); }
        }

        public virtual int SuggestionListTimeout
        {
            get { return GetValueInt32(SuggestionListTimeoutKey); }
            set { SetValue(SuggestionListTimeoutKey, value); }
        }

        public virtual int HighlightTimeout
        {
            get { return GetValueInt32(HighlightTimeoutKey); }
            set { SetValue(HighlightTimeoutKey, value); }
        }

        public virtual DateFormat DefaultDateFormat
        {
            get { return DateFormat.Parse(GetValue(DefaultDateFormatKey)); }
            set { SetValue(DefaultDateFormatKey, value); }
        }

        public virtual int DragStepCount
        {
            get { return GetValueInt32(DragStepCountKey); }
            set { SetValue(DragStepCountKey, value); }
        }

        public virtual bool InProc
        {
            get { return GetValueBoolean(InProcKey); }
            set { SetValue(InProcKey, value); }
        }

        public virtual bool ComboBoxItemsPopulatedWithoutDropDownOpen
        {
            get { return GetValueBoolean(ComboBoxItemsPopulatedWithoutDropDownOpenKey); }
            set { SetValue(ComboBoxItemsPopulatedWithoutDropDownOpenKey, value); }
        }

        public virtual int ComboBoxItemSelectionTimeout
        {
            get { return GetValueInt32(ComboBoxItemSelectionTimeoutKey); }
            set { SetValue(ComboBoxItemSelectionTimeoutKey, value); }
        }

        public virtual int RawInputQueueProcessingTime
        {
            get { return GetValueInt32(RawInputQueueProcessingTimeKey); }
            set { SetValue(RawInputQueueProcessingTimeKey, value); }
        }

        public virtual bool RawElementBasedSearch
        {
            get { return GetValueBoolean(RawElementBasedSearchKey); }
            set { SetValue(RawElementBasedSearchKey, value); }
        }

        public virtual int MaxElementSearchDepth
        {
            get { return GetValueInt32(MaxElementSearchDepthKey); }
            set { SetValue(MaxElementSearchDepthKey, value); }
        }

        public virtual int DoubleClickInterval
        {
            get { return GetValueInt32(DoubleClickIntervalKey); }
            set { SetValue(DoubleClickIntervalKey, value); }
        }

        public virtual bool MoveMouseToGetStatusOfHourGlass
        {
            get { return GetValueBoolean(MoveMouseToGetStatusOfHourGlassKey); }
            set { SetValue(MoveMouseToGetStatusOfHourGlassKey, value); }
        }

        /// <summary>
        /// Flag to allow keeping the <see cref="TestStack.White.Application"/> and <see cref="TestStack.White.UIItems.WindowItems.Window" />
        /// open after White has disposed it's objects.
        /// </summary>
        public virtual bool KeepOpenOnDispose
        {
            get { return GetValueBoolean(KeepOpenOnDisposeKey); }
            set { SetValue(KeepOpenOnDisposeKey, value); }
        }
    }
}
