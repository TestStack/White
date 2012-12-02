namespace Core.UIItems
{
    public class Error
    {
        private string message;

        public Error(string message)
        {
            this.message = message;
        }

        public virtual string Message
        {
            get { return message; }
        }
    }
}