using System.IO;

namespace Repository.Configuration
{
    //TODO: Power management
    public interface RepositoryConfiguration
    {
        bool RecordFlow { get; }
        DirectoryInfo ServiceCallHistoryLocation { get; }
        bool UseHistory { get; }
    }
}