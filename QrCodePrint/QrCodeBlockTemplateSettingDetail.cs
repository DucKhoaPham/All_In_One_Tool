using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace QrCodePrint
{
    public class QrCodeBlockTemplateSettingDetail : ICloneable
    {
        public string TemplateName { get; set; }
        public string TemplatePath { get; set; }

        public void CopyValue(QrCodeBlockTemplateSettingDetail setting)
        {
            this.TemplateName = setting.TemplateName;
            this.TemplatePath = setting.TemplatePath;
        }

        public object Clone()
        {
            return new QrCodeBlockTemplateSettingDetail()
            {
                TemplateName = this.TemplateName,
                TemplatePath = this.TemplatePath,
            };
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("TemplateName: {0}|", TemplateName);
            builder.AppendFormat("TemplatePath: {0}|", TemplatePath);

            return builder.ToString();
        }

        public static string Serialize(QrCodeBlockTemplateSettingDetail info)
        {
            string result = null;
            XmlSerializer serializer = new XmlSerializer(typeof(QrCodeBlockTemplateSettingDetail));
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

        public static QrCodeBlockTemplateSettingDetail Deserialize(string value)
        {
            QrCodeBlockTemplateSettingDetail result = null;

            XmlSerializer serializer = new XmlSerializer(typeof(QrCodeBlockTemplateSettingDetail));
            using (MemoryStream readStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(value)))
            {
                XmlReader reader = new XmlTextReader(readStream);
                result = (QrCodeBlockTemplateSettingDetail)serializer.Deserialize(reader);
            }
            return result;
        }
    }
}
