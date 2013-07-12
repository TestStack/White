using System.Runtime.Serialization;

namespace TestStack.White.ScreenMap
{
    [DataContract]
    public class ControlTypeSurrogate
    {
        [DataMember]
        public virtual int ControlTypeId { get; set; }
    }
}