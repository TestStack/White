using TestStack.White.Configuration.Readers;

namespace TestStack.White.WebBrowser.Configuration
{
    public static class WebBrowserConfigurationLocator
    {
        private static WebBrowserConfiguration webBrowserConfiguration;

        public static WebBrowserConfiguration Get()
        {
            if (webBrowserConfiguration == null)
            {
                Set(new AppConfigReader("White", "WebBrowser"));
            }
            return webBrowserConfiguration;
        }

        public static void Set(IConfigurationReader configurationReader)
        {
            webBrowserConfiguration = new WebBrowserConfiguration();
            configurationReader.FillConfigurationFromReader(webBrowserConfiguration);
        }
    }
}
