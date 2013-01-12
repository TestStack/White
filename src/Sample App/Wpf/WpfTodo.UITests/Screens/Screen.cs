using System;
using System.Windows.Automation;
using White.Core;
using White.Core.UIItems.WindowItems;
using White.Core.Utility;

namespace WpfTodo.UITests.Screens
{
    public class Screen
    {
        protected Screen(Application application, Window whiteWindow)
        {
            Application = application;
            WhiteWindow = whiteWindow;
        }

        public Application Application { get; set; }
        public Window WhiteWindow { get; set; }

        public void WaitWhileBusy()
        {
            Retry.For(ShellIsBusy, isBusy => isBusy, TimeSpan.FromSeconds(30));
        }

        bool ShellIsBusy()
        {
            var currentPropertyValue = WhiteWindow.AutomationElement.GetCurrentPropertyValue(AutomationElement.HelpTextProperty);
            return currentPropertyValue != null && ((string)currentPropertyValue).Contains("Busy");
        }
    }
}