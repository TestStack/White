using System;

namespace White.Core
{
    public class AutomationException : Exception
    {
        public AutomationException(string message, string debugDetails) : base(message)
        {
            DebugDetails = debugDetails;
        }

        public AutomationException(string message, string debugDetails, Exception innerException) : base(message, innerException)
        {
            DebugDetails = debugDetails;
        }

        /// <summary>
        /// Contains the current UI Automation tree
        /// </summary>
        public string DebugDetails { get; private set; }
    }
}