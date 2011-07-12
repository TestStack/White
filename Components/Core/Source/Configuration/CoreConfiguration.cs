using System.IO;
using Bricks.DynamicProxy;
using White.Core.UIItems;

namespace White.Core.Configuration
{
    /// <summary>
    /// Represents all the configuration at Core level. These configuration can be set from the configuration file as well as programmatically.
    /// </summary>
    public interface CoreConfiguration
    {
        int BusyTimeout { get; set; }
        bool WaitBasedOnHourGlass { get; set; }
        DynamicProxyInterceptors Interceptors { get; }
        DirectoryInfo WorkSessionLocation { get; set; }
        int UIAutomationZeroWindowBugTimeout { get; set; }
        int PopupTimeout { get; set; }
        int TooltipWaitTime { get; set; }
        int SuggestionListTimeout { get; set; }
        DateFormat DefaultDateFormat { get; set; }
        int DragStepCount { get; }
        bool InProc { get; set; }
        bool ComboBoxItemsPopulatedWithoutDropDownOpen { get; set; }
        IWaitHook AdditionalWaitHook { get; set; }
        int MaxElementSearchDepth { get; set; }
        bool RawElementBasedSearch { get; set; }
        int DoubleClickInterval { get; set; }
        bool MoveMouseToGetStatusOfHourGlass { get; set; }
    }
}