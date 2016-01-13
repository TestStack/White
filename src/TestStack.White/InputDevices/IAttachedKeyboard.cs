using TestStack.White.WindowsAPI;

namespace TestStack.White.InputDevices
{
    public interface IAttachedKeyboard
    {
        /// <summary>
        /// Enter a string
        /// </summary>
        /// <param name="keysToType">String to enter</param>
        void Enter(string keysToType);

        /// <summary>
        /// Press special Keys
        /// </summary>
        /// <param name="key"><see cref="KeyboardInput.SpecialKeys"/> to press</param>
        void PressSpecialKey(KeyboardInput.SpecialKeys key);

        /// <summary>
        /// Hold a special key
        /// </summary>
        /// <param name="key"><see cref="KeyboardInput.SpecialKeys"/> to hold</param>
        void HoldKey(KeyboardInput.SpecialKeys key);

        /// <summary>
        /// Leave a pressed Key
        /// </summary>
        /// <param name="key">Key to leave</param>
        void LeaveKey(KeyboardInput.SpecialKeys key);

        /// <summary>
        /// Get / Set the CapsLock
        /// </summary>
        bool CapsLockOn { get; set; }

        /// <summary>
        /// List of Held Keys
        /// </summary>
        KeyboardInput.SpecialKeys[] HeldKeys { get; }

        /// <summary>
        /// Leave all Keys
        /// </summary>
        void LeaveAllKeys();
    }
}