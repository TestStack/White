using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using TestStack.White.Configuration;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.AutomationElementSearch
{
    public class DescendantFinder : IDescendantFinder
    {
        private readonly AutomationElement automationElement;
        private readonly ILogger logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(DescendantFinder));

        public DescendantFinder(AutomationElement automationElement)
        {
            if (automationElement == null) throw new ArgumentNullException("automationElement");
            this.automationElement = automationElement;
        }

        public virtual AutomationElement Descendant(AutomationSearchCondition automationSearchCondition)
        {
            return Descendant(automationSearchCondition.Condition);
        }

        public virtual AutomationElement Descendant(Condition condition)
        {
            return automationElement.FindFirst(TreeScope.Descendants, condition);
        }

        public virtual List<AutomationElement> Descendants(AutomationSearchCondition automationSearchCondition)
        {
            var collection = automationElement.FindAll(TreeScope.Descendants, automationSearchCondition.Condition);

            //Automation elements identified in current window...
            //AutomationElement[] elementsArray = new AutomationElement[collection.Count];

            //collection.CopyTo(elementsArray, 0);

            //foreach (AutomationElement e in elementsArray)
            //{
            //    logger.InfoFormat("Element Automation Id: ({0})..", e.Current.AutomationId);
            //}

            var enumerable = collection.Cast<AutomationElement>();
            return new List<AutomationElement>(enumerable);
        }
    }
}