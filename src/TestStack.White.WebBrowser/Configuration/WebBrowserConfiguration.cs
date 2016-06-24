using System.Collections.Generic;
using TestStack.White.Configuration;

namespace TestStack.White.WebBrowser.Configuration
{
    public class WebBrowserConfiguration : ConfigurationBase<WebBrowserConfiguration>
    {
        private const string FirefoxSingleWindowCheckWaitKey = "FirefoxSingleWindowCheckWait";

        public override Dictionary<string, object> DefaultValues
        {
            get
            {
                return new Dictionary<string, object>
                {
                    {FirefoxSingleWindowCheckWaitKey, 2000}
                };
            }
        }

        public virtual int FirefoxSingleWindowCheckWait
        {
            get { return GetValueInt32(FirefoxSingleWindowCheckWaitKey); }
            set { SetValue(FirefoxSingleWindowCheckWaitKey, value); }
        }
    }
}