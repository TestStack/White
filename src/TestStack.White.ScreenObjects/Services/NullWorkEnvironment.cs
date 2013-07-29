namespace TestStack.White.ScreenObjects.Services
{
    public class NullWorkEnvironment : IWorkEnvironment
    {
        public virtual object TakeSnapshot()
        {
            return null;
        }

        public virtual void RevertToSnapshot(object snapshotId) { }

        public virtual void DropSnapshot(object snapshotId) { }
    }
}