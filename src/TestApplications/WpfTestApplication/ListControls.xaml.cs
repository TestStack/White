using System.Windows;

namespace WpfTestApplication
{
    public partial class ListControls
    {
        public ListControls()
        {
            InitializeComponent();
        }

        private void ChangeListItems_OnClick(object sender, RoutedEventArgs e)
        {
            ListBoxWpf.Items.Clear();
            ListBoxWpf.Items.Add("Jackson");
            ListBoxWpf.Items.Add("Lucus");
            ListBoxWpf.Items.Add("Cameron");
            ListBoxWpf.Items.Add("Tarantino");
            ListBoxWpf.Items.Add("Singleton");
            ListBoxWpf.Items.Add("Allen");
        }
    }
}
