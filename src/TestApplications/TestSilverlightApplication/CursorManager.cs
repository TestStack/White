// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CursorManager.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the CursorManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TestSilverlightApplication
{
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    ///     The cursor manager.
    /// </summary>
    public static class CursorManager
    {
        /// <summary>
        ///     The do.
        /// </summary>
        public delegate void Do();

        /// <summary>
        ///     The wait and perform.
        /// </summary>
        /// <param name="frameworkElement">
        ///     The framework element.
        /// </param>
        /// <param name="do">
        ///     The do.
        /// </param>
        public static void WaitAndPerform(FrameworkElement frameworkElement, Do @do)
        {
            frameworkElement.Cursor = Cursors.Wait;
            try
            {
                @do();
            }
            finally
            {
                frameworkElement.Cursor = Cursors.Arrow;
            }
        }
    }
}