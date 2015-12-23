using NUnit.Framework;
using System;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects.ScreenAttributes;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.ScreenObjects.UITests.Testing
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
            Button.Click();
            Assert.That(result.Text, Is.EqualTo("Button Clicked"));
        }

        public virtual void EnterText()
        {
            textBox.Text = "abcd";
            Assert.That(textBox.Text, Is.EqualTo("abcd"));
            Assert.That(result.Text, Is.EqualTo("Text changed"));
        }

        public virtual void SelectComboBoxItem()
        {
            komboBox.Select("Arundhati Roy");
            Assert.That(komboBox.SelectedItemText, Is.EqualTo("Arundhati Roy"));
            komboBox.Select("Noam Chomsky");
            Assert.That(komboBox.SelectedItemText, Is.EqualTo("Noam Chomsky"));
        }

        public virtual void EnterTextInTheTextBoxesWithSameNameUsingIndex()
        {
            myNameIsDuplicateBox.Text = "one";
            Assert.That(myNameIsDuplicateBox.Text, Is.EqualTo("one"));
            iAmDuplicateBox.Text = "two";
            Assert.That(iAmDuplicateBox.Text, Is.EqualTo("two"));
        }

        public virtual void SelectTab()
        {
            seasons.SelectTabPage("Winter");
        }

        public virtual void SelectCheckbox()
        {
            chequeBox.Checked = true;
            Assert.That(chequeBox.Checked, Is.True);
            chequeBox.Checked = false;
            Assert.That(chequeBox.Checked, Is.False);
        }

        public virtual void SelectItemInChequedListBox()
        {
            chequedListBox.Check("Bill Gates");
            Assert.That(chequedListBox.IsChecked("Bill Gates"), Is.True);
        }

        public virtual void SelectRadioButton()
        {
            Assert.That(radioButton1.IsSelected, Is.False);
            Assert.That(radioButton2.IsSelected, Is.False);
            radioButton1.Select();
            Assert.That(radioButton1.IsSelected, Is.True);
            radioButton2.Select();
            Assert.That(radioButton2.IsSelected, Is.True);
        }

        public virtual void SelectItemInListBox()
        {
            listBox.Select("Speilberg");
            Assert.That(listBox.IsSelected("Speilberg"), Is.True);
            listBox.Select("Nagesh");
            Assert.That(listBox.IsSelected("Nagesh"), Is.True);
        }

        public virtual void SelectDateTime()
        {
            Assert.That(dateTimePicker.Date, Is.EqualTo(DateTime.Today));
            DateTime tenDaysFromToday = DateTime.Today.AddDays(10);
            dateTimePicker.Date = tenDaysFromToday;
            Assert.That(dateTimePicker.Date, Is.EqualTo(tenDaysFromToday));
        }

        public virtual void SelectItemInListView()
        {
            listView.Select(0);
            Assert.That(listView.Rows[0].IsSelected, Is.True);
            listView.Select(1);
            Assert.That(listView.Rows[1].IsSelected, Is.True);
        }

        public virtual void LaunchModalWindow()
        {
            launchModal.Click();
            ScreenRepository.GetModal<ModalScreen>("ModalForm", Window, InitializeOption.NoCache).Close();
            linkLaunchesModalWindow.Click();
            ScreenRepository.GetModal<ModalScreen>("ModalForm", Window, InitializeOption.NoCache).Close();
            checkBoxLaunchedModalWindow.Click();
            ScreenRepository.GetModal<ModalScreen>("ModalForm", Window, InitializeOption.NoCache).Close();
        }

        public virtual void SelectNodesInTree()
        {
            ped.Node("Root").Expand();
            ped.Node("Root", "Child").Expand();
            Assert.That(ped.Nodes, Has.Count.EqualTo(2));
            addNode.Click();
            Assert.That(ped.HasNode("DynamicNode"), Is.True);
        }

        public virtual void CheckProgress()
        {
            mainProgressBars.Check();
        }
    }
    // ReSharper restore FieldCanBeMadeReadOnly.Local
}