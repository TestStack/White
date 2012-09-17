using System;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.UIItems.Actions;
using White.Core.Utility;

namespace White.Core.UIItems.ListViewItems
{
    public static class SuggestionListView
    {
        private static SuggestionList Find(ActionListener actionListener)
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
            WaitTill(new NullActionListener(), "Took too long to select the item in SuggestionList", obj => obj == null);
        }

        private static SuggestionList WaitTill(ActionListener actionListener, string failureMessage, Predicate<SuggestionList> matched)
        {
            try
            {
                return Retry.For(() => Find(actionListener), matched, CoreAppXmlConfiguration.Instance.SuggestionListTimeout);
            }
            catch (Exception ex)
            {
                throw new UIActionException(failureMessage + Constants.BusyMessage, ex);
            }
        }

        public static SuggestionList WaitAndFind(ActionListener actionListener)
        {
            return WaitTill(actionListener, "Took too long to find suggestion list", obj => obj != null);
        }
    }
}