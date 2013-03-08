using System;
using System.Runtime.Serialization;

namespace White.Core
{
    [Serializable]
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

        protected WhiteException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public virtual string DebugDetails { get; private set; }
    }
}