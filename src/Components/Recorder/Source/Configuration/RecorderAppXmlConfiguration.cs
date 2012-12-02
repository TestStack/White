using System.Collections.Generic;
using Bricks;
using log4net;

namespace Recorder.Configuration
{
    public class RecorderAppXmlConfiguration : AssemblyConfiguration, RecorderConfiguration
    {
        public static RecorderAppXmlConfiguration instance;
        private static readonly Dictionary<string, object> DefaultValues = new Dictionary<string, object>();

        public static RecorderAppXmlConfiguration Instance
        {
            get
            {
                if (instance == null) instance = new RecorderAppXmlConfiguration();
                return instance;
            }
        }

        private RecorderAppXmlConfiguration()
            : base("White", "Recorder", DefaultValues, LogManager.GetLogger(typeof(RecorderAppXmlConfiguration)))
        {
        }
    }
}