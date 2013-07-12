namespace TestStack.White.Repository.Services
{
    public interface WorkEnvironment
    {
        object TakeSnapshot();
        void RevertToSnapshot(object snapshotId);
        void DropSnapshot(object snapshotId);
    }

    public class NullWorkEnvironment : WorkEnvironment
    {
        public virtual object TakeSnapshot()
        {
            return null;
        }

        public virtual void RevertToSnapshot(object snapshotId) { }

        public virtual void DropSnapshot(object snapshotId) { }
    }
}