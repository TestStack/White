using System;

namespace White.CustomControls.Automation
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class PeerRepositoryAttribute : Attribute
    {
        private readonly Type peerFactoryType;

        public PeerRepositoryAttribute(Type peerFactoryType)
        {
            this.peerFactoryType = peerFactoryType;
        }

        public virtual Type PeerFactory
        {
            get { return peerFactoryType; }
        }
    }
}