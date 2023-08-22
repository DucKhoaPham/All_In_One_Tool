using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BarcodePrint
{
    public class BarcodeBlockService
    {
        private static BarcodeBlockService _barcodeService = null;

        public const string DefaultSettingsFileName = @"Config\BarcodeMultiZoneSettings.xml";

        public static BarcodeBlockService GetInstance()
        {
            if (_barcodeService == null)
            {
                _barcodeService = new BarcodeBlockService();
            }

            return _barcodeService;
        }

        private BarcodeBlockService()
        {
        }

        public void SaveSettings(BarcodeMultiZoneSetting settings, string fileName)
        {
            FileInfo file = new FileInfo(fileName);

            if (!Directory.Exists(file.DirectoryName))
            {
                Directory.CreateDirectory(file.DirectoryName);
            }

            using (FileStream fileStream = File.Create(fileName))
            {
                string data = BarcodeMultiZoneSetting.Serialize(settings);
                byte[] rawData = UTF8Encoding.UTF8.GetBytes(data);
                fileStream.Write(rawData, 0, rawData.Length);
            }
        }

        public BarcodeMultiZoneSetting LoadSettings(string fileName)
        {
            BarcodeMultiZoneSetting result = null;
            string fullPath = fileName;
            if (!File.Exists(fullPath))
            {
                fullPath = string.Format("{0}\\{1}",
                    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                    fileName);
            }

            if (File.Exists(fullPath))
            {
                using (TextReader readFileStream = new StreamReader(fullPath))
                {
                    string data = readFileStream.ReadToEnd();
                    result = BarcodeMultiZoneSetting.Deserialize(data);
                }
            }

            return result;
        }

        private double CalculateStampSize(double pageWidth, int numberOfStampPerPage)
        {
            double result = (pageWidth / numberOfStampPerPage);
            return result;
        }

        private double CalculateStampLeft(double pageWidth, int stampIndex, int numberOfStampPerPage)
        {
            double result = CalculateStampSize(pageWidth, numberOfStampPerPage) * stampIndex;
            return result;
        }

        private FontStyle GetFontStyle(FontSetting settings)
        {
            FontStyle style = FontStyle.Regular;
            if (settings != null)
            {
                style = style | (settings.IsBold ? FontStyle.Bold : FontStyle.Regular);
                style = style | (settings.IsItalic ? FontStyle.Italic : FontStyle.Regular);
            }

            return style;
        }

        private Font GetFont(FontSetting settings, double ratio, float generalFontSize = 3)//mm
        {
            var fontSizeApply = (settings != null ? (float)settings.FontSize : generalFontSize);
            fontSizeApply = (float)ConvertFromMmToPixelDot(fontSizeApply, ratio);

            Font font = new Font("Verdana", fontSizeApply,
                GetFontStyle(settings),
                GraphicsUnit.Pixel);

            return font;
        }

        public double ConvertFromMmToPixelDot(double valueMm, double ratio)
        {
            return valueMm * ratio;
        }

        public void Draw(BarcodeMultiZoneSetting settings, double ratio, Graphics printingGraphics,
            string barcode, List<string> blockStringDisplays,
            bool showRectMargin)
        {
            double barcodePageW = ConvertFromMmToPixelDot(settings.PaperSizeW, ratio);
            double barcodePageH = ConvertFromMmToPixelDot(settings.PaperSizeH, ratio);

            double marginLeft = ConvertFromMmToPixelDot(settings.MarginLeft, ratio);
            double marginRight = ConvertFromMmToPixelDot(settings.MarginRight, ratio);
            double marginTop = ConvertFromMmToPixelDot(settings.MarginTop, ratio);
            double marginBottom = ConvertFromMmToPixelDot(settings.MarginBottom, ratio);

            int numberOfStampPerPage = settings.StampsPerPage;

            Pen showBorderRectPen = new Pen(Color.Black, 1);
            showBorderRectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            Pen previewRectPen = new Pen(Color.DarkRed, 1);
            previewRectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            printingGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, (int)barcodePageW, (int)barcodePageH);

            printingGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            printingGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            printingGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            for (int stampIndex = 0; stampIndex < numberOfStampPerPage; stampIndex++)
            {
                double offsetTop = marginTop;
                double offsetLeft = CalculateStampLeft(barcodePageW, stampIndex, numberOfStampPerPage);
                double stampSize = CalculateStampSize(barcodePageW, numberOfStampPerPage);

                if (showRectMargin)
                {
                    printingGraphics.DrawRectangle(
                        previewRectPen,
                        new Rectangle(
                            new Point((int)offsetLeft, 0),
                            new Size((int)stampSize, (int)(barcodePageH))));
                }

                var barcodeText = barcode.Trim();
                if (!string.IsNullOrEmpty(barcodeText))
                {

                    // draw barcode
                    double barcodeOffsetLeft = ConvertFromMmToPixelDot(settings.BarcodeOffsetLeft, ratio);
                    double barcodeOffsetTop = ConvertFromMmToPixelDot(settings.BarcodeOffsetTop, ratio);
                    double barcodeW = ConvertFromMmToPixelDot(settings.BarCodeWidth, ratio);
                    double barcodeH = ConvertFromMmToPixelDot(settings.BarCodeHeight, ratio);

                    DrawBarcode(printingGraphics, (float)barcodeW, (float)barcodeH, barcodeText,
                        (float)(offsetLeft + marginLeft + barcodeOffsetLeft),
                        (float)(offsetTop + barcodeOffsetTop));

                    // for debug only
                    if (showRectMargin)
                    {
                        printingGraphics.DrawRectangle(
                            previewRectPen,
                            new Rectangle(
                                new Point(
                                    (int)(offsetLeft + marginLeft + barcodeOffsetLeft),
                                    (int)(offsetTop + barcodeOffsetTop)),
                                new Size(
                                    (int)(barcodeW),
                                    (int)(barcodeH))));

                    }
                    offsetTop += barcodeH + 2;
                }

                if (blockStringDisplays != null)
                {
                    //draw block
                    for (int i = 0; i < blockStringDisplays.Count; i++)
                    {
                        var strDraw = blockStringDisplays[i];
                        if (i < settings.BarcodeBlockSettings.Count && settings.BarcodeBlockSettings[i] != null)
                        {
                            var blockSetting = settings.BarcodeBlockSettings[i];

                            double leftIndent = 0;
                            double rightIndent = 0;
                            double offsetX = ConvertFromMmToPixelDot(blockSetting.OffsetX, ratio);
                            double offsetY = ConvertFromMmToPixelDot(blockSetting.OffsetY, ratio);
                            double blockWidth = ConvertFromMmToPixelDot(blockSetting.Width, ratio);
                            double blockHeight = ConvertFromMmToPixelDot(blockSetting.Height, ratio);
                            Font fontUsing = GetFont(settings.BarcodeBlockSettings[i].FontSetting, ratio);
                            if (settings.BarcodeBlockSettings[i].FontSetting != null)
                            {
                                leftIndent += ConvertFromMmToPixelDot(blockSetting.FontSetting.LeftIndent, ratio);
                                rightIndent += ConvertFromMmToPixelDot(blockSetting.FontSetting.RightIndent, ratio);
                            }

                            SizeF stringSize = printingGraphics.MeasureString(strDraw, fontUsing);

                            var rect = new Rectangle(
                                        new Point((int)(offsetLeft + marginLeft + offsetX), (int)(marginTop + offsetY)),
                                        new Size((int)blockWidth, (int)blockHeight));

                            printingGraphics.DrawString(strDraw, fontUsing, new SolidBrush(Color.Black),
                                rect, new StringFormat()
                                {
                                    Alignment = blockSetting.FontSetting.Align,
                                    FormatFlags = StringFormatFlags.NoClip
                                });


                            if (settings.BarcodeBlockSettings[i].ShowBorder)
                            {
                                printingGraphics.DrawRectangle(showBorderRectPen, rect);
                            }
                            else if (showRectMargin)
                            {
                                //draw first line
                                printingGraphics.DrawRectangle(previewRectPen, rect);
                            }
                        }
                    }
                }
                //}

                //canvas.Save();
            }

            //return bmpOut;
        }

        /// <summary>
        /// Gắn cột hình barcode vào datatable
        /// </summary>
        /// <param name="dtPrint"></param>
        /// <param name="columnName"></param>
        /// <param name="barcodeWidthMm">độ rộng của hình barcdoe = mm</param>
        /// <param name="barcodeHeightMm">độ cao của hình barcode = mm</param>
        /// <param name="barcodePrint"></param>
        public void AppendBarcodeColumn(DataTable dtPrint, string columnName, int barcodeWidthMm, int barcodeHeightMm, string barcodePrint)
        {
            var settings = new BarcodeMultiZoneSetting()
            {
                PaperSizeW = barcodeWidthMm, // đo trên report ( propeties rồi chuyển từ inches sang mm)
                PaperSizeH = barcodeHeightMm,
                //DPI = 203,
                StampsPerPage = 1,
                MarginLeft = 0,
                MarginRight = 0,
                MarginTop = 0,
                MarginBottom = 0,
                BarCodeWidth = barcodeWidthMm, // đo trên report ( propeties rồi chuyển từ inches sang mm)
                BarCodeHeight = barcodeHeightMm,
                BarcodeOffsetLeft = 0,
                BarcodeOffsetTop = 0
            };

            AppendBarcodeColumn(dtPrint, columnName, settings, barcodePrint);
        }

        public void AppendBarcodeColumn(DataTable dtPrint, string columnName, BarcodeMultiZoneSetting settings, string barcodePrint)
        {
            if (dtPrint != null && settings != null)
            {
                var pidImageRaw = CreateBarcode(settings, barcodePrint, null);
                DataColumn columnPIDImage = new DataColumn(columnName, typeof(byte[]));
                dtPrint.Columns.Add(columnPIDImage);

                for (int i = 0; i < dtPrint.Rows.Count; i++)
                {
                    dtPrint.Rows[i][columnPIDImage] = pidImageRaw;
                }
            }
        }
        /// <summary>
        /// Gắn cột hình barcode vào datatable
        /// </summary>
        /// <param name="dtPrint"></param>
        /// <param name="columnName"></param>
        /// <param name="barcodeWidthMm">độ rộng của hình barcdoe = mm</param>
        /// <param name="barcodeHeightMm">độ cao của hình barcode = mm</param>
        /// <param name="barcodePrint"></param>
        public byte[] AppendBarcodeColumn(int barcodeWidthMm, int barcodeHeightMm, string barcodePrint)
        {
            var settings = new BarcodeMultiZoneSetting()
            {
                PaperSizeW = barcodeWidthMm, // đo trên report ( propeties rồi chuyển từ inches sang mm)
                PaperSizeH = barcodeHeightMm,
                StampsPerPage = 1,
                MarginLeft = 0,
                MarginRight = 0,
                MarginTop = 0,
                MarginBottom = 0,
                BarCodeWidth = barcodeWidthMm, // đo trên report ( propeties rồi chuyển từ inches sang mm)
                BarCodeHeight = barcodeHeightMm,
                BarcodeOffsetLeft = 0,
                BarcodeOffsetTop = 0
            };
            return AppendBarcodeColumn(settings, barcodePrint);
        }
        public byte[] AppendBarcodeColumn(BarcodeMultiZoneSetting settings, string barcodePrint)
        {
            byte[] pidImageRaw = null;
            if (settings != null)
            {
                var pidImage = CreateBarcodeBitmap(settings, barcodePrint, null);
                using (MemoryStream ms = new MemoryStream())
                {
                    pidImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    pidImageRaw = ms.ToArray();
                }
            }
            return pidImageRaw;
        }

        /// <summary>
        /// Tạo barcode gắn trong list để đưa vào report
        /// </summary>
        /// <param name="dtPrint"></param>
        /// <param name="columnName"></param>
        /// <param name="barcodeWidthMm">độ rộng của hình barcdoe = mm</param>
        /// <param name="barcodeHeightMm">độ cao của hình barcode = mm</param>
        /// <param name="barcodePrint"></param>
        /// 
        public byte[] CreateBarcode(int barcodeWidthMm, int barcodeHeightMm, string barcodePrint)
        {
            byte[] pidImageRaw = null;
            var settings = new BarcodeMultiZoneSetting()
            {
                PaperSizeW = barcodeWidthMm, // đo trên report ( propeties rồi chuyển từ inches sang mm)
                PaperSizeH = barcodeHeightMm,
                StampsPerPage = 1,
                MarginLeft = 0,
                MarginRight = 0,
                MarginTop = 0,
                MarginBottom = 0,
                BarCodeWidth = barcodeWidthMm, // đo trên report ( propeties rồi chuyển từ inches sang mm)
                BarCodeHeight = barcodeHeightMm,
                BarcodeOffsetLeft = 0,
                BarcodeOffsetTop = 0
            };
            pidImageRaw = CreateBarcode(settings, barcodePrint, null);
            return pidImageRaw;
        }

        public byte[] CreateBarcode(BarcodeMultiZoneSetting settings, string barcodePrint, List<string> listLabels)
        {
            byte[] pidImageRaw = null;
            if (settings != null)
            {
                Bitmap pidImage = CreateBarcodeBitmap(settings, barcodePrint, listLabels);
                if (pidImage != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pidImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        pidImageRaw = ms.ToArray();
                    }
                }
            }
            return pidImageRaw;
        }

        public Bitmap CreateBarcodeBitmap(BarcodeMultiZoneSetting settings, string barcodePrint, List<string> listLabels)
        {
            if (settings != null)
            {
                float dpi = 203;
                double zoomRatio = dpi / 25.4;
                double barcodePageW = ConvertFromMmToPixelDot(settings.PaperSizeW, zoomRatio);
                double barcodePageH = ConvertFromMmToPixelDot(settings.PaperSizeH, zoomRatio);

                Bitmap pidImage = new Bitmap((int)barcodePageW, (int)barcodePageH);
                //pidImage.SetResolution(dpi, dpi);
                using (Graphics canvas = Graphics.FromImage(pidImage))
                {
                    BarcodeBlockService.GetInstance().Draw(settings, zoomRatio, canvas, barcodePrint, listLabels, false);
                    canvas.Save();
                }
                return pidImage;
            }
            return null;
        }

        private void DrawBarcode(Graphics canvas, float width, float height, string rawData,
            float offsetLeft, float offsetTop)
        {
            var ibarcode = new Code128(rawData);
            var encodedValue = ibarcode.Encoded_Value;
            if (encodedValue == "")
            {
                throw new Exception("EGENERATE_IMAGE-1: Must be encoded first.");
            }

            float iBarWidth = width / encodedValue.Length;
            float iBarWidthModifier = 1;

            if (iBarWidth <= 0)
            {
                throw new Exception("EGENERATE_IMAGE-2: Image size specified not large enough to draw image. (Bar size determined to be less than 1 pixel)");
            }

            int countDraw = 0;
            int startBlock = -1;

            SolidBrush blackBrush = new SolidBrush(Color.Black);
            float singleEncodeVal = iBarWidth / iBarWidthModifier;
            for (int i = 0; i < encodedValue.Length; i++)
            {
                if (encodedValue[i] == '1')
                {
                    countDraw++;
                    if (startBlock == -1)
                    {
                        startBlock = i;
                    }
                }
                else
                {
                    canvas.FillRectangle(blackBrush,
                        offsetLeft + (startBlock * iBarWidth), offsetTop + 0, singleEncodeVal * countDraw, height);

                    countDraw = 0;
                    startBlock = -1;
                }
            }

            if (countDraw > 0)
            {
                canvas.FillRectangle(blackBrush,
                        offsetLeft + (startBlock * iBarWidth), offsetTop + 0, singleEncodeVal * countDraw, height);
            }
        }
    }
}
