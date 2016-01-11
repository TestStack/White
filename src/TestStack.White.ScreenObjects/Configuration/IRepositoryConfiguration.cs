using System.IO;

namespace TestStack.White.ScreenObjects.Configuration
{
    //TODO: Power management
    public interface IRepositoryConfiguration
    {
        bool RecordFlow { get; }
        DirectoryInfo ServiceCallHistoryLocation { get; }
        bool UseHistory { get; }
    }
}