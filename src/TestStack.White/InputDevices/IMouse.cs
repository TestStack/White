using System.Windows;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.InputDevices
{
    public interface IMouse : IBaseMouse
    {
        #region Mouse Click

        /// <summary>
        /// Perform a Click Operation
        /// </summary>
        /// <param name="point">Point where to Click on</param>
        /// <param name="actionListener">ActionListener to use after Click Operation</param>
        void Click(Point point, IActionListener actionListener);
        
        /// <summary>
        /// Perform a Click Operation
        /// </summary>
        /// <param name="mouseButton">MouseButton to Click</param>
        /// <param name="actionListener">ActionListener to use after Click Operation</param>
        /// <remarks>
        /// Clicks the specified mouse button. Makes sure to not accidentaly fire a double click
        /// if called multiple times
        /// </remarks>
        void Click(MouseButton mouseButton, IActionListener actionListener);

        /// <summary>
        /// Perform a Click Operation
        /// </summary>
        /// <param name="mouseButton">MouseButton to Click</param>
        /// <param name="point">Point to Click on</param>
        /// <param name="actionListener">ActionListener to use after Click Operation</param>
        /// <remarks>
        /// Clicks the specified mouse button. Makes sure to not accidentaly fire a double click
        /// if called multiple times
        /// </remarks>
        void Click(MouseButton mouseButton, Point point, IActionListener actionListener);

        #endregion

        #region Double Click

        /// <summary>
        /// Perform a Double Click Operation
        /// </summary>
        /// <param name="point">Point where to Double Click on</param>
        /// <param name="actionListener">ActionListener to use after Click Operation</param>
        void DoubleClick(Point point, IActionListener actionListener);

        /// <summary>
        /// Perform a Double Click Operation
        /// </summary>
        /// <param name="mouseButton">MouseButton to double click</param>
        /// <param name="actionListener">ActionListener to use after Click Operation</param>
        void DoubleClick(MouseButton mouseButton, IActionListener actionListener);

        /// <summary>
        /// Perform a Double Click Operation
        /// </summary>
        /// <param name="mouseButton">MouseButton to double click</param>
        /// <param name="point">Point where to Double Click on</param>
        /// <param name="actionListener">ActionListener to use after Click Operation</param>
        void DoubleClick(MouseButton mouseButton, Point point, IActionListener actionListener);

        #endregion

        #region Right Click

        /// <summary>
        /// Perform a Right Click Operation
        /// </summary>
        /// <param name="point">Point where to Double Click on</param>
        /// <param name="actionListener">ActionListener to use after Click Operation</param>
        void RightClick(Point point, IActionListener actionListener);

        #endregion

        #region Perform Action

        /// <summary>
        /// Perform an Action on the Action Listener 
        /// </summary>
        /// <param name="actionListener"><see cref="IActionListener"/> to perform an Action on</param>
        void ActionPerformed(IActionListener actionListener);

        #endregion

    }
}