using System;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Recording;
using TestStack.White.UIItemEvents;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Scrolling;

namespace TestStack.White.UIItems.ListBoxItems
{
    public class ComboBox : ListControl
    {
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
            //if (!Enabled)
            //{
            //    Logger.WarnFormat("Could not select {0}in {1} since it is disabled", itemText, Name);
            //    return;
            //}
            //if (Equals(itemText, SelectedItemText)) return;
            //base.Select(itemText);

            AutomationElement comboboxList = this.AutomationElement.FindFirst(TreeScope.Children,
                new PropertyCondition(AutomationElement.ControlTypeProperty,
                ControlType.List));

            AutomationElementCollection comboboxItem = comboboxList.FindAll(TreeScope.Children,
                new PropertyCondition(AutomationElement.ControlTypeProperty,
                ControlType.ListItem));

            AutomationElement[] itemArray = new AutomationElement[comboboxItem.Count];
            comboboxItem.CopyTo(itemArray, 0);

            AutomationElement itemToSelect = null;

            for (int i = 0; i < itemArray.Length; i++)
            {
                if (itemArray[i].Current.Name.Equals(itemText))
                {
                    itemToSelect = itemArray[i];
                }
            }

            if (itemToSelect != null)
            {
                Object selectPattern = null;
                if (itemToSelect.TryGetCurrentPattern(SelectionItemPattern.Pattern, out selectPattern))
                {
                    ((SelectionItemPattern)selectPattern).Select();
                }
            }
        }

        public override void Select(int index)
        {
            //if (!Enabled)
            //{
            //    Logger.Warn("Could not select " + index + "in " + Name + " since it is disabled");
            //    return;
            //}
            //base.Select(index);
            //var p = (ExpandCollapsePattern) this.AutomationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
            //if (p.Current.ExpandCollapseState.Equals(ExpandCollapseState.Expanded))
            //    p.Collapse();

            AutomationElement comboboxList = this.AutomationElement.FindFirst(TreeScope.Children, 
                new PropertyCondition(AutomationElement.ControlTypeProperty,
                ControlType.List));

            AutomationElementCollection comboboxItem = comboboxList.FindAll(TreeScope.Children,
                new PropertyCondition(AutomationElement.ControlTypeProperty,
                ControlType.ListItem));

            AutomationElement itemToSelect = comboboxItem[index];

            Object selectPattern = null;
            if (itemToSelect.TryGetCurrentPattern(SelectionItemPattern.Pattern, out selectPattern))
            {
                ((SelectionItemPattern)selectPattern).Select();
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