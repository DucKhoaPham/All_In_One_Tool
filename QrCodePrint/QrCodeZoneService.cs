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
using QRCoder;

namespace QrCodePrint
{
    public class QrCodeZoneService
    {
        private static QrCodeZoneService _barcodeService = null;

        public const string DefaultSettingsFileName = @"Config\QrCodeZoneSettings.xml";

        public static QrCodeZoneService GetInstance()
        {
            if (_barcodeService == null)
            {
                _barcodeService = new QrCodeZoneService();
            }

            return _barcodeService;
        }

        private QrCodeZoneService()
        {
        }

        public void SaveSettings(QrCodeZoneSetting settings, string fileName)
        {
            FileInfo file = new FileInfo(fileName);

            if (!Directory.Exists(file.DirectoryName))
            {
                Directory.CreateDirectory(file.DirectoryName);
            }

            using (FileStream fileStream = File.Create(fileName))
            {
                string data = QrCodeZoneSetting.Serialize(settings);
                byte[] rawData = UTF8Encoding.UTF8.GetBytes(data);
                fileStream.Write(rawData, 0, rawData.Length);
            }
        }

        public QrCodeZoneSetting LoadSettings(string fileName)
        {
            QrCodeZoneSetting result = null;
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
                    result = QrCodeZoneSetting.Deserialize(data);
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

        //private double ConvertFromMmToPixelDot(double valueMm, double dpi)
        //{
        //    return (valueMm * dpi) / 25.4;
        //}

        //private double GetRatio(double paperSizeMm, double printableWidth)
        //{
        //    return printableWidth / paperSizeMm;
        //}

        public double ConvertFromMmToPixelDot(double valueMm, double ratio)
        {
            return valueMm * ratio;
        }

        public void Draw(QrCodeZoneSetting settings, double ratio, Graphics printingGraphics,
            string barcode, List<string> blockStringDisplays,
            bool showRectMargin)
        {
            //PrintDocument _printDoc = new PrintDocument();
            //_printDoc.PrinterSettings.PrinterName = "w80";

            //var ratio = GetRatio(settings.PaperSizeW, printingGraphics. _printDoc.DefaultPageSettings.PrintableArea.Width);

            //double dpi = Convert.ToInt32(settings.DPI);

            //do rong mm cho tung chu khoang tu 2.75 - 3
            //double barcodeCharRatio = Convert.ToDouble(settings.MMPerChar); //number of char per mm

            double barcodePageW = ConvertFromMmToPixelDot(settings.PaperSizeW, ratio);
            double barcodePageH = ConvertFromMmToPixelDot(settings.PaperSizeH, ratio);

            double marginLeft = ConvertFromMmToPixelDot(settings.MarginLeft, ratio);
            double marginRight = ConvertFromMmToPixelDot(settings.MarginRight, ratio);
            double marginTop = ConvertFromMmToPixelDot(settings.MarginTop, ratio);
            double marginBottom = ConvertFromMmToPixelDot(settings.MarginBottom, ratio);

            int numberOfStampPerPage = settings.StampsPerPage;



            //Bitmap bmpOut = new Bitmap((int)barcodePageW, (int)barcodePageH);
            //bmpOut.SetResolution((int)dpi, (int)dpi);

            //_printDoc.PrinterSettings.CreateMeasurementGraphics();

            //using (Graphics canvas = _printDoc.PrinterSettings.CreateMeasurementGraphics())
            //{
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


                // draw barcode
                double barcodeOffsetLeft = ConvertFromMmToPixelDot(settings.BarcodeOffsetLeft, ratio);
                double barcodeOffsetTop = ConvertFromMmToPixelDot(settings.BarcodeOffsetTop, ratio);
                double barcodeW = ConvertFromMmToPixelDot(settings.BarCodeWidth, ratio);
                //double barcodeH = ConvertFromMmToPixelDot(settings.BarCodeHeight, ratio);

                //Image imageBarCodeRaw = null;
                QRCodeGenerator.ECCLevel eccLevel = QRCodeGenerator.ECCLevel.Q;
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                {
                    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(barcodeText, eccLevel))
                    {
                        float xxx = (float) (barcodeW / qrCodeData.ModuleMatrix.Count);

                        using (QRCode qrCode = new QRCode(qrCodeData))
                        {
                            //imageBarCodeRaw = qrCode.GetGraphicF((float)barcodeW, Color.Black, Color.White);
                            //.ResizeTo(100, 100).SetMargins(0)
                            qrCode.GetGraphic(20);
                            //qrCode.DrawGraphicF(printingGraphics,
                            //    (float)(offsetLeft + marginLeft + barcodeOffsetLeft),
                            //    (float)(offsetTop + barcodeOffsetTop),
                            //    (float)barcodeW, Color.Black, Color.White);
                        }
                    }
                }

                //var imageBarCodeRaw = IronBarCode.BarcodeWriter
                //.CreateBarcode(barcodeText, BarcodeEncoding.QRCode, (int)barcodeW, (int)barcodeH)
                //.ResizeTo(100, 100).SetMargins(0)
                //.ToImage();

                //printingGraphics.DrawImageUnscaled(imageBarCodeRaw,
                //    (int)(offsetLeft + marginLeft + barcodeOffsetLeft),
                //    (int)(offsetTop + barcodeOffsetTop),
                //    imageBarCodeRaw.Width, imageBarCodeRaw.Height);

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
                                (int)(barcodeW))));

                }
                offsetTop += barcodeW + 2;

                if (blockStringDisplays != null)
                {
                    //draw block
                    for (int i = 0; i < blockStringDisplays.Count; i++)
                    {
                        var strDraw = blockStringDisplays[i];
                        if (i < settings.QrCodeBlockSettings.Count && settings.QrCodeBlockSettings[i] != null)
                        {
                            var blockSetting = settings.QrCodeBlockSettings[i];

                            double leftIndent = 0;
                            double rightIndent = 0;
                            double offsetX = ConvertFromMmToPixelDot(blockSetting.OffsetX, ratio);
                            double offsetY = ConvertFromMmToPixelDot(blockSetting.OffsetY, ratio);
                            double blockWidth = ConvertFromMmToPixelDot(blockSetting.Width, ratio);
                            double blockHeight = ConvertFromMmToPixelDot(blockSetting.Height, ratio);
                            Font fontUsing = GetFont(settings.QrCodeBlockSettings[i].FontSetting, ratio);
                            if (settings.QrCodeBlockSettings[i].FontSetting != null)
                            {
                                leftIndent += ConvertFromMmToPixelDot(blockSetting.FontSetting.LeftIndent, ratio);
                                rightIndent += ConvertFromMmToPixelDot(blockSetting.FontSetting.RightIndent, ratio);
                            }

                            SizeF stringSize = printingGraphics.MeasureString(strDraw, fontUsing);

                            var rect = new Rectangle(
                                        new Point((int)(offsetLeft + marginLeft + offsetX), (int)(marginTop + offsetY)),
                                        new Size((int)blockWidth, (int)blockHeight));

                            printingGraphics.DrawString(strDraw, fontUsing, new SolidBrush(Color.Black),
                                rect,
                                new StringFormat() { Alignment = blockSetting.FontSetting.Align, FormatFlags = StringFormatFlags.NoClip });

                            if (settings.QrCodeBlockSettings[i].ShowBorder)
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
        public void AppendBarcodeColumn(DataTable dtPrint, string columnName, int barcodeWidthMm, int barcodeHeightMm, string barcodePrint)
        {
            var settings = new QrCodeZoneSetting()
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
                //BarCodeHeight = barcodeHeightMm,
                BarcodeOffsetLeft = 0,
                BarcodeOffsetTop = 0
            };

            AppendBarcodeColumn(dtPrint, columnName, settings, barcodePrint);
        }

        public void AppendBarcodeColumn(DataTable dtPrint, string columnName, QrCodeZoneSetting settings, string barcodePrint)
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
            var settings = new QrCodeZoneSetting()
            {
                PaperSizeW = barcodeWidthMm, // đo trên report ( propeties rồi chuyển từ inches sang mm)
                PaperSizeH = barcodeHeightMm,
                StampsPerPage = 1,
                MarginLeft = 0,
                MarginRight = 0,
                MarginTop = 0,
                MarginBottom = 0,
                BarCodeWidth = barcodeWidthMm, // đo trên report ( propeties rồi chuyển từ inches sang mm)
                //BarCodeHeight = barcodeHeightMm,
                BarcodeOffsetLeft = 0,
                BarcodeOffsetTop = 0
            };
            return AppendBarcodeColumn(settings, barcodePrint);
        }
        public byte[] AppendBarcodeColumn(QrCodeZoneSetting settings, string barcodePrint)
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
            var settings = new QrCodeZoneSetting()
            {
                PaperSizeW = barcodeWidthMm, // đo trên report ( propeties rồi chuyển từ inches sang mm)
                PaperSizeH = barcodeHeightMm,
                StampsPerPage = 1,
                MarginLeft = 0,
                MarginRight = 0,
                MarginTop = 0,
                MarginBottom = 0,
                BarCodeWidth = barcodeWidthMm, // đo trên report ( propeties rồi chuyển từ inches sang mm)
                //BarCodeHeight = barcodeHeightMm,
                BarcodeOffsetLeft = 0,
                BarcodeOffsetTop = 0,
                Zoom=7
            };
            pidImageRaw = CreateBarcode(settings, barcodePrint, null);
            return pidImageRaw;
        }

        public byte[] CreateBarcode(QrCodeZoneSetting settings, string barcodePrint, List<string> listLabels)
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

        public Bitmap CreateBarcodeBitmap(QrCodeZoneSetting settings, string barcodePrint, List<string> listLabels)
        {
            if (settings != null)
            {
                double barcodePageW = ConvertFromMmToPixelDot(settings.PaperSizeW, settings.Zoom);
                double barcodePageH = ConvertFromMmToPixelDot(settings.PaperSizeH, settings.Zoom);

                Bitmap pidImage = new Bitmap((int)barcodePageW, (int)barcodePageH);
                using (Graphics canvas = Graphics.FromImage(pidImage))
                {
                    QrCodeZoneService.GetInstance().Draw(settings, settings.Zoom, canvas, barcodePrint, listLabels, false);
                    canvas.Save();
                }
                return pidImage;
            }
            return null;
        }
        /// <summary>
        /// Gép danh sách các ảnh thành 1 hàng
        /// </summary>
        /// <param name="img1"></param>
        /// <param name="img2"></param>
        /// <returns></returns>
        public List<Bitmap> CreateBarcodeMutiImge(List<Bitmap> img, QrCodeZoneSetting settings)
        {
            List<Bitmap> _listresult = new List<Bitmap>();
            int demitemp = 0;
            int dem = 0;
            List<Bitmap> listimgprintrow = new List<Bitmap>();
            foreach (var item in img)
            {
                demitemp++;
                dem++;
                listimgprintrow.Add(item);
                if (demitemp == settings.NumberTemInRow || dem == img.Count)
                {
                    Bitmap bitmap = new Bitmap(img[0].Width * settings.NumberTemInRow, img[0].Height);
                    bitmap.SetResolution((int)settings.DPI, (int)(settings.DPI));
                    using (var canvas = Graphics.FromImage(bitmap))
                    {
                        canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        int _width = 0;
                        foreach (var itemrow in listimgprintrow)
                        {
                            canvas.DrawImage(itemrow,
                                        new Rectangle(_width,
                                                      0,
                                                      itemrow.Width,
                                                      itemrow.Height),
                                        new Rectangle(0,
                                                      0,
                                                      itemrow.Width,
                                                      itemrow.Height),
                                        GraphicsUnit.Pixel);
                            _width += itemrow.Width;
                        }
                        canvas.Save();
                    }
                    demitemp = 0;
                    _listresult.Add(bitmap);
                    listimgprintrow.Clear();
                }
            }
            return _listresult;
        }
    }
}
