using NUnit.Framework;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class WinFormHyperlinkTest : HyperlinkTest {}

    [TestFixture, SWTCategory]
    public class SWTHyperlinkTest : HyperlinkTest {}
}