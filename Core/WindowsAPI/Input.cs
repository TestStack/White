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
        [FieldOffset(4)] private HardwareInput hi;

        public static Input Mouse(MouseInput mouseInput)
        {
            Input input = new Input();
            input.type = WindowsConstants.INPUT_MOUSE;
            input.mi = mouseInput;
            return input;
        }

        public static Input Keyboard(KeyboardInput keyboardInput)
        {
            Input input = new Input();
            input.type = WindowsConstants.INPUT_KEYBOARD;
            input.ki = keyboardInput;
            return input;
        }
    }
}