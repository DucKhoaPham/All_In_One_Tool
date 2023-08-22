using System.Globalization;

namespace QI.Core.Extension
{
    public static class DecimalExtension
    {
        public static string ToString2VN(this decimal? value)
        {
            return value.HasValue ? value.Value.ToString("##.0", new CultureInfo("en-US", false)) : null;
        }

        public static string ToString2VN(this decimal value)
        {
            return value.ToString("##.00", new CultureInfo("en-US", false));
        }
    }
}
