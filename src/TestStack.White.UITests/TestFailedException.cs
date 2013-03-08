using System;
using System.Runtime.Serialization;

namespace TestStack.White.UITests
{
    [Serializable]
    public class TestFailedException : Exception
    {
        public TestFailedException(string message) : base(message) { }
        public TestFailedException(string message, Exception innerException) : base(message, innerException) { }
        protected TestFailedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}