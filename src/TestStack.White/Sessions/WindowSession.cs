using System;
using System.Windows;
using System.Windows.Automation;
using Castle.Core.Logging;
using White.Core.Configuration;
using White.Core.Factory;
using White.Core.ScreenMap;
using White.Core.UIA;
using White.Core.UIItems;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Container;
using White.Core.UIItems.Finders;
using Window=White.Core.UIItems.WindowItems.Window;

namespace White.Core.Sessions
{
    public class WindowSession : IDisposable
    {
        private readonly ApplicationSession applicationSession;
        private readonly WindowItemsMap windowItemsMap;
        private readonly InitializeOption initializeOption;
        private readonly ILogger logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(WindowSession));

        public WindowSession(ApplicationSession applicationSession, InitializeOption initializeOption)
        {
            this.applicationSession = applicationSession;
            windowItemsMap = WindowItemsMap.Create(initializeOption, RectX.UnlikelyWindowPosition);
            if (windowItemsMap.LoadedFromFile) initializeOption.NonCached();
            this.initializeOption = initializeOption;
        }

        protected WindowSession() {}

        public virtual WindowSession ModalWindowSession(InitializeOption modalInitializeOption)
        {
            return applicationSession.WindowSession(modalInitializeOption);
        }

        public virtual IUIItem Get(ContainerItemFactory containerItemFactory, SearchCriteria searchCriteria, ActionListener actionListener)
        {
            logger.DebugFormat("Finding item based on criteria: ({0}) on ({1})", searchCriteria, initializeOption.Identifier);
            Point location = windowItemsMap.GetItemLocation(searchCriteria);
            if (location.Equals(RectX.UnlikelyWindowPosition))
            {
                logger.Debug("[PositionBasedSearch] Could not find based on position, finding using search.");
                return Create(containerItemFactory, searchCriteria, actionListener);
            }

            AutomationElement automationElement = AutomationElementX.GetAutomationElementFromPoint(location);
            if (automationElement != null && searchCriteria.AppliesTo(automationElement))
            {
                IUIItem item = new DictionaryMappedItemFactory().Create(automationElement, actionListener, searchCriteria.CustomItemType);
                return UIItemProxyFactory.Create(item, actionListener);
            }

            logger.DebugFormat("[PositionBasedSearch] UIItem {0} changed its position, finding using search.", searchCriteria);
            return Create(containerItemFactory, searchCriteria, actionListener);
        }

        private IUIItem Create(ContainerItemFactory containerItemFactory, SearchCriteria searchCriteria, ActionListener actionListener)
        {
            IUIItem item = containerItemFactory.Get(searchCriteria, actionListener);
            if (item == null) return null;
            windowItemsMap.Add(item.Location, searchCriteria);
            return item;
        }

        public virtual void Dispose()
        {
            windowItemsMap.Save();
        }

        public virtual void Register(Window window)
        {
            window.Focus();
            LocationChanged(window);
        }

        public virtual void LocationChanged(Window window)
        {
            windowItemsMap.CurrentWindowPosition = window.Location;
        }
    }
}