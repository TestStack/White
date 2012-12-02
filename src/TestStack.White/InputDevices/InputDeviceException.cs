using System;

namespace White.Core.InputDevices
{
    public class InputDeviceException : Exception
    {
        public InputDeviceException(string message) : base(message) {}
        public InputDeviceException(string message, Exception exception) : base(message, exception) {}
    }
}