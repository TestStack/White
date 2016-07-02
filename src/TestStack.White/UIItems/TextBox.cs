using System.Windows.Automation;
using TestStack.White.Recording;
using TestStack.White.UIA;
using TestStack.White.UIItemEvents;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems
{
    public class TextBox : UIItem, IScrollable
    {
        private AutomationPropertyChangedEventHandler handler;
        protected TextBox() {}
        public TextBox(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener) {}

        /// <summary>Gets or sets the text.</summary>
        /// <remarks>
        /// Enters the text in the textbox. The text would be cleared first. This is not as good performing as the BulkText method. 
        /// This does raise all keyboard events - that means that your string will consist of letters that match the letters
        /// of your string but in current input language.
        /// </remarks>
        public virtual string Text
        {
            get
            {
                if (this.automationElement.Current.IsPassword)
                {
                    throw new WhiteException("Text cannot be retrieved from textbox which has secret text (e.g. password) stored in it");
                }

                var pattern = this.Pattern(ValuePattern.Pattern) as ValuePattern;
                if (pattern != null)
                {
                    return pattern.Current.Value;
                }

                var textPattern = this.Pattern(TextPattern.Pattern) as TextPattern;
                if (textPattern != null)
                {
                    return textPattern.DocumentRange.GetText(int.MaxValue);
                }

                throw new WhiteException($"AutomationElement for {this.ToString()} supports neither ValuePattern or TextPattern");
            }

            set
            {
                this.Enter(value);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <remarks>
        /// Sets the text in the textbox. The text would be cleared first. This is a better performing than the Text method. This doesn't raise all keyboard events.
        /// The string will be set exactly as it is in your code.
        /// </remarks>
        public virtual string BulkText
        {
            get
            {
                return this.Text;
            }

            set
            {
                try
                {
                    var pattern = this.Pattern(ValuePattern.Pattern) as ValuePattern;
                    if (pattern != null)
                    {
                        pattern.SetValue(value);
                    }
                    else
                    {
                        this.Logger.WarnFormat("BulkText failed, {0} does not support ValuePattern. Trying Text", this.ToString());
                        this.Text = value;
                        this.actionListener.ActionPerformed(Action.WindowMessage);
                    }
                }
                catch (System.InvalidOperationException)
                {
                    this.Logger.Warn("BulkText failed, now trying Text on " + this.ToString());
                    this.Text = value;
                    this.actionListener.ActionPerformed(Action.WindowMessage);
                }
            }
        }

        /// <summary>
        /// Gets or sets the value indicates whether the control is read-only.
        /// </summary>
        public virtual bool IsReadOnly => ((ValuePattern) this.Pattern(ValuePattern.Pattern)).Current.IsReadOnly;

        public virtual void ClickAtRightEdge()
        {
            mouse.Click(this.Bounds.ImmediateInteriorEast(), this.actionListener);
        }

        public virtual void ClickAtCenter()
        {
            mouse.Click(this.Bounds.Center(), this.actionListener);
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
