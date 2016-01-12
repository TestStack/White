using TestStack.White.Configuration.Readers;

namespace TestStack.White.Configuration
{
    public static class CoreConfigurationLocator
    {
        private static CoreConfiguration coreConfiguration;

        public static CoreConfiguration Get()
        {
            if (coreConfiguration == null)
            {
                Set(new AppConfigReader("White", "Core"));
            }
            return coreConfiguration;
        }

        public static void Set(IConfigurationReader configurationReader)
        {
            coreConfiguration = new CoreConfiguration();
            configurationReader.FillConfigurationFromReader(coreConfiguration);
        }
    }
}
