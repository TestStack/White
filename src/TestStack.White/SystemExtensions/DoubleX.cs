namespace White.Core.SystemExtensions
{
    public static class DoubleX
    {
        public static bool IsInvalid(this double @double)
        {
            return @double == double.PositiveInfinity || @double == double.NegativeInfinity || double.IsNaN(@double);
        }
    }
}