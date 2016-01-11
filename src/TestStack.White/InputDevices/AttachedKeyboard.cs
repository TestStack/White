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
        private readonly UIItemContainer container;
        private readonly Keyboard keyboard;

        internal AttachedKeyboard(UIItemContainer container, Keyboard keyboard)
        {
            this.container = container;
            this.keyboard = keyboard;
        }

        public virtual void Enter(string keysToType)
        {
            container.Focus();
            keyboard.Send(keysToType, container);
        }

        public virtual void PressSpecialKey(KeyboardInput.SpecialKeys key)
        {
            container.Focus();
            keyboard.PressSpecialKey(key, container);
        }

        public virtual void HoldKey(KeyboardInput.SpecialKeys key)
        {
            container.Focus();
            keyboard.HoldKey(key, container);
        }

        public virtual void LeaveKey(KeyboardInput.SpecialKeys key)
        {
            container.Focus();
            keyboard.LeaveKey(key, container);
        }

        public virtual bool CapsLockOn
        {
            get { return keyboard.CapsLockOn; }
            set
            {
                container.Focus();
                keyboard.CapsLockOn = value;
            }
        }
    }
}