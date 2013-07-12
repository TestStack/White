using System;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.TabItems;
using White.Core.UIItems.TreeItems;
using White.Core.UIItems.WindowItems;
using White.Repository.ScreenAttributes;
using Xunit;

namespace White.Repository.UITests.Testing
{
    //TODO: Why do the tests continue running even after it has finished
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    public class MainScreen : BaseScreen
    {
        private Button launchModal = null;
        private Button addNode = null;
        private Label result = null;
        private TextBox textBox = null;
        private ComboBox komboBox = null;
        private CheckBox chequeBox = null;
        private CheckBox checkBoxLaunchedModalWindow = null;
        private ListBox chequedListBox = null;
        private ListBox listBox = null;
        private RadioButton radioButton1 = null;
        private RadioButton radioButton2 = null;
        private DateTimePicker dateTimePicker = null;
        private ListView listView = null;
        private Hyperlink linkLaunchesModalWindow = null;
        private Tab seasons = null;
        private Tree ped = null;
        [AutomationId("duplicateBox"), Index(0)]
        private TextBox myNameIsDuplicateBox = null;
        [AutomationId("duplicateBox"), Index(1)]
        private TextBox iAmDuplicateBox = null;

        private MainProgressBars mainProgressBars = null;

        public MainScreen(Window window, ScreenRepository screenRepository) : base(window, screenRepository)
        {
        }

        public virtual void ClickButton()
        {
            buton.Click();
            Assert.Equal("Button Clicked", result.Text);
        }

        public virtual void EnterText()
        {
            textBox.Text = "abcd";
            Assert.Equal("abcd", textBox.Text);
            Assert.Equal("Text changed", result.Text);
        }

        public virtual void SelectComboBoxItem()
        {
            komboBox.Select("Arundhati Roy");
            Assert.Equal("Arundhati Roy", komboBox.SelectedItemText);
            komboBox.Select("Noam Chomsky");
            Assert.Equal("Noam Chomsky", komboBox.SelectedItemText);
        }

        public virtual void EnterTextInTheTextBoxesWithSameNameUsingIndex()
        {
            myNameIsDuplicateBox.Text = "one";
            Assert.Equal("one", myNameIsDuplicateBox.Text);
            iAmDuplicateBox.Text = "two";
            Assert.Equal("two", iAmDuplicateBox.Text);
        }

        public virtual void SelectTab()
        {
            seasons.SelectTabPage("Winter");
        }

        public virtual void SelectCheckbox()
        {
            chequeBox.Checked = true;
            Assert.Equal(true, chequeBox.Checked);
            chequeBox.Checked = false;
            Assert.Equal(false, chequeBox.Checked);
        }

        public virtual void SelectItemInChequedListBox()
        {
            chequedListBox.Check("Bill Gates");
            Assert.Equal(true,chequedListBox.IsChecked("Bill Gates"));
        }

        public virtual void SelectRadioButton()
        {
            Assert.Equal(false,radioButton1.IsSelected);
            Assert.Equal(false,radioButton2.IsSelected);
            radioButton1.Select();
            Assert.Equal(true, radioButton1.IsSelected);
            radioButton2.Select();
            Assert.Equal(true, radioButton2.IsSelected);
        }

        public virtual void SelectItemInListBox()
        {
            listBox.Select("Speilberg");
            Assert.Equal(true,listBox.IsSelected("Speilberg"));
            listBox.Select("Nagesh");
            Assert.Equal(true,listBox.IsSelected("Nagesh"));
        }

        public virtual void SelectDateTime()
        {
            Assert.Equal(DateTime.Today, dateTimePicker.Date);
            DateTime tenDaysFromToday = DateTime.Today.AddDays(10);
            dateTimePicker.Date = tenDaysFromToday;
            Assert.Equal(tenDaysFromToday, dateTimePicker.Date);
        }

        public virtual void SelectItemInListView()
        {
            listView.Select(0);
            Assert.Equal(true,listView.Rows[0].IsSelected);
            listView.Select(1);
            Assert.Equal(true,listView.Rows[1].IsSelected);
        }

        public virtual void LaunchModalWindow()
        {
            launchModal.Click();
            screenRepository.GetModal<ModalScreen>("ModalForm", window, InitializeOption.NoCache).Close();
            linkLaunchesModalWindow.Click();
            screenRepository.GetModal<ModalScreen>("ModalForm", window, InitializeOption.NoCache).Close();
            checkBoxLaunchedModalWindow.Click();
            screenRepository.GetModal<ModalScreen>("ModalForm", window, InitializeOption.NoCache).Close();
        }

        public virtual void SelectNodesInTree()
        {
            ped.Node("Root").Expand();
            ped.Node("Root", "Child").Expand();
            Assert.Equal(2, ped.Nodes.Count);
            addNode.Click();
            Assert.Equal(true, ped.HasNode("DynamicNode"));
        }

        public virtual void CheckProgress()
        {
            mainProgressBars.Check();
        }
    }
    // ReSharper restore FieldCanBeMadeReadOnly.Local
}