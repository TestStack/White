namespace White.Repository.Services
{
    public class LastServiceCallStatus
    {
        private readonly object returnValue;

        public LastServiceCallStatus(object returnValue)
        {
            this.returnValue = returnValue;
        }

        protected LastServiceCallStatus() {}

        public virtual bool WasExecuted
        {
            get { return true; }
        }

        public virtual object ReturnValue
        {
            get { return returnValue; }
        }
    }

    public class NullLastServiceCallStatus : LastServiceCallStatus
    {
        public override bool WasExecuted
        {
            get { return false; }
        }

        public override object ReturnValue
        {
            get { return null; }
        }
    }
}