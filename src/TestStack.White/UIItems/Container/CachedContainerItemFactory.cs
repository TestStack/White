using TestStack.White.Finder;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UIItems.Container
{
    internal class CachedContainerItemFactory : ContainerItemFactory
    {
        private readonly CachedUIItems children;

        public CachedContainerItemFactory(CachedUIItems cachedUIItems, IActionListener actionListener)
        {
            children = cachedUIItems;
            this.actionListener = actionListener;
        }

        protected override IUIItem Find(SearchCriteria searchCriteria)
        {
            return children.Get(searchCriteria, actionListener);
        }

        public override void Visit(IWindowControlVisitor windowControlVisitor)
        {
            UIItemCollection uiItems = children.UIItems(actionListener);
            foreach (UIItem uiItem in uiItems)
                uiItem.Visit(windowControlVisitor);
        }

        public override UIItemCollection GetAll(SearchCriteria searchCriteria)
        {
            return children.GetAll(searchCriteria, actionListener);
        }
    }
}