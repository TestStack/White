using System;
using System.Runtime.Serialization;

namespace TestStack.White.UIItems.Custom
{
    [Serializable]
    public class CustomUIItemException : Exception
    {
        public CustomUIItemException(string message) : base(message) { }
        public CustomUIItemException(string message, Exception exception) : base(message, exception) { }
        protected CustomUIItemException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}