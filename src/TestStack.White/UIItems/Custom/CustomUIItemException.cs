using System;

namespace White.Core.UIItems.Custom
{
    public class CustomUIItemException : Exception
    {
        public CustomUIItemException(string message) : base(message) {}
        public CustomUIItemException(string message, Exception exception) : base(message, exception) {}
    }
}