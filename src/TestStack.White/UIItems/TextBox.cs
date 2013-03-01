using System.Windows.Automation;
using TestStack.White.Recording;
using TestStack.White.UIA;
using TestStack.White.UIItemEvents;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems
{
    public class TextBox : UIItem, Scrollable
    {
        private AutomationPropertyChangedEventHandler handler;
        protected TextBox() {}
        public TextBox(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        /// <summary>
        /// Enters the text in the textbox. The text would be cleared first. This is not as good performing as the BulkText method. 
        /// This does raise all keyboard events.
        /// </summary>
        public virtual string Text
        {
            get
            {
                if (automationElement.Current.IsPassword)
                    throw new WhiteException("Text cannot be retrieved from textbox which has secret text (e.g. password) stored in it");
                var pattern = Pattern(ValuePattern.Pattern) as ValuePattern;
                if (pattern != null) return pattern.Current.Value;
                var textPattern = Pattern(TextPattern.Pattern) as TextPattern;
                if (textPattern != null) return textPattern.DocumentRange.GetText(int.MaxValue);

                throw new WhiteException(string.Format("AutomationElement for {0} supports neither ValuePattern or TextPattern", ToString()));
            }
            set { Enter(value); }
        }

        /// <summary>
        /// Sets the text in the textbox. The text would be cleared first. This is a better performing than the Text method. This doesn't raise all keyboard events.
        /// </summary>
        public virtual string BulkText
        {
            set
            {
                try
                {
                    var pattern = Pattern(ValuePattern.Pattern) as ValuePattern;
                    if (pattern != null) pattern.SetValue(value);
                    else
                    {
                        Logger.WarnFormat("BulkText failed, {0} does not support ValuePattern. Trying Text", ToString());
                        Text = value;
                        ActionListener.ActionPerformed(Action.WindowMessage);
                    }
                }
                catch (System.InvalidOperationException)
                {
                    Logger.Warn("BulkText failed, now trying Text on " + ToString());
                    Text = value;
                    ActionPerformed();
                }
            }
            get { return Text; }
        }

        public virtual bool IsReadOnly
        {
            get { return ((ValuePattern) Pattern(ValuePattern.Pattern)).Current.IsReadOnly; }
        }

        public virtual void ClickAtRightEdge()
        {
            mouse.Click(Bounds.ImmediateInteriorEast(), ActionListener);
        }

        public virtual void ClickAtCenter()
        {
            mouse.Click(Bounds.Center(), ActionListener);
        }

        public override void HookEvents(UIItemEventListener eventListener)
        {
            handler = delegate { eventListener.EventOccured(new TextBoxEvent(this)); };
            Automation.AddAutomationPropertyChangedEventHandler(automationElement, TreeScope.Element, handler, ValuePattern.ValueProperty);
        }

        public override void UnHookEvents()
        {
            Automation.RemoveAutomationPropertyChangedEventHandler(automationElement, handler);
        }

        //TODO: This should be configurable
        public override void SetValue(object value)
        {
            BulkText = value.ToString();
        }
    }
}
