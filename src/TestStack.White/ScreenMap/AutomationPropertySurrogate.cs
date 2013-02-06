using System.Runtime.Serialization;

namespace White.Core.ScreenMap
{
    [DataContract]
    public class AutomationPropertySurrogate
    {
        [DataMember]
        public virtual int AutomationId { get; set; }
    }
}