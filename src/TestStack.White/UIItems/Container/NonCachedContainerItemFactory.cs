using System;
using TestStack.White.Factory;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UIItems.Container
{
    internal class NonCachedContainerItemFactory : ContainerItemFactory
    {
        private readonly PrimaryUIItemFactory factory;

        public NonCachedContainerItemFactory(PrimaryUIItemFactory factory, ActionListener actionListener)
        {
            this.factory = factory;
            this.actionListener = actionListener;
        }

        public override void Visit(WindowControlVisitor windowControlVisitor)
        {
            throw new NotSupportedException("Use Cached approach");
        }

        protected override IUIItem Find(SearchCriteria searchCriteria)
        {
            return factory.Create(searchCriteria, actionListener);
        }

        public override UIItemCollection GetAll(SearchCriteria searchCriteria, string defaultFrameworkId)
        {
            return factory.CreateAll(searchCriteria, actionListener, defaultFrameworkId);
        }
    }
}