// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPage.xaml.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the MainPage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestSilverlightApplication
{
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// The main page.
    /// </summary>
    public partial class MainPage
    {
        /// <summary>
        /// The button click count.
        /// </summary>
        private int butonClickCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            DataContext = this;
            InitializeComponent();
            AddItemToComboBox(Combo, "foo", "bar");
            AddItemToComboBox(CustomCombo, "Baz", "Quux");

            Button.Click += this.ButtonClick;
        }

        /// <summary>
        /// The list items.
        /// </summary>
        public ObservableCollection<string> ListItems => new ObservableCollection<string>
                                                             {
                                                                 "Test",
                                                                 "Test2",
                                                                 "Test3",
                                                                 "Test4",
                                                                 "Test5"
                                                             };

        /// <summary>
        /// Adds to the combo box.
        /// </summary>
        /// <param name="comboBox">The combo box.</param>
        /// <param name="texts">The texts.</param>
        private static void AddItemToComboBox(ComboBox comboBox, params string[] texts)
        {
            foreach (var text in texts)
            {
                var comboBoxItem = new ComboBoxItem { Content = text };
                comboBox.Items.Add(comboBoxItem);
            }
        }

        /// <summary>
        /// The button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event argument.</param>
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Status.Text = butonClickCount.ToString(CultureInfo.InvariantCulture);
            butonClickCount++;
        }
    }
}
