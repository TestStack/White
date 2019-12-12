namespace WpfTestApplication.Scenarios
{
    using System.Windows;
    using System.Windows.Automation;

    public partial class WindowWithScrollbars
    {
        public WindowWithScrollbars()
        {
            InitializeComponent();
        }

        private void ButtonBackUpTop_OnClick(object sender, RoutedEventArgs e)
        {
            AutomationProperties.SetHelpText(ButtonBackUpTop, "ButtonBackUpTopClicked");
        }

        private void HiddenButton_OnClick(object sender, RoutedEventArgs e)
        {
            AutomationProperties.SetHelpText(HiddenButton, "HiddenButtonClicked");
        }
    }
}