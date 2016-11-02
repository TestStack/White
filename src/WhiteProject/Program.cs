using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        const string WINDOW_NAME = "Start menu";

        static void Main(string[] args)
        {
            Console.WriteLine("Applications...");
            Window loginWindow = null;
            Window startMenu = null;
            Window startEditWindow = null;
            Thread.Sleep(5000);
            List<Window> windows = WindowFactory.Desktop.DesktopWindows();
            
            //var fdaf = new ProcessStartInfo("gsdg");
            //Application application = Application.AttachOrLaunch(fdaf);
            //Window mainWindow = application.GetWindows()[0];
            //Thread.Sleep(5000);
            foreach (Window w in windows)
            {
                if (w.AutomationElement.Current.Name.Equals(WINDOW_NAME))
                {
                    //Console.WriteLine(w.Title);
                    //Console.WriteLine(w.Hierarchy);
                    loginWindow = w;
                    loginWindow.Focus();
                }
            }

            //IUIItem start = loginWindow.Get(SearchCriteria.ByXPath("//button[@Name='Start']", loginWindow));
            //start.Click();

            //List<Window> windows1 = WindowFactory.Desktop.DesktopWindows();

            //foreach (Window w in windows1)
            //{
            //    if (w.AutomationElement.Current.ClassName.Equals("IEFrame"))
            //    {
            //        //Console.WriteLine(w.Title);
            //        //Console.WriteLine(w.Hierarchy);
            //        startMenu = w;
            //        startMenu.Focus();
            //    }
            //}

            // 

            //IUIItem searchPath = loginWindow.Get(SearchCriteria.ByXPath("//button[@Name='Previous Locations']", loginWindow));
            //searchPath.Click();
            //IUIItem searchText = loginWindow.Get(SearchCriteria.ByXPath("//edit[@Name='Address']", loginWindow));
            //searchPath.Enter("dfasdgs");

            IUIItem startEdit1 = loginWindow.Get(SearchCriteria.ByXPath("//pane[@Name='Start menu']/pane[5]/pane[1]/pane[1]", loginWindow));
            startEdit1.Click();
            IUIItem startEdit = loginWindow.Get(SearchCriteria.ByXPath("//edit[@Name='Search Box']", loginWindow));
            //startEdit.Click();
            startEdit.Enter("notepad");
            startEdit.DrawHighlight();
            startEdit.Click();

            IUIItem startEdit2 = loginWindow.Get(SearchCriteria.ByXPath("//window[@AutomationId='MangoDashBoard']/menu[4]/menu-item[@Name='Actions']/menu-item[@Name='Copy']", loginWindow));
            startEdit2.Click();
            
 //startEdit.SetValue("virtusarpa");






            startEdit.DrawHighlight();
          //  startEdit.Click();
            //Thread.Sleep(3000);
            //startEdit.SetValue("remote1");
           // startEdit.Click();

            //Thread.Sleep(2000);

            //IUIItem remote = startEditWindow.Get(SearchCriteria.ByXPath("//list-item[@Name='Remote Desktop Connection']", startEditWindow));
            //remote.Click();

            //Console.Clear();
             
            //IUIItem[] uiItemList = loginWindow.GetMultiple(SearchCriteria.All);
            //Console.WriteLine(uiItemList.Length);
            //AutomationElement ele = uiItemList[10].GetElement(SearchCriteria.All);
        
            //AutomationElementCollection collecton = ele.FindAll(TreeScope.Children, Condition.TrueCondition);

            //AutomationElement rootElement = AutomationElement.RootElement;
            //var winCollection = rootElement.FindAll(TreeScope.Children, Condition.TrueCondition);
            //Console.Clear();
            //foreach (AutomationElement element in winCollection)
            //{
            //    Console.WriteLine(element.Current.Name);
            //}

            //Console.WriteLine(uiItemList.Length);


            //var comboBox = loginWindow.Get<TestStack.White.UIItems.ListBoxItems.ComboBox>(SearchCriteria.ByXPath("//window[@Name='Add New Machine']/combo-box[1]", loginWindow));

            //ComboBoxClick(loginWindow, comboBox.AutomationElement);

            //var combo = loginWindow.Get(SearchCriteria.ByXPath("//window[@Name='Add New Machine']/combo-box[1]", loginWindow));
            //var combo = loginWindow.Get(SearchCriteria.ByAutomationId("JavaFX34"));
            //combo.Click();
            //var comboItem = loginWindow.Get(SearchCriteria.ByXPath("//window[@Name='Add New Machine']/combo-box[1]", loginWindow));
            //comboItem.Click();

            //ComboBox comboBox = (ComboBox)combo;

            //foreach (ListItem item in comboBox.Items)
            //{
            //    Console.WriteLine(item.Text);
            //}
            //comboBox.Select("Linux");

            //AutomationElement selectElement = comboBox.AutomationElement;

            //Condition propertyCondition = new PropertyCondition(AutomationElement.NameProperty, "Windows", PropertyConditionFlags.None);
            //AutomationElement firstMatch = comboBox.AutomationElement.FindFirst(TreeScope.Children, propertyCondition);

            //SelectListItem(selectElement, "JavaFX34");

            //var username1 = loginWindow.Get(SearchCriteria.ByXPath("sdgsdg"));
            //var username = loginWindow.Get(SearchCriteria.Indexed());
            
            //username.Enter("nija");

            //SetCombobValueByUIA(comboBox.AutomationElement, "Mac");

            //var testMachineGroup = loginWindow.Get(SearchCriteria.ByXPath("//title-pane[@Name='Test Machine Group']/text[1]", loginWindow));
            //testMachineGroup.Click();

            //var draggedElement = loginWindow.Get(SearchCriteria.ByXPath("//window[@Name='Tempo Workstation 1.0.2.1']/list[1]/list-item[1]", loginWindow));
            //draggedElement.Click();

            //var dropElement = loginWindow.Get(SearchCriteria.ByXPath("//title-pane[@Name='Test Machine Group']/list[1]", loginWindow));

            //Mouse.Instance.DragAndDrop(draggedElement, dropElement);


            Console.ReadLine();
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
