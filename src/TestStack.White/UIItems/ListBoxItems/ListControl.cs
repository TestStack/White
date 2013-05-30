using System.Collections.Generic;
using System.Threading;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Scrolling;

namespace White.Core.UIItems.ListBoxItems
{
    //TODO: Find a better way for doing ActionPerforming, instead of putting it every method
    /// <summary>
    /// ListControl is made of up ListItems and scroll bars.
    /// </summary>
    public class ListControl : UIItem, ListItemContainer, VerticalSpanProvider
    {
        protected AutomationElementFinder Finder;
        protected ListControl() { }

        public ListControl(AutomationElement automationElement, ActionListener actionListener)
            : base(automationElement, actionListener)
        {
            Finder = new AutomationElementFinder(automationElement);
        }

        /// <summary>
        /// Returns all the items belonging to the ListControl
        /// </summary>
        public virtual ListItems Items
        {
            get
            {
                var children = GetChildren();
                return new ListItems(children, this);
            }
        }

        private List<AutomationElement> GetChildren()
        {
            ExpandCollapsePattern expandCollapsePattern;
            var expanded = ExpandListIfNeeded(out expandCollapsePattern);

            var children = Finder.Descendants(AutomationSearchCondition.ByControlType(ControlType.ListItem));

            if (expanded)
            {
                CollapseList(expandCollapsePattern);
            }
            return children;
        }

        private static void CollapseList(ExpandCollapsePattern expandCollapsePattern)
        {
            expandCollapsePattern.Collapse();
            Thread.Sleep(50);
        }

        private bool TryGetExpandCollapsePattern(out ExpandCollapsePattern expandCollapsePattern)
        {
            object pattern;
            if (!AutomationElement.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out pattern))
            {
                expandCollapsePattern = null;
                return false;
            }

            expandCollapsePattern = (ExpandCollapsePattern)pattern;
            return true;
        }

        private static bool IsExpansionRequired
        {
            get { return CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen; }
        }

        private bool ExpandListIfNeeded(out ExpandCollapsePattern expandCollapsePattern)
        {
            if (!IsExpansionRequired || !Enabled)
            {
                expandCollapsePattern = null;
                return false;
            }

            if (!TryGetExpandCollapsePattern(out expandCollapsePattern))
                return false;

            var expansionState = expandCollapsePattern.Current.ExpandCollapseState;
            if (expansionState != ExpandCollapseState.Collapsed)
                return false;

            expandCollapsePattern.Expand();
            Thread.Sleep(50);

            return true;
        }

        public virtual ListItem Item(string itemText)
        {
            return Items.Item(itemText);
        }

        public virtual ListItem Item(int index)
        {
            return Items[index];
        }

        /// <summary>
        /// Selects list item which matches the text.
        /// (For WPF application the lists of objects might require you to provide a ToString override to be selected by text.
        /// The standard ToString method returns the objects type so all objects of the same type will look alike.)
        /// </summary>
        /// <param name="itemText"></param>
        public virtual void Select(string itemText)
        {
            Item(itemText).Select();
        }

        /// <summary>
        /// Selects list item by its index
        /// </summary>
        /// <param name="index"></param>
        public virtual void Select(int index)
        {
            Item(index).Select();
        }

        public virtual string SelectedItemText
        {
            get { return Items.SelectedItemText; }
        }

        public virtual ListItem SelectedItem
        {
            get { return Items.SelectedItem; }
        }

        public override void SetValue(object value)
        {
            Select(value.ToString());
        }

        public override void ActionPerforming(UIItem uiItem)
        {
            var screenItem = new ScreenItem(uiItem, ScrollBars);
            screenItem.MakeVisible(this);
        }

        public virtual VerticalSpan VerticalSpan
        {
            get { return new VerticalSpan(Bounds); }
        }
    }
}