using TestStack.White.Configuration.Readers;

namespace TestStack.White.ScreenObjects.Configuration
{
    public static class RepositoryConfigurationLocator
    {
        private static RepositoryConfiguration repositoryConfiguration;

        public static RepositoryConfiguration Get()
        {
            if (repositoryConfiguration == null)
            {
                Set(new AppConfigReader("White", "Repository"));
            }
            return repositoryConfiguration;
        }

        public static void Set(IConfigurationReader configurationReader)
        {
            repositoryConfiguration = new RepositoryConfiguration();
            configurationReader.FillConfigurationFromReader(repositoryConfiguration);
        }
    }
}