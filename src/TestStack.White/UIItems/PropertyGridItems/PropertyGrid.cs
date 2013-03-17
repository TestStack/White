using System.Collections.Generic;
using System.Windows.Automation;
using White.Core.UIA;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.PropertyGridItems
{
    public class PropertyGrid : UIItem
    {
        private readonly PropertyGridElementFinder finder;
        protected PropertyGrid() {}

        public PropertyGrid(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
        {
            finder = new PropertyGridElementFinder(automationElement);
        }

        /// <summary>
        /// Provides a list of categories in the property grid.
        /// </summary>
        public virtual List<PropertyGridCategory> Categories
        {
            get
            {
                var categories = new List<PropertyGridCategory>();
                List<AutomationElement> rows = finder.FindRows();
                foreach (AutomationElement element in rows)
                {
                    var automationPatterns = new AutomationPatterns(element);
                    if (!automationPatterns.HasPattern(ValuePattern.Pattern))
                        categories.Add(new PropertyGridCategory(element, ActionListener, finder));
                }

                return categories;
            }
        }

        /// <summary>
        /// Find a category
        /// </summary>
        /// <param name="name"></param>
        /// <returns>PropertyGridCategory matching the name</returns>
        public virtual PropertyGridCategory Category(string name)
        {
            return Categories.Find(category => Equals(name, category.Text));
        }
    }
}