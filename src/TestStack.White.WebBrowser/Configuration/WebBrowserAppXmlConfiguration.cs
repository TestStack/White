using System;
using System.Collections.Generic;
using TestStack.White.Bricks;
using TestStack.White.Configuration;

namespace TestStack.White.WebBrowser.Configuration
{
    public class WebBrowserAppXmlConfiguration : AssemblyConfiguration, IWebBrowserConfiguration
    {
        private static readonly Dictionary<string, object> DefaultValues = new Dictionary<string, object>();
        private static IWebBrowserConfiguration instance;

        static WebBrowserAppXmlConfiguration()
        {
            DefaultValues.Add("FirefoxSingleWindowCheckWait", 2000);
        }

        private WebBrowserAppXmlConfiguration() : base("White", "WebBrowser", DefaultValues, 
            CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(WebBrowserAppXmlConfiguration))){}

        public static IWebBrowserConfiguration Instance
        {
            get { return instance ?? (instance = new WebBrowserAppXmlConfiguration()); }
        }

        public virtual int FirefoxSingleWindowCheckWait
        {
            get { return Convert.ToInt32(UsedValues["FirefoxSingleWindowCheckWait"]); }
        }
    }
}