namespace White.Core.UITests.UIItems.TableItems
{
    [WinFormCategory]
    public class NoTableHeaderTest : AbstractTableTest
    {
        protected override string CommandLineArguments
        {
            get { return "notableheader"; }
        }
    }
}