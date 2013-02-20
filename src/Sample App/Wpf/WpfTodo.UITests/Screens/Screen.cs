using System;
using System.Windows.Automation;
using White.Core.UIItems.WindowItems;
using White.Core.Utility;
using White.Repository;

namespace WpfTodo.UITests.Screens
{
    public class Screen : AppScreen
    {
        public Screen(Window window, ScreenRepository screenRepository) : base(window, screenRepository)
        {
        }

        public virtual void WaitWhileBusy()
        {
            Retry.For(ShellIsBusy, isBusy => isBusy, TimeSpan.FromSeconds(30));
        }

        bool ShellIsBusy()
        {
            var currentPropertyValue = window.AutomationElement.GetCurrentPropertyValue(AutomationElement.HelpTextProperty);
            return currentPropertyValue != null && ((string)currentPropertyValue).Contains("Busy");
        }
    }
}