using System;
using System.Threading;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.Recording;
using TestStack.White.UIA;
using TestStack.White.UIItemEvents;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Scrolling;

namespace TestStack.White.UIItems.ListBoxItems
{
    public class ComboBox : ListControl
    {
        private class TempExpand : IDisposable
        {
            private readonly ComboBox parent;
            private readonly bool needsCollapse;

            private TempExpand(ComboBox parent)
            {
                this.parent = parent;
                needsCollapse = parent.Expand();
                parent.Logger.DebugFormat("TempExpand called. Expansion made: {0}", needsCollapse);
            }

            public virtual void Dispose()
            {
                parent.Logger.DebugFormat("TempExpand finished. Will be collapsed: {0}", needsCollapse);
                if (needsCollapse)
                    parent.Collapse();
            }

            public static TempExpand IfNeeded(ComboBox parent)
            {
                return new TempExpand(parent);
            }
        }

        private AutomationPropertyChangedEventHandler handler;
        private ListItem lastSelectedItem;

        protected ComboBox()
        {
        }

        public ComboBox(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener)
        {
            this.actionListener = actionListener;
        }

        public override VerticalSpan VerticalSpan
        {
            get
            {
                AutomationElement listElement = Finder.Child(AutomationSearchCondition.ByControlType(ControlType.List));
                var listContainerItem = new UIItem(listElement, new NullActionListener());
                return new VerticalSpan(listContainerItem.Bounds).Union(listContainerItem.Bounds);
            }
        }

        public override IScrollBars ScrollBars
        {
            get { return new ComboBoxScrollBars(automationElement, actionListener); }
        }

        public virtual string EditableText
        {
            get { return EditableItem.Text; }
            set { EditableItem.Text = value; }
        }

        protected virtual TextBox EditableItem
        {
            get
            {
                AutomationElement editElement = EditableElement();
                if (editElement != null)
                {
                    return new TextBox(editElement, actionListener);
                }
                throw new WhiteException("ComboBox is not editable");
            }
        }

        public override ListItems Items
        {
            get
            {
                using (TempExpand.IfNeeded(this))
                    return base.Items;
            }
        }

        public virtual bool Expand()
        {
            if (CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen) return false;
            if (!Enabled) return false;

            var ecp = AutomationElement.GetPattern<ExpandCollapsePattern>();
            if (ecp != null && ecp.Current.ExpandCollapseState == ExpandCollapseState.Collapsed)
            {
                ecp.Expand();
                Thread.Sleep(50);
                return true;
            }
            return false;
        }

        public virtual bool Collapse()
        {
            var ecp = AutomationElement.GetPattern<ExpandCollapsePattern>();
            if (ecp != null && ecp.Current.ExpandCollapseState == ExpandCollapseState.Expanded)
            {
                ecp.Collapse();
                return true;
            }
            return false;
        }

        public virtual ExpandCollapseState ExpandCollapseState
        {
            get
            {
                var ecp = AutomationElement.GetPattern<ExpandCollapsePattern>();
                if (ecp != null)
                {
                    var state = ecp.Current.ExpandCollapseState;
                    return state;
                }
                return ExpandCollapseState.LeafNode;
            }
        }

        public virtual bool IsEditable
        {
            get { return EditableElement() != null;}
        }

        private AutomationElement EditableElement()
        {
            return Finder.Child(AutomationSearchCondition.ByControlType(ControlType.Edit));
        }

        public override void Select(string itemText)
        {
            if (!Enabled)
            {
                Logger.WarnFormat("Could not select {0}in {1} since it is disabled", itemText, Name);
                return;
            }
            using (TempExpand.IfNeeded(this))
            {
                if (Equals(itemText, SelectedItemText)) return;
                base.Select(itemText);
            }
        }

        public override void Select(int index)
        {
            if (!Enabled)
            {
                Logger.Warn("Could not select " + index + "in " + Name + " since it is disabled");
                return;
            }
            using (TempExpand.IfNeeded(this))
                base.Select(index);
        }

        public override string SelectedItemText
        {
            get
            {
                using (TempExpand.IfNeeded(this))
                    return base.SelectedItemText;
            }
        }

        public override ListItem SelectedItem
        {
            get
            {
                using (TempExpand.IfNeeded(this))
                    return base.SelectedItem;
            }
        }

        public override void HookEvents(IUIItemEventListener eventListener)
        {
            lastSelectedItem = SelectedItem;
            handler = delegate(object sender, AutomationPropertyChangedEventArgs e)
                          {
                              if (SelectedItem == null || e.NewValue.Equals(1)) return;
                              if (SameListItem()) return;
                              lastSelectedItem = SelectedItem;
                              eventListener.EventOccured(new ComboBoxEvent(this, SelectedItemText));
                          };
            Automation.AddAutomationPropertyChangedEventHandler(automationElement, TreeScope.Element, handler, ExpandCollapsePattern.ExpandCollapseStateProperty);
        }

        public override void UnHookEvents()
        {
            Automation.RemoveAutomationPropertyChangedEventHandler(automationElement, handler);
        }

        private bool SameListItem()
        {
            if (lastSelectedItem == null && SelectedItem != null) return false;
            return Equals(SelectedItemText, lastSelectedItem == null ? null : lastSelectedItem.Text);
        }
    }
}