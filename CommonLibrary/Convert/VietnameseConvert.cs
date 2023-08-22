using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ConvertDB;

namespace CommonLibrary.Convert
{
    public static class VietnameseConvert
    {
        public static string GetDayOfWeekLocalize(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Thứ hai";
                case DayOfWeek.Tuesday:
                    return "Thứ ba";
                case DayOfWeek.Wednesday:
                    return "Thứ tư";
                case DayOfWeek.Thursday:
                    return "Thứ năm";
                case DayOfWeek.Friday:
                    return "Thứ sáu";
                case DayOfWeek.Saturday:
                    return "Thứ bảy";
                case DayOfWeek.Sunday:
                    return "Chủ nhật";
            }

            return "";
        }

        public static bool CheckUnicodeContains(string compareSource, string compareExpression)
        {
            if (!string.IsNullOrEmpty(compareSource) && !string.IsNullOrEmpty(compareExpression))
            {
                return CultureInfo.InvariantCulture.CompareInfo.IndexOf(
                    VietnameseConvert.RemoveDiacritics(compareSource),
                    VietnameseConvert.RemoveDiacritics(compareExpression),
                    CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) > -1;
            }
            return false;
        }

        public static string RemoveDiacritics(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                string formD = text.Normalize(NormalizationForm.FormD);
                StringBuilder builder = new StringBuilder();

                foreach (char ch in formD)
                {
                    UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                    if (uc != UnicodeCategory.NonSpacingMark)
                    {
                        builder.Append(ch);
                    }
                }

                //-- unicode chuẩn
                builder.Replace("Á", "A");
                builder.Replace("À", "A");
                builder.Replace("Ả", "A");
                builder.Replace("Ã", "A");
                builder.Replace("Ạ", "A");
                builder.Replace("Ả", "A");
                //-- unicode tổ hợp
                builder.Replace("Á", "A");
                builder.Replace("À", "A");
                builder.Replace("Ả", "A");
                builder.Replace("Ã", "A");
                builder.Replace("Ạ", "A");

                //-- unicode chuẩn
                builder.Replace("Â", "A");
                builder.Replace("Ấ", "A");
                builder.Replace("Ầ", "A");
                builder.Replace("Ẩ", "A");
                builder.Replace("Ẫ", "A");
                builder.Replace("Ậ", "A");
                //-- unicode tổ hợp
                builder.Replace("Â", "A");
                builder.Replace("Ấ", "A");
                builder.Replace("Ầ", "A");
                builder.Replace("Ẩ", "A");
                builder.Replace("Ẫ", "A");
                builder.Replace("Ậ", "A");

                //-- unicode chuẩn
                builder.Replace("Ă", "A");
                builder.Replace("Ắ", "A");
                builder.Replace("Ằ", "A");
                builder.Replace("Ẳ", "A");
                builder.Replace("Ẵ", "A");
                builder.Replace("Ặ", "A");
                //-- unicode tổ hợp
                builder.Replace("Ă", "A");
                builder.Replace("Ắ", "A");
                builder.Replace("Ằ", "A");
                builder.Replace("Ẳ", "A");
                builder.Replace("Ẵ", "A");
                builder.Replace("Ặ", "A");

                //-- unicode chuẩn
                builder.Replace("É", "E");
                builder.Replace("È", "E");
                builder.Replace("Ẻ", "E");
                builder.Replace("Ẽ", "E");
                builder.Replace("Ẹ", "E");
                //-- unicode tổ hợp
                builder.Replace("É", "E");
                builder.Replace("È", "E");
                builder.Replace("Ẻ", "E");
                builder.Replace("Ẽ", "E");
                builder.Replace("Ẹ", "E");

                //-- unicode chuẩn
                builder.Replace("Ê", "E");
                builder.Replace("Ế", "E");
                builder.Replace("Ề", "E");
                builder.Replace("Ể", "E");
                builder.Replace("Ễ", "E");
                builder.Replace("Ệ", "E");
                //-- unicode tổ hợp
                builder.Replace("Ê", "E");
                builder.Replace("Ế", "E");
                builder.Replace("Ề", "E");
                builder.Replace("Ể", "E");
                builder.Replace("Ễ", "E");
                builder.Replace("Ệ", "E");

                //-- unicode chuẩn
                builder.Replace("Í", "I");
                builder.Replace("Ì", "I");
                builder.Replace("Ỉ", "I");
                builder.Replace("Ĩ", "I");
                builder.Replace("Ị", "I");
                //-- unicode tổ hợp
                builder.Replace("Í", "I");
                builder.Replace("Ì", "I");
                builder.Replace("Ỉ", "I");
                builder.Replace("Ĩ", "I");
                builder.Replace("Ị", "I");

                //-- unicode chuẩn
                builder.Replace("Ó", "O");
                builder.Replace("Ò", "O");
                builder.Replace("Ỏ", "O");
                builder.Replace("Õ", "O");
                builder.Replace("Ọ", "O");
                //-- unicode tổ hợp
                builder.Replace("Ó", "O");
                builder.Replace("Ò", "O");
                builder.Replace("Ỏ", "O");
                builder.Replace("Õ", "O");
                builder.Replace("Ọ", "O");

                //-- unicode chuẩn
                builder.Replace("Ô", "O");
                builder.Replace("Ố", "O");
                builder.Replace("Ồ", "O");
                builder.Replace("Ổ", "O");
                builder.Replace("Ỗ", "O");
                builder.Replace("Ộ", "O");
                //-- unicode tổ hợp
                builder.Replace("Ô", "O");
                builder.Replace("Ố", "O");
                builder.Replace("Ồ", "O");
                builder.Replace("Ổ", "O");
                builder.Replace("Ỗ", "O");
                builder.Replace("Ộ", "O");

                //-- unicode chuẩn
                builder.Replace("Ơ", "O");
                builder.Replace("Ớ", "O");
                builder.Replace("Ờ", "O");
                builder.Replace("Ở", "O");
                builder.Replace("Ỡ", "O");
                builder.Replace("Ợ", "O");
                //-- unicode tổ hợp
                builder.Replace("Ơ", "O");
                builder.Replace("Ớ", "O");
                builder.Replace("Ờ", "O");
                builder.Replace("Ở", "O");
                builder.Replace("Ỡ", "O");
                builder.Replace("Ợ", "O");

                //-- unicode chuẩn
                builder.Replace("Ú", "U");
                builder.Replace("Ù", "U");
                builder.Replace("Ủ", "U");
                builder.Replace("Ũ", "U");
                builder.Replace("Ụ", "U");
                //-- unicode tổ hợp
                builder.Replace("Ú", "U");
                builder.Replace("Ù", "U");
                builder.Replace("Ủ", "U");
                builder.Replace("Ũ", "U");
                builder.Replace("Ụ", "U");

                //-- unicode chuẩn
                builder.Replace("Ư", "U");
                builder.Replace("Ứ", "U");
                builder.Replace("Ừ", "U");
                builder.Replace("Ử", "U");
                builder.Replace("Ữ", "U");
                builder.Replace("Ự", "U");
                //-- unicode tổ hợp
                builder.Replace("Ư", "U");
                builder.Replace("Ứ", "U");
                builder.Replace("Ừ", "U");
                builder.Replace("Ử", "U");
                builder.Replace("Ữ", "U");
                builder.Replace("Ự", "U");

                //-- unicode chuẩn
                builder.Replace("Ý", "Y");
                builder.Replace("Ỳ", "Y");
                builder.Replace("Ỷ", "Y");
                builder.Replace("Ỹ", "Y");
                builder.Replace("Ỵ", "Y");
                //-- unicode tổ hợp
                builder.Replace("Ý", "Y");
                builder.Replace("Ỳ", "Y");
                builder.Replace("Ỷ", "Y");
                builder.Replace("Ỹ", "Y");
                builder.Replace("Ỵ", "Y");

                //-- unicode chuẩn
                builder.Replace("Đ", "D");
                //-- unicode tổ hợp
                builder.Replace("Đ", "D");

                return builder.ToString().Normalize(NormalizationForm.FormC);
            }

            return text;
        }

        public static char[] RemoveVietnameseAccent(string value)
        {
            List<char> byteArr = new List<char>();
            foreach (var charItem in value.ToCharArray())
            {
                if (charItem == 'À') { byteArr.Add('A'); }
                else if (charItem == 'Á') { byteArr.Add('A'); }
                else if (charItem == 'Â') { byteArr.Add('A'); }
                else if (charItem == 'Ã') { byteArr.Add('A'); }
                else if (charItem == 'È') { byteArr.Add('E'); }
                else if (charItem == 'É') { byteArr.Add('E'); }
                else if (charItem == 'Ê') { byteArr.Add('E'); }
                else if (charItem == 'Ì') { byteArr.Add('I'); }
                else if (charItem == 'Í') { byteArr.Add('I'); }
                else if (charItem == 'Ò') { byteArr.Add('O'); }
                else if (charItem == 'Ó') { byteArr.Add('O'); }
                else if (charItem == 'Ô') { byteArr.Add('O'); }
                else if (charItem == 'Õ') { byteArr.Add('O'); }
                else if (charItem == 'Ù') { byteArr.Add('U'); }
                else if (charItem == 'Ú') { byteArr.Add('U'); }
                else if (charItem == 'Ý') { byteArr.Add('Y'); }
                else if (charItem == 'à') { byteArr.Add('a'); }
                else if (charItem == 'á') { byteArr.Add('a'); }
                else if (charItem == 'â') { byteArr.Add('a'); }
                else if (charItem == 'ã') { byteArr.Add('a'); }
                else if (charItem == 'è') { byteArr.Add('e'); }
                else if (charItem == 'é') { byteArr.Add('e'); }
                else if (charItem == 'ê') { byteArr.Add('e'); }
                else if (charItem == 'ì') { byteArr.Add('i'); }
                else if (charItem == 'í') { byteArr.Add('i'); }
                else if (charItem == 'ò') { byteArr.Add('o'); }
                else if (charItem == 'ó') { byteArr.Add('o'); }
                else if (charItem == 'ô') { byteArr.Add('o'); }
                else if (charItem == 'õ') { byteArr.Add('o'); }
                else if (charItem == 'ù') { byteArr.Add('u'); }
                else if (charItem == 'ú') { byteArr.Add('u'); }
                else if (charItem == 'ý') { byteArr.Add('y'); }
                else if (charItem == 'Ă') { byteArr.Add('A'); }
                else if (charItem == 'ă') { byteArr.Add('a'); }
                else if (charItem == 'Đ') { byteArr.Add('D'); }
                else if (charItem == 'đ') { byteArr.Add('d'); }
                else if (charItem == 'Ĩ') { byteArr.Add('I'); }
                else if (charItem == 'ĩ') { byteArr.Add('i'); }
                else if (charItem == 'Ũ') { byteArr.Add('U'); }
                else if (charItem == 'ũ') { byteArr.Add('u'); }
                else if (charItem == 'Ơ') { byteArr.Add('O'); }
                else if (charItem == 'ơ') { byteArr.Add('o'); }
                else if (charItem == 'Ư') { byteArr.Add('U'); }
                else if (charItem == 'ư') { byteArr.Add('u'); }
                else if (charItem == 'Ạ') { byteArr.Add('A'); }
                else if (charItem == 'ạ') { byteArr.Add('a'); }
                else if (charItem == 'Ả') { byteArr.Add('A'); }
                else if (charItem == 'ả') { byteArr.Add('a'); }
                else if (charItem == 'Ấ') { byteArr.Add('A'); }
                else if (charItem == 'ấ') { byteArr.Add('a'); }
                else if (charItem == 'Ầ') { byteArr.Add('A'); }
                else if (charItem == 'ầ') { byteArr.Add('a'); }
                else if (charItem == 'Ẩ') { byteArr.Add('A'); }
                else if (charItem == 'ẩ') { byteArr.Add('a'); }
                else if (charItem == 'Ẫ') { byteArr.Add('A'); }
                else if (charItem == 'ẫ') { byteArr.Add('a'); }
                else if (charItem == 'Ậ') { byteArr.Add('A'); }
                else if (charItem == 'ậ') { byteArr.Add('a'); }
                else if (charItem == 'Ắ') { byteArr.Add('A'); }
                else if (charItem == 'ắ') { byteArr.Add('a'); }
                else if (charItem == 'Ằ') { byteArr.Add('A'); }
                else if (charItem == 'ằ') { byteArr.Add('a'); }
                else if (charItem == 'Ẳ') { byteArr.Add('A'); }
                else if (charItem == 'ẳ') { byteArr.Add('a'); }
                else if (charItem == 'Ẵ') { byteArr.Add('A'); }
                else if (charItem == 'ẵ') { byteArr.Add('a'); }
                else if (charItem == 'Ặ') { byteArr.Add('A'); }
                else if (charItem == 'ặ') { byteArr.Add('a'); }
                else if (charItem == 'Ẹ') { byteArr.Add('a'); }
                else if (charItem == 'ẹ') { byteArr.Add('e'); }
                else if (charItem == 'Ẻ') { byteArr.Add('E'); }
                else if (charItem == 'ẻ') { byteArr.Add('e'); }
                else if (charItem == 'Ẽ') { byteArr.Add('E'); }
                else if (charItem == 'ẽ') { byteArr.Add('e'); }
                else if (charItem == 'Ế') { byteArr.Add('E'); }
                else if (charItem == 'ế') { byteArr.Add('e'); }
                else if (charItem == 'Ề') { byteArr.Add('E'); }
                else if (charItem == 'ề') { byteArr.Add('e'); }
                else if (charItem == 'Ể') { byteArr.Add('E'); }
                else if (charItem == 'ể') { byteArr.Add('e'); }
                else if (charItem == 'Ễ') { byteArr.Add('E'); }
                else if (charItem == 'ễ') { byteArr.Add('e'); }
                else if (charItem == 'Ệ') { byteArr.Add('E'); }
                else if (charItem == 'ệ') { byteArr.Add('e'); }
                else if (charItem == 'Ỉ') { byteArr.Add('I'); }
                else if (charItem == 'ỉ') { byteArr.Add('i'); }
                else if (charItem == 'Ị') { byteArr.Add('I'); }
                else if (charItem == 'ị') { byteArr.Add('i'); }
                else if (charItem == 'Ọ') { byteArr.Add('O'); }
                else if (charItem == 'ọ') { byteArr.Add('o'); }
                else if (charItem == 'Ỏ') { byteArr.Add('O'); }
                else if (charItem == 'ỏ') { byteArr.Add('o'); }
                else if (charItem == 'Ố') { byteArr.Add('O'); }
                else if (charItem == 'ố') { byteArr.Add('o'); }
                else if (charItem == 'Ồ') { byteArr.Add('O'); }
                else if (charItem == 'ồ') { byteArr.Add('o'); }
                else if (charItem == 'Ổ') { byteArr.Add('O'); }
                else if (charItem == 'ổ') { byteArr.Add('o'); }
                else if (charItem == 'Ỗ') { byteArr.Add('O'); }
                else if (charItem == 'ỗ') { byteArr.Add('o'); }
                else if (charItem == 'Ộ') { byteArr.Add('O'); }
                else if (charItem == 'ộ') { byteArr.Add('o'); }
                else if (charItem == 'Ớ') { byteArr.Add('O'); }
                else if (charItem == 'ớ') { byteArr.Add('o'); }
                else if (charItem == 'Ờ') { byteArr.Add('O'); }
                else if (charItem == 'ờ') { byteArr.Add('o'); }
                else if (charItem == 'Ở') { byteArr.Add('O'); }
                else if (charItem == 'ở') { byteArr.Add('o'); }
                else if (charItem == 'Ỡ') { byteArr.Add('O'); }
                else if (charItem == 'ỡ') { byteArr.Add('o'); }
                else if (charItem == 'Ợ') { byteArr.Add('O'); }
                else if (charItem == 'ợ') { byteArr.Add('o'); }
                else if (charItem == 'Ụ') { byteArr.Add('U'); }
                else if (charItem == 'ụ') { byteArr.Add('u'); }
                else if (charItem == 'Ủ') { byteArr.Add('U'); }
                else if (charItem == 'ủ') { byteArr.Add('u'); }
                else if (charItem == 'Ứ') { byteArr.Add('U'); }
                else if (charItem == 'ứ') { byteArr.Add('u'); }
                else if (charItem == 'Ừ') { byteArr.Add('U'); }
                else if (charItem == 'ừ') { byteArr.Add('u'); }
                else if (charItem == 'Ử') { byteArr.Add('U'); }
                else if (charItem == 'ử') { byteArr.Add('u'); }
                else if (charItem == 'Ữ') { byteArr.Add('U'); }
                else if (charItem == 'ữ') { byteArr.Add('u'); }
                else if (charItem == 'Ự') { byteArr.Add('U'); }
                else if (charItem == 'ự') { byteArr.Add('u'); }
                else if (charItem == 'Ỳ') { byteArr.Add('Y'); }
                else if (charItem == 'ỳ') { byteArr.Add('y'); }
                else if (charItem == 'Ỵ') { byteArr.Add('Y'); }
                else if (charItem == 'ỵ') { byteArr.Add('y'); }
                else if (charItem == 'Ỷ') { byteArr.Add('Y'); }
                else if (charItem == 'ỷ') { byteArr.Add('y'); }
                else if (charItem == 'Ỹ') { byteArr.Add('Y'); }
                else if (charItem == 'ỹ') { byteArr.Add('y'); }
                else { byteArr.Add(charItem); }
            }

            return byteArr.ToArray();
        }

        public static char[] ConvertFromUnicodeToTCVN3(string value)
        {
            List<char> byteArr = new List<char>();
            foreach (var charItem in value.ToCharArray())
            {
                if (charItem == 'À') { byteArr.Add('µ'); }
                else if (charItem == 'Á') { byteArr.Add('¸'); }
                else if (charItem == 'Â') { byteArr.Add('¢'); }
                else if (charItem == 'Ã') { byteArr.Add('·'); }
                else if (charItem == 'È') { byteArr.Add('Ì'); }
                else if (charItem == 'É') { byteArr.Add('Ð'); }
                else if (charItem == 'Ê') { byteArr.Add('£'); }
                else if (charItem == 'Ì') { byteArr.Add('×'); }
                else if (charItem == 'Í') { byteArr.Add('Ý'); }
                else if (charItem == 'Ò') { byteArr.Add('ß'); }
                else if (charItem == 'Ó') { byteArr.Add('ã'); }
                else if (charItem == 'Ô') { byteArr.Add('¤'); }
                else if (charItem == 'Õ') { byteArr.Add('â'); }
                else if (charItem == 'Ù') { byteArr.Add('ï'); }
                else if (charItem == 'Ú') { byteArr.Add('ó'); }
                else if (charItem == 'Ý') { byteArr.Add('ý'); }
                else if (charItem == 'à') { byteArr.Add('µ'); }
                else if (charItem == 'á') { byteArr.Add('¸'); }
                else if (charItem == 'â') { byteArr.Add('©'); }
                else if (charItem == 'ã') { byteArr.Add('·'); }
                else if (charItem == 'è') { byteArr.Add('Ì'); }
                else if (charItem == 'é') { byteArr.Add('Ð'); }
                else if (charItem == 'ê') { byteArr.Add('ª'); }
                else if (charItem == 'ì') { byteArr.Add('×'); }
                else if (charItem == 'í') { byteArr.Add('Ý'); }
                else if (charItem == 'ò') { byteArr.Add('ß'); }
                else if (charItem == 'ó') { byteArr.Add('ã'); }
                else if (charItem == 'ô') { byteArr.Add('«'); }
                else if (charItem == 'õ') { byteArr.Add('â'); }
                else if (charItem == 'ù') { byteArr.Add('ï'); }
                else if (charItem == 'ú') { byteArr.Add('ó'); }
                else if (charItem == 'ý') { byteArr.Add('ý'); }
                else if (charItem == 'Ă') { byteArr.Add('¡'); }
                else if (charItem == 'ă') { byteArr.Add('¨'); }
                else if (charItem == 'Đ') { byteArr.Add('§'); }
                else if (charItem == 'đ') { byteArr.Add('®'); }
                else if (charItem == 'Ĩ') { byteArr.Add('Ü'); }
                else if (charItem == 'ĩ') { byteArr.Add('Ü'); }
                else if (charItem == 'Ũ') { byteArr.Add('ò'); }
                else if (charItem == 'ũ') { byteArr.Add('ò'); }
                else if (charItem == 'Ơ') { byteArr.Add('¥'); }
                else if (charItem == 'ơ') { byteArr.Add('¬'); }
                else if (charItem == 'Ư') { byteArr.Add('¦'); }
                else if (charItem == 'ư') { byteArr.Add('­'); }
                else if (charItem == 'Ạ') { byteArr.Add('¹'); }
                else if (charItem == 'ạ') { byteArr.Add('¹'); }
                else if (charItem == 'Ả') { byteArr.Add('¶'); }
                else if (charItem == 'ả') { byteArr.Add('¶'); }
                else if (charItem == 'Ấ') { byteArr.Add('Ê'); }
                else if (charItem == 'ấ') { byteArr.Add('Ê'); }
                else if (charItem == 'Ầ') { byteArr.Add('Ç'); }
                else if (charItem == 'ầ') { byteArr.Add('Ç'); }
                else if (charItem == 'Ẩ') { byteArr.Add('È'); }
                else if (charItem == 'ẩ') { byteArr.Add('È'); }
                else if (charItem == 'Ẫ') { byteArr.Add('É'); }
                else if (charItem == 'ẫ') { byteArr.Add('É'); }
                else if (charItem == 'Ậ') { byteArr.Add('Ë'); }
                else if (charItem == 'ậ') { byteArr.Add('Ë'); }
                else if (charItem == 'Ắ') { byteArr.Add('¾'); }
                else if (charItem == 'ắ') { byteArr.Add('¾'); }
                else if (charItem == 'Ằ') { byteArr.Add('»'); }
                else if (charItem == 'ằ') { byteArr.Add('»'); }
                else if (charItem == 'Ẳ') { byteArr.Add('¼'); }
                else if (charItem == 'ẳ') { byteArr.Add('¼'); }
                else if (charItem == 'Ẵ') { byteArr.Add('½'); }
                else if (charItem == 'ẵ') { byteArr.Add('½'); }
                else if (charItem == 'Ặ') { byteArr.Add('Æ'); }
                else if (charItem == 'ặ') { byteArr.Add('Æ'); }
                else if (charItem == 'Ẹ') { byteArr.Add('Ñ'); }
                else if (charItem == 'ẹ') { byteArr.Add('Ñ'); }
                else if (charItem == 'Ẻ') { byteArr.Add('Î'); }
                else if (charItem == 'ẻ') { byteArr.Add('Î'); }
                else if (charItem == 'Ẽ') { byteArr.Add('Ï'); }
                else if (charItem == 'ẽ') { byteArr.Add('Ï'); }
                else if (charItem == 'Ế') { byteArr.Add('Õ'); }
                else if (charItem == 'ế') { byteArr.Add('Õ'); }
                else if (charItem == 'Ề') { byteArr.Add('Ò'); }
                else if (charItem == 'ề') { byteArr.Add('Ò'); }
                else if (charItem == 'Ể') { byteArr.Add('Ó'); }
                else if (charItem == 'ể') { byteArr.Add('Ó'); }
                else if (charItem == 'Ễ') { byteArr.Add('Ô'); }
                else if (charItem == 'ễ') { byteArr.Add('Ô'); }
                else if (charItem == 'Ệ') { byteArr.Add('Ö'); }
                else if (charItem == 'ệ') { byteArr.Add('Ö'); }
                else if (charItem == 'Ỉ') { byteArr.Add('Ø'); }
                else if (charItem == 'ỉ') { byteArr.Add('Ø'); }
                else if (charItem == 'Ị') { byteArr.Add('Þ'); }
                else if (charItem == 'ị') { byteArr.Add('Þ'); }
                else if (charItem == 'Ọ') { byteArr.Add('ä'); }
                else if (charItem == 'ọ') { byteArr.Add('ä'); }
                else if (charItem == 'Ỏ') { byteArr.Add('á'); }
                else if (charItem == 'ỏ') { byteArr.Add('á'); }
                else if (charItem == 'Ố') { byteArr.Add('è'); }
                else if (charItem == 'ố') { byteArr.Add('è'); }
                else if (charItem == 'Ồ') { byteArr.Add('å'); }
                else if (charItem == 'ồ') { byteArr.Add('å'); }
                else if (charItem == 'Ổ') { byteArr.Add('æ'); }
                else if (charItem == 'ổ') { byteArr.Add('æ'); }
                else if (charItem == 'Ỗ') { byteArr.Add('ç'); }
                else if (charItem == 'ỗ') { byteArr.Add('ç'); }
                else if (charItem == 'Ộ') { byteArr.Add('é'); }
                else if (charItem == 'ộ') { byteArr.Add('é'); }
                else if (charItem == 'Ớ') { byteArr.Add('í'); }
                else if (charItem == 'ớ') { byteArr.Add('í'); }
                else if (charItem == 'Ờ') { byteArr.Add('ê'); }
                else if (charItem == 'ờ') { byteArr.Add('ê'); }
                else if (charItem == 'Ở') { byteArr.Add('ë'); }
                else if (charItem == 'ở') { byteArr.Add('ë'); }
                else if (charItem == 'Ỡ') { byteArr.Add('ì'); }
                else if (charItem == 'ỡ') { byteArr.Add('ì'); }
                else if (charItem == 'Ợ') { byteArr.Add('î'); }
                else if (charItem == 'ợ') { byteArr.Add('î'); }
                else if (charItem == 'Ụ') { byteArr.Add('ô'); }
                else if (charItem == 'ụ') { byteArr.Add('ô'); }
                else if (charItem == 'Ủ') { byteArr.Add('ñ'); }
                else if (charItem == 'ủ') { byteArr.Add('ñ'); }
                else if (charItem == 'Ứ') { byteArr.Add('ø'); }
                else if (charItem == 'ứ') { byteArr.Add('ø'); }
                else if (charItem == 'Ừ') { byteArr.Add('õ'); }
                else if (charItem == 'ừ') { byteArr.Add('õ'); }
                else if (charItem == 'Ử') { byteArr.Add('ö'); }
                else if (charItem == 'ử') { byteArr.Add('ö'); }
                else if (charItem == 'Ữ') { byteArr.Add('÷'); }
                else if (charItem == 'ữ') { byteArr.Add('÷'); }
                else if (charItem == 'Ự') { byteArr.Add('ù'); }
                else if (charItem == 'ự') { byteArr.Add('ù'); }
                else if (charItem == 'Ỳ') { byteArr.Add('ú'); }
                else if (charItem == 'ỳ') { byteArr.Add('ú'); }
                else if (charItem == 'Ỵ') { byteArr.Add('þ'); }
                else if (charItem == 'ỵ') { byteArr.Add('þ'); }
                else if (charItem == 'Ỷ') { byteArr.Add('û'); }
                else if (charItem == 'ỷ') { byteArr.Add('û'); }
                else if (charItem == 'Ỹ') { byteArr.Add('ü'); }
                else if (charItem == 'ỹ') { byteArr.Add('ü'); }
                else { byteArr.Add(charItem); }
            }

            return byteArr.ToArray();
        }

        public static char[] ConvertFromUnicodeToVNI(string value)
        {
            List<char> byteArr = new List<char>();
            if (!string.IsNullOrEmpty(value))
            {
                foreach (var charItem in value.ToCharArray())
                {
                    if (charItem == 'À') { byteArr.AddRange(new char[] { (char)0x41, (char)0xD8 }); }
                    else if (charItem == 'Á') { byteArr.AddRange(new char[] { (char)0x41, (char)0xD9 }); }
                    else if (charItem == 'Â') { byteArr.AddRange(new char[] { (char)0x41, (char)0xC2 }); }
                    else if (charItem == 'Ã') { byteArr.AddRange(new char[] { (char)0x41, (char)0xD5 }); }
                    else if (charItem == 'È') { byteArr.AddRange(new char[] { (char)0x45, (char)0xD8 }); }
                    else if (charItem == 'É') { byteArr.AddRange(new char[] { (char)0x45, (char)0xD9 }); }
                    else if (charItem == 'Ê') { byteArr.AddRange(new char[] { (char)0x45, (char)0xC2 }); }
                    else if (charItem == 'Ò') { byteArr.AddRange(new char[] { (char)0x4F, (char)0xD8 }); }
                    else if (charItem == 'Ó') { byteArr.AddRange(new char[] { (char)0x4F, (char)0xD9 }); }
                    else if (charItem == 'Ô') { byteArr.AddRange(new char[] { (char)0x4F, (char)0xC2 }); }
                    else if (charItem == 'Õ') { byteArr.AddRange(new char[] { (char)0x4F, (char)0xD5 }); }
                    else if (charItem == 'Ù') { byteArr.AddRange(new char[] { (char)0x55, (char)0xD8 }); }
                    else if (charItem == 'Ú') { byteArr.AddRange(new char[] { (char)0x55, (char)0xD9 }); }
                    else if (charItem == 'ú') { byteArr.AddRange(new char[] { (char)0x75, (char)0xF9 }); }
                    else if (charItem == 'Ý') { byteArr.AddRange(new char[] { (char)0x59, (char)0xD9 }); }
                    else if (charItem == 'à') { byteArr.AddRange(new char[] { (char)0x61, (char)0xF8 }); }
                    else if (charItem == 'á') { byteArr.AddRange(new char[] { (char)0x61, (char)0xF9 }); }
                    else if (charItem == 'â') { byteArr.AddRange(new char[] { (char)0x61, (char)0xE2 }); }
                    else if (charItem == 'ã') { byteArr.AddRange(new char[] { (char)0x61, (char)0xF5 }); }
                    else if (charItem == 'è') { byteArr.AddRange(new char[] { (char)0x65, (char)0xF8 }); }
                    else if (charItem == 'é') { byteArr.AddRange(new char[] { (char)0x65, (char)0xF9 }); }
                    else if (charItem == 'ê') { byteArr.AddRange(new char[] { (char)0x65, (char)0xE2 }); }
                    else if (charItem == 'ò') { byteArr.AddRange(new char[] { (char)0x6F, (char)0xF8 }); }
                    else if (charItem == 'ó') { byteArr.AddRange(new char[] { (char)0x6F, (char)0xF9 }); }
                    else if (charItem == 'ô') { byteArr.AddRange(new char[] { (char)0x6F, (char)0xE2 }); }
                    else if (charItem == 'õ') { byteArr.AddRange(new char[] { (char)0x6F, (char)0xF5 }); }
                    else if (charItem == 'ù') { byteArr.AddRange(new char[] { (char)0x75, (char)0xF8 }); }
                    else if (charItem == 'à') { byteArr.AddRange(new char[] { (char)0x75, (char)0xF9 }); }
                    else if (charItem == 'ý') { byteArr.AddRange(new char[] { (char)0x79, (char)0xF9 }); }
                    else if (charItem == 'Ă') { byteArr.AddRange(new char[] { (char)0x41, (char)0xCA }); }
                    else if (charItem == 'ă') { byteArr.AddRange(new char[] { (char)0x61, (char)0xEA }); }
                    else if (charItem == 'Ũ') { byteArr.AddRange(new char[] { (char)0x55, (char)0xD5 }); }
                    else if (charItem == 'ũ') { byteArr.AddRange(new char[] { (char)0x75, (char)0xF5 }); }
                    else if (charItem == 'Ạ') { byteArr.AddRange(new char[] { (char)0x41, (char)0xCF }); }
                    else if (charItem == 'ạ') { byteArr.AddRange(new char[] { (char)0x61, (char)0xEF }); }
                    else if (charItem == 'Ả') { byteArr.AddRange(new char[] { (char)0x41, (char)0xDB }); }
                    else if (charItem == 'ả') { byteArr.AddRange(new char[] { (char)0x61, (char)0xFB }); }
                    else if (charItem == 'Ấ') { byteArr.AddRange(new char[] { (char)0x41, (char)0xC1 }); }
                    else if (charItem == 'ấ') { byteArr.AddRange(new char[] { (char)0x61, (char)0xE1 }); }
                    else if (charItem == 'Ầ') { byteArr.AddRange(new char[] { (char)0x41, (char)0xC0 }); }
                    else if (charItem == 'ầ') { byteArr.AddRange(new char[] { (char)0x61, (char)0xE0 }); }
                    else if (charItem == 'Ẩ') { byteArr.AddRange(new char[] { (char)0x41, (char)0xC5 }); }
                    else if (charItem == 'ẩ') { byteArr.AddRange(new char[] { (char)0x62, (char)0xE5 }); }
                    else if (charItem == 'Ẫ') { byteArr.AddRange(new char[] { (char)0x41, (char)0xC3 }); }
                    else if (charItem == 'ẫ') { byteArr.AddRange(new char[] { (char)0x61, (char)0xE3 }); }
                    else if (charItem == 'Ậ') { byteArr.AddRange(new char[] { (char)0x41, (char)0xC4 }); }
                    else if (charItem == 'ậ') { byteArr.AddRange(new char[] { (char)0x61, (char)0xE4 }); }
                    else if (charItem == 'Ắ') { byteArr.AddRange(new char[] { (char)0x41, (char)0xC9 }); }
                    else if (charItem == 'ắ') { byteArr.AddRange(new char[] { (char)0x61, (char)0xE9 }); }
                    else if (charItem == 'Ằ') { byteArr.AddRange(new char[] { (char)0x41, (char)0xC8 }); }
                    else if (charItem == 'ằ') { byteArr.AddRange(new char[] { (char)0x61, (char)0xE8 }); }
                    else if (charItem == 'Ẳ') { byteArr.AddRange(new char[] { (char)0x41, (char)0xDA }); }
                    else if (charItem == 'ẳ') { byteArr.AddRange(new char[] { (char)0x61, (char)0xFA }); }
                    else if (charItem == 'Ẵ') { byteArr.AddRange(new char[] { (char)0x41, (char)0xDC }); }
                    else if (charItem == 'ẵ') { byteArr.AddRange(new char[] { (char)0x61, (char)0xFC }); }
                    else if (charItem == 'Ặ') { byteArr.AddRange(new char[] { (char)0x41, (char)0xCB }); }
                    else if (charItem == 'ặ') { byteArr.AddRange(new char[] { (char)0x61, (char)0xEB }); }
                    else if (charItem == 'Ẹ') { byteArr.AddRange(new char[] { (char)0x45, (char)0xCF }); }
                    else if (charItem == 'ẹ') { byteArr.AddRange(new char[] { (char)0x65, (char)0xEF }); }
                    else if (charItem == 'Ẻ') { byteArr.AddRange(new char[] { (char)0x45, (char)0xDB }); }
                    else if (charItem == 'ẻ') { byteArr.AddRange(new char[] { (char)0x65, (char)0xFB }); }
                    else if (charItem == 'Ẽ') { byteArr.AddRange(new char[] { (char)0x45, (char)0xD5 }); }
                    else if (charItem == 'ẽ') { byteArr.AddRange(new char[] { (char)0x65, (char)0xF5 }); }
                    else if (charItem == 'Ế') { byteArr.AddRange(new char[] { (char)0x45, (char)0xC1 }); }
                    else if (charItem == 'ế') { byteArr.AddRange(new char[] { (char)0x65, (char)0xE1 }); }
                    else if (charItem == 'Ề') { byteArr.AddRange(new char[] { (char)0x45, (char)0xC0 }); }
                    else if (charItem == 'ề') { byteArr.AddRange(new char[] { (char)0x65, (char)0xE0 }); }
                    else if (charItem == 'Ể') { byteArr.AddRange(new char[] { (char)0x45, (char)0xC5 }); }
                    else if (charItem == 'ể') { byteArr.AddRange(new char[] { (char)0x65, (char)0xE5 }); }
                    else if (charItem == 'Ễ') { byteArr.AddRange(new char[] { (char)0x45, (char)0xC3 }); }
                    else if (charItem == 'ễ') { byteArr.AddRange(new char[] { (char)0x65, (char)0xE3 }); }
                    else if (charItem == 'Ệ') { byteArr.AddRange(new char[] { (char)0x45, (char)0xC4 }); }
                    else if (charItem == 'ệ') { byteArr.AddRange(new char[] { (char)0x65, (char)0xE4 }); }
                    else if (charItem == 'Ọ') { byteArr.AddRange(new char[] { (char)0x4F, (char)0xCF }); }
                    else if (charItem == 'ọ') { byteArr.AddRange(new char[] { (char)0x6F, (char)0xEF }); }
                    else if (charItem == 'Ỏ') { byteArr.AddRange(new char[] { (char)0x4F, (char)0xDB }); }
                    else if (charItem == 'ỏ') { byteArr.AddRange(new char[] { (char)0x6F, (char)0xFB }); }
                    else if (charItem == 'Ố') { byteArr.AddRange(new char[] { (char)0x4F, (char)0xC1 }); }
                    else if (charItem == 'ố') { byteArr.AddRange(new char[] { (char)0x6F, (char)0xE1 }); }
                    else if (charItem == 'Ồ') { byteArr.AddRange(new char[] { (char)0x4F, (char)0xC0 }); }
                    else if (charItem == 'ồ') { byteArr.AddRange(new char[] { (char)0x6F, (char)0xE0 }); }
                    else if (charItem == 'Ổ') { byteArr.AddRange(new char[] { (char)0x4F, (char)0xC5 }); }
                    else if (charItem == 'ổ') { byteArr.AddRange(new char[] { (char)0x6F, (char)0xE5 }); }
                    else if (charItem == 'Ỗ') { byteArr.AddRange(new char[] { (char)0x4F, (char)0xC3 }); }
                    else if (charItem == 'ỗ') { byteArr.AddRange(new char[] { (char)0x6F, (char)0xE3 }); }
                    else if (charItem == 'Ộ') { byteArr.AddRange(new char[] { (char)0x4F, (char)0xC4 }); }
                    else if (charItem == 'ộ') { byteArr.AddRange(new char[] { (char)0x6F, (char)0xE4 }); }
                    else if (charItem == 'Ớ') { byteArr.AddRange(new char[] { (char)0xD4, (char)0xD9 }); }
                    else if (charItem == 'ớ') { byteArr.AddRange(new char[] { (char)0xF4, (char)0xF9 }); }
                    else if (charItem == 'Ờ') { byteArr.AddRange(new char[] { (char)0xD4, (char)0xD8 }); }
                    else if (charItem == 'ờ') { byteArr.AddRange(new char[] { (char)0xF4, (char)0xF8 }); }
                    else if (charItem == 'Ở') { byteArr.AddRange(new char[] { (char)0xD4, (char)0xDB }); }
                    else if (charItem == 'ở') { byteArr.AddRange(new char[] { (char)0xF4, (char)0xFB }); }
                    else if (charItem == 'Ỡ') { byteArr.AddRange(new char[] { (char)0xD4, (char)0xD5 }); }
                    else if (charItem == 'ỡ') { byteArr.AddRange(new char[] { (char)0xF4, (char)0xF5 }); }
                    else if (charItem == 'Ợ') { byteArr.AddRange(new char[] { (char)0xD4, (char)0xCF }); }
                    else if (charItem == 'ợ') { byteArr.AddRange(new char[] { (char)0xF4, (char)0xEF }); }
                    else if (charItem == 'Ụ') { byteArr.AddRange(new char[] { (char)0x55, (char)0xCF }); }
                    else if (charItem == 'ụ') { byteArr.AddRange(new char[] { (char)0x75, (char)0xEF }); }
                    else if (charItem == 'Ủ') { byteArr.AddRange(new char[] { (char)0x55, (char)0xDB }); }
                    else if (charItem == 'ủ') { byteArr.AddRange(new char[] { (char)0x75, (char)0xFB }); }
                    else if (charItem == 'Ứ') { byteArr.AddRange(new char[] { (char)0xD6, (char)0xD9 }); }
                    else if (charItem == 'ứ') { byteArr.AddRange(new char[] { (char)0xF6, (char)0xF9 }); }
                    else if (charItem == 'Ừ') { byteArr.AddRange(new char[] { (char)0xD6, (char)0xD8 }); }
                    else if (charItem == 'ừ') { byteArr.AddRange(new char[] { (char)0xF6, (char)0xF8 }); }
                    else if (charItem == 'Ử') { byteArr.AddRange(new char[] { (char)0xD6, (char)0xDB }); }
                    else if (charItem == 'ử') { byteArr.AddRange(new char[] { (char)0xF6, (char)0xFB }); }
                    else if (charItem == 'Ữ') { byteArr.AddRange(new char[] { (char)0xD6, (char)0xD5 }); }
                    else if (charItem == 'ữ') { byteArr.AddRange(new char[] { (char)0xF6, (char)0xF5 }); }
                    else if (charItem == 'Ự') { byteArr.AddRange(new char[] { (char)0xD6, (char)0xCF }); }
                    else if (charItem == 'ự') { byteArr.AddRange(new char[] { (char)0xF6, (char)0xEF }); }
                    else if (charItem == 'Ỳ') { byteArr.AddRange(new char[] { (char)0x59, (char)0xD8 }); }
                    else if (charItem == 'ỳ') { byteArr.AddRange(new char[] { (char)0x79, (char)0xF8 }); }
                    else if (charItem == 'Ỷ') { byteArr.AddRange(new char[] { (char)0x59, (char)0xDB }); }
                    else if (charItem == 'ỷ') { byteArr.AddRange(new char[] { (char)0x79, (char)0xFB }); }
                    else if (charItem == 'Ỹ') { byteArr.AddRange(new char[] { (char)0x59, (char)0xD5 }); }
                    else if (charItem == 'ỹ') { byteArr.AddRange(new char[] { (char)0x79, (char)0xF5 }); }
                    else if (charItem == 'Ì') { byteArr.AddRange(new char[] { (char)0xCC }); }
                    else if (charItem == 'Í') { byteArr.AddRange(new char[] { (char)0xCD }); }
                    else if (charItem == 'ì') { byteArr.AddRange(new char[] { (char)0xEC }); }
                    else if (charItem == 'í') { byteArr.AddRange(new char[] { (char)0xED }); }
                    else if (charItem == 'Đ') { byteArr.AddRange(new char[] { (char)0xD1 }); }
                    else if (charItem == 'đ') { byteArr.AddRange(new char[] { (char)0xF1 }); }
                    else if (charItem == 'Ĩ') { byteArr.AddRange(new char[] { (char)0xD3 }); }
                    else if (charItem == 'ĩ') { byteArr.AddRange(new char[] { (char)0xF3 }); }
                    else if (charItem == 'Ơ') { byteArr.AddRange(new char[] { (char)0xD4 }); }
                    else if (charItem == 'ơ') { byteArr.AddRange(new char[] { (char)0xF4 }); }
                    else if (charItem == 'Ư') { byteArr.AddRange(new char[] { (char)0xD6 }); }
                    else if (charItem == 'ư') { byteArr.AddRange(new char[] { (char)0xF6 }); }
                    else if (charItem == 'Ỉ') { byteArr.AddRange(new char[] { (char)0xC6 }); }
                    else if (charItem == 'ỉ') { byteArr.AddRange(new char[] { (char)0xE6 }); }
                    else if (charItem == 'Ị') { byteArr.AddRange(new char[] { (char)0xD2 }); }
                    else if (charItem == 'ị') { byteArr.AddRange(new char[] { (char)0xF2 }); }
                    else if (charItem == 'Ỵ') { byteArr.AddRange(new char[] { (char)0xCE }); }
                    else if (charItem == 'ị') { byteArr.AddRange(new char[] { (char)0xEE }); }
                    else { byteArr.AddRange(new char[] { charItem }); }
                }
            }
            return byteArr.ToArray();
        }

        private static bool CheckTCVN3(StringBuilder builder, byte[] values, int index, byte firstByte, byte secondByte, char check)
        {
            bool result = false;
            if (values[index] == firstByte && values[index + 1] == secondByte)
            {
                builder.Append(check);
                result = true;
            }

            return result;
        }
        private static bool CheckUTF8(StringBuilder builder, byte[] values, int index, byte firstByte, byte secondByte, byte third, byte four, byte five, char check)
        {
            bool result = false;
            if (values[index] == firstByte && values[index + 1] == secondByte && values[index + 2] == third && values[index + 3] == four && values[index + 4] == five)
            {
                builder.Append(check);
                result = true;
            }

            return result;
        }
        private static bool CheckUTF8(StringBuilder builder, byte[] values, int index, byte firstByte, byte secondByte, byte third, byte four, char check)
        {
            bool result = false;
            if (values[index] == firstByte && values[index + 1] == secondByte && values[index + 2] == third && values[index + 3] == four)
            {
                builder.Append(check);
                result = true;
            }

            return result;
        }
        private static bool CheckUTF8(StringBuilder builder, byte[] values, int index, byte firstByte, byte secondByte, char check)
        {
            bool result = false;
            if (values[index] == firstByte && values[index + 1] == secondByte)
            {
                builder.Append(check);
                result = true;
            }

            return result;
        }
        private static bool CheckUTF8(StringBuilder builder, byte[] values, int index, byte firstByte, byte secondByte, byte third, char check)
        {
            bool result = false;
            if (values[index] == firstByte && values[index + 1] == secondByte && values[index + 2] == third)
            {
                builder.Append(check);
                result = true;
            }

            return result;
        }
        private static bool CheckTCVN3(StringBuilder builder, byte[] values, int index, byte firstByte, char check)
        {
            bool result = false;
            if (values[index] == firstByte)
            {
                builder.Append(check);
                result = true;
            }

            return result;
        }

        public static string ConvertFromTCVN3ToUnicode(byte[] values)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < values.Length; i++)
            {
                bool found = false;
                if (i + 1 < values.Length)
                {
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xB5, 'À')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xB8, 'Á')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xB7, 'Ã')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xCC, 'È')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xD0, 'É')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x49, 0xD7, 'Ì')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x49, 0xDD, 'Í')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xDF, 'Ò')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xE3, 'Ó')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xE2, 'Õ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x55, 0xEF, 'Ù')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x55, 0xF3, 'Ú')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x59, 0xFD, 'Ý')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x49, 0xDC, 'Ĩ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x55, 0xF2, 'Ũ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xB9, 'Ạ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xB6, 'Ả')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA2, 0xCA, 'Ấ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA2, 0xC7, 'Ầ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA2, 0xC8, 'Ẩ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA2, 0xC9, 'Ẫ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA2, 0xCB, 'Ậ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA1, 0xBE, 'Ắ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA1, 0xBC, 'Ẳ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA1, 0xBD, 'Ẵ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA1, 0xBB, 'Ằ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA3, 0xD6, 'Ệ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x49, 0xD8, 'Ỉ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x49, 0xDE, 'Ị')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA3, 0xD2, 'Ề')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA3, 0xD3, 'Ể')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA3, 0xD4, 'Ễ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xCE, 'Ẻ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xCF, 'Ẽ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA3, 0xD5, 'Ế')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA1, 0xC6, 'Ặ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xD1, 'Ẹ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xE4, 'Ọ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xE1, 'Ỏ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA4, 0xE8, 'Ố')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA4, 0xE5, 'Ồ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA4, 0xE6, 'Ổ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA4, 0xE7, 'Ỗ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA4, 0xE9, 'Ộ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA5, 0xED, 'Ớ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA5, 0xEA, 'Ờ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA5, 0xEB, 'Ở')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA5, 0xEC, 'Ỡ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA5, 0xEE, 'Ợ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x55, 0xF4, 'Ụ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x55, 0xF1, 'Ủ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA6, 0xF8, 'Ứ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA6, 0xF5, 'Ừ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA6, 0xF6, 'Ử')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA6, 0xF7, 'Ữ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA6, 0xF9, 'Ự')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x59, 0xFA, 'Ỳ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x59, 0xFE, 'Ỵ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x59, 0xFB, 'Ỷ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x59, 0xFC, 'Ỹ')) { found = true; }

                    if (found)
                    {
                        i++;
                    }
                }

                if (!found)
                {
                    if (!found && CheckTCVN3(builder, values, i, 0xA2, 'Â')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA3, 'Ê')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA4, 'Ô')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xB5, 'à')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xB8, 'á')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA9, 'â')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xB7, 'ã')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xCC, 'è')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD0, 'é')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xAA, 'ê')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD7, 'ì')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xDD, 'í')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xDF, 'ò')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xE3, 'ó')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xAB, 'ô')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xE2, 'õ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xEF, 'ù')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF3, 'ú')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xFD, 'ý')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA1, 'Ă')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA8, 'ă')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA7, 'Đ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xAE, 'đ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xDC, 'ĩ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF2, 'ũ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA5, 'Ơ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xAC, 'ơ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xA6, 'Ư')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xAD, 'ư')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xB9, 'ạ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xB6, 'ả')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xCA, 'ấ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xC7, 'ầ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xC8, 'ẩ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xC9, 'ẫ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xBE, 'ắ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xBB, 'ằ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xCB, 'ậ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xBC, 'ẳ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xBD, 'ẵ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xC6, 'ặ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD1, 'ẹ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xCE, 'ẻ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xCF, 'ẽ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD5, 'ế')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD2, 'ề')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD3, 'ể')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD4, 'ễ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD6, 'ệ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD8, 'ỉ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xDE, 'ị')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xE4, 'ọ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xE1, 'ỏ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xE8, 'ố')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xE5, 'ồ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xE6, 'ổ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xE7, 'ỗ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xE9, 'ộ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xED, 'ớ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xEA, 'ờ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xEB, 'ở')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xEC, 'ỡ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xEE, 'ợ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF4, 'ụ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF1, 'ủ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF8, 'ứ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF5, 'ừ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF6, 'ử')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF7, 'ữ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF9, 'ự')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xFA, 'ỳ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xFE, 'ỵ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xFC, 'ỹ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xFB, 'ỷ')) { found = true; }
                }

                if (!found)
                {
                    builder.Append((char)values[i]);
                }
            }

            return builder.ToString();
        }
        public static string ConvertFromVNIToUnicode(byte[] values)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < values.Length; i++)
            {
                bool found = false;
                if (i + 1 < values.Length)
                {
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xD8, 'À')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xD9, 'Á')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xC2, 'Â')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xD5, 'Ã')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xD8, 'È')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xD9, 'É')) { found = true; }

                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xD8, 'Ò')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xD9, 'Ó')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xC2, 'Ô')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xD5, 'Õ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x55, 0xD8, 'Ù')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x55, 0xD9, 'Ú')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x59, 0xD9, 'Ý')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xF8, 'à')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xF9, 'á')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xE2, 'â')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xF5, 'ã')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x65, 0xF8, 'è')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x65, 0xF9, 'é')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x65, 0xE2, 'ê')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x6F, 0xF8, 'ò')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x6F, 0xF9, 'ó')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x6F, 0xE2, 'ô')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x6F, 0xF5, 'õ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x75, 0xF8, 'ù')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x75, 0xF9, 'ú')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x75, 0xF9, 'à')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x79, 0xF9, 'ý')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xCA, 'Ă')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xEA, 'ă')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x55, 0xD5, 'Ũ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x75, 0xF5, 'ũ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xCF, 'Ạ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xEF, 'ạ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xDB, 'Ả')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xFB, 'ả')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xC1, 'Ấ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xE1, 'ấ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xC0, 'Ầ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xE0, 'ầ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xC5, 'Ẩ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xE5, 'ẩ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xC3, 'Ẫ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xE3, 'ẫ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xC4, 'Ậ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xE4, 'ậ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xC9, 'Ắ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xE9, 'ắ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xC8, 'Ằ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xE8, 'ằ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xDA, 'Ẳ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xFA, 'ẳ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xDC, 'Ẵ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xFC, 'ẵ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x41, 0xCB, 'Ặ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x61, 0xEB, 'ặ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xCF, 'Ẹ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x65, 0xEF, 'ẹ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xDB, 'Ẻ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x65, 0xFB, 'ẻ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xD5, 'Ẽ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x65, 0xF5, 'ẽ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xC1, 'Ế')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x65, 0xE1, 'ế')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xC0, 'Ề')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x65, 0xE0, 'ề')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xC5, 'Ể')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x65, 0xE5, 'ể')) { found = true; }
                    //if (!found && CheckTCVN3_V2(builder, values, i, 69, 194, 126, 'Ễ')) { found = true; i++; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xC2, 'Ê')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xC3, 'Ễ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x65, 0xE3, 'ễ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x45, 0xC4, 'Ệ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x65, 0xE4, 'ệ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xCF, 'Ọ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x6F, 0xEF, 'ọ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xDB, 'Ỏ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x6F, 0xFB, 'ỏ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xC1, 'Ố')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x6F, 0xE1, 'ố')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xC0, 'Ồ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x6F, 0xE0, 'ồ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xC5, 'Ổ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x6F, 0xE5, 'ổ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xC3, 'Ỗ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x6F, 0xE3, 'ỗ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x4F, 0xC4, 'Ộ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x6F, 0xE4, 'ộ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD4, 0xD9, 'Ớ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF4, 0xF9, 'ớ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD4, 0xD8, 'Ờ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF4, 0xF8, 'ờ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD4, 0xDB, 'Ở')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF4, 0xFB, 'ở')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD4, 0xD5, 'Ỡ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF4, 0xF5, 'ỡ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD4, 0xCF, 'Ợ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF4, 0xEF, 'ợ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x55, 0xCF, 'Ụ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x75, 0xEF, 'ụ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x55, 0xDB, 'Ủ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x75, 0xFB, 'ủ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD6, 0xD9, 'Ứ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF6, 0xF9, 'ứ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD6, 0xD8, 'Ừ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF6, 0xF8, 'ừ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD6, 0xDB, 'Ử')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF6, 0xFB, 'ử')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD6, 0xD5, 'Ữ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF6, 0xF5, 'ữ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD6, 0xCF, 'Ự')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF6, 0xEF, 'ự')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x59, 0xD8, 'Ỳ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x79, 0xF8, 'ỳ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x59, 0xDB, 'Ỷ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x79, 0xFB, 'ỷ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x59, 0xD5, 'Ỹ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0x79, 0xF5, 'ỹ')) { found = true; }
                    if (found)
                    {
                        i++;
                    }
                }

                if (!found)
                {
                    if (!found && CheckTCVN3(builder, values, i, 0xCC, 'Ì')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xCD, 'Í')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xEC, 'ì')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xED, 'í')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD1, 'Đ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF1, 'đ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD3, 'Ĩ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF3, 'ĩ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD4, 'Ơ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF4, 'ơ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD6, 'Ư')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF6, 'ư')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xC6, 'Ỉ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xE6, 'ỉ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xD2, 'Ị')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xF2, 'ị')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xCE, 'Ỵ')) { found = true; }
                    if (!found && CheckTCVN3(builder, values, i, 0xEE, 'ị')) { found = true; }
                }
                if (!found)
                {
                    builder.Append((char)values[i]);
                }
            }
            return builder.ToString();
        }
        //Convert VNI to Unicode in UTF8 by KhoaPD 8/8/2020
        public static string ConvertVNIToUnicodeUTF8(byte[] values)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < values.Length; i++)
            {
                bool found = false;
                if (i + 1 < values.Length)
                {
                    if (!found && CheckUTF8(builder, values, i, 0x45, 0xC3, 0x82, 0xCC, 0x83, 'Ễ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x45, 0xC3, 0x82, 0xCC, 0x81, 'Ế')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x45, 0xC3, 0x82, 0xCC, 0x82, 'Ể')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x45, 0xC3, 0x82, 0xCC, 0x80, 'Ề')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x65, 0xc3, 0xa2, 0xcc, 0xa3, 'ệ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x65, 0xc3, 0xa2, 0xcc, 0x80, 'ề')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x65, 0xc3, 0xa2, 0xcc, 0x81, 'ế')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x65, 0xc3, 0xa2, 0xcc, 0x89, 'ể')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x65, 0xc3, 0xa2, 0xcc, 0x83, 'ễ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x45, 0xc3, 0x82, 0xcc, 0xa3, 'Ệ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x6f, 0xc3, 0xa2, 0xcc, 0xa3, 'ộ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x6f, 0xc3, 0xa2, 0xcc, 0x80, 'ồ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x6f, 0xc3, 0xa2, 0xcc, 0x81, 'ố')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x6f, 0xc3, 0xa2, 0xcc, 0x83, 'ỗ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x6f, 0xc3, 0xa2, 0xcc, 0x89, 'ổ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x41, 0xc3, 0x82, 0xcc, 0x81, 'Ấ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x41, 0xc3, 0x82, 0xcc, 0x80, 'Ầ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x41, 0xc3, 0x82, 0xcc, 0x83, 'Ẫ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x41, 0xc3, 0x82, 0xcc, 0x89, 'Ẩ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x41, 0xc3, 0x82, 0xcc, 0xa3, 'Ậ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x4f, 0xc3, 0x82, 0xcc, 0x81, 'Ố')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x4f, 0xc3, 0x82, 0xcc, 0x80, 'Ồ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x4f, 0xc3, 0x82, 0xcc, 0x83, 'Ỗ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x4f, 0xc3, 0x82, 0xcc, 0x89, 'Ổ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x4f, 0xc3, 0x82, 0xcc, 0xa3, 'Ộ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x61, 0xc3, 0xa2, 0xcc, 0x81, 'ấ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x61, 0xc3, 0xa2, 0xcc, 0x80, 'ầ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x61, 0xc3, 0xa2, 0xcc, 0x83, 'ẫ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x61, 0xc3, 0xa2, 0xcc, 0x89, 'ẩ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x61, 0xc3, 0xa2, 0xcc, 0xa3, 'ậ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x61, 0xc3, 0xaa, 0xcc, 0xa3, 'ặ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x61, 0xc3, 0xaa, 0xcc, 0x80, 'ằ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x61, 0xc3, 0xaa, 0xcc, 0x81, 'ắ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x61, 0xc3, 0xaa, 0xcc, 0x83, 'ẵ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0x61, 0xc3, 0xaa, 0xcc, 0x89, 'ẳ')) { found = true; }
                    if (found)
                    {
                        i += 4;
                    }
                    if (!found)
                    {
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0x94, 0xC3, 0x99, 'Ớ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0xB4, 0xC3, 0xB9, 'ớ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0x94, 0xC3, 0x98, 'Ờ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0xB4, 0xC3, 0xB8, 'ờ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0x94, 0xC3, 0x9B, 'Ở')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0xB4, 0xC3, 0xBB, 'ở')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0x94, 0xC3, 0x95, 'Ỡ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0xB4, 0xC3, 0xB5, 'ỡ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0x94, 0xC3, 0x8F, 'Ợ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0x94, 0xC3, 0xa3, 'Ợ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0xB4, 0xC3, 0xAF, 'ợ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0x96, 0xC3, 0x99, 'Ứ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0xB6, 0xC3, 0xB9, 'ứ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0x96, 0xC3, 0x98, 'Ừ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0xB6, 0xC3, 0xB8, 'ừ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0x96, 0xC3, 0x9B, 'Ử')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0xB6, 0xC3, 0xBB, 'ử')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0x96, 0xC3, 0x95, 'Ữ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0xB6, 0xC3, 0xB5, 'ữ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0x96, 0xC3, 0x8F, 'Ự')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xC3, 0xB6, 0xC3, 0xAF, 'ự')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xc3, 0xb4, 0xcc, 0xa3, 'ợ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xc3, 0xb4, 0xcc, 0x81, 'ớ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xc3, 0xb4, 0xcc, 0x80, 'ờ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xc3, 0xb4, 0xcc, 0x83, 'ỡ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xc3, 0xb4, 0xcc, 0x89, 'ở')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xc3, 0x96, 0xcc, 0x89, 'Ử')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xc3, 0x96, 0xcc, 0x80, 'Ừ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xc3, 0x96, 0xcc, 0x81, 'Ứ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xc3, 0x96, 0xcc, 0x83, 'Ữ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xc3, 0x96, 0xcc, 0xa3, 'Ự')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xc3, 0xb6, 0xcc, 0xa3, 'ự')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xc3, 0x94, 0xcc, 0x89, 'Ở')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xc3, 0x94, 0xcc, 0x80, 'Ờ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xc3, 0x94, 0xcc, 0x81, 'Ớ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0xc3, 0x94, 0xcc, 0x83, 'Ỡ')) { found = true; }

                        if (found)
                        {
                            i += 3;
                        }
                    }
                    if (!found)
                    {
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xc3, 0x82, 'Â')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xc3, 0x98, 'À')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xc3, 0x99, 'Á')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xc3, 0x95, 'Ã')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x45, 0xc3, 0x98, 'È')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x45, 0xC3, 0x99, 'É')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x4F, 0xC3, 0x98, 'Ò')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x4F, 0xC3, 0x99, 'Ó')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x4F, 0xC3, 0x82, 'Ô')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x4F, 0xC3, 0x95, 'Õ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x55, 0xC3, 0x98, 'Ù')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x55, 0xcc, 0x80, 'Ù')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x55, 0xC3, 0x99, 'Ú')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x59, 0xC3, 0x99, 'Ý')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x59, 0xcc, 0x81, 'Ý')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xB8, 'à')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xB9, 'á')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xA2, 'â')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xB5, 'ã')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xC3, 0xB8, 'è')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xC3, 0xB9, 'é')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xC3, 0xA2, 'ê')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6F, 0xC3, 0xB8, 'ò')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6F, 0xC3, 0xB9, 'ó')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6F, 0xC3, 0xA2, 'ô')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6F, 0xC3, 0xB5, 'õ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6f, 0xcc, 0x80, 'ò')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6f, 0xcc, 0x81, 'ó')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6f, 0xcc, 0x82, 'ô')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6f, 0xcc, 0x83, 'õ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6f, 0xcc, 0x89, 'ỏ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x75, 0xC3, 0xB8, 'ù')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x75, 0xC3, 0xB9, 'ú')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x79, 0xC3, 0xB9, 'ý')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xC3, 0x8A, 'Ă')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xAA, 'ă')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x55, 0xC3, 0x95, 'Ũ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x75, 0xC3, 0xB5, 'ũ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xC3, 0x8F, 'Ạ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xAF, 'ạ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xC3, 0x9B, 'Ả')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xBB, 'ả')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xC3, 0x81, 'Ấ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xA1, 'ấ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xC3, 0x80, 'Ầ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xA0, 'ầ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xC3, 0x85, 'Ẩ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xA5, 'ẩ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xC3, 0x83, 'Ẫ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xA3, 'ẫ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xC3, 0x84, 'Ậ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xA4, 'ậ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xC3, 0x89, 'Ắ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xA9, 'ắ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xC3, 0x88, 'Ằ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xA8, 'ằ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xC3, 0x9A, 'Ẳ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xBA, 'ẳ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xC3, 0x9C, 'Ẵ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xBC, 'ẵ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xC3, 0x8B, 'Ặ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xC3, 0xAB, 'ặ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x45, 0xC3, 0x8F, 'Ẹ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xC3, 0xAF, 'ẹ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x45, 0xC3, 0x9B, 'Ẻ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xC3, 0xBB, 'ẻ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x45, 0xC3, 0x95, 'Ẽ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xC3, 0xB5, 'ẽ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x45, 0xC3, 0x81, 'Ế')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xC3, 0xA1, 'ế')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x45, 0xC3, 0x80, 'Ề')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xC3, 0xA0, 'ề')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x45, 0xC3, 0x85, 'Ể')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xC3, 0xA5, 'ể')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x45, 0xC3, 0x82, 'Ê')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x45, 0xC3, 0x83, 'Ễ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xC3, 0xA3, 'ễ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x45, 0xC3, 0x84, 'Ệ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xC3, 0xA4, 'ệ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xcc, 0x80, 'è')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xcc, 0x81, 'é')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xcc, 0x82, 'ê')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xcc, 0x83, 'ẽ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x65, 0xcc, 0x89, 'ẻ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x4F, 0xC3, 0x8F, 'Ọ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6F, 0xC3, 0xAF, 'ọ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x4F, 0xC3, 0x9B, 'Ỏ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6F, 0xC3, 0xBB, 'ỏ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x4F, 0xC3, 0x81, 'Ố')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6F, 0xC3, 0xA1, 'ố')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x4F, 0xC3, 0x80, 'Ồ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6F, 0xC3, 0xA0, 'ồ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x4F, 0xC3, 0x85, 'Ổ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6F, 0xC3, 0xA5, 'ổ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x4F, 0xC3, 0x83, 'Ỗ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6F, 0xC3, 0xA3, 'ỗ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x4F, 0xC3, 0x84, 'Ộ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x6F, 0xC3, 0xA4, 'ộ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x69, 0xcc, 0x80, 'ì')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x69, 0xcc, 0x81, 'í')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x69, 0xcc, 0x83, 'ĩ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x69, 0xcc, 0x89, 'ỉ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x55, 0xC3, 0x8F, 'Ụ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x75, 0xcc, 0xa3, 'ụ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x75, 0xC3, 0xAF, 'ụ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x55, 0xC3, 0x9B, 'Ủ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x75, 0xC3, 0xBB, 'ủ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x75, 0xcc, 0x80, 'ù')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x75, 0xcc, 0x81, 'ú')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x75, 0xcc, 0x83, 'ũ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x75, 0xcc, 0x89, 'ủ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x49, 0xcc, 0xa3, 'Ị')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xcc, 0x80, 'À')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xcc, 0x81, 'Á')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xcc, 0x82, 'Â')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xcc, 0x83, 'Ã')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x41, 0xcc, 0x89, 'Ả')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xcc, 0x80, 'à')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xcc, 0x81, 'á')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xcc, 0x82, 'â')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xcc, 0x83, 'ã')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xcc, 0x89, 'ả')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x59, 0xC3, 0x98, 'Ỳ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x59, 0xcc, 0x80, 'Ỳ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x59, 0xcc, 0x82, 'Ỹ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x79, 0xcc, 0x80, 'ỳ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x79, 0xcc, 0x81, 'ý')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x79, 0xcc, 0x83, 'ỹ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x79, 0xcc, 0x89, 'ỷ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x79, 0xC3, 0xB8, 'ỳ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x59, 0xC3, 0x9B, 'Ỷ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x59, 0xcc, 0x89, 'Ỷ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x79, 0xC3, 0xBB, 'ỷ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x59, 0xC3, 0x95, 'Ỹ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x79, 0xC3, 0xB5, 'ỹ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x59, 0xcc, 0xa3, 'Ỵ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x75, 0xcc, 0x83, 'ũ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x55, 0xcc, 0xa3, 'Ụ')) { found = true; }
                        if (!found && CheckUTF8(builder, values, i, 0x61, 0xcc, 0xa3, 'ạ')) { found = true; }

                        if (found)
                        {
                            i += 2;
                        }
                    }

                }
                if (!found)
                {
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0x8C, 'Ì')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0x8D, 'Í')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0xAC, 'ì')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0xAD, 'í')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0x91, 'Đ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0xB1, 'đ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0x93, 'Ĩ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0xB3, 'ĩ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0x94, 'Ơ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0xB4, 'ơ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0x96, 'Ư')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0xB6, 'ư')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0x86, 'Ỉ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0xA6, 'ỉ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0x92, 'Ị')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0xB2, 'ị')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0x8E, 'Ỵ')) { found = true; }
                    if (!found && CheckUTF8(builder, values, i, 0xC3, 0xAE, 'ỵ')) { found = true; }
                    if (found)
                    {
                        i++;
                    }
                }
                if (!found)
                {
                    builder.Append((char)values[i]);
                }
            }
            return builder.ToString();
        }

        public static bool ConvertUnicode(ref string text)
        {
            ConvertFont convert = new ConvertFont();
            FontIndex getFont = 0;
            var checkFont = convert.isVietnamese(text, ref getFont);
            text = text.Replace(" ", " ");
            var checkConvert = convert.Convert(ref text, getFont, FontIndex.iUNI);
            return checkConvert;
        }
        public static bool CompareString(string str1, string str2)
        {
            // 0: Bằng - 1: Khác
            var checkfont = String.Compare(str1, str2, new System.Globalization.CultureInfo("vi-VN"), System.Globalization.CompareOptions.None);
            if (checkfont == 0)
                return true;
            else
                return false;
        }
    }
}
