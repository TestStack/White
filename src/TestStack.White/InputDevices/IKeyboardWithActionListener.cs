using TestStack.White.UIItems.Actions;
using TestStack.White.WindowsAPI;

namespace TestStack.White.InputDevices
{
    public interface IKeyboardWithActionListener : IKeyboard
    {
        /// <summary>
        /// Send a strig to a specific <see cref="IActionListener"/>
        /// </summary>
        /// <param name="keysToType">String to send</param>
        /// <param name="actionListener"><see cref="IActionListener"/> to receive the string</param>
        void Send(string keysToType, IActionListener actionListener);

        /// <summary>
        /// Press special Keys
        /// </summary>
        /// <param name="key"><see cref="KeyboardInput.SpecialKeys"/> to press</param>
        /// <param name="actionListener"><see cref="IActionListener"/> to receive the string</param>
        void PressSpecialKey(KeyboardInput.SpecialKeys key, IActionListener actionListener);

        /// <summary>
        /// Hold a special key
        /// </summary>
        /// <param name="key"><see cref="KeyboardInput.SpecialKeys"/> to hold</param>
        /// <param name="actionListener"><see cref="IActionListener"/> to receive the string</param>
        void HoldKey(KeyboardInput.SpecialKeys key, IActionListener actionListener);

        /// <summary>
        /// Leave a pressed Key
        /// </summary>
        /// <param name="key">Key to leave</param>
        /// <param name="actionListener"><see cref="IActionListener"/> to receive the string</param>
        void LeaveKey(KeyboardInput.SpecialKeys key, IActionListener actionListener);

        /// <summary>
        /// Perform an Action on the Action Listener 
        /// </summary>
        /// <param name="actionListener"><see cref="IActionListener"/> to perform an Action on</param>
        void ActionPerformed(IActionListener actionListener);
    }
}