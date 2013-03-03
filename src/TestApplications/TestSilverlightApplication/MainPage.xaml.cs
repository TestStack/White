using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace TestSilverlightApplication
{
    public partial class MainPage
    {
        private int butonClickCount;

        public MainPage()
        {
            DataContext = this;
            InitializeComponent();
            AddItemToComboBox(Combo, "foo", "bar");
            AddItemToComboBox(CustomCombo, "Baz", "Quux");

            Button.Click += ButtonClick;
        }

        public ObservableCollection<string> ListItems
        {
            get
            {
                return new ObservableCollection<string>
                    {
                        "Test",
                        "Test2",
                        "Test3",
                        "Test4",
                        "Test5"
                    };
            }
        }


        private static void AddItemToComboBox(ComboBox comboBox, params string[] texts)
        {
            foreach (var text in texts)
            {
                var comboBoxItem = new ComboBoxItem { Content = text };
                comboBox.Items.Add(comboBoxItem);
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Status.Text = butonClickCount.ToString(CultureInfo.InvariantCulture);
            butonClickCount++;
        }
    }
}
