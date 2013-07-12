using System;
using System.Globalization;
using Castle.Core.Logging;

namespace TestStack.White.Configuration
{
    class WhiteDefaultLogger : LevelFilteredLogger
    {
        public WhiteDefaultLogger() { }

        public WhiteDefaultLogger(string name)
            : base(name)
        {
        }

        public WhiteDefaultLogger(LoggerLevel loggerLevel)
            : base(loggerLevel)
        {
        }

        public WhiteDefaultLogger(string loggerName, LoggerLevel loggerLevel)
            : base(loggerName, loggerLevel)
        {
        }

        public override ILogger CreateChildLogger(string loggerName)
        {
            if (loggerName == null)
                throw new ArgumentNullException("loggerName", "To create a child logger you must supply a non null name");
            return new ConsoleLogger(string.Format(CultureInfo.CurrentCulture, "{0}.{1}", new object[]
            {
                Name,
                loggerName
            }), Level);

        }

        protected override void Log(LoggerLevel loggerLevel, string loggerName, string message, Exception exception)
        {
            Console.Out.WriteLine("[{0} - {3}] '{1}' {2}", loggerLevel, loggerName, message, DateTime.Now.ToLongTimeString());
            if (exception == null)
                return;
            Console.Out.WriteLine("[{0} - {5}] '{1}' {2}: {3} {4}", loggerLevel, loggerName,
                exception.GetType().FullName, exception.Message, exception.StackTrace, DateTime.Now.ToLongTimeString());
        }
    }
}