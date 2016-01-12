using System;
using System.IO;
using Castle.Core.Logging;
using TestStack.White.Bricks;
using TestStack.White.UIItems;

namespace TestStack.White.Configuration
{
    /// <summary>
    /// Represents all the configuration at Core level. These configuration can be set from the configuration file as well as programmatically.
    /// </summary>
    public interface ICoreConfiguration
    {
        ILoggerFactory LoggerFactory { get; set; }
        IDisposable ApplyTemporarySetting(Action<ICoreConfiguration> changes);
        IWaitHook AdditionalWaitHook { get; set; }
        DynamicProxyInterceptors Interceptors { get; }

        /// <summary>
        /// In Milliseconds
        /// </summary>
        int BusyTimeout { get; set; }
        int FindWindowTimeout { get; set; }
        bool WaitBasedOnHourGlass { get; set; }
        DirectoryInfo WorkSessionLocation { get; set; }
        int UIAutomationZeroWindowBugTimeout { get; set; }
        int PopupTimeout { get; set; }
        int TooltipWaitTime { get; set; }
        int SuggestionListTimeout { get; set; }
        int HighlightTimeout { get; set; }
        DateFormat DefaultDateFormat { get; set; }
        int DragStepCount { get; set; }
        bool InProc { get; set; }
        bool ComboBoxItemsPopulatedWithoutDropDownOpen { get; set; }
        int ComboBoxItemSelectionTimeout { get; set; }
        int RawInputQueueProcessingTime { get; set; }
        bool RawElementBasedSearch { get; set; }
        int MaxElementSearchDepth { get; set; }
        int DoubleClickInterval { get; set; }
        bool MoveMouseToGetStatusOfHourGlass { get; set; }
        /// <summary>
        /// Flag to allow keeping the <see cref="TestStack.White.Application"/> and <see cref="TestStack.White.UIItems.WindowItems.Window" />
        /// open after White has disposed it's objects.
        /// </summary>
        bool KeepOpenOnDispose { get;set;}
    }
}