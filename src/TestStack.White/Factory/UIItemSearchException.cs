using System;
using System.Runtime.Serialization;

namespace TestStack.White.Factory
{
    [Serializable]
    public class UIItemSearchException : Exception
    {
        public UIItemSearchException(string message) : base(message) { }
        public UIItemSearchException(string message, Exception exception) : base(message, exception) { }
        protected UIItemSearchException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}