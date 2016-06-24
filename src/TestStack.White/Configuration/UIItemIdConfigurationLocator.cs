using TestStack.White.Configuration.Readers;

namespace TestStack.White.Configuration
{
    public static class UIItemIdConfigurationLocator
    {
        private static UIItemIdConfiguration uiItemIdConfiguration;

        public static UIItemIdConfiguration Get()
        {
            if (uiItemIdConfiguration == null)
            {
                Set(new AppConfigReader("White", "UIItemId"));
            }
            return uiItemIdConfiguration;
        }

        public static void Set(IConfigurationReader configurationReader)
        {
            uiItemIdConfiguration = new UIItemIdConfiguration();
            configurationReader.FillConfigurationFromReader(uiItemIdConfiguration);
        }
    }
}
