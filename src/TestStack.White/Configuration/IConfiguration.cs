using System.Collections.Generic;

namespace TestStack.White.Configuration
{
    public interface IConfiguration
    {
        void SetValue(string key, object value);
        string GetValue(string key);
        Dictionary<string, object> DefaultValues { get; }
    }
}
