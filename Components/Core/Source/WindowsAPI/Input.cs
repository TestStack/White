using System.Runtime.InteropServices;
using White.Core.InputDevices;

namespace White.Core.WindowsAPI
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Input
    {
        [FieldOffset(0)] private int type;
        [FieldOffset(4)] private MouseInput mi;
        [FieldOffset(4)] private KeyboardInput ki;
        [FieldOffset(4)] private readonly HardwareInput hi;

        public static Input Mouse(MouseInput mouseInput)
        {
            return new Input {type = WindowsConstants.INPUT_MOUSE, mi = mouseInput};
        }

        public static Input Keyboard(KeyboardInput keyboardInput)
        {
            return new Input {type = WindowsConstants.INPUT_KEYBOARD, ki = keyboardInput};
        }
    }
}