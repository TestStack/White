using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfTestApplication
{
    public partial class MainWindow
    {
        private bool controlsDisabled;

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
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

        private void LaunchHorizontalGridSplitter(object sender, RoutedEventArgs e)
        {
            new HorizontalGridSplitter().ShowDialog();
        }

        private void LaunchVerticalGridSplitter(object sender, RoutedEventArgs e)
        {
            new VerticalGridSplitter().ShowDialog();
        }

        private void GetMultiple(object sender, RoutedEventArgs e)
        {
            new GetMultiple().ShowDialog();
        }

        private void OpenListView(object sender, RoutedEventArgs e)
        {
            new ListViewWindow().ShowDialog();
        }

        private void RightClickOnButtonWithTooltip(object sender, MouseButtonEventArgs e)
        {
            ButtonWithTooltip.Content = "Right click received";
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

        private void SetControlsEnabled(bool enabled)
        {
            ListControls.IsEnabled = enabled;
            DatePicker.IsEnabled = enabled;
            CheckBox.IsEnabled = enabled;
            TextBox.IsEnabled = enabled;
            MultiLineTextBox.IsEnabled = enabled;
        }

        private void OpenFormWithoutScrollAndItemOutside(object sender, RoutedEventArgs e)
        {
            new FormWithoutScrollAndControlOutside().ShowDialog();
        }

        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            AutomationProperties.SetHelpText(TextBox, "Text Changed");
        }

        private void OpenDragDropScenario(object sender, RoutedEventArgs e)
        {
            new DragAndDropTestWindow().ShowDialog();
        }
    }
}
