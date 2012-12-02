using System;

namespace White.Core.Mappings
{
    public class ControlDictionaryException : Exception
    {
        public ControlDictionaryException(string message) : base(message) {}
        public ControlDictionaryException(string message, Exception exception) : base(message, exception) {}
    }
}