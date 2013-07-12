using System.Collections.Generic;
using System.Windows.Automation;

namespace TestStack.White.AutomationElementSearch
{
    public class ElementSearchResult
    {
        private bool many;
        private readonly List<AutomationElement> elements = new List<AutomationElement>();

        private ElementSearchResult()
        {
        }

        public static ElementSearchResult ForMany()
        {
            return new ElementSearchResult {many = true};
        }

        public static ElementSearchResult ForOne()
        {
            return new ElementSearchResult { many = false };
        }

        public virtual bool AllResultsFound
        {
            get
            {
                return many ? false : elements.Count >= 1;
            }
        }

        public virtual void Add(AutomationElement element)
        {
            elements.Add(element);
        }

        public virtual List<AutomationElement> Elements
        {
            get { return elements; }
        }
    }
}