using System.Runtime.InteropServices;
using TestStack.White.WindowsAPI;

namespace TestStack.White.InputDevices
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Input64
    {
        [FieldOffset(0)]
        public int type;
        [FieldOffset(8)]
        public MouseInput mi;
        [FieldOffset(8)]
        public KeyboardInput ki;
        [FieldOffset(8)]
        public HardwareInput hi;

        /// <summary>
        /// Converts a 32bit Input to a 64bit Input
        /// </summary>
        /// <param name="input"></param>
        public Input64(Input input)
        {
            type = input.type;
            mi = input.mi;
            ki = input.ki;
            hi = input.hi;
        }
    }
}