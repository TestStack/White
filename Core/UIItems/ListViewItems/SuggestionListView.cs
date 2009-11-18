using System.Windows.Automation;
using Bricks.Core;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.UIItems.Actions;

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
            Clock.Matched matched = obj => obj == null;
            WaitTill(new NullActionListener(), "Took too long to select the item in SuggestionList", matched);
        }

        private static SuggestionList WaitTill(ActionListener actionListener, string failureMessage, Clock.Matched matched)
        {
            Clock.Do getSuggestionList = () => Find(actionListener);
            Clock.Expired onExpiration = delegate { throw new UIActionException(failureMessage + Constants.BusyMessage); };

            return
                (SuggestionList) new Clock(CoreAppXmlConfiguration.Instance.SuggestionListTimeout).Perform(getSuggestionList, matched, onExpiration);
        }

        public static SuggestionList WaitAndFind(ActionListener actionListener)
        {
            Clock.Matched matched = obj => obj != null;
            return WaitTill(actionListener, "Took too long to find suggestion list", matched);
        }
    }
}