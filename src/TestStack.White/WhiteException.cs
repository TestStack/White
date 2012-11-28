using System;

namespace White.Core
{
    public class WhiteException : Exception
    {
        public WhiteException(string message) : base(message) {}
        public WhiteException(string message, Exception innerException) : base(message, innerException) { }
        public WhiteException(string message, string debugDetails) : base(message)
        {
            DebugDetails = debugDetails;
        }

        public WhiteException(string message, string debugDetails, Exception innerException) : base(message, innerException)
        {
            DebugDetails = debugDetails;
        }

        public virtual string DebugDetails { get; private set; }
    }
}