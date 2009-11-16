using System;
using System.Windows.Automation;

namespace White.Core.UIA
{
    public static class AutomationElementCollectionX
    {
        public static bool Contains(this AutomationElementCollection collection, Predicate<AutomationElement> predicate)
        {
            foreach (AutomationElement automationElement in collection)
            {
                if (predicate(automationElement)) return true;
            }
            return false;
        }
    }
}