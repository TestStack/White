// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HorizontalGridSplitter.xaml.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the HorizontalGridSplitter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TestSilverlightApplication
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    ///     The horizontal grid splitter.
    /// </summary>
    public partial class HorizontalGridSplitter : ChildWindow
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="HorizontalGridSplitter" /> class.
        /// </summary>
        public HorizontalGridSplitter()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///     The cancel button_ click.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The e.
        /// </param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        /// <summary>
        ///     The ok button_ click.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The e.
        /// </param>
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}