using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.WindowItems
{
    public class TitleBar : UIItem
    {
        private readonly AutomationElementFinder automationElementFinder;

        public TitleBar(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener)
        {
            automationElementFinder = new AutomationElementFinder(automationElement);
        }

        protected TitleBar() {}

        public virtual Button MinimizeButton
        {
            get { return FindButton("Minimize"); }
        }

        public virtual Button MaximizeButton
        {
            get { return FindButton("Maximize"); }
        }

        public virtual Button RestoreButton
        {
            get { return FindButton("Restore"); }
        }

        public virtual Button CloseButton
        {
            get { return FindButton("Close"); }
        }

        public virtual void SetDisplayState(DisplayState displayState)
        {
            switch (displayState)
            {
                case DisplayState.Maximized:
                    SetDisplayState(MaximizeButton);
                    break;
                case DisplayState.Minimized:
                    SetDisplayState(MinimizeButton);
                    break;
                case DisplayState.Restored:
                    SetDisplayState(RestoreButton);
                    break;
            }
        }

        private void SetDisplayState(Button button)
        {
            if (button == null) return;
            button.Click();
        }

        private Button FindButton(string automationId)
        {
            AutomationElement element =
                automationElementFinder.Child(AutomationSearchCondition.ByControlType(ControlType.Button).WithAutomationId(automationId));
            if (element == null) return null;
            return new Button(element, actionListener);
        }
    }
}