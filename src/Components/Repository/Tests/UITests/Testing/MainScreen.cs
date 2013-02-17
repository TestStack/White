using System;
using Repository;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.TabItems;
using White.Core.UIItems.TreeItems;
using White.Core.UIItems.WindowItems;
using NUnit.Framework;
using Repository.ScreenAttributes;

namespace White.Repository.UITests.Testing
{
    //TODO: Why do the tests continue running even after it has finished
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    public class MainScreen : AppScreen
    {
        private Button buton = null;
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
            Assert.AreEqual("Button Clicked", result.Text);
        }

        public virtual void EnterText()
        {
            textBox.Text = "abcd";
            Assert.AreEqual("abcd", textBox.Text);
            Assert.AreEqual("Text changed", result.Text);
        }

        public virtual void SelectComboBoxItem()
        {
            komboBox.Select("Arundhati Roy");
            Assert.AreEqual("Arundhati Roy", komboBox.SelectedItemText);
            komboBox.Select("Noam Chomsky");
            Assert.AreEqual("Noam Chomsky", komboBox.SelectedItemText);
        }

        public virtual void EnterTextInTheTextBoxesWithSameNameUsingIndex()
        {
            myNameIsDuplicateBox.Text = "one";
            Assert.AreEqual("one", myNameIsDuplicateBox.Text);
            iAmDuplicateBox.Text = "two";
            Assert.AreEqual("two", iAmDuplicateBox.Text);
        }

        public virtual void SelectTab()
        {
            seasons.SelectTabPage("Winter");
        }

        public virtual void SelectCheckbox()
        {
            chequeBox.Checked = true;
            Assert.AreEqual(true, chequeBox.Checked);
            chequeBox.Checked = false;
            Assert.AreEqual(false, chequeBox.Checked);
        }

        public virtual void SelectItemInChequedListBox()
        {
            chequedListBox.Check("Bill Gates");
            Assert.AreEqual(true,chequedListBox.IsChecked("Bill Gates"));
        }

        public virtual void SelectRadioButton()
        {
            Assert.AreEqual(false,radioButton1.IsSelected);
            Assert.AreEqual(false,radioButton2.IsSelected);
            radioButton1.Select();
            Assert.AreEqual(true, radioButton1.IsSelected);
            radioButton2.Select();
            Assert.AreEqual(true, radioButton2.IsSelected);
        }

        public virtual void SelectItemInListBox()
        {
            listBox.Select("Speilberg");
            Assert.AreEqual(true,listBox.IsSelected("Speilberg"));
            listBox.Select("Nagesh");
            Assert.AreEqual(true,listBox.IsSelected("Nagesh"));
        }

        public virtual void SelectDateTime()
        {
            Assert.AreEqual(DateTime.Today, dateTimePicker.Date);
            DateTime tenDaysFromToday = DateTime.Today.AddDays(10);
            dateTimePicker.Date = tenDaysFromToday;
            Assert.AreEqual(tenDaysFromToday, dateTimePicker.Date);
        }

        public virtual void SelectItemInListView()
        {
            listView.Select(0);
            Assert.AreEqual(true,listView.Rows[0].IsSelected);
            listView.Select(1);
            Assert.AreEqual(true,listView.Rows[1].IsSelected);
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
            Assert.AreEqual(2, ped.Nodes.Count);
            addNode.Click();
            Assert.AreEqual(true, ped.HasNode("DynamicNode"));
        }

        public virtual void CheckProgress()
        {
            mainProgressBars.Check();
        }
    }
    // ReSharper restore FieldCanBeMadeReadOnly.Local
}