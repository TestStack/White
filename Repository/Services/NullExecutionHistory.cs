namespace Repository.Services
{
    public class NullExecutionHistory : ExecutionHistory
    {
        public override void Add(ServiceCall serviceCall) {}

        public override ServiceCalls FindCalls(ServiceCall match)
        {
            return new ServiceCalls();
        }

        public override object Data
        {
            get { return null; }
            set { }
        }

        public override object LastSnapshot
        {
            set { }
            get { return null; }
        }

        public override bool HasError
        {
            get { return false; }
            set {}
        }
    }
}