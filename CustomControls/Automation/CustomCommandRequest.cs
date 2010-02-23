using System.Collections.Generic;

namespace White.CustomControls.Automation
{
    public class CustomCommandRequest
    {
        private readonly object[] request;

        public CustomCommandRequest(object[] request)
        {
            this.request = request;
        }

        public virtual bool IsLoadAssemblyCommand
        {
            get { return request[1] is byte[]; }
        }

        public virtual string AssemblyName
        {
            get { return (string) request[0]; }
        }

        public virtual byte[] AssemblyContents
        {
            get { return (byte[]) request[1]; }
        }

        public virtual string Payload
        {
            get { return (string) request[1]; }
        }
    }
}