using System.Windows;
using System.Windows.Controls;

namespace TestSilverlightApplication
{
    public partial class Page
    {
        private int butonClickCount;

        public Page()
        {
            InitializeComponent();
            AddItemToComboBox(combo, "foo", "bar");
            AddItemToComboBox(custom_combo, "Baz", "Quux");

            buton.Click += ButonClick;
        }

        private static void AddItemToComboBox(ComboBox comboBox, params string[] texts)
        {
            foreach (var text in texts)
            {
                var comboBoxItem = new ComboBoxItem {Content = text};
                comboBox.Items.Add(comboBoxItem);
            }
        }

        private void ButonClick(object sender, RoutedEventArgs e)
        {
            status.Text = butonClickCount.ToString();
            butonClickCount++;
        }
    }
}