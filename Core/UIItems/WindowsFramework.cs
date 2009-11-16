using Bricks.Core;

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
            get { return frameworkId.Equals(Constants.WinFormFrameworkId); }
        }

        public virtual bool WPF
        {
            get { return frameworkId.Equals(Constants.WPFFrameworkId); }
        }

        public virtual bool Win32
        {
            get { return frameworkId.Equals(Constants.Win32FrameworkId); }
        }

        public virtual bool UIAutomationBug
        {
            get { return S.IsEmpty(frameworkId); }
        }

        public override string ToString()
        {
            return frameworkId;
        }
    }
}