using TestStack.White.UIItems;
using TestStack.White.WindowsAPI;

namespace TestStack.White.InputDevices
{
    /// <summary>
    /// Any operation performed using the keyboard would wait till the container is busy after this operation. Before any operation is 
    /// performed on the container, from which it was retreived, is brought to focus if it is not.
    /// </summary>
    public class AttachedKeyboard : IBaseKeyboard
    {
        #region Fields

        private readonly IUIItemContainer container;
        private readonly IKeyboard keyboard;

        #endregion

        #region Constructor

        internal AttachedKeyboard(IUIItemContainer container, IKeyboard keyboard)
        {
            this.container = container;
            this.keyboard = keyboard;
        }

        #endregion

        /// <summary>
        /// Implements <see cref="IBaseKeyboard.Enter(string)"/>
        /// </summary>
        public virtual void Enter(string keysToType)
        {
            container.Focus();
            keyboard.Send(keysToType, container);
        }

        /// <summary>
        /// Implements <see cref="IBaseKeyboard.PressSpecialKey(KeyboardInput.SpecialKeys)"/>
        /// </summary>
        public virtual void PressSpecialKey(KeyboardInput.SpecialKeys key)
        {
            container.Focus();
            keyboard.PressSpecialKey(key, container);
        }

        /// <summary>
        /// Implements <see cref="IBaseKeyboard.HoldKey(KeyboardInput.SpecialKeys)"/>
        /// </summary>
        public virtual void HoldKey(KeyboardInput.SpecialKeys key)
        {
            container.Focus();
            keyboard.HoldKey(key, container);
        }

        /// <summary>
        /// Implements <see cref="IBaseKeyboard.LeaveKey(KeyboardInput.SpecialKeys)"/>
        /// </summary>
        public virtual void LeaveKey(KeyboardInput.SpecialKeys key)
        {
            container.Focus();
            keyboard.LeaveKey(key, container);
        }

        /// <summary>
        /// Implements <see cref="IBaseKeyboard.CapsLockOn"/>
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
        /// Implements <see cref="IBaseKeyboard.HeldKeys"/>
        /// </summary>
        public virtual KeyboardInput.SpecialKeys[] HeldKeys
        {
            get
            {
                return keyboard.HeldKeys;
            }
        }

        /// <summary>
        /// Implements <see cref="IBaseKeyboard.LeaveAllKeys()"/>
        /// </summary>
        public virtual void LeaveAllKeys()
        {
            container.Focus();
            keyboard.LeaveAllKeys();
        }
    }
}