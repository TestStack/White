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
    public class UIItemContainer : UIItem, IUIItemContainer, IVerticalSpanProvider
    {
        protected readonly CurrentContainerItemFactory CurrentContainerItemFactory;
        protected WindowSession WindowSession = new NullWindowSession();

        #region Constructor

        protected UIItemContainer()
        {
        }

        public UIItemContainer(AutomationElement automationElement, IActionListener actionListener,
            InitializeOption initializeOption,
            WindowSession windowSession) : base(automationElement, actionListener)
        {
            WindowSession = windowSession;
            CurrentContainerItemFactory = new CurrentContainerItemFactory(factory, initializeOption, automationElement,
                ChildrenActionListener);
        }

        public UIItemContainer(AutomationElement automationElement, IActionListener actionListener)
            : this(automationElement, actionListener, InitializeOption.NoCache, new NullWindowSession())
        {
        }

        #endregion
        
        /// <summary>
        /// Implements <see cref="IUIItemContainer.ToolTip" />
        /// </summary>
        public virtual ToolTip ToolTip
        {
            get { return factory.ToolTip; }
        }

        /// <summary>
        /// Implements <see cref="IUIItemContainer.GetToolTipOn" />
        /// </summary>
        public virtual ToolTip GetToolTipOn(IUIItem uiItem)
        {
            Mouse.Location = uiItem.Bounds.Center();
            uiItem.Focus();
            return ToolTip;
        }

        #region Get UI Item

        /// <summary>
        /// Implements <see cref="IUIItemContainer.Get{T}()" />
        /// </summary>
        public virtual T Get<T>() where T : IUIItem
        {
            return Get<T>(SearchCriteria.All);
        }

        /// <summary>
        /// Implements <see cref="IUIItemContainer.Get{T}(string)" />
        /// </summary>
        public virtual T Get<T>(string primaryIdentification) where T : IUIItem
        {
            return Get<T>(SearchCriteria.ByAutomationId(primaryIdentification));
        }

        /// <summary>
        /// Implements <see cref="IUIItemContainer.Get{T}(SearchCriteria)" />
        /// </summary>
        public virtual T Get<T>(SearchCriteria searchCriteria) where T : IUIItem
        {
            return (T) Get(searchCriteria.AndControlType(typeof (T), Framework));
        }

        /// <summary>
        /// Implements <see cref="IUIItemContainer.Get(SearchCriteria)" />
        /// </summary>
        public virtual IUIItem Get(SearchCriteria searchCriteria)
        {
            return Get(searchCriteria, CoreAppXmlConfiguration.Instance.BusyTimeout());
        }

        /// <summary>
        /// Implements <see cref="IUIItemContainer.Get(SearchCriteria, TimeSpan)" />
        /// </summary>
        public virtual IUIItem Get(SearchCriteria searchCriteria, TimeSpan busyTimeout)
        {
            try
            {
                var uiItem = Retry.For(() =>
                    CurrentContainerItemFactory.Find(searchCriteria, WindowSession),
                    b =>
                        (bool) b.AutomationElement.GetCurrentPropertyValue(AutomationElement.IsOffscreenProperty, false),
                    busyTimeout);

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
                throw new WhiteException(string.Format("Error occurred while getting {0}", searchCriteria), debugDetails,
                    e);
            }
        }

        #endregion

        #region Get UI Items

        /// <summary>
        /// Implements <see cref="IUIItemContainer.GetMultiple()" />
        /// </summary>
        public virtual IUIItem[] GetMultiple()
        {
            return GetMultiple(SearchCriteria.All);
        }

        /// <summary>
        /// Implements <see cref="IUIItemContainer.GetMultiple(SearchCriteria)" />
        /// </summary>
        public virtual IUIItem[] GetMultiple(SearchCriteria criteria)
        {
            return CurrentContainerItemFactory.FindAll(criteria).ToArray();
        }

        /// <summary>
        /// Implements <see cref="IUIItemContainer.GetMultiple{T}()" />
        /// </summary>
        public virtual T[] GetMultiple<T>() where T : IUIItem
        {
            return GetMultiple<T>(SearchCriteria.All);
        }

        /// <summary>
        /// Implements <see cref="IUIItemContainer.GetMultiple{T}(SearchCriteria)" />
        /// </summary>
        public virtual T[] GetMultiple<T>(SearchCriteria searchCriteria) where T : IUIItem
        {
            var items = GetMultiple(searchCriteria.AndControlType(typeof(T), Framework));
            return items.Select(item => (T)item).Where(cast => cast != null).ToArray();
        }

        #endregion

        #region UI Item Exists

        /// <summary>
        /// Implements <see cref="IUIItemContainer.Exists{T}()" />
        /// </summary>
        public virtual bool Exists<T>() where T : IUIItem
        {
            return Exists<T>(SearchCriteria.All);
        }

        /// <summary>
        /// Implements <see cref="IUIItemContainer.Exists{T}(string)" />
        /// </summary>
        public virtual bool Exists<T>(string primaryIdentification) where T : IUIItem
        {
            return Exists<T>(SearchCriteria.ByAutomationId(primaryIdentification));
        }

        /// <summary>
        /// Implements <see cref="IUIItemContainer.Exists{T}(SearchCriteria)" />
        /// </summary>
        public virtual bool Exists<T>(SearchCriteria searchCriteria) where T : IUIItem
        {
            return Exists(searchCriteria.AndControlType(typeof(T), Framework));
        }

        /// <summary>
        /// Implements <see cref="IUIItemContainer.Exists{SearchCriteria}()" />
        /// </summary>
        public virtual bool Exists(SearchCriteria searchCriteria)
        {
            try
            {
                Get(searchCriteria, TimeSpan.FromMilliseconds(0));
                return true;
            }
            catch (AutomationException)
            {
                return false;
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// Returns a list of UIItems contained in the container/window. 
        /// This is not the same as AutomationElements because white needs to translate AutomationElements to UIItem. 
        /// Hence for certain AE there might not be corresponding UIItem type.
        /// </summary>
        public virtual UIItemCollection Items
        {
            get { return CurrentContainerItemFactory.FindAll(); }
        }

        /// <summary>
        /// Returns a keyboard which is associated to this window. 
        /// Any operation performed using the mouse would wait till the window is busy after this operation. 
        /// Before any operation is performed the window is brought to focus.
        /// </summary>
        public virtual AttachedKeyboard Keyboard
        {
            get { return new AttachedKeyboard(this, keyboard); }
        }

        /// <summary>
        /// Returns a mouse which is associated to this window. 
        /// Any operation performed using the mouse would wait till the window is busy after this operation. 
        /// Before any operation is performed the window is brought to focus.
        /// </summary>
        public virtual AttachedMouse Mouse
        {
            get { return new AttachedMouse(mouse, this); }
        }

        public virtual MenuBar MenuBar
        {
            get { return (MenuBar) Get(SearchCriteria.ForMenuBar(Framework)); }
        }

        public virtual List<MenuBar> MenuBars
        {
            get { return new List<MenuBar>(GetMultiple(SearchCriteria.ForMenuBar(Framework)).OfType<MenuBar>()); }
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

        /// <summary>
        /// Overrides <see cref="UIItem.ActionPerforming"/>
        /// </summary>
        /// <param name="uiItem"></param>
        public override void ActionPerforming(UIItem uiItem)
        {
            Focus();
            var screenItem = new ScreenItem(uiItem, ScrollBars);
            screenItem.MakeVisible(this);
        }

        /// <summary>
        /// Implements <see cref="IVerticalSpanProvider.VerticalSpan"/>
        /// </summary>
        public virtual VerticalSpan VerticalSpan
        {
            get { return new VerticalSpan(Bounds); }
        }

        /// <summary>
        /// Applicable only if CacheMode is used. 
        /// This is for internal purpose of white and should not be used, 
        /// as caching by itself is not supported
        /// </summary>
        /// <param name="option"></param>
        public virtual void ReInitialize(InitializeOption option)
        {
            CurrentContainerItemFactory.ReInitialize(option);
        }

        public virtual MenuBar GetMenuBar(SearchCriteria searchCriteria)
        {
            return (MenuBar) Get(SearchCriteria.ForMenuBar(Framework).Merge(searchCriteria));
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
            var itemsWithin = factory.ItemsWithin(containingItem.Bounds, this);
            return itemsWithin.Where(item => !item.Equals(containingItem)).Cast<UIItem>().ToList();
        }

        #endregion

        #region Private

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
            var interceptorField = customUIItem.GetType().GetField("__interceptors",
                BindingFlags.NonPublic | BindingFlags.Public |
                BindingFlags.Instance);
            var interceptors = (IInterceptor[]) interceptorField.GetValue(customUIItem);
            var realCustomUIItem = (CustomUIItem) ((CoreInterceptor) interceptors[0]).Context.UiItem;
            realCustomUIItem.SetContainer(new UIItemContainer(customUIItem.AutomationElement, ChildrenActionListener,
                InitializeOption.NoCache, WindowSession));
        }

        private bool HasActionInterceptionBehaviour()
        {
            return ScrollBars.CanScroll;
        }

        #endregion

        #region Protected

        protected virtual IActionListener ChildrenActionListener
        {
            get { return HasActionInterceptionBehaviour() ? this : actionListener; }
        }

        protected virtual void CustomWait()
        {
            if (CoreAppXmlConfiguration.Instance.AdditionalWaitHook != null)
            {
                CoreAppXmlConfiguration.Instance.AdditionalWaitHook.WaitFor(this);
            }
        }

        #endregion

        #region Internal

        //BUG: Try this method out with all windows on the desktop and see if it works
        internal virtual void Associate(WindowSession session)
        {
            WindowSession = session;
        }

        #endregion
    }
}
