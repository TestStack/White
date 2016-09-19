using System;
using TestStack.White.UIItems;
using TestStack.White.WindowsAPI;

namespace TestStack.White.InputDevices
{
    /// <summary>
    /// Any operation performed using the keyboard would wait till the container is busy after this operation. Before any operation is 
    /// performed on the container, from which it was retreived, is brought to focus if it is not.
    /// </summary>
    public class AttachedKeyboard : IKeyboard
    {
        private readonly IUIItemContainer container;
        private readonly IKeyboardWithActionListener keyboard;

        internal AttachedKeyboard(IUIItemContainer container, IKeyboard keyboard)
            : this(container, TryMouseWithActionListener(keyboard))
        {
        }

        internal AttachedKeyboard(IUIItemContainer container, IKeyboardWithActionListener keyboard)
        {
            this.container = container;
            this.keyboard = keyboard;
        }

        /// <summary>
        /// Implements <see cref="IKeyboard.Enter(string)"/>
        /// </summary>
        public virtual void Enter(string keysToType)
        {
            container.Focus();
            keyboard.Send(keysToType, container);
        }

        /// <summary>
        /// Implements <see cref="IKeyboard.PressSpecialKey(KeyboardInput.SpecialKeys)"/>
        /// </summary>
        public virtual void PressSpecialKey(KeyboardInput.SpecialKeys key)
        {
            container.Focus();
            keyboard.PressSpecialKey(key, container);
        }

        /// <summary>
        /// Implements <see cref="IKeyboard.HoldKey(KeyboardInput.SpecialKeys)"/>
        /// </summary>
        public virtual void HoldKey(KeyboardInput.SpecialKeys key)
        {
            container.Focus();
            keyboard.HoldKey(key, container);
        }

        /// <summary>
        /// Implements <see cref="IKeyboard.LeaveKey(KeyboardInput.SpecialKeys)"/>
        /// </summary>
        public virtual void LeaveKey(KeyboardInput.SpecialKeys key)
        {
            container.Focus();
            keyboard.LeaveKey(key, container);
        }

        /// <summary>
        /// Implements <see cref="IKeyboard.CapsLockOn"/>
        /// </summary>
        public virtual bool CapsLockOn
        {
            get
            {
                return keyboard.CapsLockOn;
            }
            set
            {
                keyboard.CapsLockOn = value;
            }
        }

        /// <summary>
        /// Implements <see cref="IKeyboard.HeldKeys"/>
        /// </summary>
        public virtual KeyboardInput.SpecialKeys[] HeldKeys
        {
            get
            {
                return keyboard.HeldKeys;
            }
        }

        /// <summary>
        /// Implements <see cref="IKeyboard.LeaveAllKeys()"/>
        /// </summary>
        public virtual void LeaveAllKeys()
        {
            container.Focus();
            keyboard.LeaveAllKeys();
        }

        internal static IKeyboardWithActionListener TryMouseWithActionListener(IKeyboard keyboardToCheck)
        {
            var actionKeyboard = keyboardToCheck as IKeyboardWithActionListener;
            if (actionKeyboard == null)
            {
                throw new Exception("Mouse does not Implement" + typeof(IKeyboardWithActionListener));
            }
            return actionKeyboard;
        }
    }
}