using System;

namespace White.Core.UIItems
{
    //TODO: Change NUnit code to provide aspects, Checkout NUnit code and fix it
    [Serializable]
    public class UIActionException : Exception
    {
        public UIActionException(string message) : base(message) {}

        public UIActionException(string message, Exception innerException) : base(message, innerException) {}
    }
}