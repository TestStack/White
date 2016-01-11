using TestStack.White.Configuration;

namespace TestStack.White.ScreenObjects.Configuration
{
    public static class RepositoryConfigurationLocator
    {
        private static RepositoryConfiguration repositoryConfiguration;

        public static RepositoryConfiguration Get()
        {
            if (repositoryConfiguration == null)
            {
                Register(new AppConfigReader("White", "Repository"));
            }
            return repositoryConfiguration;
        }

        public static void Register(ConfigurationReaderBase configurationReader)
        {
            repositoryConfiguration = new RepositoryConfiguration();
            configurationReader.FillConfigurationFromReader(repositoryConfiguration);
        }
    }
}
