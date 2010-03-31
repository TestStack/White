using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using White.Core.Configuration;
using White.Core.Logging;
using White.Core.UIA;

namespace White.Core.AutomationElementSearch
{
    public class RawAutomationElementFinder : IDescendantFinder
    {
        private readonly AutomationElement automationElement;
        private static readonly TreeWalker rawViewWalker = TreeWalker.RawViewWalker;

        public RawAutomationElementFinder(AutomationElement automationElement)
        {
            this.automationElement = automationElement;
        }

        public virtual AutomationElement Child(AutomationSearchCondition automationSearchCondition)
        {
            return FindAll(automationSearchCondition, ElementSearchResult.ForOne(), 1).Elements.FirstOrDefault();
        }

        public virtual AutomationElement Descendant(AutomationSearchCondition automationSearchCondition)
        {
            return
                FindAll(automationSearchCondition, ElementSearchResult.ForOne(), CoreAppXmlConfiguration.Instance.MaxElementSearchDepth).Elements.FirstOrDefault
                    ();
        }

        public AutomationElement Descendant(Condition condition)
        {
            return Descendant(new AutomationSearchCondition(condition));
        }

        public virtual List<AutomationElement> Descendants(AutomationSearchCondition automationSearchCondition)
        {
            return FindAll(automationSearchCondition, ElementSearchResult.ForMany(), CoreAppXmlConfiguration.Instance.MaxElementSearchDepth).Elements;
        }

        private ElementSearchResult FindAll(AutomationSearchCondition automationSearchCondition, ElementSearchResult elementSearchResult, int depth)
        {
            WhiteLogger.Instance.DebugFormat("[RawSearch] Finding in: ({0})", automationElement.Display());
            FindMatchingDescendants(automationElement, automationSearchCondition, elementSearchResult, depth);
            return elementSearchResult;
        }

        private static void FindMatchingDescendants(AutomationElement element, AutomationSearchCondition automationSearchCondition,
                                                    ElementSearchResult elementSearchResult, int depth)
        {
            if (depth == 0)
            {
                return;
            }
            WhiteLogger.Instance.DebugFormat("[RawSearch] Finding descendants of: ({0})", element.Display());
            AutomationElement current = rawViewWalker.GetFirstChild(element);
            while (current != null)
            {
                MatchElement(current, automationSearchCondition, elementSearchResult);
                if (elementSearchResult.AllResultsFound) return;
                FindMatchingDescendants(current, automationSearchCondition, elementSearchResult, depth - 1);
                if (elementSearchResult.AllResultsFound) return;
                current = rawViewWalker.GetNextSibling(current);
            }
        }

        private static void MatchElement(AutomationElement current, AutomationSearchCondition automationSearchCondition, ElementSearchResult elementSearchResult)
        {
            WhiteLogger.Instance.DebugFormat("[RawSearch] Matching: ({0})", current.Display());
            if (automationSearchCondition.Satisfies(current))
            {
                WhiteLogger.Instance.DebugFormat("[RawSearch] Matched: ({0})", current.Display());
                elementSearchResult.Add(current);
            }
        }
    }
}