using System;

//TODO: Programmatically change the csproj file to make jpeg and designer.cs or visual studio plugin should do this
namespace White.Repository.ScreenFlow
{
    public class GraphWriter
    {
        private readonly StringGraphWriter writer;

        public GraphWriter(string fileName)
        {
            writer = new StringGraphWriter(fileName);
        }

        public virtual void Start(Type screenType)
        {
            writer.Start(screenType.Name);
        }

        public virtual void Stop(Type screenType)
        {
            writer.Stop(screenType.Name);
        }

        public virtual void AppendFlow(Type fromType, Type toType)
        {
            writer.AppendFlow(fromType.Name, toType.Name);
        }

        public virtual void AppendError()
        {
            writer.AppendError();
        }
    }
}