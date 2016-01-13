using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TestStack.White.WindowsAPI;

namespace TestStack.White.InputDevices
{
    //BUG: KeysConverter
    /// <summary>
    /// Represents Keyboard attachment to the machine.
    /// </summary>
    internal static class KeyboardWin32
    {
        private static readonly List<KeyboardInput.SpecialKeys> ScanCodeDependent = new List<KeyboardInput.SpecialKeys>
                                                                               {
                                                                                   KeyboardInput.SpecialKeys.RIGHT_ALT,
                                                                                   KeyboardInput.SpecialKeys.INSERT,
                                                                                   KeyboardInput.SpecialKeys.DELETE,
                                                                                   KeyboardInput.SpecialKeys.LEFT,
                                                                                   KeyboardInput.SpecialKeys.HOME,
                                                                                   KeyboardInput.SpecialKeys.END,
                                                                                   KeyboardInput.SpecialKeys.UP,
                                                                                   KeyboardInput.SpecialKeys.DOWN,
                                                                                   KeyboardInput.SpecialKeys.PAGEUP,
                                                                                   KeyboardInput.SpecialKeys.PAGEDOWN,
                                                                                   KeyboardInput.SpecialKeys.RIGHT,
                                                                                   KeyboardInput.SpecialKeys.LWIN,
                                                                                   KeyboardInput.SpecialKeys.RWIN
                                                                               };

        [DllImport("user32", EntryPoint = "SendInput")]
        private static extern int SendInput(uint numberOfInputs, ref Input input, int structSize);

        [DllImport("user32", EntryPoint = "SendInput")]
        private static extern int SendInput64(int numberOfInputs, ref Input64 input, int structSize);

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]
        internal static extern short VkKeyScan(char ch);

        [DllImport("user32.dll")]
        internal static extern ushort GetKeyState(uint virtKey);

        internal static bool ShiftKeyIsNeeded(short key)
        {
            return ((key >> 8) & 1) == 1;
        }

        internal static bool CtrlKeyIsNeeded(short key)
        {
            return ((key >> 8) & 2) == 2;
        }

        internal static bool AltKeyIsNeeded(short key)
        {
            return ((key >> 8) & 4) == 4;
        }

        internal static KeyboardInput.KeyUpDown GetSpecialKeyCode(bool specialKey, KeyboardInput.KeyUpDown key)
        {
            if (specialKey && ScanCodeDependent.Contains((KeyboardInput.SpecialKeys) key)) key |= KeyboardInput.KeyUpDown.KEYEVENTF_EXTENDEDKEY;
            return key;
        }

        internal static void SendInput(Input input)
        {
            // Added check for 32/64 bit  
            if (IntPtr.Size == 4)
                SendInput(1, ref input, Marshal.SizeOf(typeof(Input)));
            else
            {
                var input64 = new Input64(input);
                SendInput64(1, ref input64, Marshal.SizeOf(typeof(Input)));
            }
        }

        internal static Input GetInputFor(short character, KeyboardInput.KeyUpDown keyUpOrDown)
        {
            return InputFactory.Keyboard(new KeyboardInput(character, keyUpOrDown, GetMessageExtraInfo()));
        }
    }
}