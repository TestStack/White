using TestStack.White.Configuration;

namespace TestStack.White
{
    public static class Constants
    {
        public static string BusyMessage
        {
            get { return string.Format(", after waiting for {0} ms", CoreConfigurationLocator.Get().BusyTimeout); }
        }
    }
}