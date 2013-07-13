using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace WindowsPresentationFramework
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1
    {
        public Window1()
        {
            if (Environment.CommandLine.Contains("splash"))
            {
                var screen = new SplashScreen();
                screen.Show();
                MessageBox.Show("Bar", "Foo");
                screen.Close();
                Environment.Exit(0);
            }

            InitializeComponent();
            AddContextMenu();
            addNode.Click += AddNode;
            checkBoxLaunchedModalWindow.Checked += CheckBoxChecked;
            progressBar.Maximum = 100;
            progressBar.Minimum = 0;
            progressBar.Value = 50;
            launchModal.Click += LaunchModal;
            comboBoxLaunchingModalWindow.Items.Add("Arundhati Roy");
            comboBoxLaunchingModalWindow.Items.Add("Noam Chomsky");
            comboBoxLaunchingModalWindow.SelectionChanged += ComboBoxLaunchingModalWindowSelectionChanged;
            textBox1.Document.PageWidth = 1000;
            textBox1.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            textBox1.AppendText(
                "hfdsfjkhsdfjhdsfjhdsfhkjsdfhdsfkjhsdfjkdshfkjdsfhsdkfhsdkfhhfdsfjkhsdfjhdsfjhdsfhkjsdfhdsfkjhsdfjkdshfkjdsfhsdkfhsdkfhhfdsfjkhsdfjhdsfjhdsfhkjsdfhdsfkjhsdfjkdshfkjdsfhsdkfhsdkfh");

            komboBox.Items.Add("1");
            komboBox.Items.Add("2");
            komboBox.Items.Add("3");
            komboBox.Items.Add("4");
            komboBox.Items.Add("5");
            komboBox.Items.Add("6");
            komboBox.Items.Add("7");
            komboBox.Items.Add("ReallyReallyLongTextHere");

            var winter = (TabItem) seasons.Items[2];
            var canvas = new Canvas();
            winter.Content = canvas;
            canvas.Children.Add(GetTabBox(10));
            canvas.Children.Add(GetTabBox(120));

            var treeViewItem = (TreeViewItem) treeViewLaunchesModal.Items[0];
            treeViewItem.Expanded += TreeViewItemExpanded;

            Closing += Window1Closing;

            statusBar1.Items.Add(GetStatusBarItem("Status Item 1"));
            statusBar1.Items.Add(GetStatusBarItem("Status Item 2"));

            dynamicControl.Visibility = Visibility.Hidden;
            invisibleControlShower.Click += InvisibleControlShowerClick;
            addDynamicControl.Click += AddDynamicControlClick;

            image.MouseLeftButtonDown += ImageMouseLeftButtonDown;

            AddMenusToMenubar();

            AddStuffToListView();

            disableControls.Click += DisableControls;

            var textBoxInsidePanel = new TextBox {Name = "textBoxInsidePanel"};
            canvasContainingTextBox.Children.Add(textBoxInsidePanel);

            buttonInGroupBox.Click += ButtonInGroupBoxClicked;

            buttonLaunchesMessageBox.Click += LaunchMessageBox;

            slider1.Value = 4;

            ObservableComboBox();

            changeLanguage.Click += ChangeLanguageClicked;
        }

        private void ChangeLanguageClicked(object sender, RoutedEventArgs e)
        {
            listBoxWithDynamicItems.Items.Clear();
            listBoxWithDynamicItems.Items.Add("Ek");
            listBoxWithDynamicItems.Items.Add("Do");
            listBoxWithDynamicItems.Items.Add("Teen");
            listBoxWithDynamicItems.Items.Add("Char");
            listBoxWithDynamicItems.Items.Add("Panch");
            listBoxWithDynamicItems.Items.Add("Gheh");
        }

        private void ObservableComboBox()
        {
            ObservableCollection<ExampleItem> anExampleCollection =
                ((ExampleCollection) Resources["theExamples"]).ExampleItemsCollection;
            int[] intValues = {1, 2, 3, 4, 5, 6, 7, 8};
            string[] stringValues = {"a", "b", "c", "d", "e", "f", "g", "h"};

            for (int i = 0; i < intValues.Length; i++)
            {
                var anExample = new ExampleItem(intValues[i], stringValues[i]);

                anExampleCollection.Add(anExample);
            }

            // Now that everything is loaded, enable the controls
            ExampleComboBox.IsEnabled = true;

            // Select the default value in one combo box
            ExampleComboBox.SelectedIndex = 4;
        }

        private void LaunchMessageBox(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Close Me", "Close Me");
        }

        private void ButtonInGroupBoxClicked(object sender, RoutedEventArgs e)
        {
            result.Content = "Button In GroupBox Clicked";
        }

        private void DisableControls(object sender, RoutedEventArgs e)
        {
            textBox.IsEnabled = false;
            komboBox.IsEnabled = false;
        }

        private void ImageMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            result.Content = "Image Clicked";
        }

        private void AddStuffToListView()
        {
            listView.View = new GridView();
            var viewBase = (GridView) listView.View;

            var column = new GridViewColumn();
            var image1 = new Image {Visibility = Visibility.Visible, Source = Icon};
            var dataTemplate = new DataTemplate();
            dataTemplate.Resources.Add("image", image1);

            column.CellTemplate = dataTemplate;
            viewBase.Columns.Add(column);

            column = new GridViewColumn {Header = "Key", DisplayMemberBinding = new Binding("Key")};
            viewBase.Columns.Add(column);

            column = new GridViewColumn {Header = "Value", DisplayMemberBinding = new Binding("Value")};
            viewBase.Columns.Add(column);

            listView.Items.Add(new ListViewData("Search", "Google"));
            listView.Items.Add(new ListViewData("Mail", "GMail"));
            listView.Items.Add(new ListViewData("Picture", "Piccasa"));
            listView.Items.Add(new ListViewData("Open", "Code"));
            listView.Items.Add(new ListViewData("HomePage", "Pages"));
            listView.Items.Add(new ListViewData("YouTube", "YouTube"));
            listView.MouseDoubleClick += ListViewDoubleClicked;
            listView.SelectionChanged += ListViewSelectionChanged;
        }

        private void ListViewDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            ShowModalWindow();
        }

        private void ListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            result.Content = "listView item selected - " + listView.SelectedIndex;
        }

        private void AddMenusToMenubar()
        {
            MenuItem fileMenu = CreateMenuItem("File");
            fileMenu.Items.Add(CreateMenuItem("LaunchModal"));
            MenuItem clickMeItem = CreateMenuItem("Click Me");
            clickMeItem.Click += ClickMeItemClick;
            fileMenu.Items.Add(clickMeItem);
            menu1.Items.Add(fileMenu);
        }

        private void ClickMeItemClick(object sender, RoutedEventArgs e)
        {
            result.Content = "Click Me Clicked";
        }

        private static MenuItem CreateMenuItem(string header)
        {
            var fileMenu = new MenuItem {Header = header, Name = header.Replace(" ", "") + "Id"};
            return fileMenu;
        }

        private void AddDynamicControlClick(object sender, RoutedEventArgs e)
        {
            var dynamicTextBox = new TextBox {Name = "dynamicTextBox", Width = 100};
            canvas1.Children.Add(dynamicTextBox);
        }

        private void InvisibleControlShowerClick(object sender, RoutedEventArgs e)
        {
            dynamicControl.Visibility = Visibility.Visible;
        }

        private static StatusBarItem GetStatusBarItem(string text)
        {
            var statusBarItem = new StatusBarItem {Content = text};
            return statusBarItem;
        }

        private void Window1Closing(object sender, CancelEventArgs e)
        {
            if (Environment.CommandLine.Contains("ModalAtClose")) ShowModalWindow();
        }

        private void TreeViewItemExpanded(object sender, RoutedEventArgs e)
        {
            ShowModalWindow();
        }

        private static TextBox GetTabBox(int margin)
        {
            var tabBox = new TextBox {Name = "duplicateBox", Width = 100, Margin = new Thickness(margin, 0, 0, 0)};
            return tabBox;
        }

        private void HyperlinkClickLaunchingModal(object sender, RoutedEventArgs e)
        {
            ShowModalWindow();
        }

        private void ComboBoxLaunchingModalWindowSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowModalWindow();
        }

        private void LaunchModal(object sender, RoutedEventArgs e)
        {
            ShowModalWindow();
        }

        private void AddContextMenu()
        {
            var contextMenu1 = new ContextMenu();
            var menuItem = new MenuItem {Header = "Show Films"};
            menuItem.Click += MenuItemClick;
            contextMenu1.Items.Add(menuItem);
            listBox.ContextMenu = contextMenu1;

            var contextMenu2 = new ContextMenu();
            var root = new MenuItem {Header = "Root"};
            var level1 = new MenuItem {Header = "Level1"};
            root.Items.Add(level1);
            var level2 = new MenuItem {Header = "Level2"};
            level1.Items.Add(level2);
            contextMenu2.Items.Add(root);
            listBoxWithVScrollBar.ContextMenu = contextMenu2;
            level2.Click += Level2Click;
        }

        private void Level2Click(object sender, RoutedEventArgs e)
        {
            result.Content = "Level2Click";
        }

        private void MenuItemClick(object sender, RoutedEventArgs e)
        {
            result.Content = "All good films";
        }

        private void CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            ShowModalWindow();
        }

        private void ShowModalWindow()
        {
            Thread.Sleep(500);
            var modalWindow = new ModalWindow();
            if (Environment.CommandLine.Contains("setowner"))
            {
                modalWindow.Owner = this;
            }
            modalWindow.ShowDialog();
        }

        private void AddNode(object sender, RoutedEventArgs e)
        {
            ped.Items.Add("DynamicNode");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            result.Content = "Button Clicked";
        }

        private void toolBarButton_Click(object sender, RoutedEventArgs e)
        {
            result.Content = "ToolBar Button Clicked";
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            result.Content = "Text changed";
        }
    }
}