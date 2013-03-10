using System;
using White.Core.Factory;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;

namespace White.Core.UIItems.Container
{
    internal class NonCachedContainerItemFactory : ContainerItemFactory
    {
        private readonly PrimaryUIItemFactory factory;

        public NonCachedContainerItemFactory(PrimaryUIItemFactory factory, ActionListener actionListener)
        {
            this.factory = factory;
            this.actionListener = actionListener;
        }

        /// <summary>
        /// Not supported. Use cached approach instead.
        /// </summary>
        /// <exception cref="NotSupportedException"> always</exception>
        public override void Visit(WindowControlVisitor windowControlVisitor)
        {
            throw new NotSupportedException("Use Cached approach");
        }

        protected override IUIItem Find(SearchCriteria searchCriteria)
        {
            return factory.Create(searchCriteria, actionListener);
        }

        public override UIItemCollection GetAll(SearchCriteria searchCriteria)
        {
            return factory.CreateAll(searchCriteria, actionListener);
        }
    }
}