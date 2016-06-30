// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryMappedItemFactory.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the DictionaryMappedItemFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestStack.White.Factory
{
    using System;
    using System.Windows.Automation;

    using TestStack.White.Mappings;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Actions;

    /// <summary>
    /// The dictionary mapped item factory.
    /// </summary>
    public sealed class DictionaryMappedItemFactory : IUIItemFactory
    {
        /// <summary>
        /// Creates the UI item.
        /// </summary>
        /// <param name="automationElement">
        /// The automation element.
        /// </param>
        /// <param name="actionListener">
        /// The action listener.
        /// </param>
        /// <returns>
        /// The <see cref="IUIItem"/>.
        /// </returns>
        public IUIItem Create(AutomationElement automationElement, IActionListener actionListener)
        {
            if (automationElement == null)
            {
                return null;
            }

            return this.Create(automationElement, ControlDictionary.Instance.GetTestControlType(automationElement), actionListener);
        }

        /// <summary>
        /// Creates the UI item.
        /// </summary>
        /// <param name="automationElement">
        /// The automation element.
        /// </param>
        /// <param name="actionListener">
        /// The action listener.
        /// </param>
        /// <param name="customItemType">
        /// The custom item type.
        /// </param>
        /// <returns>
        /// The <see cref="IUIItem"/>.
        /// </returns>
        public IUIItem Create(AutomationElement automationElement, IActionListener actionListener, Type customItemType)
        {
            if (automationElement == null)
            {
                return null;
            }

            if (customItemType != null)
            {
                return this.Create(automationElement, customItemType, actionListener);
            }

            return this.Create(automationElement, actionListener);
        }

        /// <summary>
        /// Creates the UI item.
        /// </summary>
        /// <param name="automationElement">
        /// The automation element.
        /// </param>
        /// <param name="itemType">
        /// The item type.
        /// </param>
        /// <param name="actionListener">
        /// The action listener.
        /// </param>
        /// <returns>
        /// The <see cref="IUIItem"/>.
        /// </returns>
        private IUIItem Create(AutomationElement automationElement, Type itemType, IActionListener actionListener)
        {
            if (itemType == null)
            {
                return null;
            }

            return (IUIItem)Activator.CreateInstance(itemType, automationElement, actionListener);
        }
    }
}