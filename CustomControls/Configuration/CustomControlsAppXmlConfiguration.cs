using System.Collections.Generic;
using System.Configuration;

namespace White.WPFCustomControls.Configuration
{
    public class CustomControlsAppXmlConfiguration : CustomControlsConfiguration
    {
        private static CustomControlsConfiguration instance;
        private readonly Dictionary<string, string> usedValues = new Dictionary<string, string>();
        private const string WhitePeersAssemblyKey = "WhitePeersAssembly";
        private const string CustomPeersAssemblyKey = "CustomPeersAssembly";

        public static CustomControlsConfiguration Instance
        {
            get
            {
                if (instance == null) instance = new CustomControlsAppXmlConfiguration();
                return instance;
            }
        }

        private CustomControlsAppXmlConfiguration()
        {
            CustomPeersAssembly = ConfigurationManager.AppSettings[CustomPeersAssemblyKey];
        }

        public virtual string WhitePeersAssembly
        {
            get { return usedValues[WhitePeersAssemblyKey]; }
            set { usedValues[WhitePeersAssemblyKey] = value; }
        }

        public virtual string CustomPeersAssembly
        {
            get { return usedValues[CustomPeersAssemblyKey]; }
            set { usedValues[CustomPeersAssemblyKey] = value; }
        }
    }
}