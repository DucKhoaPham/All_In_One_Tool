using System;
using System.Collections.Generic;
using System.Text;

namespace QI.Core.Extension
{
    public static class StringExtension
    {
        public static string ToNormalizeLower(this string value)
        {
            if (!string.IsNullOrEmpty(value))
                return value.Trim().ToLower().Normalize(NormalizationForm.FormKD).Replace("  ", " ");
            return value;
        }
    }
}
