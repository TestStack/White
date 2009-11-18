using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Logging;
using White.Core.Recording;
using White.Core.UIItemEvents;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Scrolling;

namespace White.Core.UIItems.ListBoxItems
{
    public class ComboBox : ListControl
    {
        private AutomationPropertyChangedEventHandler handler;
        private ListItem lastSelectedItem;

        protected ComboBox() {}

        public ComboBox(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
        {
            this.actionListener = actionListener;
            MakeActionReady();
        }

        public override VerticalSpan VerticalSpan
        {
            get
            {
                AutomationElement listElement = finder.Child(AutomationSearchCondition.ByControlType(ControlType.List));
                var listContainerItem = new UIItem(listElement, new NullActionListener());
                return new VerticalSpan(listContainerItem.Bounds).Union(listContainerItem.Bounds);
            }
        }

        public override IScrollBars ScrollBars
        {
            get { return new ComboBoxScrollBars(automationElement, actionListener); }
        }

        public override void Select(string itemText)
        {
            if (!Enabled)
            {
                WhiteLogger.Instance.WarnFormat("Could not select {0}in {1} since it is disabled", itemText, Name);
                return;
            }
            ToggleDropDown();
            base.Select(itemText);
        }

        public override void Select(int index)
        {
            if (!Enabled)
            {
                WhiteLogger.Instance.Warn("Could not select " + index + "in " + Name + " since it is disabled");
                return;
            }
            ToggleDropDown();
            base.Select(index);
        }

        protected virtual void MakeActionReady()
        {
            ToggleDropDown();
            ToggleDropDown();
        }

        protected virtual void ToggleDropDown()
        {
            var button = new Button(finder.Child(AutomationSearchCondition.ByControlType(ControlType.Button)), actionListener);
            button.PerformClick();
        }

        public override void HookEvents(UIItemEventListener eventListener)
        {
            lastSelectedItem = SelectedItem;
            handler = delegate(object sender, AutomationPropertyChangedEventArgs e)
                          {
                              if (SelectedItem == null || e.NewValue.Equals(1)) return;
                              if (SameListItem()) return;
                              lastSelectedItem = SelectedItem;
                              eventListener.EventOccured(new ComboBoxEvent(this, SelectedItemText));
                          };
            Automation.AddAutomationPropertyChangedEventHandler(automationElement, TreeScope.Element, handler,
                                                                ExpandCollapsePattern.ExpandCollapseStateProperty);
        }

        public override void UnHookEvents()
        {
            Automation.RemoveAutomationPropertyChangedEventHandler(automationElement, handler);
        }

        private bool SameListItem()
        {
            if (lastSelectedItem == null && SelectedItem != null) return false;
            return SelectedItemText.Equals(lastSelectedItem.Text);
        }
    }
}
