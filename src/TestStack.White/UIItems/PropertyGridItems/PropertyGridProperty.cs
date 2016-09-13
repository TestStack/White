using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.PropertyGridItems
{
    public class PropertyGridProperty : UIItem
    {
        private readonly PropertyGridElementFinder gridElementFinder;

        protected PropertyGridProperty() {}
        public PropertyGridProperty(AutomationElement automationElement, PropertyGridElementFinder gridElementFinder, IActionListener actionListener) : base(automationElement, actionListener)
        {
            this.gridElementFinder = gridElementFinder;
        }

        public virtual string Value
        {
            get { return ValuePatternId().Value; }
            set { ValuePattern().SetValue(value); }
        }

        private ValuePattern.ValuePatternInformation ValuePatternId()
        {
            return ValuePattern().Current;
        }

        private ValuePattern ValuePattern()
        {
            return ((ValuePattern) Pattern(System.Windows.Automation.ValuePattern.Pattern));
        }

        public virtual bool IsReadOnly
        {
            get { return ValuePatternId().IsReadOnly; }
        }

        public virtual string Text
        {
            get { return Name; }
        }

        public virtual void BrowseForValue()
        {
            Click();
            AutomationElement browseButtonElement = gridElementFinder.FindBrowseButton();
            if (browseButtonElement == null) throw new WhiteException(string.Format("Property {0} isn't browsable.", Text));
            var button = new Button(browseButtonElement, actionListener);
            button.Click();
        }
    }
}