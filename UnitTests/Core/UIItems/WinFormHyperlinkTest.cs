using NUnit.Framework;

namespace White.Core.UIItems
{
    [TestFixture, WinFormCategory]
    public class WinFormHyperlinkTest : HyperlinkTest {}

    [TestFixture, SWTCategory]
    public class SWTHyperlinkTest : HyperlinkTest {}
}