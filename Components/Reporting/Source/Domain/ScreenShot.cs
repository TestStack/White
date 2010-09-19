namespace Reporting.Domain
{
    public class ScreenShot
    {
        private readonly string snapShotPath;
        private readonly string thumbNailPath;

        public ScreenShot(string snapShotPath, string thumbNailPath)
        {
            this.snapShotPath = snapShotPath;
            this.thumbNailPath = thumbNailPath;
        }

        public virtual string SnapShotPath
        {
            get { return snapShotPath; }
        }

        public virtual string ThumbNailPath
        {
            get { return thumbNailPath; }
        }
    }
}