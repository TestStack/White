using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TestStack.White.UIItems.Actions;
using TestStack.White.WindowsAPI;
using Action = TestStack.White.UIItems.Actions.Action;

namespace TestStack.White.InputDevices
{
    //BUG: KeysConverter
    /// <summary>
    /// Represents Keyboard attachment to the machine.
    /// </summary>
    public class Keyboard : IKeyboard
    {
        private static readonly List<KeyboardInput.SpecialKeys> scanCodeDependent = new List<KeyboardInput.SpecialKeys>
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

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]
        private static extern short VkKeyScan(char ch);

        [DllImport("user32.dll")]
        private static extern ushort GetKeyState(uint virtKey);

        private readonly List<KeyboardInput.SpecialKeys> heldKeys = new List<KeyboardInput.SpecialKeys>();

        /// <summary>
        /// Use Window.Keyboard method to get handle to the Keyboard. Keyboard instance got using this method would not wait while the application
        /// is busy.
        /// </summary>
        public static readonly Keyboard Instance = new Keyboard();

        private readonly List<int> keysHeld = new List<int>();

        private Keyboard()
        {
        }

        public virtual void Enter(string keysToType)
        {
            Send(keysToType, new NullActionListener());
        }

        public virtual void Send(string keysToType, ActionListener actionListener)
        {
            if (heldKeys.Count > 0) keysToType = keysToType.ToLower();

            CapsLockOn = false;
            foreach (char c in keysToType)
            {
                short key = VkKeyScan(c);
                if (c.Equals('\r')) continue;

                if (ShiftKeyIsNeeded(key)) SendKeyDown((short) KeyboardInput.SpecialKeys.SHIFT, false);
                if (CtrlKeyIsNeeded(key)) SendKeyDown((short) KeyboardInput.SpecialKeys.CONTROL, false);
                if (AltKeyIsNeeded(key)) SendKeyDown((short) KeyboardInput.SpecialKeys.ALT, false);
                Press(key, false);
                if (ShiftKeyIsNeeded(key)) SendKeyUp((short) KeyboardInput.SpecialKeys.SHIFT, false);
                if (CtrlKeyIsNeeded(key)) SendKeyUp((short) KeyboardInput.SpecialKeys.CONTROL, false);
                if (AltKeyIsNeeded(key)) SendKeyUp((short) KeyboardInput.SpecialKeys.ALT, false);
            }

            actionListener.ActionPerformed(Action.WindowMessage);
        }

        public virtual void PressSpecialKey(KeyboardInput.SpecialKeys key)
        {
            PressSpecialKey(key, new NullActionListener());
        }

        public virtual void PressSpecialKey(KeyboardInput.SpecialKeys key, ActionListener actionListener)
        {
            Send(key, true);
            actionListener.ActionPerformed(Action.WindowMessage);
        }

        public virtual void HoldKey(KeyboardInput.SpecialKeys key)
        {
            HoldKey(key, new NullActionListener());
        }

        internal virtual void HoldKey(KeyboardInput.SpecialKeys key, ActionListener actionListener)
        {
            SendKeyDown((short) key, true);
            heldKeys.Add(key);
            actionListener.ActionPerformed(Action.WindowMessage);
        }

        public virtual void LeaveKey(KeyboardInput.SpecialKeys key)
        {
            LeaveKey(key, new NullActionListener());
        }

        public virtual void LeaveKey(KeyboardInput.SpecialKeys key, ActionListener actionListener)
        {
            SendKeyUp((short) key, true);
            heldKeys.Remove(key);
            actionListener.ActionPerformed(Action.WindowMessage);
        }

        private void Press(short key, bool specialKey)
        {
            SendKeyDown(key, specialKey);
            SendKeyUp(key, specialKey);
        }

        private void Send(KeyboardInput.SpecialKeys key, bool specialKey)
        {
            Press((short) key, specialKey);
        }

        private static bool ShiftKeyIsNeeded(short key)
        {
            return ((key >> 8) & 1) == 1;
        }

        private static bool CtrlKeyIsNeeded(short key)
        {
            return ((key >> 8) & 2) == 2;
        }

        private static bool AltKeyIsNeeded(short key)
        {
            return ((key >> 8) & 4) == 4;
        }

        private void SendKeyUp(short b, bool specialKey)
        {
            if (!keysHeld.Contains(b)) throw new InputDeviceException(string.Format("Cannot unpress the key {0}, it has not been pressed", b));
            keysHeld.Remove(b);
            KeyboardInput.KeyUpDown keyUpDown = GetSpecialKeyCode(specialKey, KeyboardInput.KeyUpDown.KEYEVENTF_KEYUP);
            SendInput(GetInputFor(b, keyUpDown));
        }

        private static KeyboardInput.KeyUpDown GetSpecialKeyCode(bool specialKey, KeyboardInput.KeyUpDown key)
        {
            if (specialKey && scanCodeDependent.Contains((KeyboardInput.SpecialKeys) key)) key |= KeyboardInput.KeyUpDown.KEYEVENTF_EXTENDEDKEY;
            return key;
        }

        private void SendKeyDown(short b, bool specialKey)
        {
            if (keysHeld.Contains(b)) throw new InputDeviceException(string.Format("Cannot press the key {0} as its already pressed", b));
            keysHeld.Add(b);
            KeyboardInput.KeyUpDown keyUpDown = GetSpecialKeyCode(specialKey, KeyboardInput.KeyUpDown.KEYEVENTF_KEYDOWN);
            SendInput(GetInputFor(b, keyUpDown));
        }

        private static void SendInput(Input input)
        {
            SendInput(1, ref input, Marshal.SizeOf(typeof (Input)));
        }

        private static Input GetInputFor(short character, KeyboardInput.KeyUpDown keyUpOrDown)
        {
            return InputFactory.Keyboard(new KeyboardInput(character, keyUpOrDown, GetMessageExtraInfo()));
        }

        public virtual bool CapsLockOn
        {
            get
            {
                ushort state = GetKeyState((uint) KeyboardInput.SpecialKeys.CAPS);
                return state != 0;
            }
            set { if (CapsLockOn != value) Send(KeyboardInput.SpecialKeys.CAPS, true); }
        }

        public virtual KeyboardInput.SpecialKeys[] HeldKeys
        {
            get { return heldKeys.ToArray(); }
        }

        public virtual void LeaveAllKeys()
        {
            new List<KeyboardInput.SpecialKeys>(heldKeys).ForEach(LeaveKey);
        }
    }
}