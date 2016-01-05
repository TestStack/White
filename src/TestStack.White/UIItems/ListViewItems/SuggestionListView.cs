using System;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.UIItems.Actions;
using TestStack.White.Utility;

namespace TestStack.White.UIItems.ListViewItems
{
    public static class SuggestionListView
    {
        private static ISuggestionList Find(IActionListener actionListener)
        {
            AutomationElement dropDown =
                new AutomationElementFinder(AutomationElement.RootElement).Child(AutomationSearchCondition.ByClassName("Auto-Suggest Dropdown"));
            if (dropDown == null) return null;

            AutomationElement listViewElement =
                new AutomationElementFinder(dropDown).Child(AutomationSearchCondition.ByControlType(ControlType.DataGrid));
            if (listViewElement == null) return null;
            return new ListView(listViewElement, actionListener);
        }

        public static void WaitTillNotPresent()
        {
            WaitTill(new NullActionListener(), "Took too long to select the item in SuggestionList", obj => obj != null);
        }

        private static ISuggestionList WaitTill(IActionListener actionListener, string failureMessage, Predicate<ISuggestionList> shouldRetry)
        {
            try
            {
                return Retry.For(() => Find(actionListener), shouldRetry, CoreAppXmlConfiguration.Instance.SuggestionListTimeout());
            }
            catch (Exception ex)
            {
                throw new UIActionException(failureMessage + Constants.BusyMessage, ex);
            }
        }

        public static ISuggestionList WaitAndFind(IActionListener actionListener)
        {
            return WaitTill(actionListener, "Took too long to find suggestion list", obj => obj == null);
        }
    }
}