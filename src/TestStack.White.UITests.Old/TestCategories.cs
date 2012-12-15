using NUnit.Framework;

namespace White.Core.UITests
{
    public class WinFormCategory : CategoryAttribute
    {
        public WinFormCategory() : base("WinForm") {}
    }

    public class WPFCategory : CategoryAttribute
    {
        public WPFCategory() : base("WPF") {}
    }

    public class SWTCategory : CategoryAttribute
    {
        public SWTCategory() : base("SWT") {}
    }

    public class NormalCategory : CategoryAttribute
    {
        public NormalCategory() : base("Normal") {}
    }
}