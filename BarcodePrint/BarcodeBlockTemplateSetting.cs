using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BarcodePrint
{
    public class BarcodeBlockTemplateSetting : ICloneable
    {
        public List<BarcodeBlockTemplateSettingDetail> ListDetail { get; set; }

        public BarcodeBlockTemplateSetting()
        {
            ListDetail = new List<BarcodeBlockTemplateSettingDetail>();
        }

        public void CopyValue(BarcodeBlockTemplateSetting setting)
        {
            this.ListDetail.Clear();
            this.ListDetail.AddRange(setting.ListDetail);
        }

        public object Clone()
        {
            var temp = new BarcodeBlockTemplateSetting();
            temp.ListDetail.AddRange(
                this.ListDetail);
            return temp;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("ListDetail: [");
            if(ListDetail != null)
            {
                foreach(var item in ListDetail)
                {
                    builder.AppendFormat("{0},");
                }
            }
            builder.AppendFormat("]");
            return builder.ToString();
        }

        public static string Serialize(BarcodeBlockTemplateSetting info)
        {
            string result = null;
            XmlSerializer serializer = new XmlSerializer(typeof(BarcodeBlockTemplateSetting));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = UTF8Encoding.UTF8;
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
                using (XmlWriter xmlTextWriter = XmlWriter.Create(memoryStream, settings))
                {
                    serializer.Serialize(xmlTextWriter, info);
                }

                result = Encoding.UTF8.GetString(memoryStream.ToArray());
            }

            return result;
        }

        public static BarcodeBlockTemplateSetting Deserialize(string value)
        {
            BarcodeBlockTemplateSetting result = null;

            XmlSerializer serializer = new XmlSerializer(typeof(BarcodeBlockTemplateSetting));
            using (MemoryStream readStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(value)))
            {
                XmlReader reader = new XmlTextReader(readStream);
                result = (BarcodeBlockTemplateSetting)serializer.Deserialize(reader);
            }
            return result;
        }
    }
}
