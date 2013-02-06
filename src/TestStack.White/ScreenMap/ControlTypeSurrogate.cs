using System.Runtime.Serialization;

namespace White.Core.ScreenMap
{
    [DataContract]
    public class ControlTypeSurrogate
    {
        [DataMember]
        public virtual int ControlTypeId { get; set; }
    }
}