namespace QI.Core.Extension
{
    public static class BooleanExtension
    {
        public static string ToBitString(this bool value)
        {
            return value ? "1" : "0";
        }

        public static string ToBitString(this bool? value)
        {
            return value == true ? "1" : "0";
        }
    }
}
