namespace TestStack.White.Repository.Services
{
    public interface IWorkEnvironment
    {
        object TakeSnapshot();
        void RevertToSnapshot(object snapshotId);
        void DropSnapshot(object snapshotId);
    }
}