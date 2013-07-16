using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;

namespace WpfTestApplication
{
    public partial class ListControls
    {
        public ListControls()
        {
            InitializeComponent();
            AddContextMenu();
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

        void AddContextMenu()
        {
            var contextMenu2 = new ContextMenu();
            var root = new MenuItem { Header = "Root" };
            var root2 = new MenuItem { Header = "Root2" };
            var level1 = new MenuItem { Header = "Level1" };
            root.Items.Add(level1);
            var level2 = new MenuItem { Header = "Level2" };
            level1.Items.Add(level2);
            contextMenu2.Items.Add(root);
            contextMenu2.Items.Add(root2);
            root2.Click += RootClick;
            level2.Click += Level2Click;
            ListBoxWithVScrollBar.ContextMenu = contextMenu2;
        }

        private void RootClick(object sender, RoutedEventArgs e)
        {
            AutomationProperties.SetHelpText(ListBoxWithVScrollBar, "Root2 Clicked");
        }

        private void Level2Click(object sender, RoutedEventArgs e)
        {
            AutomationProperties.SetHelpText(ListBoxWithVScrollBar, "Level 2 Clicked");
        }
    }
}
