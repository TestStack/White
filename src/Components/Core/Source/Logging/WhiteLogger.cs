using Bricks.Logging;
using log4net;

namespace White.Core.Logging
{
    public class WhiteLogger : BricksLogger
    {
        static WhiteLogger()
        {
            new WhiteLogger();
        }

        private WhiteLogger() {}
        public static readonly ILog Instance = LogManager.GetLogger("root");
    }
}