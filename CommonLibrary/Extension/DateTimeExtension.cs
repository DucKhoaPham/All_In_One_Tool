using System;

namespace QI.Core.Extension
{
    public static class DateTimeExtension
    {
        public static string ToStringDMY(this DateTime? value)
        {
            return value.HasValue ? value.Value.ToString("dd/MM/yyyy") : null;
        }

        public static string ToStringDMYHHmm(this DateTime? value)
        {
            return value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : null;
        }

        public static string ToStringDMY(this DateTime value)
        {
            return value.ToString("dd/MM/yyyy");
        }
    }
}
