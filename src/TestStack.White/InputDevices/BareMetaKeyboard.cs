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
    public class BareMetaKeyboard
    {
        protected static readonly List<KeyboardInput.SpecialKeys> ScanCodeDependent = new List<KeyboardInput.SpecialKeys>
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
        protected static extern int SendInput(uint numberOfInputs, ref Input input, int structSize);

        [DllImport("user32", EntryPoint = "SendInput")]
        protected static extern int SendInput64(int numberOfInputs, ref Input64 input, int structSize);

        [DllImport("user32.dll")]
        protected static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]
        protected static extern short VkKeyScan(char ch);

        [DllImport("user32.dll")]
        protected static extern ushort GetKeyState(uint virtKey);

        protected static bool ShiftKeyIsNeeded(short key)
        {
            return ((key >> 8) & 1) == 1;
        }

        protected static bool CtrlKeyIsNeeded(short key)
        {
            return ((key >> 8) & 2) == 2;
        }

        protected static bool AltKeyIsNeeded(short key)
        {
            return ((key >> 8) & 4) == 4;
        }

        protected static KeyboardInput.KeyUpDown GetSpecialKeyCode(bool specialKey, KeyboardInput.KeyUpDown key)
        {
            if (specialKey && ScanCodeDependent.Contains((KeyboardInput.SpecialKeys) key)) key |= KeyboardInput.KeyUpDown.KEYEVENTF_EXTENDEDKEY;
            return key;
        }

        protected static void SendInput(Input input)
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

        protected static Input GetInputFor(short character, KeyboardInput.KeyUpDown keyUpOrDown)
        {
            return InputFactory.Keyboard(new KeyboardInput(character, keyUpOrDown, GetMessageExtraInfo()));
        }
    }
}