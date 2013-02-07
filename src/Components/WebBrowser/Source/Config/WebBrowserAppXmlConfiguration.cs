using System;
using System.Collections.Generic;
using White.Core.Bricks;
using White.Core.Configuration;

namespace White.WebBrowser.Config
{
    public class WebBrowserAppXmlConfiguration : AssemblyConfiguration, WebBrowserConfiguration
    {
        private static readonly Dictionary<string, object> DefaultValues = new Dictionary<string, object>();
        private static WebBrowserConfiguration instance;

        static WebBrowserAppXmlConfiguration()
        {
            DefaultValues.Add("FirefoxSingleWindowCheckWait", 2000);
        }

        private WebBrowserAppXmlConfiguration() : base("White", "WebBrowser", DefaultValues, 
            CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(WebBrowserAppXmlConfiguration))){}

        public static WebBrowserConfiguration Instance
        {
            get { return instance ?? (instance = new WebBrowserAppXmlConfiguration()); }
        }

        public virtual int FirefoxSingleWindowCheckWait
        {
            get { return Convert.ToInt32(UsedValues["FirefoxSingleWindowCheckWait"]); }
        }
    }
}