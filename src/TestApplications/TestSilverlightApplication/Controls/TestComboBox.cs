// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestComboBox.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the TestComboBox type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestSilverlightApplication.Controls
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// The test combo box.
    /// </summary>
    public class TestComboBox : ComboBox
    {
        /// <summary>
        /// The on mouse left button down.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            CursorManager.WaitAndPerform(this, () => base.OnMouseLeftButtonDown(e));
        }

        /// <summary>
        /// The on drop down closed.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnDropDownClosed(EventArgs e)
        {
            CursorManager.WaitAndPerform(this, () => base.OnDropDownClosed(e));
        }

        /// <summary>
        /// The on drop down opened.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnDropDownOpened(EventArgs e)
        {
            CursorManager.WaitAndPerform(this, () => base.OnDropDownOpened(e));
        }
    }
}