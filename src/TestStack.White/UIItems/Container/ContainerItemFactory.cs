using TestStack.White.Factory;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UIItems.Container
{
    public abstract class ContainerItemFactory
    {
        protected IActionListener actionListener;

        public virtual IUIItem Get(SearchCriteria searchCriteria, IActionListener uiItemActionListener)
        {
            IUIItem item = Find(searchCriteria);
            if (item == null || item is UIItemContainer)
            {
                //Cannot create dynamic proxy for class which has methods using generics. Also its not required to intercept methods on UIItem containers
                return item;
            }
            return UIItemProxyFactory.Create(item, uiItemActionListener);
        }

        protected abstract IUIItem Find(SearchCriteria searchCriteria);
        public abstract void Visit(IWindowControlVisitor windowControlVisitor);
        public abstract UIItemCollection GetAll(SearchCriteria searchCriteria);
    }
}