using System;

namespace White.Core.CustomCommands
{
    public class CustomCommandException : Exception
    {
        public CustomCommandException(string message) : base(message)
        {
        }

        public CustomCommandException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}