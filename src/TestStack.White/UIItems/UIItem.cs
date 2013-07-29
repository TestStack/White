using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Automation;
using Castle.Core.Logging;
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
        internal static readonly Mouse mouse = Mouse.Instance;
        protected readonly PrimaryUIItemFactory factory;
        internal readonly Keyboard keyboard = Keyboard.Instance;
        protected IScrollBars scrollBars;
        private AutomationEventHandler handler;
        protected readonly ILogger Logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(UIItem));

        protected UIItem()
        {
        }

        public UIItem(AutomationElement automationElement, ActionListener actionListener)
        {
            if (null == automationElement) throw new NullReferenceException();
            this.automationElement = automationElement;
            ActionListener = actionListener;
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

        /// <summary>
        /// Perform window message action.
        /// </summary>
        protected virtual void ActionPerformed()
        {
            ActionPerformed(Action.WindowMessage);
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
            get { return (Point) Property(AutomationElement.ClickablePointProperty); }
        }

        public virtual string AccessKey
        {
            get { return automationElement.Current.AccessKey; }
        }

        public virtual bool ValueOfEquals(AutomationProperty property, object compareTo)
        {
            return Property(property).Equals(compareTo);
        }

        protected virtual T Pattern<T>()
        {
            var fieldInfo = typeof(T).GetField("Pattern", BindingFlags.Static | BindingFlags.Public);
            var pattern = (AutomationPattern)fieldInfo.GetValue(null);
            object patternObject;
            if (automationElement.TryGetCurrentPattern(pattern, out patternObject))
            {
                return (T)patternObject;
            }
            return (T)(object)null;
        }

        protected virtual BasePattern Pattern(AutomationPattern pattern)
        {
            return Pattern(AutomationElement, pattern);
        }

        internal static BasePattern Pattern(AutomationElement automationElement, AutomationPattern pattern)
        {
            object patternObject;
            if (automationElement.TryGetCurrentPattern(pattern, out patternObject))
            {
                return (BasePattern) patternObject;
            }
            return null;
        }

        public virtual void RightClickAt(Point point)
        {
            mouse.RightClick(point, ActionListener);
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

        public virtual void Visit(WindowControlVisitor windowControlVisitor)
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
            ActionPerformed();
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

        public virtual ActionListener ActionListener {  get; private set; }

        /// <summary>
        /// Performs mouse click at the center of this item
        /// </summary>
        public virtual void Click()
        {
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
            mouse.Click(bounds.Center(), ActionListener);
        }

        /// <summary>
        /// Performs mouse double click at the center of this item
        /// </summary>
        public virtual void DoubleClick()
        {
            PerformIfValid(()=>mouse.DoubleClick(Bounds.Center(), ActionListener));
        }

        /// <summary>
        /// Perform keyboard action on this UIItem
        /// </summary>
        /// <param name="key"></param>
        public virtual void KeyIn(KeyboardInput.SpecialKeys key)
        {
            keyboard.PressSpecialKey(key, ActionListener);
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
            get { return scrollBars ?? (scrollBars = ScrollerFactory.CreateBars(automationElement, ActionListener)); }
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
                System.Drawing.Image image = displayedItem.GetVisibleImage();
                return new Bitmap(image);
            }
        }

        public virtual string HelpText { get { return automationElement.Current.HelpText; } }

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
            ActionListener.ActionPerforming(uiItem);
        }

        public virtual void ActionPerformed(Action action)
        {
            ActionListener.ActionPerformed(action);
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
            var pattern = Pattern(ValuePattern.Pattern) as ValuePattern;
            if (pattern != null) pattern.SetValue(string.Empty);
            if (string.IsNullOrEmpty(value)) return;

            ActionPerformed();
            EnterData(value);
        }

        protected virtual void EnterData(string value)
        {
            var lines = value.Replace("\r\n", "\n").Split('\n');
            keyboard.Send(lines[0], ActionListener);
            foreach (var line in lines.Skip(1))
            {
                keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                keyboard.Send(line, ActionListener); 
            }
        }

        internal virtual UIItemContainer AsContainer()
        {
            return new UIItemContainer(AutomationElement, ActionListener);
        }

        public virtual void RaiseClickEvent()
        {
            var invokePattern = (InvokePattern) Pattern(InvokePattern.Pattern);
            if (invokePattern != null) invokePattern.Invoke();
        }
    }
}