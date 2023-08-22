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
    public class BarcodeMultiZoneSetting
    {
        public double PaperSizeW { get; set; }
        public double PaperSizeH { get; set; }
        public double DPI { get; set; }
        public int StampsPerPage { get; set; }
        public double MarginLeft { get; set; }
        public double MarginRight { get; set; }
        public double MarginTop { get; set; }
        public double MarginBottom { get; set; }

        public double BarCodeWidth { get; set; }

        public double BarCodeHeight { get; set; }

        public double BarcodeOffsetLeft { get; set; }

        public double BarcodeOffsetTop { get; set; }


        //public StringAlignment BarcodeAlign { get; set; }

        public string BarcodePrinterName { get; set; }

        public string SamplpeBarcode { get; set; }

        public List<BarcodeBlockSetting> BarcodeBlockSettings { get; set; }

        public BarcodeMultiZoneSetting()
        {
            BarcodeBlockSettings = new List<BarcodeBlockSetting>();
        }

        public static string Serialize(BarcodeMultiZoneSetting info)
        {
            string result = null;
            XmlSerializer serializer = new XmlSerializer(typeof(BarcodeMultiZoneSetting));
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

        public static BarcodeMultiZoneSetting Deserialize(string value)
        {
            BarcodeMultiZoneSetting result = null;

            XmlSerializer serializer = new XmlSerializer(typeof(BarcodeMultiZoneSetting));
            using (MemoryStream readStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(value)))
            {
                XmlReader reader = new XmlTextReader(readStream);
                result = (BarcodeMultiZoneSetting)serializer.Deserialize(reader);
            }
            return result;
        }
    }
}
