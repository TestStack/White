namespace WpfTestApplication
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Automation;
    using System.Windows.Controls;
    using System.Windows.Input;

    using WpfTestApplication.Scenarios;
    using WpfTestApplication.Scenarios.CustomUIItem;

    public partial class MainWindow
    {
        private bool controlsDisabled;

        public MainWindow()
        {
            DataContext = this;

            InitializeComponent();

            var treeViewItem = new TreeViewItem { Header = "Lots Of Children" };
            foreach (var i in Enumerable.Range(1, 50))
            {
                treeViewItem.Items.Add(new TreeViewItem { Header = "Child" + i });
            }

            TreeView.Items.Add(treeViewItem);

            States.Add(
                new State
                    {
                        Id = "1", 
                        Contents = "Item1", 
                        Description = "Simple item 1", 
                        ComboboxItems = new ObservableCollection<string>(DataGridComboboxItems)
                    });

            States.Add(
                new State
                    {
                        Id = "2", 
                        Contents = "Item2", 
                        Description = string.Empty, 
                        ComboboxItems = new ObservableCollection<string>(DataGridComboboxItems)
                    });

            States.Add(
                new State
                    {
                        Id = "3", 
                        Contents = "Item3", 
                        Description = string.Empty, 
                        ComboboxItems = new ObservableCollection<string>(DataGridComboboxItems)
                    });
        }

        public string[] DataGridComboboxItems
        {
            get
            {
                return new[] { "Item1", "Item2", "Item3", "Item4" };
            }
        }

        public ObservableCollection<string> ListItems
        {
            get
            {
                return new ObservableCollection<string> { "Test", "Test2", "Test3", "Test4", "Test5" };
            }
        }

        public ObservableCollection<State> States { get; } = new ObservableCollection<State>();

        private void AddNode_OnClick(object sender, RoutedEventArgs e)
        {
            TreeView.Items.Add("AddedNode");
        }

        private void AddTextBox_OnClick(object sender, RoutedEventArgs e)
        {
            AddControlPanel.Children.Add(new TextBox { Name = "AddedTextBox" });
        }

        private void ButtonWithTooltip_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonWithTooltip.Content = "Clicked";
        }

        private void ButtonWithTooltip_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                ButtonWithTooltip.Content = "Button Clicked with Mouse";
                e.Handled = true;
            }
        }

        private void ClickMe_OnClick(object sender, RoutedEventArgs e)
        {
            AutomationProperties.SetHelpText(this, "Click Me Clicked");
        }

        private void CustomUIItemScenarioClick(object sender, RoutedEventArgs e)
        {
            new CustomUIItemScenario().ShowDialog();
        }

        private void DisableControlsClick(object sender, RoutedEventArgs e)
        {
            if (controlsDisabled)
            {
                SetControlsEnabled(true);
                controlsDisabled = false;
                DisableControls.Content = "Disable Controls";
            }
            else
            {
                SetControlsEnabled(false);
                controlsDisabled = true;
                DisableControls.Content = "Enable Controls";
            }
        }

        private void GetMultiple(object sender, RoutedEventArgs e)
        {
            new GetMultiple().ShowDialog();
        }

        private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            AutomationProperties.SetHelpText(LinkLabel, "Hyperlink Clicked");
        }

        private void LaunchHorizontalGridSplitter(object sender, RoutedEventArgs e)
        {
            new HorizontalGridSplitter().ShowDialog();
        }

        private void LaunchVerticalGridSplitter(object sender, RoutedEventArgs e)
        {
            new VerticalGridSplitter().ShowDialog();
        }

        private void OpenDragDropScenario(object sender, RoutedEventArgs e)
        {
            new DragAndDropTestWindow().ShowDialog();
        }

        private void OpenFormWithoutScrollAndItemOutside(object sender, RoutedEventArgs e)
        {
            new FormWithoutScrollAndControlOutside().ShowDialog();
        }

        private void OpenListView(object sender, RoutedEventArgs e)
        {
            new ListViewWindow().ShowDialog();
        }

        private void OpenMessageBoxClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, "Close me", "Test message box", MessageBoxButton.OK);
        }

        private void OpenWindowWithScrollbars(object sender, RoutedEventArgs e)
        {
            new WindowWithScrollbars().ShowDialog();
        }

        private void RightClickOnButtonWithTooltip(object sender, MouseButtonEventArgs e)
        {
            ButtonWithTooltip.Content = "Right click received";
        }

        private void SetControlsEnabled(bool enabled)
        {
            ListControls.IsEnabled = enabled;
            DatePicker.IsEnabled = enabled;
            CheckBox.IsEnabled = enabled;
            TextBox.IsEnabled = enabled;
            MultiLineTextBox.IsEnabled = enabled;
        }

        private void ShowHiddenTextBox_OnClick(object sender, RoutedEventArgs e)
        {
            HiddenTextBox.Visibility = Visibility.Visible;
        }

        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            AutomationProperties.SetHelpText(TextBox, "Text Changed");
        }

        public class State
        {
            public ObservableCollection<string> ComboboxItems { get; set; }

            public string Contents { get; set; }

            public string Description { get; set; }

            public string Id { get; set; }
        }
    }
}