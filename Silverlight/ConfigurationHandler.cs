using System.Configuration;
using System.Xml;
using Core.Factory;
using White.Web.Browsers;

namespace White.Web
{
    public class ConfigurationHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            WindowFactory.AddSpecializedWindowFactory(new BrowserWindowFactory());

            NameValueSectionHandler sectionHandler = new NameValueSectionHandler();
            return sectionHandler.Create(parent, configContext, section);
        }
    }
}