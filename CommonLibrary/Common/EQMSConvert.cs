namespace QI.Core.Common
{
    public class EQMSConvert
    {
        public static string SoLuong(string soLuong)
        {
            if (string.IsNullOrEmpty(soLuong))
                return "0";
            if (soLuong == null)
                return null;
            if (soLuong.Equals("Rất tích cực", System.StringComparison.InvariantCultureIgnoreCase))
            {
                return "3";
            }
            else if (soLuong.Equals("Tích cực", System.StringComparison.InvariantCultureIgnoreCase))
            {
                return "2";
            }
            else if (soLuong.Equals("Không tích cực", System.StringComparison.InvariantCultureIgnoreCase))
            {
                return "1";
            }
            else if (soLuong.Equals("Chưa tích cực", System.StringComparison.InvariantCultureIgnoreCase))
            {
                return "1";
            }
            else if (soLuong.Equals("Có", System.StringComparison.InvariantCultureIgnoreCase))
            {
                return "1";
            }
            else if (soLuong.Equals("Không", System.StringComparison.InvariantCultureIgnoreCase))
            {
                return "0";
            }
            else if (soLuong.Equals("null", System.StringComparison.InvariantCultureIgnoreCase))
            {
                return "";
            }
            return soLuong;
        }
    }
}
