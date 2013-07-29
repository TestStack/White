using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Automation;
using Castle.DynamicProxy;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.Interceptors;
using TestStack.White.Sessions;
using TestStack.White.UIA;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Container;
using TestStack.White.UIItems.Custom;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.Scrolling;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.Utility;

namespace TestStack.White.UIItems
{
    //BUG: Allow finding more than one item, also ability to do this within a container
    //TODO: Dont let people compile code is they are trying to find UIItem which are secondary or window
    public class UIItemContainer : UIItem, IUIItemContainer, VerticalSpanProvider
    {
        protected readonly CurrentContainerItemFactory CurrentContainerItemFactory;
        protected WindowSession WindowSession = new NullWindowSession();

        protected UIItemContainer()
        {
        }

        public UIItemContainer(AutomationElement automationElement, ActionListener actionListener,
                               InitializeOption initializeOption,
                               WindowSession windowSession) : base(automationElement, actionListener)
        {
            WindowSession = windowSession;
            CurrentContainerItemFactory = new CurrentContainerItemFactory(factory, initializeOption, automationElement, ChildrenActionListener);
        }

        public UIItemContainer(AutomationElement automationElement, ActionListener actionListener)
            : this(automationElement, actionListener, InitializeOption.NoCache, new NullWindowSession())
        {
        }

        public virtual T Get<T>() where T : IUIItem
        {
            return Get<T>(SearchCriteria.All);
        }

        public virtual T Get<T>(string primaryIdentification) where T : IUIItem
        {
            return Get<T>(SearchCriteria.ByAutomationId(primaryIdentification));
        }

        public virtual T Get<T>(SearchCriteria searchCriteria) where T : IUIItem
        {
            return (T) Get(searchCriteria.AndControlType(typeof (T), Framework));
        }

        public virtual IUIItem Get(SearchCriteria searchCriteria)
        {
            return Get(searchCriteria, CoreAppXmlConfiguration.Instance.BusyTimeout());
        }

        /// <summary>
        /// Finds UIItem which matches specified type and searchCriteria. Look at documentation of SearchCriteria for details on it.
        /// </summary>
        /// <param name="searchCriteria">Criteria provided to search IUIItem</param>
        /// <param name="timeout">Time to wait for item to come on-screen before returning off-screen element, if found.</param>
        /// <returns>First items matching the criteria</returns>
        /// <exception cref="AutomationException">when item not found</exception>
        /// <exception cref="WhiteException">when any errors occured during search</exception>
        public virtual IUIItem Get(SearchCriteria searchCriteria, TimeSpan timeout)
        {
            try
            {
                var uiItem = Retry.For(() =>
                    CurrentContainerItemFactory.Find(searchCriteria, WindowSession),
                    b =>(bool)b.AutomationElement.GetCurrentPropertyValue(AutomationElement.IsOffscreenProperty, false),
                    timeout);

                if (uiItem == null)
                {
                    var debugDetails = Debug.Details(automationElement);
                    throw new AutomationException(string.Format("Failed to get {0}", searchCriteria), debugDetails);
                }

                HandleIfCustomUIItem(uiItem);
                HandleIfUIItemContainer(uiItem);
                return uiItem;
            }
            catch (AutomationException)
            {
                throw;
            }
            catch (Exception e)
            {
                var debugDetails = Debug.Details(automationElement);

                throw new WhiteException(string.Format("Error occured while geting {0}", searchCriteria), debugDetails, e);
            }
        }

        private void HandleIfUIItemContainer(IUIItem uiItem)
        {
            var uiItemContainer = uiItem as UIItemContainer;
            if (uiItemContainer == null) return;
            uiItemContainer.Associate(WindowSession);
        }

        private void HandleIfCustomUIItem(IUIItem uiItem)
        {
            var customUIItem = uiItem as CustomUIItem;
            if (customUIItem == null) return;
            FieldInfo interceptorField = customUIItem.GetType().GetField("__interceptors",
                                                                         BindingFlags.NonPublic | BindingFlags.Public |
                                                                         BindingFlags.Instance);
            var interceptors = (IInterceptor[]) interceptorField.GetValue(customUIItem);
            var realCustomUIItem = (CustomUIItem) ((CoreInterceptor) interceptors[0]).Context.UiItem;
            realCustomUIItem.SetContainer(new UIItemContainer(customUIItem.AutomationElement, ChildrenActionListener,
                                                              InitializeOption.NoCache, WindowSession));
        }

        /// <summary>
        /// Applicable only if CacheMode is used. This is for internal purpose of white and should not be used, as caching by itself is not supported
        /// </summary>
        /// <param name="option"></param>
        public virtual void ReInitialize(InitializeOption option)
        {
            CurrentContainerItemFactory.ReInitialize(option);
        }

        protected virtual ActionListener ChildrenActionListener
        {
            get { return HasActionInterceptionBehaviour() ? this : actionListener; }
        }

        private bool HasActionInterceptionBehaviour()
        {
            return ScrollBars.CanScroll;
        }

        //BUG: Try this method out with all windows on the desktop and see if it works
        /// <summary>
        /// Returns a list of UIItems contained in the container/window. This is not the same as AutomationElements because white needs to translate
        /// AutomationElements to UIItem. Hence for certain AE there might not be corresponding UIItem type.
        /// </summary>
        public virtual UIItemCollection Items
        {
            get { return CurrentContainerItemFactory.FindAll(); }
        }

        /// <summary>
        /// Returns a keyboard which is associated to this window. Any operation performed using the mouse would wait till the window is busy after this
        /// operation. Before any operation is performed the window is brought to focus.
        /// </summary>
        public virtual AttachedKeyboard Keyboard
        {
            get { return new AttachedKeyboard(this, keyboard); }
        }

        /// <summary>
        /// Returns a mouse which is associated to this window. Any operation performed using the mouse would wait till the window is busy after this
        /// operation. Before any operation is performed the window is brought to focus.
        /// </summary>
        public virtual AttachedMouse Mouse
        {
            get { return new AttachedMouse(mouse, this); }
        }

        public virtual IUIItem[] GetMultiple(SearchCriteria criteria)
        {
            return CurrentContainerItemFactory.FindAll(criteria).ToArray();
        }

        internal virtual void Associate(WindowSession session)
        {
            WindowSession = session;
        }

        public virtual VerticalSpan VerticalSpan
        {
            get { return new VerticalSpan(Bounds); }
        }

        public override void ActionPerforming(UIItem uiItem)
        {
            Focus();
            var screenItem = new ScreenItem(uiItem, ScrollBars);
            screenItem.MakeVisible(this);
        }

        public virtual MenuBar MenuBar
        {
            get { return (MenuBar) Get(SearchCriteria.ForMenuBar(Framework)); }
        }

        public virtual MenuBar GetMenuBar(SearchCriteria searchCriteria)
        {
            return (MenuBar) Get(SearchCriteria.ForMenuBar(Framework).Merge(searchCriteria));
        }

        public virtual List<MenuBar> MenuBars
        {
            get { return new List<MenuBar>(GetMultiple(SearchCriteria.ForMenuBar(Framework)).OfType<MenuBar>()); }
        }

        public virtual ToolTip ToolTip
        {
            get { return factory.ToolTip; }
        }

        public virtual ToolTip GetToolTipOn(UIItem uiItem)
        {
            Mouse.Location = uiItem.Bounds.Center();
            uiItem.Focus(); 
            return ToolTip;
        }

        public virtual ToolStrip ToolStrip
        {
            get
            {
                Focus();
                return (ToolStrip) Get(SearchCriteria.ByControlType(ControlType.ToolBar));
            }
        }

        public virtual List<Tab> Tabs
        {
            get { return CurrentContainerItemFactory.FindAll<Tab>(); }
        }

        public virtual ToolStrip GetToolStrip(string primaryIdentification)
        {
            var toolStrip = (ToolStrip) Get(SearchCriteria.ByAutomationId(primaryIdentification));
            if (toolStrip == null) return null;
            toolStrip.Associate(WindowSession);
            return toolStrip;
        }

        /// <summary>
        /// Find all the UIItems which belongs to a window and are within (bounds of) another UIItem.
        /// </summary>
        /// <param name="containingItem">Containing item</param>
        /// <returns>List of all the items.</returns>
        public virtual List<UIItem> ItemsWithin(UIItem containingItem)
        {
            UIItemCollection itemsWithin = factory.ItemsWithin(containingItem.Bounds, this);
            return itemsWithin.Where(item => !item.Equals(containingItem)).Cast<UIItem>().ToList();
        }

        protected virtual void CustomWait()
        {
            if (CoreAppXmlConfiguration.Instance.AdditionalWaitHook != null)
            {
                CoreAppXmlConfiguration.Instance.AdditionalWaitHook.WaitFor(this);
            }
        }
    }
}