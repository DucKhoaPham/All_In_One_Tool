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
    public class BarcodeMultilinePageSetting
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

        public StringAlignment BarcodeAlign { get; set; }

        public List<FontSetting> TopPaneFontSettings { get; set; }

        public List<FontSetting> BottomPaneFontSettings { get; set; }

        public List<FontSetting> SidePaneFontSettings { get; set; }

        public string BarcodePrinterName { get; set; }

        public List<BarcodeBlockSetting> BarcodeBlockSettings { get; set; }

        public BarcodeMultilinePageSetting()
        {
            TopPaneFontSettings = new List<FontSetting>();
            BottomPaneFontSettings = new List<FontSetting>();
            SidePaneFontSettings = new List<FontSetting>();
            BarcodeBlockSettings = new List<BarcodeBlockSetting>();
        }

        public static string Serialize(BarcodeMultilinePageSetting info)
        {
            string result = null;
            XmlSerializer serializer = new XmlSerializer(typeof(BarcodeMultilinePageSetting));
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

        public static BarcodeMultilinePageSetting Deserialize(string value)
        {
            BarcodeMultilinePageSetting result = null;

            XmlSerializer serializer = new XmlSerializer(typeof(BarcodeMultilinePageSetting));
            using (MemoryStream readStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(value)))
            {
                XmlReader reader = new XmlTextReader(readStream);
                result = (BarcodeMultilinePageSetting)serializer.Deserialize(reader);
            }
            return result;
        }
    }
}
