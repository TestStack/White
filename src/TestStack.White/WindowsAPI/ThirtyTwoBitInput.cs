using System.Runtime.InteropServices;
using White.Core.InputDevices;

namespace White.Core.WindowsAPI
{
    [StructLayout(LayoutKind.Explicit)]
    public struct ThirtyTwoBitInput
    {
        [FieldOffset(0)] private int type;
        [FieldOffset(4)] private MouseInput mi;
        [FieldOffset(4)] private KeyboardInput ki;
        [FieldOffset(4)] private readonly HardwareInput hi;

        public static ThirtyTwoBitInput Mouse(MouseInput mouseInput)
        {
            return new ThirtyTwoBitInput {type = WindowsConstants.INPUT_MOUSE, mi = mouseInput};
        }

        public static ThirtyTwoBitInput Keyboard(KeyboardInput keyboardInput)
        {
            return new ThirtyTwoBitInput {type = WindowsConstants.INPUT_KEYBOARD, ki = keyboardInput};
        }
    }
}