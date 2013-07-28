using System.Runtime.InteropServices;

namespace TestStack.White.WindowsAPI
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Input
    {
        [FieldOffset(0)]
        public int type;
        [FieldOffset(4)]
        public MouseInput mi;
        [FieldOffset(4)]
        public KeyboardInput ki;
        [FieldOffset(4)]
        public readonly HardwareInput hi;

        public static Input MouseInput(int type, MouseInput mouseInput)
        {
            return new Input {type = type, mi = mouseInput};
        }

        public static Input KeyboardInput(int type, KeyboardInput keyboardInput)
        {
            return new Input {type = type, ki = keyboardInput};
        }
    }
}