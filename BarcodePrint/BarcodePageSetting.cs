using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BarcodePrint
{
    public class BarcodePageSetting
    {
        public double PaperSizeW { get; set; }
        public double PaperSizeH { get; set; }
        public double DPI { get; set; }
        public int StampsPerPage { get; set; }

        public double MarginLeft { get; set; }
        public double MarginRight { get; set; }
        public double MarginTop { get; set; }
        public double MarginBottom { get; set; }

        public double MMPerChar { get; set; }

        public double FontSize { get; set; }

        public double BarCodeHeight { get; set; }

        public StringAlignment HorizontalAlign { get; set; }

        public FontSetting FirstLineFontSetting { get; set; }
        public FontSetting SecondLineFontSetting { get; set; }
        public FontSetting DescriptionFontSetting { get; set; }
        public FontSetting SideFontSetting { get; set; }

        public StringAlignment BarcodeAlign { get; set; }

        public static string Serialize(BarcodePageSetting info)
        {
            string result = null;
            XmlSerializer serializer = new XmlSerializer(typeof(BarcodePageSetting));
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

        public static BarcodePageSetting Deserialize(string value)
        {
            BarcodePageSetting result = null;

            XmlSerializer serializer = new XmlSerializer(typeof(BarcodePageSetting));
            using (MemoryStream readStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(value)))
            {
                XmlReader reader = new XmlTextReader(readStream);
                result = (BarcodePageSetting)serializer.Deserialize(reader);
            }
            return result;
        }
    }
}
