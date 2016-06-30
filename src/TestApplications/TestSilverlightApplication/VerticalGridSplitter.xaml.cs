// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VerticalGridSplitter.xaml.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the VerticalGridSplitter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestSilverlightApplication
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// The vertical grid splitter.
    /// </summary>
    public partial class VerticalGridSplitter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VerticalGridSplitter"/> class.
        /// </summary>
        public VerticalGridSplitter()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The ok button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        /// <summary>
        /// The cancel button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

