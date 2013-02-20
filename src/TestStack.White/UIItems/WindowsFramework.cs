namespace White.Core.UIItems
{
    public class WindowsFramework
    {
        private readonly string frameworkId;

        public WindowsFramework(string frameworkId)
        {
            this.frameworkId = frameworkId;
        }

        public virtual bool IsManaged
        {
            get { return WinForm || WPF; }
        }

        public virtual bool WinForm
        {
            get { return FrameworkId.Equals(Constants.WinFormFrameworkId); }
        }

        public virtual bool WPF
        {
            get { return FrameworkId.Equals(Constants.WPFFrameworkId); }
        }

        public virtual bool Win32
        {
            get { return FrameworkId.Equals(Constants.Win32FrameworkId); }
        }

        public virtual bool UIAutomationBug
        {
            get { return string.IsNullOrEmpty(FrameworkId) || FrameworkId.Trim() == string.Empty; }
        }

        public virtual bool Silverlight
        {
            get { return FrameworkId.Equals(Constants.SilverlightFrameworkId); }
        }

        public virtual string FrameworkId
        {
            get { return frameworkId; }
        }

        public override string ToString()
        {
            return FrameworkId;
        }
    }
}