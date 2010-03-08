namespace White.Core.CustomCommands
{
    public class CustomCommandResponse
    {
        private readonly object[] objects;

        public CustomCommandResponse(object[] @objects)
        {
            this.objects = objects;
        }

        public virtual bool IsValidResponse
        {
            get { return objects.Length == 1; }
        }

        public virtual bool IsException
        {
            get { return IsNotValidResponse() && objects[0] != null; }
        }

        private bool IsNotValidResponse()
        {
            return objects != null && objects.Length == 2;
        }

        public virtual bool IsAssemblyNotFound
        {
            get { return IsNotValidResponse() && objects[0] == null; }
        }

        public virtual string Exception
        {
            get { return (string) objects[0]; }
        }

        public virtual object ReturnValue
        {
            get { return objects[0]; }
        }
    }
}