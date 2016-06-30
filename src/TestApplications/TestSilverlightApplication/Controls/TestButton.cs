// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestButton.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the TestButton type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestSilverlightApplication.Controls
{
    using System.Windows.Controls;

    /// <summary>
    /// The test button.
    /// </summary>
    public class TestButton : Button
    {
        /// <summary>
        /// The on click.
        /// </summary>
        protected override void OnClick()
        {
            CursorManager.WaitAndPerform(this, () => base.OnClick());
        }
    }
}