using System.Xml.Serialization;

namespace QI.Core.Common
{
    public class UtilsHelper
    {
        /// <summary>
        /// Object to xml
        /// </summary>
        public static string ObjectToXML<T>(T obj)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(stringwriter, obj);
            return stringwriter.ToString();
        }
        public static int ParseInt(string value, int defaultValue = 0)
        {
            int valueInt = defaultValue;
            int.TryParse(value, out valueInt);
            return valueInt;
        }
    }
}
