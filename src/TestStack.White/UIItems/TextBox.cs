using System;
using System.Windows.Automation;
using White.Core.Recording;
using White.Core.UIA;
using White.Core.UIItemEvents;
using White.Core.UIItems.Actions;
using White.Core.UIItems.ListViewItems;
using Action=White.Core.UIItems.Actions.Action;

namespace White.Core.UIItems
{
    public class TextBox : UIItem
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
                return ((ValuePattern) Pattern(ValuePattern.Pattern)).Current.Value;
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
                    ((ValuePattern) Pattern(ValuePattern.Pattern)).SetValue(value);
                }
                catch (InvalidOperationException)
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

    [PlatformSpecificItem]
    public class WinFormTextBox : TextBox
    {
        public WinFormTextBox(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}
        public WinFormTextBox() {}

        public virtual SuggestionList SuggestionList
        {
            get { return SuggestionListView.WaitAndFind(ActionListener); }
        }
    }
}
