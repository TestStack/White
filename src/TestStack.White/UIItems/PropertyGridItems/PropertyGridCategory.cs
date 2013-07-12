using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.UIA;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.PropertyGridItems
{
    public class PropertyGridCategory : UIItem
    {
        private readonly PropertyGridElementFinder gridElementFinder;
        protected PropertyGridCategory() {}
        internal PropertyGridCategory(AutomationElement automationElement, ActionListener actionListener, PropertyGridElementFinder gridElementFinder) : 
            base(automationElement, actionListener)
        {
            this.gridElementFinder = gridElementFinder;
        }

        public virtual List<PropertyGridProperty> Properties
        {
            get
            {
                bool thisElementFound = false;
                var properties = new List<PropertyGridProperty>();
                List<AutomationElement> rows = gridElementFinder.FindRows();
                foreach (AutomationElement rowElement in rows)
                {
                    bool thisElement = rowElement.Equals(automationElement);
                    if (thisElement)
                    {
                        thisElementFound = true;
                        continue;
                    }
                    if (!thisElementFound) continue;

                    var automationPatterns = new AutomationPatterns(rowElement);
                    if (automationPatterns.HasPattern(ValuePattern.Pattern))
                    {
                        properties.Add(new PropertyGridProperty(rowElement, gridElementFinder, actionListener));
                    }
                    else
                    {
                        break;                        
                    }
                }
                return properties;
            }
        }

        public virtual string Text
        {
            get { return Name; }
        }

        public virtual PropertyGridProperty GetProperty(string text)
        {
            return Properties.Find(property => property.Text.Equals(text));
        }
    }
}