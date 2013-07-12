using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Container;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.Sessions
{
    public class NullWindowSession : WindowSession
    {
        public override WindowSession ModalWindowSession(InitializeOption modalInitializeOption)
        {
            return new NullWindowSession();
        }

        public override IUIItem Get(ContainerItemFactory containerItemFactory, SearchCriteria searchCriteria, ActionListener actionListener)
        {
            return containerItemFactory.Get(searchCriteria, actionListener);
        }

        public override void Dispose()
        {
        }

        public override void Register(Window window)
        {
        }

        public override void LocationChanged(Window window)
        {
        }
    }
}