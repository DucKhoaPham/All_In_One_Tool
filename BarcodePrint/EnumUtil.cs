using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BarcodePrint
{
    public class DisplayItem<T>
    {
        public T ID { get; set; }
        public string Name { get; set; }
    }

    public static class EnumUtil
    {
        public static string GetEnumDescription(Enum value, string defaultValue)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null &&
                attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return defaultValue;
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null &&
                attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public static List<DisplayItem<T>> GetList<T>()
        {
            List<DisplayItem<T>> result = new List<DisplayItem<T>>();
            var temps = Enum.GetValues(typeof(T));
            foreach (var enumValue in temps)
            {
                DisplayItem<T> displayItem = new DisplayItem<T>()
                {
                    ID = (T)enumValue,
                    Name = GetEnumDescription((Enum)enumValue)
                };
                result.Add(displayItem);
            }

            return result;
        }

        public static T FromString<T>(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return default(T);
            }
            return (T)Enum.Parse(typeof(T), value);

        }
    }
}
