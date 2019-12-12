// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UIItemCollection.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the UIItemCollection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestStack.White.UIItems
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Automation;

    using Castle.Core.Logging;

    using TestStack.White.Configuration;
    using TestStack.White.Factory;
    using TestStack.White.Mappings;
    using TestStack.White.UIA;
    using TestStack.White.UIItems.Actions;

    /// <summary>
    /// The UI item collection.
    /// </summary>
    public class UIItemCollection : List<IUIItem>
    {
        /// <summary>
        /// The dictionary mapped item factory.
        /// </summary>
        private static readonly DictionaryMappedItemFactory DictionaryMappedItemFactory = new DictionaryMappedItemFactory();

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(UIItemCollection));

        /// <summary>
        /// Initializes a new instance of the <see cref="UIItemCollection"/> class.
        /// </summary>
        /// <param name="uiItems">The UI Items.</param>
        public UIItemCollection(params UIItem[] uiItems)
        {
            this.AddRange(uiItems);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIItemCollection"/> class.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public UIItemCollection(IEnumerable entities)
            : base(entities.OfType<IUIItem>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIItemCollection"/> class.
        /// </summary>
        /// <param name="automationElements">
        /// The automation elements.
        /// </param>
        /// <param name="actionListener">
        /// The action listener.
        /// </param>
        public UIItemCollection(IEnumerable<AutomationElement> automationElements, IActionListener actionListener)
            : this(automationElements, DictionaryMappedItemFactory, actionListener)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIItemCollection"/> class.
        /// </summary>
        /// <param name="automationElements">
        /// The automation elements.
        /// </param>
        /// <param name="actionListener">
        /// The action listener.
        /// </param>
        public UIItemCollection(IEnumerable automationElements, IActionListener actionListener)
            : this(automationElements, DictionaryMappedItemFactory, actionListener)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIItemCollection"/> class.
        /// </summary>
        /// <param name="automationElements">
        /// The automation elements.
        /// </param>
        /// <param name="uiItemFactory">
        /// The UI Item factory.
        /// </param>
        /// <param name="actionListener">
        /// The action listener.
        /// </param>
        public UIItemCollection(IEnumerable automationElements, IUIItemFactory uiItemFactory, IActionListener actionListener)
        {
            foreach (AutomationElement automationElement in automationElements)
            {
                var uiItem = uiItemFactory.Create(automationElement, actionListener);
                if (uiItem != null)
                {
                    this.Add(uiItem);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIItemCollection"/> class.
        /// </summary>
        /// <param name="automationElements">
        /// The automation elements.
        /// </param>
        /// <param name="actionListener">
        /// The action listener.
        /// </param>
        /// <param name="customItemType">
        /// The custom item Type.
        /// </param>
        public UIItemCollection(IEnumerable automationElements, IActionListener actionListener, Type customItemType)
        {
            foreach (AutomationElement automationElement in automationElements)
            {
                try
                {
                    if (!automationElement.IsPrimaryControl())
                    {
                        continue;
                    }

                    var uiItem = DictionaryMappedItemFactory.Create(automationElement, actionListener, customItemType);
                    if (uiItem != null)
                    {
                        this.Add(uiItem);
                    }
                }
                catch (ControlDictionaryException)
                {
                    this.logger.WarnFormat("Couldn't create UIItem for AutomationElement, {0}", automationElement.Display());
                }
            }
        }
    }
}