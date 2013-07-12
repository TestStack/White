using System;
using System.Runtime.Serialization;

namespace TestStack.White
{
    [Serializable]
    public class AutomationException : Exception
    {
        public AutomationException(string message, string debugDetails)
            : base(message)
        {
            DebugDetails = debugDetails;
        }

        public AutomationException(string message, string debugDetails, Exception innerException)
            : base(message, innerException)
        {
            DebugDetails = debugDetails;
        }

        protected AutomationException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Contains the current UI Automation tree
        /// </summary>
        public virtual string DebugDetails { get; private set; }
    }
}