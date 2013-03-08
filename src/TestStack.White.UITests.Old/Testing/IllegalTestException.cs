using System;
using System.Runtime.Serialization;

namespace White.Core.UITests.Testing
{
    [Serializable]
    public class IllegalTestException : Exception
    {
        public IllegalTestException(string message) : base(message) { }
        public IllegalTestException(string message, Exception innerException) : base(message, innerException) { }
        protected IllegalTestException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}