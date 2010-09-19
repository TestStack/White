using System;

namespace Repository.ScreenFlow
{
    //TODO: Reporting of graph can be done on web
    public class WorkReport : ScreenRepositoryListener
    {
        private readonly WorkFlow workFlow;
        private ScreenIdentity current;

        public WorkReport(WorkFlow workFlow)
        {
            this.workFlow = workFlow;
        }

        void ScreenRepositoryListener.NewScreen(Type screenType, string title)
        {
            workFlow.Track();
            ScreenIdentity requested = new ScreenIdentity(screenType, title);
            if (current == null)
            {
                current = requested;
                return;
            }
            workFlow.Move(current.Type,requested.Type);
            current = requested;
        }

        void ScreenRepositoryListener.MessageBox(string title)
        {
            workFlow.Track();
        }

        void ScreenRepositoryListener.Disposing()
        {
            workFlow.Stop();
        }

        public virtual void ScreenChanged()
        {
            workFlow.Track();
        }
    }
}