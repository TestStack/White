// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowLaunchers.xaml.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the WindowLaunchers type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TestSilverlightApplication
{
    using System.Windows;

    /// <summary>
    ///     The window launchers.
    /// </summary>
    public partial class WindowLaunchers
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WindowLaunchers" /> class.
        /// </summary>
        public WindowLaunchers()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///     The launch horizontal grid splitter.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The e.
        /// </param>
        private void LaunchHorizontalGridSplitter(object sender, RoutedEventArgs e)
        {
            new HorizontalGridSplitter().Show();
        }

        /// <summary>
        ///     The launch vertical grid splitter.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The e.
        /// </param>
        private void LaunchVerticalGridSplitter(object sender, RoutedEventArgs e)
        {
            new VerticalGridSplitter().Show();
        }
    }
}