﻿using NUnit.Framework;
using System.Diagnostics;
using System.Linq;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.WindowsAPI;

namespace TestStack.White.UITests.Scenarios
{
    [TestFixture]
    public class Win32Tests
    {
        const string ExeSourceFile = @"C:\Windows\system32\calc.exe";
        const string Notepad = @"C:\Windows\system32\notepad.exe";
        const string InternetExplorer = @"C:\Program Files\Internet Explorer\iexplore.exe";

        [Test]
        public void NotepadTests()
        {
            using (var app = Application.Launch(Notepad))
            using (var window = app.GetWindow("Untitled - Notepad"))
            {
                window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.ALT);
                window.Keyboard.Enter("o");
                window.Keyboard.Enter("f");

                using (var modalWindow = window.ModalWindow("Font"))
                {
                    Assert.That(modalWindow, Is.Not.Null);
                }
            }
        }

        [Test]
        [Ignore("There are different IE versions which make this test fail")]
        public void InternetExplorerTests()
        {
            using (var app = Application.Launch(InternetExplorer))
            {
                using (var window = app.GetWindows().Single())
                {
                    var button = window.Get<Button>(SearchCriteria.ByAutomationId("Item 3"));
                    //check if we can get a win32 tooltip
                    Assert.That(window.GetToolTipOn(button).Text, Is.EqualTo("Tools (Alt+X)"));
                    button.Click();
                    window.PopupMenu("Internet options").Click();
                    using (var internetOptions = window.ModalWindow("Internet Options"))
                    {
                        var textBox = internetOptions.Get<TextBox>(SearchCriteria.ByAutomationId("1487"));

                        textBox.Text = "http://google.com";

                        Assert.That(textBox.Text, Is.EqualTo("http://google.com"));
                    }
                }
            }
        }

        [Test]
        public void CalculatorTests()
        {
            //strat process for the above exe file location
            var psi = new ProcessStartInfo(ExeSourceFile);
            // launch the process through white application
            using (var application = Application.AttachOrLaunch(psi))
            using (var mainWindow = application.GetWindow(SearchCriteria.ByText("Calculator"), InitializeOption.NoCache))
            {
                // Verify can click on menu twice
                var menuBar = mainWindow.Get<MenuBar>(SearchCriteria.ByText("Application"));
                menuBar.MenuItem("Edit", "Copy").Click();
                menuBar.MenuItem("Edit", "Copy").Click();

                mainWindow.Keyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
                mainWindow.Keyboard.Enter("E");
                mainWindow.Keyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);

                //On Date window find the difference between dates.
                //Set value into combobox
                mainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("4003")).Select("Calculate the difference between two dates");
                //Click on Calculate button
                mainWindow.Get<Button>(SearchCriteria.ByAutomationId("4009")).Click();

                mainWindow.Keyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
                mainWindow.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.F4);
                mainWindow.Keyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);

                var menuView = mainWindow.Get<Menu>(SearchCriteria.ByText("View"));
                menuView.Click();
                var menuViewBasic = mainWindow.Get<Menu>(SearchCriteria.ByText("Basic"));
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
            var result = resultLable.Text;
            Assert.That(result, Is.EqualTo("6912"));
        }
    }
}