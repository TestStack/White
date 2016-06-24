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
        #region Fields

        protected readonly AutomationElement automationElement;
        protected IActionListener actionListener;
        internal static readonly Mouse mouse = Mouse.Instance;
        protected readonly PrimaryUIItemFactory factory;
        internal readonly Keyboard keyboard = Keyboard.Instance;
        protected IScrollBars scrollBars;
        private AutomationEventHandler handler;
        protected readonly ILogger Logger = CoreConfigurationLocator.Get().LoggerFactory.Create(typeof(UIItem));

        #endregion

        #region Constructor

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

        #endregion

        #region Automation

        /// <summary>
        /// Implements <see cref="IUIItem.AutomationElement"/>
        /// </summary>
        public virtual AutomationElement AutomationElement
        {
            get { return automationElement; }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.Framework"/>
        /// </summary>
        public virtual WindowsFramework Framework
        {
            get { return WindowsFrameworkExtensions.FromFrameworkId(automationElement.Current.FrameworkId); }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.ActionListener"/>
        /// </summary>
        public virtual IActionListener ActionListener
        {
            get { return actionListener; }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.GetElement(SearchCriteria)"/>
        /// </summary>
        public virtual AutomationElement GetElement(SearchCriteria searchCriteria)
        {
            return
                new AutomationElementFinder(automationElement).FindDescendantRaw(
                    searchCriteria.AutomationSearchCondition);
        }

        #endregion

        #region State Properties

        /// <summary>
        /// Implements <see cref="IUIItem.Enabled"/>
        /// </summary>
        public virtual bool Enabled
        {
            get { return automationElement.Current.IsEnabled; }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.IsOffScreen"/>
        /// </summary>
        public virtual bool IsOffScreen
        {
            get { return automationElement.Current.IsOffscreen; }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.Visible"/>
        /// </summary>
        public virtual bool Visible
        {
            get { return !automationElement.Current.IsOffscreen; }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.IsFocussed"/>
        /// </summary>
        public virtual bool IsFocussed
        {
            get { return automationElement.Current.HasKeyboardFocus; }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.ItemStatus"/>
        /// </summary>
        public virtual string ItemStatus { get { return automationElement.Current.ItemStatus; } }

        /// <summary>
        /// Implements <see cref="IUIItem.Name"/>
        /// </summary>
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

        /// <summary>
        /// Implements <see cref="IUIItem.Id"/>
        /// </summary>
        public virtual string Id
        {
            get { return automationElement.Current.AutomationId; }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.PrimaryIdentification"/>
        /// </summary>
        public virtual string PrimaryIdentification
        {
            get { return automationElement.Current.FrameworkId.Equals(WindowsFramework.Win32.FrameworkId()) ? Name : Id; }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.HelpText"/>
        /// </summary>
        public virtual string HelpText { get { return automationElement.Current.HelpText; } }

        /// <summary>
        /// AccessibleDescription in Winforms no longer sets the HelpText, use this to get the AccessibleDescription
        /// </summary>
        public virtual string LegacyHelpText
        {
            get
            {
                var helpText = automationElement.Current.HelpText;
                var legacyIAccessiblePattern = GetPattern<LegacyIAccessiblePattern>();
                if (string.IsNullOrEmpty(helpText) && legacyIAccessiblePattern != null)
                {
                    helpText = legacyIAccessiblePattern.Current.Description;
                }
                return helpText;
            }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.AccessKey"/>
        /// </summary>
        public virtual string AccessKey
        {
            get { return automationElement.Current.AccessKey; }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.ScrollBars"/>
        /// </summary>
        public virtual IScrollBars ScrollBars
        {
            get { return scrollBars ?? (scrollBars = ScrollerFactory.CreateBars(automationElement, actionListener)); }
        }

        #endregion

        #region Dimension Properties

        /// <summary>
        /// Implements <see cref="IUIItem.Location"/>
        /// </summary>
        public virtual Point Location
        {
            get { return automationElement.Current.BoundingRectangle.TopLeft; }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.Bounds"/>
        /// </summary>
        public virtual Rect Bounds
        {
            get { return automationElement.Current.BoundingRectangle; }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.ClickablePoint"/>
        /// </summary>
        public virtual Point ClickablePoint
        {
            get { return (Point)Property(AutomationElement.ClickablePointProperty); }
        }
        #endregion

        #region Graphics

        /// <summary>
        /// Implements <see cref="IUIItem.BorderColor"/>
        /// </summary>
        public virtual Color BorderColor
        {
            get { return VisibleImage.GetPixel(0, 0); }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.VisibleImage"/>
        /// </summary>
        public virtual Bitmap VisibleImage
        {
            get
            {
                var displayedItem = new DisplayedItem(new IntPtr(automationElement.Current.NativeWindowHandle));
                using (System.Drawing.Image image = displayedItem.GetVisibleImage())
                    return new Bitmap(image);
            }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.DrawHighlight()"/>
        /// </summary>
        public virtual void DrawHighlight()
        {
            DrawHighlight(Color.Red);
        }

        /// <summary>
        /// Implements <see cref="IUIItem.DrawHighlight(Color)"/>
        /// </summary>
        public virtual void DrawHighlight(Color color)
        {
            var rectangle = AutomationElement.Current.BoundingRectangle;
            if (rectangle != Rect.Empty)
            {
                new Drawing.FrameRectangle(color, rectangle).Highlight();
            }
        }

        /// <summary>
        /// Implements <see cref="IUIItem.Capture"/>
        /// </summary>
        public virtual Bitmap Capture()
        {
            return Desktop.CaptureScreenshot(Bounds);
        }

        #endregion

        #region Interaction

        /// <summary>
        /// Implements <see cref="IUIItem.Focus"/>
        /// </summary>
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

        /// <summary>
        /// Implements <see cref="IUIItem.SetForeground"/>
        /// </summary>
        public virtual void SetForeground()
        {
            NativeWindow.SetForegroundWindow(new IntPtr(automationElement.Current.NativeWindowHandle));
        }

        /// <summary>
        /// Implements <see cref="IUIItem.Visit"/>
        /// </summary>
        public virtual void Visit(IWindowControlVisitor windowControlVisitor)
        {
            windowControlVisitor.Accept(this);
        }

        /// <summary>
        /// Implements <see cref="IUIItem.Invoke"/>
        /// </summary>
        public virtual void Invoke()
        {
            var invokePattern = GetPattern<InvokePattern>();
            if (invokePattern != null) invokePattern.Invoke();
        }

        /// <summary>
        /// Implements <see cref="IUIItem.Click"/>
        /// </summary>
        public virtual void Click()
        {
            actionListener.ActionPerforming(this);
            PerformIfValid(PerformClick);
        }

        /// <summary>
        /// Implements <see cref="IUIItem.DoubleClick"/>
        /// </summary>
        public virtual void DoubleClick()
        {
            actionListener.ActionPerforming(this);
            PerformIfValid(() => mouse.DoubleClick(Bounds.Center(), actionListener));
        }

        /// <summary>
        /// Implements <see cref="IUIItem.RightClick()"/>
        /// </summary>
        public virtual void RightClick()
        {
            RightClickAt(Bounds.Center());
        }

        /// <summary>
        /// Implements <see cref="IUIItem.RightClickAt(Point)"/>
        /// </summary>
        public virtual void RightClickAt(Point point)
        {
            actionListener.ActionPerforming(this);
            mouse.RightClick(point, actionListener);
        }

        /// <summary>
        /// Implements <see cref="IUIItem.KeyIn"/>
        /// </summary>
        public virtual void KeyIn(KeyboardInput.SpecialKeys key)
        {
            actionListener.ActionPerforming(this);
            keyboard.PressSpecialKey(key, actionListener);
        }

        /// <summary>
        /// Implements <see cref="IUIItem.SetValue"/>
        /// </summary>
        public virtual void SetValue(object value)
        {
        }

        /// <summary>
        /// Implements <see cref="IUIItem.Enter"/>
        /// </summary>
        public virtual void Enter(string value)
        {
            var pattern = GetPattern<ValuePattern>();
            if (pattern != null) pattern.SetValue(string.Empty);
            if (string.IsNullOrEmpty(value)) return;

            actionListener.ActionPerformed(Action.WindowMessage);
            EnterData(value);
        }

        #endregion

        #region Recording

        /// <summary>
        /// Implements <see cref="IUIItem.UnHookEvents"/>
        /// </summary>
        public virtual void UnHookEvents()
        {
        }

        /// <summary>
        /// Implements <see cref="IUIItem.HookEvents"/>
        /// </summary>
        public virtual void HookEvents(IUIItemEventListener eventListener)
        {
        }

        #endregion

        #region Debugging

        /// <summary>
        /// Implements <see cref="IUIItem.ErrorProviderMessage"/>
        /// </summary>
        public virtual string ErrorProviderMessage(Window window)
        {
            var element =
                AutomationElement.FromPoint(automationElement.Current.BoundingRectangle.ImmediateExteriorEast());
            if (element == null) return null;
            var errorProviderBounds = element.Current.BoundingRectangle;
            if (automationElement.Current.BoundingRectangle.Right != errorProviderBounds.Left) return null;
            mouse.Location = errorProviderBounds.Center();
            actionListener.ActionPerformed(Action.WindowMessage);
            return window.ToolTip.Text;
        }

        /// <summary>
        /// Implements <see cref="IUIItem.LogStructure"/>
        /// </summary>
        public virtual void LogStructure()
        {
            Logger.Info(Debug.Details(AutomationElement));
        }

        #endregion

        #region Equality

        /// <summary>
        /// Implements <see cref="IUIItem.NameMatches"/>
        /// </summary>
        public virtual bool NameMatches(string text)
        {
            return Name.Equals(text);
        }

        /// <summary>
        /// Implements <see cref="IUIItem.ValueOfEquals"/>
        /// </summary>
        public virtual bool ValueOfEquals(AutomationProperty property, object compareTo)
        {
            return Property(property).Equals(compareTo);
        }

        /// <summary>
        /// Implements <see cref="IUIItem.Equals(object)"/>
        /// </summary>
        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            var uiItem = other as IUIItem;
            return uiItem != null && Equals(uiItem);
        }

        /// <summary>
        /// Implements <see cref="IEquatable{T}.Equals(T)"/>
        /// </summary>
        public bool Equals(IUIItem other)
        {
            return other != null && Equals(automationElement, other.AutomationElement);
        }

        /// <summary>
        /// Implements <see cref="IUIItem.GetHashCode()"/>
        /// </summary>
        public override int GetHashCode()
        {
            return automationElement.GetHashCode();
        }

        /// <summary>
        /// Implements <see cref="IUIItem.ToString()"/>
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0}. {1}", GetType().Name, automationElement.Display());
        }

        #endregion

        #region Implementation from IActionListener

        /// <summary>
        /// Implements <see cref="IActionListener.ActionPerforming"/>
        /// </summary>
        public virtual void ActionPerforming(UIItem uiItem)
        {
        }

        /// <summary>
        /// Implements <see cref="IActionListener.ActionPerformed"/>
        /// </summary>
        public virtual void ActionPerformed(Action action)
        {
            actionListener.ActionPerformed(action);
        }

        #endregion

        #region Public

        /// <summary>
        /// Make an <see cref="IUIItemContainer"/> out of the <see cref="IUIItem"/>
        /// </summary>
        /// <returns>Returns an <c><see cref="IUIItemContainer"/></c> if possibe</returns>
        public virtual IUIItemContainer AsContainer()
        {
            if (Framework != WindowsFramework.Wpf)
            {
                Logger.Warn("Only WPF items should be treated as container items");
                throw new WhiteException(string.Format(
                        "Cannot create a Container since the UI Item is not of the correct Framework Type {0}",
                        WindowsFramework.Wpf));
            }
            return new UIItemContainer(AutomationElement, ActionListener);
        }

        #endregion

        #region Protected

        protected virtual void ActionPerformed()
        {
            actionListener.ActionPerformed(Action.WindowMessage);
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

        protected virtual void HookClickEvent(IUIItemEventListener eventListener)
        {
            handler = delegate { eventListener.EventOccured(new UIItemClickEvent(this)); };
            Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent, automationElement, TreeScope.Element,
                                                 handler);
        }

        protected virtual void UnHookClickEvent()
        {
            Automation.RemoveAutomationEventHandler(InvokePattern.InvokedEvent, automationElement, handler);
        }

        protected virtual object Property(AutomationProperty automationProperty)
        {
            return automationElement.GetCurrentPropertyValue(automationProperty);
        }

        #endregion

        public virtual T GetPattern<T>() where T : BasePattern
        {
            return AutomationElement.GetPattern<T>();
        }

        #region Private

        private void PerformIfValid(System.Action action)
        {
            var startTime = DateTime.Now;
            var busyTimeout = CoreConfigurationLocator.Get().BusyTimeout / 1000;
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

        private void PerformClick()
        {
            if (!Enabled) Logger.WarnFormat("Clicked on disabled item: {0}", ToString());
            var bounds = Bounds;
            if (bounds.IsEmpty)
            {
                throw new WhiteException(string.Format("Failed to click on {0}, bounds empty", ToString()));
            }
            mouse.Click(bounds.Center(), actionListener);
        }

        #endregion
    }
}