// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Screen.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the Screen type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfTodo.UITests.Screens
{
    using System;
    using System.Windows.Automation;

    using TestStack.White.ScreenObjects;
    using TestStack.White.UIItems.WindowItems;
    using TestStack.White.Utility;

    /// <summary>
    ///     The screen.
    /// </summary>
    public class Screen : AppScreen
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Screen" /> class.
        /// </summary>
        /// <param name="window">
        ///     The window.
        /// </param>
        /// <param name="screenRepository">
        ///     The screen repository.
        /// </param>
        protected Screen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        /// <summary>
        ///     The shell is busy.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool ShellIsBusy()
        {
            var currentPropertyValue =
                Window.AutomationElement.GetCurrentPropertyValue(AutomationElement.HelpTextProperty);
            return currentPropertyValue != null && ((string)currentPropertyValue).Contains("Busy");
        }

        /// <summary>
        ///     The wait while busy.
        /// </summary>
        protected virtual void WaitWhileBusy()
        {
            Retry.For(this.ShellIsBusy, isBusy => isBusy, TimeSpan.FromSeconds(30));
        }
    }
}