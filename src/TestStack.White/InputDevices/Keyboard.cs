using System.Linq;
using TestStack.White.UIItems.Actions;
using TestStack.White.WindowsAPI;
using Action = TestStack.White.UIItems.Actions.Action;

namespace TestStack.White.InputDevices
{
    // BUG: KeysConverter
    /// <summary>
    /// Represents Keyboard attachment to the machine.
    /// </summary>
    public class Keyboard : BaseKeyboard, IKeyboard
    {
        #region Fields

        /// <summary>
        /// Use Window.Keyboard method to get handle to the Keyboard. Keyboard instance got using this method would not wait while the application
        /// is busy.
        /// </summary>
        public static readonly Keyboard Instance = new Keyboard();
        
        #endregion

        #region Implements from BaseKeyboard

        /// <summary>
        /// Overrides <see cref="BaseKeyboard.Enter(string)"/>
        /// </summary>
        public override void Enter(string keysToType)
        {
            Send(keysToType, new NullActionListener());
        }

        /// <summary>
        /// Implements <see cref="BaseKeyboard.PressSpecialKey(KeyboardInput.SpecialKeys)"/>
        /// </summary>
        public override void PressSpecialKey(KeyboardInput.SpecialKeys key)
        {
            PressSpecialKey(key, new NullActionListener());
        }

        /// <summary>
        /// Implements <see cref="BaseKeyboard.HoldKey(KeyboardInput.SpecialKeys)"/>
        /// </summary>
        public override void HoldKey(KeyboardInput.SpecialKeys key)
        {
            HoldKey(key, new NullActionListener());
        }
        
        /// <summary>
        /// Implements <see cref="BaseKeyboard.LeaveKey(KeyboardInput.SpecialKeys)"/>
        /// </summary>
        public override void LeaveKey(KeyboardInput.SpecialKeys key)
        {
            LeaveKey(key, new NullActionListener());
        }

        /// <summary>
        /// Implements <see cref="IKeyboard.ActionPerformed(IActionListener)"/>
        /// </summary>
        /// <remarks>
        /// Overrides the <see cref="BaseKeyboard.ActionPerformed"/> abstract Function
        /// </remarks>
        public override void ActionPerformed(IActionListener actionListener)
        {
            actionListener.ActionPerformed(new Action(ActionType.WindowMessage));
        }

        #endregion

        #region Implements IKeyboard

        /// <summary>
        /// Implements <see cref="IKeyboard.Send(string, IActionListener)"/>
        /// </summary>
        public virtual void Send(string keysToType, IActionListener actionListener)
        {
            if (HeldKeys.Count() > 0) keysToType = keysToType.ToLower();

            CapsLockOn = false;
            foreach (var key in from c in keysToType let key = VkKeyScan(c) where !c.Equals('\r') select key)
            {
                if (ShiftKeyIsNeeded(key))
                {
                    SendKeyDown((short) KeyboardInput.SpecialKeys.SHIFT, false);
                }
                if (CtrlKeyIsNeeded(key))
                {
                    SendKeyDown((short) KeyboardInput.SpecialKeys.CONTROL, false);
                }
                if (AltKeyIsNeeded(key))
                {
                    SendKeyDown((short) KeyboardInput.SpecialKeys.ALT, false);
                }
                Press(key, false);
                if (ShiftKeyIsNeeded(key))
                {
                    SendKeyUp((short) KeyboardInput.SpecialKeys.SHIFT, false);
                }
                if (CtrlKeyIsNeeded(key))
                {
                    SendKeyUp((short) KeyboardInput.SpecialKeys.CONTROL, false);
                }
                if (AltKeyIsNeeded(key))
                {
                    SendKeyUp((short) KeyboardInput.SpecialKeys.ALT, false);
                }
            }

            actionListener.ActionPerformed(Action.WindowMessage);
        }
        
        /// <summary>
        /// Implements <see cref="IKeyboard.PressSpecialKey(KeyboardInput.SpecialKeys, IActionListener)"/>
        /// </summary>
        public virtual void PressSpecialKey(KeyboardInput.SpecialKeys key, IActionListener actionListener)
        {
            Send(key, true);
            actionListener.ActionPerformed(Action.WindowMessage);
        }

        /// <summary>
        /// Implements <see cref="IKeyboard.HoldKey(KeyboardInput.SpecialKeys, IActionListener)"/>
        /// </summary>
        public virtual void HoldKey(KeyboardInput.SpecialKeys key, IActionListener actionListener)
        {
            SendKeyDown((short) key, true);
            AddUsedKey(key);
            actionListener.ActionPerformed(Action.WindowMessage);
        }

        /// <summary>
        /// Implements <see cref="IKeyboard.LeaveKey(KeyboardInput.SpecialKeys, IActionListener)"/>
        /// </summary>
        public virtual void LeaveKey(KeyboardInput.SpecialKeys key, IActionListener actionListener)
        {
            SendKeyUp((short) key, true);
            RemoveUsedKey(key);
            actionListener.ActionPerformed(Action.WindowMessage);
        }

        #endregion
    }
}