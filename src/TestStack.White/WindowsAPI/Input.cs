using System.Runtime.InteropServices;

namespace White.Core.WindowsAPI
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Input
    {
        [FieldOffset(0)] private int type;
        [FieldOffset(4)] private MouseInput mi;
        [FieldOffset(4)] private KeyboardInput ki;
        [FieldOffset(4)] private readonly HardwareInput hi;

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