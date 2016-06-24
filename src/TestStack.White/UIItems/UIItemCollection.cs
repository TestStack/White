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

namespace TestStack.White.UIItems
{
    public class UIItemCollection : List<IUIItem>
    {
        private static readonly DictionaryMappedItemFactory DictionaryMappedItemFactory = new DictionaryMappedItemFactory();
        private readonly ILogger logger = CoreConfigurationLocator.Get().LoggerFactory.Create(typeof(UIItemCollection));

        public UIItemCollection(params UIItem[] uiItems)
        {
            AddRange(uiItems);
        }

        public UIItemCollection(IEnumerable entities) : base(entities.OfType<IUIItem>()) {}

        public UIItemCollection(IEnumerable<AutomationElement> automationElements, IActionListener actionListener)
            : this(automationElements, DictionaryMappedItemFactory, actionListener) {}

        public UIItemCollection(IEnumerable automationElements, IActionListener actionListener)
            : this(automationElements, DictionaryMappedItemFactory, actionListener) {}

        public UIItemCollection(IEnumerable automationElements, IUIItemFactory uiItemFactory, IActionListener actionListener)
        {
            foreach (AutomationElement automationElement in automationElements)
            {
                IUIItem uiItem = uiItemFactory.Create(automationElement, actionListener);
                if (uiItem != null) Add(uiItem);
            }
        }

        public UIItemCollection(IEnumerable automationElements, IActionListener actionListener, Type customItemType)
        {
            foreach (AutomationElement automationElement in automationElements)
            {
                try
                {
                    if (!automationElement.IsPrimaryControl()) continue;
                    var uiItem = DictionaryMappedItemFactory.Create(automationElement, actionListener, customItemType);
                    if (uiItem != null) Add(uiItem);
                }
                catch (ControlDictionaryException)
                {
                    logger.WarnFormat("Couldn't create UIItem for AutomationElement, {0}", automationElement.Display());
                }
            }
        }
    }
}