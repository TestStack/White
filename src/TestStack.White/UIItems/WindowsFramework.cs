namespace TestStack.White.UIItems
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
            get { return IsWinForms || IsWpf; }
        }

        public virtual bool IsWinForms
        {
            get { return FrameworkId.Equals(Constants.WinFormFrameworkId); }
        }

        public virtual bool IsWpf
        {
            get { return FrameworkId.Equals(Constants.WPFFrameworkId); }
        }

        public virtual bool IsWin32
        {
            get { return FrameworkId.Equals(Constants.Win32FrameworkId); }
        }

        public virtual bool IsSilverlight
        {
            get { return FrameworkId.Equals(Constants.SilverlightFrameworkId); }
        }

        public virtual bool UIAutomationBug
        {
            get { return string.IsNullOrEmpty(FrameworkId) || FrameworkId.Trim() == string.Empty; }
        }

        public virtual string FrameworkId
        {
            get { return frameworkId; }
        }

        public static WindowsFramework Wpf
        {
            get{ return new WindowsFramework(Constants.WPFFrameworkId);}
        }

        public static WindowsFramework Win32
        {
            get { return new WindowsFramework(Constants.Win32FrameworkId); }
        }

        public static WindowsFramework WinForms
        {
            get { return new WindowsFramework(Constants.WinFormFrameworkId); }
        }

        public static WindowsFramework Silverlight
        {
            get { return new WindowsFramework(Constants.SilverlightFrameworkId); }
        }

        public static implicit operator string(WindowsFramework framework)
        {
            return framework.FrameworkId;
        }

        protected bool Equals(WindowsFramework other)
        {
            return string.Equals(frameworkId, other.frameworkId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WindowsFramework) obj);
        }

        public override int GetHashCode()
        {
            return (frameworkId != null ? frameworkId.GetHashCode() : 0);
        }

        public static bool operator ==(WindowsFramework left, WindowsFramework right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WindowsFramework left, WindowsFramework right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return FrameworkId;
        }
    }
}