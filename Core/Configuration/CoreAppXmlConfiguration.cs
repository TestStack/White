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
            defaultValues.Add(CodePath.Get(CodePath.New<CoreConfiguration>().BusyTimeout), 5000);
            defaultValues.Add(CodePath.Get(CodePath.New<CoreConfiguration>().WaitBasedOnHourGlass), true);
            defaultValues.Add(CodePath.Get(CodePath.New<CoreConfiguration>().WorkSessionLocation), ".");
            defaultValues.Add(CodePath.Get(CodePath.New<CoreConfiguration>().UIAutomationZeroWindowBugTimeout), 5000);
            defaultValues.Add(CodePath.Get(CodePath.New<CoreConfiguration>().PopupTimeout), 5000);
            defaultValues.Add(CodePath.Get(CodePath.New<CoreConfiguration>().TooltipWaitTime), 0);
            defaultValues.Add(CodePath.Get(CodePath.New<CoreConfiguration>().SuggestionListTimeout), 3000);
            defaultValues.Add(CodePath.Get(CodePath.New<CoreConfiguration>().DefaultDateFormat), DateFormat.CultureDefault.ToString());
            defaultValues.Add(CodePath.Get(CodePath.New<CoreConfiguration>().DragStepCount), 1);
            defaultValues.Add(CodePath.Get(CodePath.New<CoreConfiguration>().InProc), false);
            defaultValues.Add(CodePath.Get(CodePath.New<CoreConfiguration>().ComboBoxItemsPopulatedWithoutDropDownOpen), true);
            defaultValues.Add(CodePath.Get(CodePath.New<CoreConfiguration>().RawElementBasedSearch), false);
            defaultValues.Add(CodePath.Get(CodePath.New<CoreConfiguration>().MaxElementSearchDepth), 10);
        }

        public static CoreConfiguration Instance
        {
            get
            {
                if (instance == null) instance = new CoreAppXmlConfiguration();
                return instance;
            }
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
            get { return new DirectoryInfo(usedValues[CodePath.Get(CodePath.New<CoreConfiguration>().WorkSessionLocation)]); }
            set { SetUsedValue(CodePath.Get(CodePath.New<CoreConfiguration>().WorkSessionLocation), value); }
        }

        public virtual int BusyTimeout
        {
            get { return S.ToInt(usedValues[CodePath.Get(CodePath.New<CoreConfiguration>().BusyTimeout)]); }
            set { SetUsedValue(CodePath.Get(CodePath.New<CoreConfiguration>().BusyTimeout), value); }
        }

        public virtual bool WaitBasedOnHourGlass
        {
            get { return S.ToBool(usedValues[CodePath.Get(CodePath.New<CoreConfiguration>().WaitBasedOnHourGlass)]); }
            set { SetUsedValue(CodePath.Get(CodePath.New<CoreConfiguration>().WaitBasedOnHourGlass), value); }
        }

        public virtual DynamicProxyInterceptors Interceptors
        {
            get { return interceptors; }
        }

        public virtual int UIAutomationZeroWindowBugTimeout
        {
            get { return S.ToInt(usedValues[CodePath.Get(CodePath.New<CoreConfiguration>().UIAutomationZeroWindowBugTimeout)]); }
            set { SetUsedValue(CodePath.Get(CodePath.New<CoreConfiguration>().UIAutomationZeroWindowBugTimeout), value); }
        }

        public virtual int PopupTimeout
        {
            get { return S.ToInt(usedValues[CodePath.Get(CodePath.New<CoreConfiguration>().PopupTimeout)]); }
            set { SetUsedValue(CodePath.Get(CodePath.New<CoreConfiguration>().PopupTimeout), value); }
        }

        public virtual int TooltipWaitTime
        {
            get { return S.ToInt(usedValues[CodePath.Get(CodePath.New<CoreConfiguration>().TooltipWaitTime)]); }
            set { SetUsedValue(CodePath.Get(CodePath.New<CoreConfiguration>().TooltipWaitTime), value); }
        }

        public virtual int SuggestionListTimeout
        {
            get { return S.ToInt(usedValues[CodePath.Get(CodePath.New<CoreConfiguration>().SuggestionListTimeout)]); }
            set { SetUsedValue(CodePath.Get(CodePath.New<CoreConfiguration>().SuggestionListTimeout), value); }
        }

        public virtual DateFormat DefaultDateFormat
        {
            get { return DateFormat.Parse(usedValues[CodePath.Get(CodePath.New<CoreConfiguration>().DefaultDateFormat)]); }
            set { usedValues[CodePath.Get(CodePath.New<CoreConfiguration>().DefaultDateFormat)] = value.ToString(); }
        }

        public virtual int DragStepCount
        {
            get { return S.ToInt(usedValues[CodePath.Get(CodePath.New<CoreConfiguration>().DragStepCount)]); }
            set { SetUsedValue(CodePath.Get(CodePath.New<CoreConfiguration>().DragStepCount), value); }
        }

        public virtual bool InProc
        {
            get { return S.ToBool(usedValues[CodePath.Get(CodePath.New<CoreConfiguration>().InProc)]); }
            set { SetUsedValue(CodePath.Get(CodePath.New<CoreConfiguration>().InProc), value); }
        }

        public virtual bool ComboBoxItemsPopulatedWithoutDropDownOpen
        {
            get { return S.ToBool(usedValues[CodePath.Get(CodePath.New<CoreConfiguration>().ComboBoxItemsPopulatedWithoutDropDownOpen)]); }
            set { SetUsedValue(CodePath.Get(CodePath.New<CoreConfiguration>().ComboBoxItemsPopulatedWithoutDropDownOpen), value); }
        }

        public virtual IWaitHook AdditionalWaitHook { get; set; }

        public virtual int MaxElementSearchDepth
        {
            get { return S.ToInt(usedValues[CodePath.Get(CodePath.New<CoreConfiguration>().MaxElementSearchDepth)]); }
            set { SetUsedValue(CodePath.Get(CodePath.New<CoreConfiguration>().MaxElementSearchDepth), value); }
        }

        public virtual bool RawElementBasedSearch
        {
            get { return S.ToBool(usedValues[CodePath.Get(CodePath.New<CoreConfiguration>().RawElementBasedSearch)]); }
            set { SetUsedValue(CodePath.Get(CodePath.New<CoreConfiguration>().RawElementBasedSearch), value); }
        }
    }
}