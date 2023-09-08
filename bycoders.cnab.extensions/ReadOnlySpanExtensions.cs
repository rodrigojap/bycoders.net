namespace bycoders.cnab.extensions
{
    public static class ReadOnlySpanExtensions
    {
        public static int IntegerSlice(this ReadOnlySpan<char> Current, int Start, int End)
        {
            return int.Parse(Current.Slice(Start, End));
        }

        public static double DoubleSlice(this ReadOnlySpan<char> Current, int Start, int End)
        {
            return double.Parse(Current.Slice(Start, End));
        }

        public static string StringSlice(this ReadOnlySpan<char> Current, int Start, int End)
        {
            return Current.Slice(Start, End).ToString().Trim();
        }
    }
}