using Castle.Core.Logging;
using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.Recording;
using TestStack.White.UIA;
using TestStack.White.UIItemEvents;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.Scrolling;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using Action = TestStack.White.UIItems.Actions.Action;
using Point = System.Windows.Point;

namespace TestStack.White.UIItems
{
    //TODO Make this class smaller
    //TODO ToolStrip and Similar kind of support
    public class UIItem : IUIItem
    {
        protected readonly AutomationElement automationElement;
        protected IActionListener actionListener;
        internal static readonly Mouse mouse = Mouse.Instance;
        protected readonly PrimaryUIItemFactory factory;
        internal readonly Keyboard keyboard = Keyboard.Instance;
        protected IScrollBars scrollBars;
        private AutomationEventHandler handler;
        protected readonly ILogger Logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(UIItem));

        protected UIItem()
        {
        }

        public UIItem(AutomationElement automationElement, IActionListener actionListener)
        {
            if (null == automationElement) throw new NullReferenceException();
            this.automationElement = automationElement;
            this.actionListener = actionListener;
            factory = new PrimaryUIItemFactory(new AutomationElementFinder(automationElement));
        }

        /// <summary>
        /// Should be used only if white doesn't support the feature you are looking for.
        /// Knowledge of UIAutomation would be required. It would better idea to also raise an issue if you are using it.
        /// </summary>
        public virtual AutomationElement AutomationElement
        {
            get { return automationElement; }
        }

        protected virtual object Property(AutomationProperty automationProperty)
        {
            return automationElement.GetCurrentPropertyValue(automationProperty);
        }

        public virtual bool Enabled
        {
            get { return automationElement.Current.IsEnabled; }
        }

        public virtual WindowsFramework Framework
        {
            get { return WindowsFrameworkExtensions.FromFrameworkId(automationElement.Current.FrameworkId); }
        }

        public virtual Point Location
        {
            get { return automationElement.Current.BoundingRectangle.TopLeft; }
        }

        protected virtual void ActionPerformed()
        {
            actionListener.ActionPerformed(Action.WindowMessage);
        }

        public virtual Rect Bounds
        {
            get { return automationElement.Current.BoundingRectangle; }
        }

        public virtual string Name
        {
            get
            {
                try
                {
                    return automationElement.Current.Name;
                }
                catch (InvalidOperationException)
                {
                    return automationElement.Current.Name;
                }
            }
        }

        public virtual Point ClickablePoint
        {
            get { return (Point)Property(AutomationElement.ClickablePointProperty); }
        }

        public virtual string AccessKey
        {
            get { return automationElement.Current.AccessKey; }
        }

        public virtual bool ValueOfEquals(AutomationProperty property, object compareTo)
        {
            return Property(property).Equals(compareTo);
        }

        public virtual T GetPattern<T>() 
            where T : class
        {
            return AutomationElement.GetPattern<T>();
        }
        
        public virtual void RightClickAt(Point point)
        {
            actionListener.ActionPerforming(this);
            mouse.RightClick(point, actionListener);
        }

        public virtual void RightClick()
        {
            RightClickOnCenter();
        }

        private void RightClickOnCenter()
        {
            RightClickAt(Bounds.Center());
        }

        public virtual void Focus()
        {
            actionListener.ActionPerforming(this);
            try
            {
                automationElement.SetFocus();
                ActionPerformed();
            }
            catch
            {
                Logger.Debug("Could not set focus on " + AutomationElement.Display());
            }
        }

        public virtual void SetForeground()
        {
            WindowsAPI.NativeWindow.SetForegroundWindow(new IntPtr(automationElement.Current.NativeWindowHandle));
        }

        public virtual void Visit(IWindowControlVisitor windowControlVisitor)
        {
            windowControlVisitor.Accept(this);
        }

        public virtual string Id
        {
            get { return automationElement.Current.AutomationId; }
        }

        public virtual bool Visible
        {
            get { return !automationElement.Current.IsOffscreen; }
        }

        /// <summary>
        /// Provides the Error on this UIItem. This would return Error object when this item has ErrorProvider displayed next to it.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        public virtual string ErrorProviderMessage(Window window)
        {
            AutomationElement element =
                AutomationElement.FromPoint(automationElement.Current.BoundingRectangle.ImmediateExteriorEast());
            if (element == null) return null;
            Rect errorProviderBounds = element.Current.BoundingRectangle;
            if (automationElement.Current.BoundingRectangle.Right != errorProviderBounds.Left) return null;
            mouse.Location = errorProviderBounds.Center();
            actionListener.ActionPerformed(Action.WindowMessage);
            return window.ToolTip.Text;
        }

        public virtual bool NameMatches(string text)
        {
            return Name.Equals(text);
        }

        public virtual string PrimaryIdentification
        {
            get { return automationElement.Current.FrameworkId.Equals(WindowsFramework.Win32.FrameworkId()) ? Name : Id; }
        }

        public virtual IActionListener ActionListener
        {
            get { return actionListener; }
        }

        /// <summary>
        /// Performs mouse click at the center of this item
        /// </summary>
        public virtual void Click()
        {
            actionListener.ActionPerforming(this);
            PerformIfValid(PerformClick);
        }

        private void PerformIfValid(System.Action action)
        {
            var startTime = DateTime.Now;
            var busyTimeout = CoreAppXmlConfiguration.Instance.BusyTimeout / 1000;
            while (DateTime.Now.Subtract(startTime).TotalSeconds < busyTimeout)
            {
                if (Enabled && !IsOffScreen)
                {
                    action();
                    return;
                }
                Thread.Sleep(500);
            }

            string message = null;
            if (!Enabled)
                message = "element not enabled";
            else if (IsOffScreen)
                message = "element is offscreen";

            throw new AutomationException(string.Format("Cannot perform action on {0}, {1}", this, message), Debug.Details(AutomationElement));
        }

        void PerformClick()
        {
            if (!Enabled) Logger.WarnFormat("Clicked on disabled item: {0}", ToString());
            var bounds = Bounds;
            if (bounds.IsEmpty)
            {
                throw new WhiteException(string.Format("Failed to click on {0}, bounds empty", ToString()));
            }
            mouse.Click(bounds.Center(), actionListener);
        }

        /// <summary>
        /// Performs mouse double click at the center of this item
        /// </summary>
        public virtual void DoubleClick()
        {
            actionListener.ActionPerforming(this);
            PerformIfValid(() => mouse.DoubleClick(Bounds.Center(), actionListener));
        }

        /// <summary>
        /// Perform keyboard action on this UIItem
        /// </summary>
        /// <param name="key"></param>
        public virtual void KeyIn(KeyboardInput.SpecialKeys key)
        {
            actionListener.ActionPerforming(this);
            keyboard.PressSpecialKey(key, actionListener);
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            var uiItem = obj as UIItem;
            if (uiItem == null) return false;
            return Equals(automationElement, uiItem.AutomationElement);
        }

        public override int GetHashCode()
        {
            return automationElement.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}. {1}", GetType().Name, automationElement.Display());
        }

        public virtual IScrollBars ScrollBars
        {
            get { return scrollBars ?? (scrollBars = ScrollerFactory.CreateBars(automationElement, actionListener)); }
        }

        protected virtual void HookClickEvent(UIItemEventListener eventListener)
        {
            handler = delegate { eventListener.EventOccured(new UIItemClickEvent(this)); };
            Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent, automationElement, TreeScope.Element,
                                                 handler);
        }

        protected virtual void UnHookClickEvent()
        {
            Automation.RemoveAutomationEventHandler(InvokePattern.InvokedEvent, automationElement, handler);
        }

        public virtual bool IsOffScreen
        {
            get { return automationElement.Current.IsOffscreen; }
        }

        public virtual bool IsFocussed
        {
            get { return automationElement.Current.HasKeyboardFocus; }
        }

        public virtual Color BorderColor
        {
            get { return VisibleImage.GetPixel(0, 0); }
        }

        public virtual Bitmap VisibleImage
        {
            get
            {
                var displayedItem = new DisplayedItem(new IntPtr(automationElement.Current.NativeWindowHandle));
                using (System.Drawing.Image image = displayedItem.GetVisibleImage())
                    return new Bitmap(image);
            }
        }

        public virtual string HelpText
        {
            get
            {
                return automationElement.Current.HelpText;
            }
        }

        /// <summary>
        /// AccessibleDescription in Winforms no longer sets the HelpText, use this to get the AccessibleDescription
        /// </summary>
        public virtual string LegacyHelpText
        {
            get
            {
                var helpText = automationElement.Current.HelpText;
                var legacyIAccessiblePattern = AutomationElement.GetPattern<LegacyIAccessiblePattern>();
                if (string.IsNullOrEmpty(helpText) && legacyIAccessiblePattern != null)
                {
                    helpText = legacyIAccessiblePattern.Current.Description;
                }
                return helpText;
            }
        }

        public virtual string ItemStatus { get { return automationElement.Current.ItemStatus; } }

        /// <summary>
        /// Internal to white and intended to be used for white recording
        /// </summary>
        public virtual void UnHookEvents()
        {
        }

        /// <summary>
        /// Internal to white and intended to be used for white recording
        /// </summary>
        /// <param name="eventListener"></param>
        public virtual void HookEvents(UIItemEventListener eventListener)
        {
        }

        public virtual void SetValue(object value)
        {
        }

        public virtual void ActionPerforming(UIItem uiItem)
        {
        }

        public virtual void ActionPerformed(Action action)
        {
            actionListener.ActionPerformed(action);
        }

        public virtual void LogStructure()
        {
            Logger.Info(Debug.Details(AutomationElement));
        }

        /// <summary>
        /// Uses the Raw View provided by UIAutomation to find elements within this UIItem. RawView sometimes contains extra AutomationElements. This is internal to 
        /// white although made public. Should be used only if the standard approaches dont work. Also if you end up using it please raise an issue
        /// so that it can be fixed.
        /// Please understand that calling this method on any UIItem which has a lot of child AutomationElements might result in very bad performance.
        /// </summary>
        /// <param name="searchCriteria"></param>
        /// <returns>null or found AutomationElement</returns>
        public virtual AutomationElement GetElement(SearchCriteria searchCriteria)
        {
            return
                new AutomationElementFinder(automationElement).FindDescendantRaw(
                    searchCriteria.AutomationSearchCondition);
        }

        public virtual void Enter(string value)
        {
            var pattern = GetPattern<ValuePattern>();
            if (pattern != null) pattern.SetValue(string.Empty);
            if (string.IsNullOrEmpty(value)) return;

            actionListener.ActionPerformed(Action.WindowMessage);
            EnterData(value);
        }

        protected virtual void EnterData(string value)
        {
            var lines = value.Replace("\r\n", "\n").Split('\n');
            keyboard.Send(lines[0], actionListener);
            foreach (var line in lines.Skip(1))
            {
                keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                keyboard.Send(line, actionListener);
            }
        }

        internal virtual UIItemContainer AsContainer()
        {
            return new UIItemContainer(AutomationElement, ActionListener);
        }

        public virtual void RaiseClickEvent()
        {
            var invokePattern = GetPattern<InvokePattern>();
            if (invokePattern != null) invokePattern.Invoke();
        }

        /// <summary>
        /// Highlight UIItem with a red frame
        /// </summary>
        public virtual void DrawHighlight()
        {
            DrawHighlight(Color.Red);
        }
        /// <summary>
        /// Highlight UIItem with a colored frame
        /// </summary>
        public virtual void DrawHighlight(Color color)
        {
            Rect rectangle = AutomationElement.Current.BoundingRectangle;

            if (rectangle != Rect.Empty)
            {
                new Drawing.FrameRectangle(color, rectangle).Highlight();
            }
        }

        public virtual Bitmap Capture()
        {
            return Desktop.CaptureScreenshot(Bounds);
        }
    }
}