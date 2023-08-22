using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace QI.Core.Common
{
    public class CommonFunctions
    {
        private static string EncryptOrDecrypt(string text, string key)
        {
            var result = new StringBuilder();

            for (int c = 0; c < text.Length; c++)
            {
                // take next character from string
                char character = text[c];

                // cast to a uint
                uint charCode = (uint)character;

                // figure out which character to take from the key
                int keyPosition = c % key.Length; // use modulo to "wrap round"

                // take the key character
                char keyChar = key[keyPosition];

                // cast it to a uint also
                uint keyCode = (uint)keyChar;

                // perform XOR on the two character codes
                uint combinedCode = charCode ^ keyCode;

                // cast back to a char
                char combinedChar = (char)combinedCode;

                // add to the result
                result.Append(combinedChar);
            }

            return result.ToString();
        }

        public static string ConvertHexToString(String hexInput, Encoding encoding)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }

        public static string ConvertStringToHex(String input, Encoding encoding)
        {
            Byte[] stringBytes = encoding.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }

        public static string EncryptXOR(string text, string key)
        {
            return ConvertStringToHex(EncryptOrDecrypt(text, key), Encoding.ASCII);
        }

        public static string DecryptXOR(string text, string key)
        {
            return EncryptOrDecrypt(ConvertHexToString(text, Encoding.ASCII), key);
        }

        public static string RandomString(int Size, Random random)
        {
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, Size).Select(x => input[random.Next(0, input.Length)]);
            return new string(chars.ToArray());
        }

        public static string RandomString(int Size)
        {
            Random _rnd = new Random();
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, Size).Select(x => input[_rnd.Next(0, input.Length)]);
            return new string(chars.ToArray());
        }

        public static string ConvertToASCII(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            text = text.Replace(" ", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public static bool CheckHasInt(int check, int sum)
        {
            return check == (check & sum);
        }

        public static string AddJsonValue(string key, string value, string content)
        {
            try
            {
                List<JsonObject> lstObject;
                if (!string.IsNullOrWhiteSpace(content))
                    lstObject = JsonConvert.DeserializeObject<List<JsonObject>>(content);
                else
                    lstObject = new List<JsonObject>();

                lstObject.Add(new JsonObject
                {
                    Key = key,
                    Value = value
                });
                return JsonConvert.SerializeObject(lstObject);
            }
            catch
            {
            }
            return string.Empty;
        }

        public static string TakeJsonValue(string key, string content)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<JsonObject>>(content).FirstOrDefault(s => s.Key == key).Value;
            }
            catch
            {
            }
            return string.Empty;
        }

        public class JsonObject
        {
            public JsonObject()
            {

            }

            public JsonObject(string key, string value)
            {
                Key = key;
                Value = value;
            }
            public string Key { get; set; }
            public string Value { get; set; }
        }

        public static string ConvertMonDayGiaoVien2(string maMonHoc)
        {
            if (string.IsNullOrWhiteSpace(maMonHoc))
                return null;
            string maMonDay = null;
            switch (maMonHoc)
            {
                case "15":
                    {
                        maMonDay = "22";
                        break;
                    }
                case "16":
                    {
                        maMonDay = "23";
                        break;
                    }
                case "17":
                    {
                        maMonDay = "17";
                        break;
                    }
                case "18":
                    {
                        maMonDay = "21";
                        break;
                    }
                case "19":
                    {
                        maMonDay = "20";
                        break;
                    }
                case "20":
                    {
                        maMonDay = "18";
                        break;
                    }
                case "21":
                    {
                        maMonDay = "06";
                        break;
                    }
                case "22":
                    {
                        //maMonDay = "07"; năm cũ Tiếng anh mã = 22
                        maMonDay = "07";
                        break;
                    }
                case "23":
                    {
                        maMonDay = "11";
                        break;
                    }
                case "24":
                    {
                        maMonDay = "12";
                        break;
                    }
                case "25":
                    {
                        maMonDay = "13";
                        break;
                    }
                case "26":
                    {
                        maMonDay = "16";
                        break;
                    }
                case "27":
                    {
                        maMonDay = "24";
                        break;
                    }
                case "28":
                    {
                        maMonDay = "08";
                        break;
                    }
                case "29":
                    {
                        maMonDay = "05";
                        break;
                    }
                case "30":
                    {
                        maMonDay = "19";
                        break;
                    }
                case "31":
                    {
                        maMonDay = "33";
                        break;
                    }
                case "32":
                    {
                        maMonDay = "10";
                        break;
                    }
                case "33":
                    {
                        break;
                    }
                case "60":
                    {
                        break;
                    }
            }
            return maMonDay;
        }

        public static string ConvertMonDayGiaoVien3(string maMonHoc)
        {
            if (string.IsNullOrWhiteSpace(maMonHoc))
                return null;
            string maMonDay = null;
            switch (maMonHoc)
            {
                case "34":
                    {
                        maMonDay = "22";
                        break;
                    }
                case "35":
                    {
                        maMonDay = "23";
                        break;
                    }
                case "36":
                    {
                        maMonDay = "17";
                        break;
                    }
                case "37":
                    {
                        maMonDay = "21";
                        break;
                    }
                case "38":
                    {
                        maMonDay = "10";
                        break;
                    }
                case "39":
                    {
                        maMonDay = "20";
                        break;
                    }
                case "40":
                    {
                        maMonDay = "18";
                        break;
                    }
                case "41":
                    {
                        maMonDay = "06";
                        break;
                    }
                case "42":
                    {
                        maMonDay = "07";
                        break;
                    }
                case "43":
                    {
                        maMonDay = "11";
                        break;
                    }
                case "44":
                    {
                        maMonDay = "12";
                        break;
                    }
                case "45":
                    {
                        maMonDay = "13";
                        break;
                    }
                case "46":
                    {
                        maMonDay = "24";
                        break;
                    }
                case "47":
                    {
                        maMonDay = "25";
                        break;
                    }
                case "48":
                    {
                        maMonDay = "08";
                        break;
                    }
                case "49":
                    {
                        maMonDay = "33";
                        break;
                    }
                case "50":
                    {
                        break;
                    }
                case "51":
                    {
                        break;
                    }
                case "52":
                    {
                        maMonDay = "16";
                        break;
                    }
                case "61":
                    {
                        break;
                    }
            }
            return maMonDay;
        }

        public static string ConvertMonDayGiaoVienGDTX(string maMonHoc)
        {
            if (string.IsNullOrWhiteSpace(maMonHoc))
                return null;
            string maMonDay = null;
            switch (maMonHoc)
            {
                case "53"://Toán
                    {
                        maMonDay = "22";
                        break;
                    }
                case "54"://Lý
                    {
                        maMonDay = "23";
                        break;
                    }
                case "55"://Hóa
                    {
                        maMonDay = "17";
                        break;
                    }
                case "56"://Sinh học
                    {
                        maMonDay = "21";
                        break;
                    }
                case "57"://Ngữ văn
                    {
                        maMonDay = "20";
                        break;
                    }
                case "58"://Lịch sử
                    {
                        maMonDay = "18";
                        break;
                    }
                case "59"://Địa lý
                    {
                        maMonDay = "06";
                        break;
                    }
                case "63"://Tin học
                    {
                        maMonDay = "10";
                        break;
                    }
                case "64"://Ngoại ngữ
                    {
                        maMonDay = "07";
                        break;
                    }
                case "66"://GDCD
                    {
                        maMonDay = "16";
                        break;
                    }
                default:
                    {
                        maMonDay = "36";
                        break;
                    }
            }
            return maMonDay;
        }
    }
}
