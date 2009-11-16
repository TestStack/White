using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using White.Core.UIItems.Actions;
using White.Core.WindowsAPI;
using Action=White.Core.UIItems.Actions.Action;

namespace White.Core.InputDevices
{
    //BUG: KeysConverter
    /// <summary>
    /// Represents Keyboard attachment to the machine.
    /// </summary>
    public class Keyboard : IKeyboard
    {
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
        public static Keyboard Instance = new Keyboard();

        private readonly List<int> keysHeld = new List<int>();

        private Keyboard() {}

        public virtual void Enter(string keysToType)
        {
            Send(keysToType, new NullActionListener());
        }

        public virtual void Send(string keysToType, ActionListener actionListener)
        {
            CapsLockOn = false;
            foreach (char c in keysToType)
            {
                short key = VkKeyScan(c);
                if (c.Equals('\r')) continue;

                if (ShiftKeyIsNeeded(key)) SendKeyDown((short) KeyboardInput.SpecialKeys.SHIFT, false);
                Press(key, false);
                if (ShiftKeyIsNeeded(key)) SendKeyUp((short) KeyboardInput.SpecialKeys.SHIFT, false);
                actionListener.ActionPerformed(Action.WindowMessage);
            }
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

        private void SendKeyUp(short b, bool specialKey)
        {
            if (!keysHeld.Contains(b)) throw new InputDeviceException("Cannot press the key " + b + " as its already pressed");
            keysHeld.Remove(b);
            KeyboardInput.KeyUpDown keyUpDown = KeyboardInput.KeyUpDown.KEYEVENTF_KEYUP;
            if (specialKey) keyUpDown |= KeyboardInput.KeyUpDown.KEYEVENTF_EXTENDEDKEY;
            SendInput(GetInputFor(b, keyUpDown));
        }

        private void SendKeyDown(short b, bool specialKey)
        {
            if (keysHeld.Contains(b)) throw new InputDeviceException("Cannot press the key " + b + " as its already pressed");
            keysHeld.Add(b);
            KeyboardInput.KeyUpDown keyUpDown = KeyboardInput.KeyUpDown.KEYEVENTF_KEYDOWN;
            if (specialKey) keyUpDown |= KeyboardInput.KeyUpDown.KEYEVENTF_EXTENDEDKEY;
            SendInput(GetInputFor(b, keyUpDown));
        }

        private static void SendInput(Input input)
        {
            SendInput(1, ref input, Marshal.SizeOf(typeof (Input)));
        }

        private static Input GetInputFor(short character, KeyboardInput.KeyUpDown keyUpOrDown)
        {
            return Input.Keyboard(new KeyboardInput(character, keyUpOrDown, GetMessageExtraInfo()));
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
            var list = new List<KeyboardInput.SpecialKeys>(heldKeys);
            list.ForEach(LeaveKey);
        }
    }
}