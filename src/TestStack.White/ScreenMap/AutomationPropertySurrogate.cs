using System.Runtime.Serialization;

namespace TestStack.White.ScreenMap
{
    [DataContract]
    public class AutomationPropertySurrogate
    {
        [DataMember]
        public virtual int AutomationId { get; set; }
    }
}