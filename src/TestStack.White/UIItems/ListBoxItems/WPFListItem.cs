// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WPFListItem.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the WPFListItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestStack.White.UIItems.ListBoxItems
{
    using System.Windows.Automation;

    using TestStack.White.AutomationElementSearch;
    using TestStack.White.UIItems.Actions;
    using TestStack.White.UIItems.Finders;

    /// <summary>
    /// The WPF list item.
    /// </summary>
    [PlatformSpecificItem]
    public class WPFListItem : ListItem
    {
        /// <summary>
        /// The finder.
        /// </summary>
        private readonly AutomationElementFinder finder;

        /// <summary>
        /// Initializes a new instance of the <see cref="WPFListItem"/> class.
        /// </summary>
        protected WPFListItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WPFListItem"/> class.
        /// </summary>
        /// <param name="automationElement">The automation element.</param>
        /// <param name="actionListener">The action listener.</param>
        public WPFListItem(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener)
        {
            finder = new AutomationElementFinder(automationElement);
        }

        /// <summary>
        /// Gets the checked status.
        /// </summary>
        public override bool Checked => this.CheckBox.Checked;

        /// <summary>
        /// Checks the item.
        /// </summary>
        public override void Check()
        {
            if (!Checked)
            {
                CheckBox.Click();
            }
        }

        /// <summary>
        /// Unchecks the item.
        /// </summary>
        public override void UnCheck()
        {
            if (Checked)
            {
                CheckBox.Click();
            }
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        public override string Text
        {
            get
            {
                var element = this.finder.FindChildRaw(AutomationSearchCondition.ByControlType(ControlType.Text));
                if (element == null)
                {
                    return base.Text;
                }

                return element.Current.Name;
            }
        }

        /// <summary>
        /// Gets the check box.
        /// </summary>
        private CheckBox CheckBox => (CheckBox)this.factory.Create(SearchCriteria.ByControlType(ControlType.CheckBox), this.actionListener);
    }
}