
namespace TestStack.White.Configuration.Readers
{
    public interface IConfigurationReader
    {
        /// <summary>
        /// Method to override to fill the configuration
        /// </summary>
        void FillConfigurationFromReader(IConfiguration configuration);
    }
}
