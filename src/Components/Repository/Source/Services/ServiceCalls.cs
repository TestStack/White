using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Services
{
    public class ServiceCalls : List<ServiceCall>
    {
        public ServiceCalls(IEnumerable entities) : base(entities.OfType<ServiceCall>()) {}
        public ServiceCalls() {}

        public virtual ServiceCalls Matching(ServiceCall match)
        {
            return new ServiceCalls(FindAll(obj => obj.Equals(match)));
        }
    }
}