using System;

namespace Repository.ScreenFlow
{
    public class FlowWriter
    {
        private readonly StringGraphWriter writer;

        public FlowWriter(string fileName)
        {
            writer = new StringGraphWriter(fileName);
        }

        public virtual void Start(int step, Type screenType)
        {
            writer.Start(StepName(step, screenType));
        }

        private static string StepName(int step, Type screenType)
        {
            return string.Format("{0}_{1}",step,screenType.Name);
        }

        public virtual void Stop(int step, Type screenType)
        {
            writer.Stop(StepName(step, screenType));
        }

        public virtual void AppendFlow(int step, Type fromType, Type toType)
        {
            writer.AppendFlow(StepName(step, fromType), StepName(step+1,toType));
        }

        public virtual void AppendError()
        {
            writer.AppendError();
        }
    }
}