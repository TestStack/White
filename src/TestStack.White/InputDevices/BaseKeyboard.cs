using System.Collections.Generic;
using TestStack.White.UIItems.Actions;
using TestStack.White.WindowsAPI;

namespace TestStack.White.InputDevices
{
    // BUG: KeysConverter
    /// <summary>
    /// Represents Keyboard attachment to the machine.
    /// </summary>
    public abstract class BaseKeyboard : BareMetaKeyboard, IBaseKeyboard
    {
        #region Fields

        private readonly List<KeyboardInput.SpecialKeys> heldKeys = new List<KeyboardInput.SpecialKeys>();
        protected readonly List<int> KeysHeld = new List<int>();
        
        #endregion

        protected BaseKeyboard()
        {
            heldKeys = new List<KeyboardInput.SpecialKeys>();
        }

        #region Implements IKeyboard

        /// <summary>
        /// Implements <see cref="IBaseKeyboard.Enter(string)"/>
        /// </summary>
        public abstract void Enter(string keysToType);

        /// <summary>
        /// Implements <see cref="IBaseKeyboard.PressSpecialKey(KeyboardInput.SpecialKeys)"/>
        /// </summary>
        public abstract void PressSpecialKey(KeyboardInput.SpecialKeys key);

        /// <summary>
        /// Implements <see cref="IBaseKeyboard.HoldKey(KeyboardInput.SpecialKeys)"/>
        /// </summary>
        public abstract void HoldKey(KeyboardInput.SpecialKeys key);

        /// <summary>
        /// Implements <see cref="IBaseKeyboard.LeaveKey(KeyboardInput.SpecialKeys)"/>
        /// </summary>
        public abstract void LeaveKey(KeyboardInput.SpecialKeys key);

        /// <summary>
        /// Implements <see cref="IBaseKeyboard.CapsLockOn"/>
        /// </summary>
        public virtual bool CapsLockOn
        {
            get
            {
                var state = GetKeyState((uint) KeyboardInput.SpecialKeys.CAPS);
                return state != 0;
            }
            set
            {
                if (CapsLockOn != value)
                {
                    Send(KeyboardInput.SpecialKeys.CAPS, true);
                }
            }
        }

        /// <summary>
        /// Implements <see cref="IBaseKeyboard.HeldKeys"/>
        /// </summary>
        public virtual KeyboardInput.SpecialKeys[] HeldKeys
        {
            get
            {
                return heldKeys.ToArray();
            }
        }

        /// <summary>
        /// Implements <see cref="IBaseKeyboard.LeaveAllKeys()"/>
        /// </summary>
        public virtual void LeaveAllKeys()
        {
            new List<KeyboardInput.SpecialKeys>(heldKeys).ForEach(LeaveKey);
        }

        #endregion

        #region Protected

        protected virtual void Press(short key, bool specialKey)
        {
            SendKeyDown(key, specialKey);
            SendKeyUp(key, specialKey);
        }

        protected virtual void Send(KeyboardInput.SpecialKeys key, bool specialKey)
        {
            Press((short)key, specialKey);
        }

        protected virtual void SendKeyUp(short b, bool specialKey)
        {
            if (!KeysHeld.Contains(b))
            {
                throw new InputDeviceException(string.Format("Cannot unpress the key {0}, it has not been pressed", b));
            }
            KeysHeld.Remove(b);
            var keyUpDown = GetSpecialKeyCode(specialKey, KeyboardInput.KeyUpDown.KEYEVENTF_KEYUP);
            SendInput(GetInputFor(b, keyUpDown));
        }

        protected virtual void SendKeyDown(short b, bool specialKey)
        {
            if (KeysHeld.Contains(b))
            {
                throw new InputDeviceException(string.Format("Cannot press the key {0} as its already pressed", b));
            }
            KeysHeld.Add(b);
            var keyUpDown = GetSpecialKeyCode(specialKey, KeyboardInput.KeyUpDown.KEYEVENTF_KEYDOWN);
            SendInput(GetInputFor(b, keyUpDown));
        }

        protected virtual void AddUsedKey(KeyboardInput.SpecialKeys key)
        {
            if (heldKeys.Contains(key))
            {
                return;
            }
            heldKeys.Add(key);
        }

        protected virtual void RemoveUsedKey(KeyboardInput.SpecialKeys key)
        {
            if (!heldKeys.Contains(key))
            {
                return;
            }
            heldKeys.Remove(key);
        }

        #endregion

        #region Public

        public abstract void ActionPerformed(IActionListener actionListener);

        #endregion
    }
}