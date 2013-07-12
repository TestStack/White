using System.IO;

namespace TestStack.White.Repository.Configuration
{
    //TODO: Power management
    public interface RepositoryConfiguration
    {
        bool RecordFlow { get; }
        DirectoryInfo ServiceCallHistoryLocation { get; }
        bool UseHistory { get; }
    }
}