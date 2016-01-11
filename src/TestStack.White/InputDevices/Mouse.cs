using System.Windows;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.InputDevices
{
    public class Mouse : BaseMouse, IMouse
    {
        #region Fields

        public static Mouse Instance = new Mouse();

        #endregion

        #region Mouse Click

        /// <summary>
        /// Implements <see cref="IMouse.Click(Point, IActionListener)"/>
        /// </summary>
        public virtual void Click(Point point, IActionListener actionListener)
        {
            Click(MouseButton.Left, point, actionListener);
        }

        /// <summary>
        /// Implements <see cref="IMouse.Click(MouseButton, IActionListener)"/>
        /// </summary>
        public virtual void Click(MouseButton mouseButton, IActionListener actionListener)
        {
            Click(mouseButton);
            ActionPerformed(actionListener);
        }

        /// <summary>
        /// Implements <see cref="IMouse.Click(MouseButton, Point, IActionListener)"/>
        /// </summary>
        public virtual void Click(MouseButton mouseButton, Point point, IActionListener actionListener)
        {
            Location = point;
            Click(mouseButton);
            ActionPerformed(actionListener);
        }

        #endregion

        #region Double Click

        /// <summary>
        /// Implements <see cref="IMouse.DoubleClick(Point, IActionListener)"/>
        /// </summary>
        public virtual void DoubleClick(Point point, IActionListener actionListener)
        {
            DoubleClick(MouseButton.Left, point, actionListener);
        }

        /// <summary>
        /// Implements <see cref="IMouse.DoubleClick(MouseButton, IActionListener)"/>
        /// </summary>
        public virtual void DoubleClick(MouseButton mouseButton, IActionListener actionListener)
        {
            DoubleClick(mouseButton);
            ActionPerformed(actionListener);
        }

        /// <summary>
        /// Implements <see cref="IMouse.DoubleClick(MouseButton, Point, IActionListener)"/>
        /// </summary>
        public virtual void DoubleClick(MouseButton mouseButton, Point point, IActionListener actionListener)
        {
            Location = point;
            DoubleClick(mouseButton);
            ActionPerformed(actionListener);
        }

        #endregion

        #region Right Click

        /// <summary>
        /// Implements <see cref="IMouse.RightClick(Point, IActionListener)"/>
        /// </summary>
        public virtual void RightClick(Point point, IActionListener actionListener)
        {
            Click(MouseButton.Right, point, actionListener);
        }

        #endregion

        #region Public

        /// <summary>
        /// Implements <see cref="IMouse.ActionPerformed(IActionListener)"/>
        /// </summary>
        /// <remarks>
        /// Overrides the <see cref="BaseMouse.ActionPerformed"/> abstract Function
        /// </remarks>
        public override void ActionPerformed(IActionListener actionListener)
        {
            actionListener.ActionPerformed(new Action(ActionType.WindowMessage));
        }

        #endregion
    }
}