using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace WhiteProject
{
    class Program
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        const string WINDOW_PROPERTY = "Name";
        const string WINDOW_VALUE = "Untitled - Notepad";

        static void Main(string[] args)
        {
            //------------------------------ Maximizing Console Window ------------------------------
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);

            //------------------------------ Type in Notepad the save.. ------------------------------
            //TypeAndSaveNotepad();

            Console.ReadLine();
        }

        public static Window SelectWindow(String property, String value)
        {
            List<Window> windows = WindowFactory.Desktop.DesktopWindows();
            Window selectedWindow = null;
            foreach (Window window in windows)
            {
                System.Reflection.PropertyInfo propertyInfo = window.GetType().GetProperty(property);
                String propertyValue = (String)(propertyInfo.GetValue(window, null));

                if (propertyValue.Equals(value))
                {
                    selectedWindow = window;
                }
            }
            return selectedWindow;
        }

        private static void TypeAndSaveNotepad()
        {
            //------------------------------ Selecting Window ------------------------------
            Console.WriteLine("------------------------------ Select Window for given Property and Value /------------------------------");
            Window selectedWindow = SelectWindow(WINDOW_PROPERTY, WINDOW_VALUE);
            selectedWindow.Focus();

            //------------------------------ Type in Notepad ------------------------------
            String edit_Notepad = "//document[@ClassName='Edit']";
            String btn_File = "//menu-item[@Name='File']";
            String btn_New = "//menu-item[@Name='Save']";
            String combo_FileName = "//combo-box[@Name='File name:']";

            IUIItem edit_NotepadObj = selectedWindow.Get(SearchCriteria.ByXPath(edit_Notepad, selectedWindow));
            edit_NotepadObj.Enter("Testing Purpose............");

            IUIItem btn_FileObj = selectedWindow.Get(SearchCriteria.ByXPath(btn_File, selectedWindow));
            btn_FileObj.Click();

            IUIItem btn_NewObj = selectedWindow.Get(SearchCriteria.ByXPath(btn_New, selectedWindow));
            btn_NewObj.Click();
        }

        public static void ComboBoxClick(Window w, AutomationElement ele)
        {
            if (w.AutomationElement != null)
            {
                AutomationElement comboboxInstance = ele;
                if (comboboxInstance == null)
                {
                    Console.WriteLine("ComboBox instance not found.");
                }
                else
                {
                    AutomationElement comboboxList = comboboxInstance.FindFirst(TreeScope.Children,
                          new PropertyCondition
                    (AutomationElement.ControlTypeProperty, ControlType.List));

                    AutomationElementCollection comboboxItem =
                       comboboxList.FindAll(TreeScope.Children,
                        new PropertyCondition(AutomationElement.ControlTypeProperty,
                                   ControlType.ListItem));

                    AutomationElement[] itemArray = new AutomationElement[comboboxItem.Count];

                    comboboxItem.CopyTo(itemArray, 0);

                    for (int i = 0; i < itemArray.Length; i++)
                    {
                        Console.WriteLine(itemArray[1]);
                    }

                    AutomationElement itemToSelect = comboboxItem[1];

                    Object selectPattern = null;
                    if (itemToSelect.TryGetCurrentPattern(SelectionItemPattern.Pattern, out selectPattern))
                    {
                        ((SelectionItemPattern)selectPattern).Select();
                    }
                }
            }
        }

        public static void SetCombobValueByUIA(AutomationElement ctrl, string newValue)
        {
            ExpandCollapsePattern exPat = ctrl.GetCurrentPattern(ExpandCollapsePattern.Pattern)
                                                                      as ExpandCollapsePattern;

            if (exPat == null)
            {
                throw new ApplicationException("Bad Control type...");
            }

            exPat.Expand();

            AutomationElement itemToSelect = ctrl.FindFirst(TreeScope.Children, new
                                  PropertyCondition(AutomationElement.NameProperty, newValue));

            SelectionItemPattern sPat = itemToSelect.GetCurrentPattern(
                                                      SelectionItemPattern.Pattern) as SelectionItemPattern;
            sPat.Select();
        }

        public static void SelectListItem(AutomationElement selectionContainer, String itemText)
        {
            if ((selectionContainer == null) || (itemText == ""))
            {
                throw new ArgumentException(
                    "Argument cannot be null or empty.");
            }

            Condition propertyCondition = new PropertyCondition(
                AutomationElement.AutomationIdProperty,
                itemText,
                PropertyConditionFlags.IgnoreCase);

            AutomationElement firstMatch =
                selectionContainer.FindFirst(TreeScope.Children, propertyCondition);

            if (firstMatch != null)
            {
                try
                {
                    SelectionItemPattern selectionItemPattern;
                    selectionItemPattern =
                    firstMatch.GetCurrentPattern(
                    SelectionItemPattern.Pattern) as SelectionItemPattern;
                    selectionItemPattern.Select();
                }
                catch (InvalidOperationException)
                {
                    // Unable to select
                    return;
                }
            }
        }
    }
}
