using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace QrCodePrint
{
    public class QrCodeBlockTemplateSetting : ICloneable
    {
        public List<QrCodeBlockTemplateSettingDetail> ListDetail { get; set; }

        public QrCodeBlockTemplateSetting()
        {
            ListDetail = new List<QrCodeBlockTemplateSettingDetail>();
        }

        public void CopyValue(QrCodeBlockTemplateSetting setting)
        {
            this.ListDetail.Clear();
            this.ListDetail.AddRange(setting.ListDetail);
        }

        public object Clone()
        {
            var temp = new QrCodeBlockTemplateSetting();
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

        public static string Serialize(QrCodeBlockTemplateSetting info)
        {
            string result = null;
            XmlSerializer serializer = new XmlSerializer(typeof(QrCodeBlockTemplateSetting));
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

        public static QrCodeBlockTemplateSetting Deserialize(string value)
        {
            QrCodeBlockTemplateSetting result = null;

            XmlSerializer serializer = new XmlSerializer(typeof(QrCodeBlockTemplateSetting));
            using (MemoryStream readStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(value)))
            {
                XmlReader reader = new XmlTextReader(readStream);
                result = (QrCodeBlockTemplateSetting)serializer.Deserialize(reader);
            }
            return result;
        }
    }
}
