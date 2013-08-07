using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.Recording;
using TestStack.White.Sessions;
using TestStack.White.UIA;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.Utility;
using Action = TestStack.White.UIItems.Actions.Action;

namespace TestStack.White.UIItems.WindowItems
{
    //TODO support for standard dialog windows
    //TODO Read data from console window, Printer, StartMenu, DateTime, UserProfile, ControlPanel, Desktop
    //TODO Get color of controls
    //TODO Number of display monitors
    //TODO move window
    public abstract class Window : UIItemContainer, IDisposable
    {
        private static readonly Dictionary<DisplayState, WindowVisualState> WindowStates =
            new Dictionary<DisplayState, WindowVisualState>();

        private AutomationEventHandler handler;
        /// <summary>
        /// If a window is opened then you try and close it straight away, the window can fail to close
        /// 
        /// This make sure the window is open for a minimum amount of time
        /// </summary>
        private readonly Task minOpenTime;

        public delegate bool WaitTillDelegate();

        static Window()
        {
            WindowStates.Add(DisplayState.Maximized, WindowVisualState.Maximized);
            WindowStates.Add(DisplayState.Minimized, WindowVisualState.Minimized);
            WindowStates.Add(DisplayState.Restored, WindowVisualState.Normal);
        }

        protected Window()
        {
        }

        protected Window(AutomationElement automationElement, InitializeOption initializeOption, WindowSession windowSession)
            : this(automationElement, new NullActionListener(), initializeOption, windowSession) { }

        protected Window(AutomationElement automationElement, ActionListener actionListener, InitializeOption initializeOption, WindowSession windowSession)
            : base(automationElement, actionListener, initializeOption, windowSession)
        {
            InitializeWindow();
            minOpenTime = Task.Factory.StartNew(() => Thread.Sleep(500));
        }

        private void InitializeWindow()
        {
            ActionPerformed();
            Rect bounds = Desktop.Instance.Bounds;
            if (!bounds.Contains(Bounds) && (TitleBar != null && TitleBar.MinimizeButton != null))
            {
                Logger.WarnFormat(
                    @"Window with title: {0} whose dimensions are: {1}, is not contained completely on the desktop {2}. 
UI actions on window needing mouse would not work in area not falling under the desktop",
                    Title, Bounds, bounds);
            }
            WindowSession.Register(this);
        }

        protected override ActionListener ChildrenActionListener
        {
            get { return this; }
        }

        public virtual string Title
        {
            get { return TitleBar == null ? Name : TitleBar.Title; }
        }

        private WindowPattern WinPattern
        {
            get { return (WindowPattern)Pattern(WindowPattern.Pattern); }
        }

        /// <summary>
        /// Returns true if window available and is on screen. Otherwise 
        /// or if there were errors it returns false.
        /// </summary>
        public virtual bool IsClosed
        {
            get
            {
                try
                {
                    return automationElement.Current.IsOffscreen;
                }
                catch (ElementNotAvailableException)
                {
                    return true;
                }
                catch (InvalidOperationException)
                {
                    return true;
                }
                catch (COMException)
                {
                    return true;
                }
            }
        }

        public virtual void Close()
        {
            minOpenTime.Wait();
            var windowPattern = (WindowPattern)Pattern(WindowPattern.Pattern);
            try
            {
                Logger.DebugFormat("Closing window {0}", Title);
                TitleBar titleBar = TitleBar;
                if (titleBar != null && titleBar.CloseButton != null)
                {
                    Logger.Debug("Using Close Button");
                    titleBar.CloseButton.Click();
                    Logger.Debug("Clicked");
                }
                else if (windowPattern != null)
                {
                    windowPattern.Close();
                    ActionPerformed();
                }
            }
            catch (AutomationException)
            {
                Logger.Debug("Failed, falling back to windowPattern");
                if (windowPattern != null)
                {
                    windowPattern.Close();
                    ActionPerformed();
                }
            }
            catch (ElementNotAvailableException)
            {
                Logger.Debug("Failed, falling back to windowPattern");
                if (windowPattern != null)
                {
                    try
                    {
                        Thread.Sleep(100);
                        windowPattern.Close();
                        ActionPerformed();
                    }
                    catch (ElementNotAvailableException)
                    {

                    }
                }
            }
        }

        public virtual StatusStrip StatusBar(InitializeOption initializeOption)
        {
            var statusStrip = (StatusStrip)Get(SearchCriteria.ByControlType(ControlType.StatusBar));
            statusStrip.Cached = initializeOption;
            statusStrip.Associate(WindowSession);
            return statusStrip;
        }

        public virtual void WaitWhileBusy()
        {
            try
            {
                WaitForProcess();
                WaitForWindow();
                HourGlassWait();
                CustomWait();
            }
            catch (Exception e)
            {
                if (!(e is InvalidOperationException || e is ElementNotAvailableException || e is Win32Exception || e is UnauthorizedAccessException))
                    throw new UIActionException(string.Format("Window didn't respond" + Constants.BusyMessage), e);
            }
        }

        protected static void HourGlassWait()
        {
            if (!CoreAppXmlConfiguration.Instance.WaitBasedOnHourGlass) return;
            try
            {
                Retry.For(() => InputDevices.Mouse.Instance.Cursor,
                          cursor =>
                          {
                              if (MouseCursor.WaitCursors.Contains(cursor))
                              {
                                  if (CoreAppXmlConfiguration.Instance.MoveMouseToGetStatusOfHourGlass)
                                      InputDevices.Mouse.Instance.MoveOut();
                                  return true;
                              }
                              return false;
                          }, CoreAppXmlConfiguration.Instance.BusyTimeout());
            }
            catch (Exception)
            {
                throw new UIActionException(string.Format("Window in still wait mode. Cursor: {0}{1}", InputDevices.Mouse.Instance.Cursor, Constants.BusyMessage));
            }
        }

        /// <exception cref="Exception"></exception>
        /// <exception cref="UIActionException">when window is not responding</exception>
        private void WaitForWindow()
        {
            var windowPattern = (WindowPattern)Pattern(WindowPattern.Pattern);

            if (windowPattern == null) return;
            var finalState = Retry.For(
                () => windowPattern.Current.WindowInteractionState,
                windowState => windowState == WindowInteractionState.NotResponding,
                CoreAppXmlConfiguration.Instance.BusyTimeout());
            if (finalState == WindowInteractionState.NotResponding)
            {
                const string format = "Window didn't come out of WaitState{0} last state known was {1}";
                var message = string.Format(format, Constants.BusyMessage, windowPattern.Current.WindowInteractionState);
                throw new UIActionException(message);
            }
        }

        /// <exception cref="System.ArgumentException">when current process is not available any more (id expired)</exception>
        protected virtual void WaitForProcess()
        {
            Process.GetProcessById(automationElement.Current.ProcessId).WaitForInputIdle();
        }

        public override void ActionPerformed(Action action)
        {
            action.Handle(this);
            ActionPerformed();
        }

        /// <summary>
        /// Get the modal window launched by this window.
        /// </summary>
        /// <param name="title">Title of the modal window</param>
        /// <param name="option">Newly created window would be initialized using this option</param>
        /// <returns></returns>
        public abstract Window ModalWindow(string title, InitializeOption option);

        /// <summary>
        /// Get the modal window launched by this window and it uses InitializeOption as NoCache
        /// </summary>
        /// <param name="title">Title of the modal window</param>
        /// <returns></returns>
        public virtual Window ModalWindow(string title)
        {
            return ModalWindow(title, InitializeOption.NoCache);
        }

        /// <summary>
        /// Get the modal window launched by this window.
        /// </summary>
        /// <param name="searchCriteria">Search Criteria to use to find a window</param>
        /// <param name="option">Newly created window would be initialized using this option</param>
        /// <returns></returns>
        public abstract Window ModalWindow(SearchCriteria searchCriteria, InitializeOption option);

        /// <summary>
        /// Get the modal window launched by this window with NoCache initialize option
        /// </summary>
        /// <param name="searchCriteria">Search Criteria to use to find a window</param>
        /// <returns></returns>
        public virtual Window ModalWindow(SearchCriteria searchCriteria)
        {
            return ModalWindow(searchCriteria, InitializeOption.NoCache);
        }

        public override void Visit(WindowControlVisitor windowControlVisitor)
        {
            windowControlVisitor.Accept(this);
            CurrentContainerItemFactory.Visit(windowControlVisitor);
        }

        /// <summary>
        /// Execute WaitTill with the default timeout from CoreConfiguration (BusyTimeout)
        /// </summary>
        /// <exception cref="UIActionException">when methods reached the timeout</exception>
        public virtual void WaitTill(WaitTillDelegate waitTillDelegate)
        {
            WaitTill(waitTillDelegate, CoreAppXmlConfiguration.Instance.BusyTimeout());
        }

        /// <exception cref="UIActionException">when methods reached the timeout</exception>
        public virtual void WaitTill(WaitTillDelegate waitTillDelegate, TimeSpan timeout)
        {
            if (!Retry.For(() => waitTillDelegate(), timeout, new TimeSpan?()))
                throw new UIActionException("Time out happened" + Constants.BusyMessage);
        }

        public virtual void ReloadIfCached()
        {
            CurrentContainerItemFactory.ReloadIfCached();
        }

        public virtual DisplayState DisplayState
        {
            get
            {
                foreach (var keyValuePair in WindowStates)
                    if (keyValuePair.Value.Equals(WinPattern.Current.WindowVisualState)) return keyValuePair.Key;
                throw new WhiteException("Not in any of the possible states, may be it is closed");
            }
            set
            {
                if (AlreadyInAskedState(value)) return;

                WinPattern.SetWindowVisualState(WindowStates[value]);
                ActionPerformed();
                WindowSession.LocationChanged(this);
                if (AlreadyInAskedState(value) || TitleBar == null) return;

                TitleBar.SetDisplayState(value);
                WindowSession.LocationChanged(this);
            }
        }

        private bool AlreadyInAskedState(DisplayState value)
        {
            return (DisplayState.Maximized == value && !WinPattern.Current.CanMaximize) ||
                   (DisplayState.Minimized == value && !WinPattern.Current.CanMinimize);
        }

        public override void HookEvents(UIItemEventListener eventListener)
        {
            handler = delegate { };
            Automation.AddAutomationEventHandler(AutomationElement.MenuOpenedEvent, automationElement,
                                                 TreeScope.Descendants, handler);
        }

        public override void UnHookEvents()
        {
            Automation.RemoveAutomationEventHandler(AutomationElement.MenuOpenedEvent, automationElement, handler);
        }

        public override string ToString()
        {
            return Title;
        }

        public virtual void Dispose()
        {
            Close();
        }

        /// <summary>
        /// Get the MessageBox window launched by this window
        /// </summary>
        /// <param name="title">Title of the messagebox</param>
        /// <returns></returns>
        public virtual Window MessageBox(string title)
        {
            Window window = factory.ModalWindow(title, InitializeOption.NoCache, WindowSession.ModalWindowSession(InitializeOption.NoCache));
            window.actionListener = this;
            return window;
        }

        public override ActionListener ActionListener
        {
            get { return this; }
        }

        public virtual void Focus(DisplayState displayState)
        {
            DisplayState = displayState;
            base.Focus();
        }

        public virtual TitleBar TitleBar
        {
            get { return factory.GetTitleBar(this); }
        }

        public virtual bool IsModal
        {
            get { return WinPattern.Current.IsModal; }
        }

        //TODO: Position based find should understand MdiChild
        /// <summary>
        /// Returns a UIItemContainer using which other sub-ui items can be retrieved.
        /// Since there is no single standard identification for MdiChild windows, hence it is has been left open for user.
        /// </summary>
        /// <param name="searchCriteria"></param>
        /// <returns></returns>
        public virtual UIItemContainer MdiChild(SearchCriteria searchCriteria)
        {
            var finder = new AutomationElementFinder(automationElement);
            AutomationElement element = finder.Descendant(searchCriteria.AutomationCondition);
            return element == null ? null : new UIItemContainer(element, this, InitializeOption.NoCache, WindowSession);
        }

        public override VerticalSpan VerticalSpan
        {
            get { return new VerticalSpan(Bounds).Minus(ScrollBars.Horizontal.Bounds); }
        }

        /// <summary>
        /// Recursively gets all the descendant windows.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UIItemSearchException">The application type is not supported by White</exception> // from ChildWindowFactory.Create
        public virtual List<Window> ModalWindows()
        {
            var finder = new AutomationElementFinder(automationElement);
            var descendants = finder.Descendants(AutomationSearchCondition.ByControlType(ControlType.Window));
            return descendants
                .Select(descendant => ChildWindowFactory.Create(descendant, InitializeOption.NoCache, WindowSession.ModalWindowSession(InitializeOption.NoCache)))
                .ToList();
        }

        public abstract PopUpMenu Popup { get; }

        /// <summary>
        /// This should be used after RightClick on a UIItem (which can be window as well).
        /// </summary>
        /// <param name="path">Path to the menu which need to be retrieved.
        /// e.g. "Root" is one of the menus in the first level, "Level1" is inside "Root" menu and "Level2" is inside "Level1". So on.
        /// "Root", etc are text of the menu visible to user.
        /// </param>
        /// <returns></returns>
        public virtual Menu PopupMenu(params string[] path)
        {
            return Popup.Item(path);
        }

        public virtual bool HasPopup()
        {
            return Popup != null;
        }

        /// <summary>
        /// Tells whether the window is currently the topmost window. CAUTION: For Non-WPF applications it might perform poorly if there are a lot of controls
        /// in the window.
        /// </summary>
        /// <returns>true if topmost</returns>
        public virtual bool IsCurrentlyActive
        {
            get
            {
                AutomationElementCollection allElements =
                    automationElement.FindAll(TreeScope.Descendants | TreeScope.Element, Condition.TrueCondition);
                return
                    allElements.Contains(
                        element =>
                        element.Current.HasKeyboardFocus && !element.Current.ControlType.Equals(ControlType.Custom));
            }
        }
    }
}