using System;
using System.Windows.Automation;
using TestStack.White.Recording;
using TestStack.White.UIA;
using TestStack.White.UIItemEvents;
using TestStack.White.UIItems.Actions;
using TestStack.White.WindowsAPI;
using Action = TestStack.White.UIItems.Actions.Action;

namespace TestStack.White.UIItems
{
    public class TextBox : UIItem, IScrollable
    {
        private AutomationPropertyChangedEventHandler handler;
        protected TextBox() {}
        public TextBox(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener) {}

        /// <summary>
        /// Enters the text in the textbox. The text would be cleared first. This is not as good performing as the BulkText method. 
        /// This does raise all keyboard events - that means that your string will consist of letters that match the letters
        /// of your string but in current input language.
        /// </summary>
        public virtual string Text
        {
            get
            {
                if (automationElement.Current.IsPassword)
                    throw new WhiteException("Text cannot be retrieved from textbox which has secret text (e.g. password) stored in it");
                var pattern = GetPattern<ValuePattern>();
                if (pattern != null) return pattern.Current.Value;
                var textPattern = GetPattern<TextPattern>();
                if (textPattern != null) return textPattern.DocumentRange.GetText(int.MaxValue);

                throw new WhiteException(string.Format("AutomationElement for {0} supports neither ValuePattern or TextPattern", ToString()));
            }
            set
            {
                Enter(value);
            }
        }

        /// <summary>
        /// Sets the text in the textbox. The text would be cleared first. This is a better performing than the Text method. This doesn't raise all keyboard events.
        /// The string will be set exactly as it is in your code.
        /// </summary>
        public virtual string BulkText
        {
            set
            {
                try
                {
                    var pattern = GetPattern<ValuePattern>();
                    if (pattern != null) pattern.SetValue(value);
                    else
                    {
                        Logger.WarnFormat("BulkText failed, {0} does not support ValuePattern. Trying Text", ToString());
                        Text = value;
                        actionListener.ActionPerformed(Action.WindowMessage);
                    }
                }
                catch (System.InvalidOperationException)
                {
                    Logger.Warn("BulkText failed, now trying Text on " + ToString());
                    Text = value;
                    actionListener.ActionPerformed(Action.WindowMessage);
                }
            }
            get { return Text; }
        }

        public virtual bool IsReadOnly
        {
            get { return GetPattern<ValuePattern>().Current.IsReadOnly; }
        }

        public virtual void ClickAtRightEdge()
        {
            mouse.LeftClick(Bounds.ImmediateInteriorEast(), actionListener);
        }

        public virtual void ClickAtCenter()
        {
            mouse.LeftClick(Bounds.Center(), actionListener);
        }

        public override void HookEvents(IUIItemEventListener eventListener)
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
