using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Automation;
using Bricks.Core;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.Factory;
using White.Core.Logging;
using White.Core.Recording;
using White.Core.Sessions;
using White.Core.UIA;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;
using White.Core.UIItems.MenuItems;
using White.Core.UIItems.WindowStripControls;
using Action=White.Core.UIItems.Actions.Action;
using Condition=System.Windows.Automation.Condition;

namespace White.Core.UIItems.WindowItems
{
    //TODO support for standard dialog windows
    //TODO Read data from console window, Printer, StartMenu, DateTime, UserProfile, ControlPanel, Desktop
    //TODO Get color of controls
    //TODO Number of display monitors
    //TODO move window
    public abstract class Window : UIItemContainer, IDisposable
    {
        private static readonly Dictionary<DisplayState, WindowVisualState> windowStates =
            new Dictionary<DisplayState, WindowVisualState>();

        private AutomationEventHandler handler;

        public delegate bool WaitTillDelegate();

        static Window()
        {
            windowStates.Add(DisplayState.Maximized, WindowVisualState.Maximized);
            windowStates.Add(DisplayState.Minimized, WindowVisualState.Minimized);
            windowStates.Add(DisplayState.Restored, WindowVisualState.Normal);
        }

        protected Window()
        {
        }

        protected Window(AutomationElement automationElement, InitializeOption initializeOption,
                         WindowSession windowSession)
            : base(automationElement, new NullActionListener(), initializeOption, windowSession)
        {
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            ActionPerformed();
            Rect bounds = Desktop.Instance.Bounds;
            if (!bounds.Contains(Bounds) && (TitleBar != null && TitleBar.MinimizeButton != null))
            {
                WhiteLogger.Instance.WarnFormat(
                    @"Window with title: {0} whose dimensions are: {1}, is not contained completely on the desktop {2}. 
UI actions on window needing mouse would not work in area not falling under the desktop",
                    Title, Bounds, bounds);
            }
            windowSession.Register(this);
        }

        protected override ActionListener ChildrenActionListener
        {
            get { return this; }
        }

        public virtual string Title
        {
            get { return TitleBar == null ? Name : TitleBar.Name; }
        }

        private WindowPattern WinPattern
        {
            get { return (WindowPattern) Pattern(WindowPattern.Pattern); }
        }

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
            var windowPattern = (WindowPattern) Pattern(WindowPattern.Pattern);
            try
            {
                if (windowPattern == null && TitleBar != null && TitleBar.CloseButton != null)
                    TitleBar.CloseButton.Click();
                else if (windowPattern != null)
                {
                    windowPattern.Close();
                    ActionPerformed();
                }
            }
            catch (ElementNotAvailableException)
            {
            }
        }

        public virtual StatusStrip StatusBar(InitializeOption initializeOption)
        {
            var statusStrip = (StatusStrip) Get(SearchCriteria.ByControlType(ControlType.StatusBar));
            statusStrip.Cached = initializeOption;
            statusStrip.Associate(windowSession);
            return statusStrip;
        }

        public virtual void WaitWhileBusy()
        {
            WaitForProcess();
            WaitForWindow();
        }

        private void WaitForWindow()
        {
            try
            {
                WaitForProcess();
                var windowPattern = (WindowPattern) Pattern(WindowPattern.Pattern);
                if (!CoreAppXmlConfiguration.Instance.InProc &&
                    !("ConsoleWindowClass".Equals(automationElement.Current.ClassName)) &&
                    (windowPattern != null &&
                     !windowPattern.WaitForInputIdle(CoreAppXmlConfiguration.Instance.BusyTimeout)))
                    throw new Exception(string.Format("Timeout occured{0}", Constants.BusyMessage));
                if (windowPattern == null) return;
                var clock = new Clock(CoreAppXmlConfiguration.Instance.BusyTimeout, 0);
                clock.RunWhile(() => Thread.Sleep(50),
                               () =>
                               windowPattern.Current.WindowInteractionState.Equals(WindowInteractionState.NotResponding),
                               delegate
                                   {
                                       throw new UIActionException(
                                           string.Format(
                                               "Window didn't come out of WaitState{0} last state known was {1}",
                                               Constants.BusyMessage, windowPattern.Current.WindowInteractionState));
                                   });
            }
            catch (Exception e)
            {
                if (!(e is InvalidOperationException || e is ElementNotAvailableException))
                    throw new UIActionException(string.Format("Window didn't respond" + Constants.BusyMessage), e);
            }
        }

        private void WaitForProcess()
        {
            try
            {
                Process.GetProcessById(automationElement.Current.ProcessId).WaitForInputIdle();
            }
            catch
            {
            }
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
            currentContainerItemFactory.Visit(windowControlVisitor);
        }

        public virtual void WaitTill(WaitTillDelegate waitTillDelegate)
        {
            var clock = new Clock(CoreAppXmlConfiguration.Instance.BusyTimeout);
            clock.Perform(() => waitTillDelegate(), obj => obj.Equals(true),
                          delegate { throw new UIActionException("Time out happened" + Constants.BusyMessage); });
        }

        public virtual void ReloadIfCached()
        {
            currentContainerItemFactory.ReloadIfCached();
        }

        public virtual DisplayState DisplayState
        {
            get
            {
                foreach (var keyValuePair in windowStates)
                    if (keyValuePair.Value.Equals(WinPattern.Current.WindowVisualState)) return keyValuePair.Key;
                throw new WhiteException("Not in any of the possible states, may be it is closed");
            }
            set
            {
                if (AlreadyInAskedState(value)) return;

                WinPattern.SetWindowVisualState(windowStates[value]);
                ActionPerformed();

                if (AlreadyInAskedState(value) || TitleBar == null) return;

                TitleBar.SetDisplayState(value);
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
            Window window = factory.ModalWindow(title, InitializeOption.NoCache,
                                                windowSession.ModalWindowSession(InitializeOption.NoCache));
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
            return element == null ? null : new UIItemContainer(element, this, InitializeOption.NoCache, windowSession);
        }

        public override VerticalSpan VerticalSpan
        {
            get { return new VerticalSpan(Bounds).Minus(ScrollBars.Horizontal.Bounds); }
        }

        /// <summary>
        /// Recursively gets all the descendant windows.
        /// </summary>
        /// <returns></returns>
        public virtual List<Window> ModalWindows()
        {
            var modalWindows = new List<Window>();
            var finder = new AutomationElementFinder(automationElement);
            AutomationElementCollection descendants =
                finder.Descendants(AutomationSearchCondition.ByControlType(ControlType.Window));
            foreach (AutomationElement descendant in descendants)
                modalWindows.Add(ChildWindowFactory.Create(descendant, InitializeOption.NoCache,
                                                           windowSession.ModalWindowSession(InitializeOption.NoCache)));
            return modalWindows;
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