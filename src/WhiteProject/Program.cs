using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace WhiteProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Applications...");
            Window loginWindow = null;

            List<Window> windows = WindowFactory.Desktop.DesktopWindows();
            foreach (Window w in windows)
            {
                if(w.Title.Equals("Login"))
                {
                    Console.WriteLine(w.Title);
                    loginWindow = w;
                    loginWindow.Focus();
                }
            }
            Console.Clear();

            IUIItem[] uiItemList = loginWindow.GetMultiple(SearchCriteria.All);
            Console.WriteLine(uiItemList.Length);

            var username = loginWindow.Get(SearchCriteria.ByAutomationId("JavaFX3"));
            username.Enter("nija");

            Console.ReadLine();
        }                                                                                                                                                                                                                                                                         
    }
}
