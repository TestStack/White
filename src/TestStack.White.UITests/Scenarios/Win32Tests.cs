using System.Diagnostics;
using System.Globalization;
using System.Linq;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.WindowsAPI;
using Xunit;

namespace TestStack.White.UITests.Scenarios
{
    public class Win32Tests
    {
        const string ExeSourceFile = @"C:\Windows\system32\calc.exe";
        const string Notepad = @"C:\Windows\system32\notepad.exe";
        const string InternetExplorer = @"C:\Program Files\Internet Explorer\iexplore.exe";

        [Fact]
        public void NotepadTests()
        {
            string windowTitle = "Untitled - Notepad";
            string fontMenuItemShortcuts = "of";
            string fontDialogTitle = "Font";

            var lang = CultureInfo.InstalledUICulture.Name;
            if (lang.StartsWith("de"))
            {
                windowTitle = "Unbenannt - Editor";
                fontMenuItemShortcuts = "os";
                fontDialogTitle = "Schriftart";
            }

            using (var app = Application.Launch(Notepad))
            using (var window = app.GetWindow(windowTitle))
            {
                window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.ALT);
                foreach (char c in fontMenuItemShortcuts)
                    window.Keyboard.Enter(c.ToString());

                using (var modalWindow = window.ModalWindow(fontDialogTitle))
                {
                    Assert.NotNull(modalWindow);
                }
            }
        }

        [Fact]
        public void InternetExplorerTests()
        {
            string toolTipText = "Tools (Alt+X)";
            string optionsMenuItem = "Internet Options";
            string optionsDialogTitle = "Internet Options";

            var lang = CultureInfo.InstalledUICulture.Name;
            if (lang.StartsWith("de"))
            {
                toolTipText = "Extras (Alt+X)";
                optionsMenuItem = "Internetoptionen";
                optionsDialogTitle = "Internetoptionen";
            }

            using (var app = Application.Launch(InternetExplorer))
            using (var window = app.GetWindows().Single())
            {
                var button = window.Get<Button>(SearchCriteria.ByAutomationId("Item 3"));
                //check if we can get a win32 tooltip
                Assert.Equal(toolTipText, window.GetToolTipOn(button).Text);
                button.Click();
                window.PopupMenu(optionsMenuItem).Click();
                using (var internetOptions = window.ModalWindow(optionsDialogTitle))
                {
                    var textBox = internetOptions.Get<TextBox>(SearchCriteria.ByAutomationId("1487"));

                    textBox.Text = "http://google.com";

                    Assert.Equal("http://google.com", textBox.Text);
                }
            }
        }

        [Fact]
        public void CalculatorTests()
        {
            string windowTitle = "Calculator";
            string menuBarName = "Application";
            string editMenuItem = "Edit";
            string copyMenuItem = "Copy";
            string viewMenuItem = "View";
            string basicMenuItem = "Basic";
            string dateCalcAccelerator = "E";
            string dateCalcComboBoxItem = "Calculate the difference between two dates";

            var lang = CultureInfo.InstalledUICulture.Name;
            if (lang.StartsWith("de"))
            {
                windowTitle = "Rechner";
                menuBarName = "Anwendung";
                editMenuItem = "Bearbeiten";
                copyMenuItem = "Kopieren";
                viewMenuItem = "Ansicht";
                basicMenuItem = "Basismodus";
                dateCalcAccelerator = "E";
                dateCalcComboBoxItem = "Differenz zwischen zwei Datumsangaben berechnen";
            }


            //strat process for the above exe file location
            var psi = new ProcessStartInfo(ExeSourceFile);
            // launch the process through white application
            using (var application = Application.AttachOrLaunch(psi))
            using (var mainWindow = application.GetWindow(SearchCriteria.ByText(windowTitle), InitializeOption.NoCache))
            {
                // Verify can click on menu twice
                var menuBar = mainWindow.Get<MenuBar>(SearchCriteria.ByText(menuBarName));
                menuBar.MenuItem(editMenuItem, copyMenuItem).Click();
                menuBar.MenuItem(editMenuItem, copyMenuItem).Click();

                mainWindow.Keyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
                mainWindow.Keyboard.Enter(dateCalcAccelerator);
                mainWindow.Keyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);

                //On Date window find the difference between dates.
                //Set value into combobox
                mainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("4003")).Select(dateCalcComboBoxItem);
                //Click on Calculate button
                mainWindow.Get<Button>(SearchCriteria.ByAutomationId("4009")).Click();

                mainWindow.Keyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
                mainWindow.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.F4);
                mainWindow.Keyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);

                var menuView = mainWindow.Get<Menu>(SearchCriteria.ByText(viewMenuItem));
                menuView.Click();
                var menuViewBasic = mainWindow.Get<Menu>(SearchCriteria.ByText(basicMenuItem));
                menuViewBasic.Click();

                PerformSummationOnCalculator(mainWindow);
            }
        }

        /// <summary>
        /// method to Perform Addition of two numbers and validate the result
        /// </summary>
        private static void PerformSummationOnCalculator(UIItemContainer mainWindow)
        {
            mainWindow.Get<Button>(SearchCriteria.ByText("1")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("2")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("3")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("4")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("Add")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("5")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("6")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("7")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("8")).Click();
            //Button with text as +(for sum)
            //Read button to get the result
            mainWindow.Get<Button>(SearchCriteria.ByText("Equals")).Click();

            //Get the result
            var resultLable = mainWindow.Get<Label>(SearchCriteria.ByAutomationId("150"));
            string result = resultLable.Text;
            Assert.Equal("6912", result);
        }
    }
}