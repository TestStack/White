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
            AddItemToComboBox("foo");
            AddItemToComboBox("bar");

            buton.Click += ButonClick;
        }

        private void AddItemToComboBox(string text)
        {
            var comboBoxItem = new ComboBoxItem {Content = text};
            combo.Items.Add(comboBoxItem);
        }

        private void ButonClick(object sender, RoutedEventArgs e)
        {
            status.Text = butonClickCount.ToString();
            butonClickCount++;
        }
    }
}