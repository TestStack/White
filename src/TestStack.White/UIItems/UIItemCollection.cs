using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using Castle.Core.Logging;
using White.Core.Configuration;
using White.Core.UIA;
using White.Core.Factory;
using White.Core.Mappings;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems
{
    public class UIItemCollection : List<IUIItem>
    {
        private static readonly DictionaryMappedItemFactory DictionaryMappedItemFactory = new DictionaryMappedItemFactory();
        private readonly ILogger logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(UIItemCollection));

        public UIItemCollection(params UIItem[] uiItems)
        {
            AddRange(uiItems);
        }

        public UIItemCollection(IEnumerable entities) : base(entities.OfType<IUIItem>()) {}

        public UIItemCollection(IEnumerable<AutomationElement> automationElements, ActionListener actionListener)
            : this(automationElements, DictionaryMappedItemFactory, actionListener) {}

        public UIItemCollection(IEnumerable automationElements, ActionListener actionListener)
            : this(automationElements, DictionaryMappedItemFactory, actionListener) {}

        public UIItemCollection(IEnumerable automationElements, UIItemFactory uiItemFactory, ActionListener actionListener)
        {
            foreach (AutomationElement automationElement in automationElements)
            {
                IUIItem uiItem = uiItemFactory.Create(automationElement, actionListener);
                if (uiItem != null) Add(uiItem);
            }
        }

        public UIItemCollection(IEnumerable automationElements, ActionListener actionListener, Type customItemType)
        {
            foreach (AutomationElement automationElement in automationElements)
            {
                try
                {
                    if (!automationElement.IsPrimaryControl()) continue;
                    IUIItem uiItem = DictionaryMappedItemFactory.Create(automationElement, actionListener, customItemType);
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