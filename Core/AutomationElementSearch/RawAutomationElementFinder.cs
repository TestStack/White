using System.Windows.Automation;

namespace White.Core.AutomationElementSearch
{
    public class RawAutomationElementFinder
    {
        private readonly AutomationElement automationElement;

        public RawAutomationElementFinder(AutomationElement automationElement)
        {
            this.automationElement = automationElement;
        }

        public virtual AutomationElement Child(AutomationSearchCondition automationSearchCondition)
        {
            TreeWalker treeWalker = TreeWalker.RawViewWalker;
            AutomationElement sibling = treeWalker.GetFirstChild(automationElement);
            while (sibling != null)
            {
                if (automationSearchCondition.Satisfies(sibling)) return sibling;
                sibling = treeWalker.GetNextSibling(sibling);
            }
            return null;
        }

        public virtual AutomationElement Descendant(AutomationSearchCondition automationSearchCondition)
        {
            return Find(automationElement, automationSearchCondition);
        }

        private static AutomationElement Find(AutomationElement automationElement, AutomationSearchCondition automationSearchCondition)
        {
            TreeWalker treeWalker = TreeWalker.RawViewWalker;
            AutomationElement sibling = treeWalker.GetFirstChild(automationElement);
            while (sibling != null)
            {
                if (automationSearchCondition.Satisfies(sibling)) return sibling;
                
                AutomationElement descendant = Find(sibling, automationSearchCondition);
                if (descendant != null) return descendant;

                sibling = treeWalker.GetNextSibling(sibling);
            }
            return null;
        }
    }
}