using System;

namespace White.Core.Factory
{
    public class UIItemSearchException : Exception
    {
        public UIItemSearchException(string message) : base(message) {}
        public UIItemSearchException(string message, Exception exception) : base(message, exception) {}
    }
}