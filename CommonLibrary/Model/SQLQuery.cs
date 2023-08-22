using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CommonLibrary.Model
{
    public partial class SQLQuery
    {
        public string QueryText { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public NameQuery Info { get; set; }
        public SQLQuery Clone()
        {
            return (SQLQuery)this.MemberwiseClone();
        }
        public enum  NameQuery : int
        {
            [Description("Check queries running")]
            CHECK_QUERIES = 0,
            [Description("Check lock table")]
            CHECK_DEADLOCK = 1,
            [Description("Check programs running")]
            CHECK_PROGRAMS = 2,
            [Description("Check infomation of databas")]
            CHECK_INFO = 3,
        }
        public static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ArgumentException(string.Format("{0} is not an enumeration type", type));
            }

            foreach (var field in type.GetFields())
            {
                var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0 && attributes[0].Description == description)
                {
                    return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException(string.Format("No {0} member has a Description attribute with value '{1}'", type, description));
        }
        public static string GetEnumDescription(Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }
        public static bool CheckPermission(string[] permissions, string page)
        {
            if (permissions[0] == "ALL" && page != "ChangePassword.aspx")
                return true;
            var getEnum = GetEnumValueFromDescription<NameQuery>(page);
            if (permissions.Any(x => x == ((Int32)getEnum).ToString()))
                return true;
            return false;
        }
    }
}
