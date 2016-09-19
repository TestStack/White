using System;
using System.Linq;
using System.Threading;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.Utility;

namespace TestStack.White.UITests
{
    public class Windows8AppsTests
    {
        public void weatherwindows81_winjs()
        {
            var app = Application.LaunchWindows8Application("Microsoft.BingWeather_8wekyb3d8bbwe!App");
            var window = app.GetWindows().Single();
            OpenAppBar();
            window.Get<Hyperlink>("Home_link").Click();
            OpenAppBar();
            window.Get<Hyperlink>("MyPlaces_link").Click();
            var tile = window.Get<GroupBox>("CommonJS_UI_ResponsiveListView_Cluster1_Content_ListView2AddTile");
            tile.Click();
            var citySearch = window.Get<ComboBox>("SearchTextBox");
            citySearch.Enter("Sydney");
            citySearch.KeyIn(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(500);
            window.Get<ListBox>("searchResults").Item(0).Click();
            Thread.Sleep(500);
            var list = window.Get<ListBox>("CommonJS_UI_ResponsiveListView_Cluster1_Content");
            var foundAndRemoved = false;
            foreach (var item in Retry.For(() => list.Items, t => t.Count == 0, TimeSpan.FromSeconds(5)))
            {
                if (item.AutomationElement.Current.AutomationId == "CommonJS_UI_ResponsiveListView_Cluster1_Content_ResponsiveListViewSydney,_NSW,_Australia")
                {
                    item.RightClick();
                    window.Get<Button>("CommonJS_UI_ResponsiveListView_Cluster1_Content_ResponsiveListViewSydney,_NSW,_Australia_DeleteButton").Click();
                    foundAndRemoved = true;
                }
            }
        }

        void OpenAppBar()
        {
            var keyboard = new Keyboard();
            Thread.Sleep(100);
            keyboard.HoldKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.LWIN);
            keyboard.Enter("z");
            keyboard.LeaveKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.LWIN);
        }
    }
}