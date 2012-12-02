using System;
using System.Collections.Generic;

namespace WindowsPresentationFramework
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private static readonly List<string> windowsForCommand;

        static App()
        {
            windowsForCommand = new List<string>
                                    {
                                        "ScenarioSet1",
                                        "HorizontalGridSplitter",
                                        "VerticalGridSplitter",
                                        "ComboBoxWithObjectWindow",
                                        "TreeViewItemWithoutHeader",
                                        "TreeViewItemWithoutHeader",
                                        "TristateControlWindow",
                                        "CustomWhiteControlsWindow",
                                        "ListViewScenarios"
                                    };
        }

        public App()
        {
            const string urlFormat = "pack://application:,,,/WindowsPresentationFramework;component/{0}.xaml";
            StartupUri = new Uri(string.Format(urlFormat, GetWindowName()));
        }

        private static string GetWindowName()
        {
            string windowName = windowsForCommand.Find(s => Environment.CommandLine.Contains(s));
            if (!string.IsNullOrEmpty(windowName)) return windowName;
            return "Window1";
        }
    }
}