using System;

namespace TestStack.White.WebBrowser.Configuration
{
    public static class WebBrowserConfigurationLocator
    {
        private static IWebBrowserConfiguration webBrowserConfiguration;

        public static IWebBrowserConfiguration Get()
        {
            if (webBrowserConfiguration == null)
            {
                webBrowserConfiguration = new WebBrowserAppXmlConfiguration();
            }
            return webBrowserConfiguration;
        }

        public static void Register(IWebBrowserConfiguration webBrowserConfiguration)
        {
            WebBrowserConfigurationLocator.webBrowserConfiguration = webBrowserConfiguration;
        }
    }
}
