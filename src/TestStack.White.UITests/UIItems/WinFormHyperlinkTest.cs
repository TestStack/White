using NUnit.Framework;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class WinFormHyperlinkTest : HyperlinkTest {}

    [TestFixture, SWTCategory, Ignore]
    public class SWTHyperlinkTest : HyperlinkTest {}
}