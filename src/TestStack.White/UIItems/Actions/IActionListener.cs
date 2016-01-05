namespace TestStack.White.UIItems.Actions
{
    public interface IActionListener
    {
        void ActionPerforming(UIItem uiItem);
        void ActionPerformed(Action action);
    }

    public class NullActionListener : IActionListener
    {
        public virtual void ActionPerforming(UIItem uiItem) {}

        public virtual void ActionPerformed(Action action) {}
    }

    public delegate void VoidDelegate();
}