using System.Collections.Generic;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Factory;
using White.Core.Recording;
using White.Core.UIItemEvents;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.TabItems
{
    public class Tab : UIItem
    {
        private TabPages pages;
        private AutomationPropertyChangedEventHandler handler;
        protected Tab() {}

        public Tab(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual ITabPage SelectedTab
        {
            get { return Pages.Find(tabPage => tabPage.IsSelected); }
        }

        public virtual int TabCount
        {
            get { return Pages.Count; }
        }

        public virtual TabPages Pages
        {
            get
            {
                if (pages == null)
                {
                    pages = new TabPages();
                    var finder = new AutomationElementFinder(automationElement);
                    List<AutomationElement> collection = finder.Children(AutomationSearchCondition.ByControlType(ControlType.TabItem));
                    foreach (AutomationElement tabItemElement in collection)
                        pages.Add(new TabPage(tabItemElement, actionListener));
                }

                return pages;
            }
        }

        public virtual void SelectTabPage(int index)
        {
            ITabPage tabPage = Pages[index];
            tabPage.Select();
        }

        public virtual void SelectTabPage(string tabTitle)
        {
            var oldTab = SelectedTab;
            var tabPage = Pages.Find(tabItem => tabItem.NameMatches(tabTitle));
            if (tabPage == null) throw new UIItemSearchException(string.Format("No tab found with title{0}", tabTitle));

            tabPage.Select();
            if (!oldTab.Equals(SelectedTab)) actionListener.ActionPerformed(new Action(ActionType.NewControls));
        }

        public override void HookEvents(UIItemEventListener eventListener)
        {
            handler = delegate { eventListener.EventOccured(new TabEvent(this)); };
            Automation.AddAutomationPropertyChangedEventHandler(automationElement, TreeScope.Descendants, handler, SelectionItemPattern.IsSelectedProperty);
        }

        public override void UnHookEvents()
        {
            Automation.RemoveAutomationPropertyChangedEventHandler(automationElement, handler);
        }
    }
}