using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;

namespace BarcodePrint
{
    public class BarcodeMultiZoneService
    {
        private static BarcodeMultiZoneService _barcodeService = null;

        public const string DefaultSettingsFileName = @"Config\BarcodeMultiZoneSettings.xml";

        public static BarcodeMultiZoneService GetInstance()
        {
            if (_barcodeService == null)
            {
                _barcodeService = new BarcodeMultiZoneService();
            }

            return _barcodeService;
        }

        private BarcodeMultiZoneService()
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

        private Font GetFont(FontSetting settings, float generalFontSize, string fontType = null)
        {
            Font font = new Font(fontType ?? "Verdana",
                (settings != null ? (float)settings.FontSize : generalFontSize),
                GetFontStyle(settings),
                GraphicsUnit.World);

            return font;
        }

        private double ConvertFromMmToPixelDot(double valueMm, double dpi)
        {
            return (valueMm * dpi) / 25.4;
        }

        public Bitmap GenerateBitmapBarCode(BarcodeMultiZoneSetting settings,
            string barcode, List<string> blockStringDisplays,
            bool showRectMargin, string fontType = null)
        {

            double dpi = Convert.ToInt32(settings.DPI);

            //do rong mm cho tung chu khoang tu 2.75 - 3
            //double barcodeCharRatio = Convert.ToDouble(settings.MMPerChar); //number of char per mm

            double barcodePageW = ConvertFromMmToPixelDot(settings.PaperSizeW, dpi);
            double barcodePageH = ConvertFromMmToPixelDot(settings.PaperSizeH, dpi);

            double marginLeft = ConvertFromMmToPixelDot(settings.MarginLeft, dpi);
            double marginRight = ConvertFromMmToPixelDot(settings.MarginRight, dpi);
            double marginTop = ConvertFromMmToPixelDot(settings.MarginTop, dpi);
            double marginBottom = ConvertFromMmToPixelDot(settings.MarginBottom, dpi);

            int numberOfStampPerPage = settings.StampsPerPage;

            BarcodeLib.Barcode barcodeLib = new BarcodeLib.Barcode();
            barcodeLib.RotateFlipType = RotateFlipType.RotateNoneFlipNone;
            //            b.IncludeLabel = true;
            barcodeLib.LabelPosition = BarcodeLib.LabelPositions.BOTTOMLEFT;
            barcodeLib.Alignment = BarcodeLib.AlignmentPositions.CENTER;

            BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;

            Bitmap bmpOut = new Bitmap((int)barcodePageW, (int)barcodePageH);
            bmpOut.SetResolution((int)dpi, (int)dpi);

            using (Graphics canvas = Graphics.FromImage(bmpOut))
            {
                Pen showBorderRectPen = new Pen(Color.Black, 1);
                showBorderRectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                Pen previewRectPen = new Pen(Color.DarkRed, 1);
                previewRectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                canvas.FillRectangle(new SolidBrush(Color.White), 0, 0, (int)barcodePageW, (int)barcodePageH);

                canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                canvas.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                for (int stampIndex = 0; stampIndex < numberOfStampPerPage; stampIndex++)
                {
                    double offsetTop = marginTop;
                    double offsetLeft = CalculateStampLeft(barcodePageW, stampIndex, numberOfStampPerPage);
                    double stampSize = CalculateStampSize(barcodePageW, numberOfStampPerPage);

                    if (showRectMargin)
                    {
                        canvas.DrawRectangle(
                            previewRectPen,
                            new Rectangle(
                                new Point((int)offsetLeft, 0),
                                new Size((int)stampSize, (int)(barcodePageH))));
                    }

                    var barcodeText = barcode.Trim();


                    // draw barcode
                    double barcodeW = ConvertFromMmToPixelDot(settings.BarCodeWidth, dpi);
                    double barcodeH = ConvertFromMmToPixelDot(settings.BarCodeHeight, dpi);
                    double barcodeOffsetLeft = ConvertFromMmToPixelDot(settings.BarcodeOffsetLeft, dpi);
                    double barcodeOffsetTop = ConvertFromMmToPixelDot(settings.BarcodeOffsetTop, dpi);

                    var imageBarCodeRaw = barcodeLib.Encode(type,
                        barcodeText,
                        barcodeLib.ForeColor, barcodeLib.BackColor, (int)barcodeW, (int)barcodeH);

                    Bitmap bitmapBarCode = new Bitmap(imageBarCodeRaw);
                    bitmapBarCode.SetResolution((int)dpi, (int)dpi);

                    canvas.DrawImage(bitmapBarCode,
                                new PointF(
                                    (int)(offsetLeft + marginLeft + barcodeOffsetLeft),
                                    (int)(offsetTop + barcodeOffsetTop)));

                    //for debug only
                    if (showRectMargin)
                    {
                        canvas.DrawRectangle(
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
                                double offsetX = ConvertFromMmToPixelDot(blockSetting.OffsetX, dpi);
                                double offsetY = ConvertFromMmToPixelDot(blockSetting.OffsetY, dpi);
                                double blockWidth = ConvertFromMmToPixelDot(blockSetting.Width, dpi);
                                double blockHeight = ConvertFromMmToPixelDot(blockSetting.Height, dpi);
                                Font fontUsing = GetFont(settings.BarcodeBlockSettings[i].FontSetting, (float)10, fontType);
                                if (settings.BarcodeBlockSettings[i].FontSetting != null)
                                {
                                    leftIndent += ConvertFromMmToPixelDot(blockSetting.FontSetting.LeftIndent, dpi);
                                    rightIndent += ConvertFromMmToPixelDot(blockSetting.FontSetting.RightIndent, dpi);
                                }

                                SizeF stringSize = canvas.MeasureString(strDraw, fontUsing);

                                var rect = new Rectangle(
                                            new Point((int)(offsetLeft + marginLeft + offsetX), (int)(marginTop + offsetY)),
                                            new Size((int)blockWidth, (int)blockHeight));

                                canvas.DrawString(strDraw, fontUsing, new SolidBrush(Color.Black),
                                    rect,
                                    new StringFormat() { Alignment = blockSetting.FontSetting.Align, FormatFlags = StringFormatFlags.NoClip });

                                if (settings.BarcodeBlockSettings[i].ShowBorder)
                                {
                                    canvas.DrawRectangle(showBorderRectPen, rect);
                                }
                                else if (showRectMargin)
                                {
                                    //draw first line
                                    canvas.DrawRectangle(previewRectPen, rect);
                                }
                            }
                        }
                    }
                }

                canvas.Save();
            }

            return bmpOut;
        }
        //không tạo hình barcode
        public Bitmap GenerateBitmapBarCodeNotShowBarcode(BarcodeMultiZoneSetting settings,
            string barcode, List<string> blockStringDisplays,
            bool showRectMargin)
        {

            double dpi = Convert.ToInt32(settings.DPI);

            //do rong mm cho tung chu khoang tu 2.75 - 3
            //double barcodeCharRatio = Convert.ToDouble(settings.MMPerChar); //number of char per mm

            double barcodePageW = ConvertFromMmToPixelDot(settings.PaperSizeW, dpi);
            double barcodePageH = ConvertFromMmToPixelDot(settings.PaperSizeH, dpi);

            double marginLeft = ConvertFromMmToPixelDot(settings.MarginLeft, dpi);
            double marginRight = ConvertFromMmToPixelDot(settings.MarginRight, dpi);
            double marginTop = ConvertFromMmToPixelDot(settings.MarginTop, dpi);
            double marginBottom = ConvertFromMmToPixelDot(settings.MarginBottom, dpi);

            int numberOfStampPerPage = settings.StampsPerPage;

            BarcodeLib.Barcode barcodeLib = new BarcodeLib.Barcode();
            barcodeLib.RotateFlipType = RotateFlipType.RotateNoneFlipNone;
            //            b.IncludeLabel = true;
            barcodeLib.LabelPosition = BarcodeLib.LabelPositions.BOTTOMLEFT;
            barcodeLib.Alignment = BarcodeLib.AlignmentPositions.CENTER;

            BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;

            Bitmap bmpOut = new Bitmap((int)barcodePageW, (int)barcodePageH);
            bmpOut.SetResolution((int)dpi, (int)dpi);

            using (Graphics canvas = Graphics.FromImage(bmpOut))
            {
                Pen showBorderRectPen = new Pen(Color.Black, 1);
                showBorderRectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                Pen previewRectPen = new Pen(Color.DarkRed, 1);
                previewRectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                canvas.FillRectangle(new SolidBrush(Color.White), 0, 0, (int)barcodePageW, (int)barcodePageH);

                canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                canvas.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                for (int stampIndex = 0; stampIndex < numberOfStampPerPage; stampIndex++)
                {
                    double offsetTop = marginTop;
                    double offsetLeft = CalculateStampLeft(barcodePageW, stampIndex, numberOfStampPerPage);
                    double stampSize = CalculateStampSize(barcodePageW, numberOfStampPerPage);

                    if (showRectMargin)
                    {
                        canvas.DrawRectangle(
                            previewRectPen,
                            new Rectangle(
                                new Point((int)offsetLeft, 0),
                                new Size((int)stampSize, (int)(barcodePageH))));
                    }

                    var barcodeText = barcode.Trim();


                    // draw barcode
                    double barcodeW = ConvertFromMmToPixelDot(settings.BarCodeWidth, dpi);
                    double barcodeH = ConvertFromMmToPixelDot(settings.BarCodeHeight, dpi);
                    double barcodeOffsetLeft = ConvertFromMmToPixelDot(settings.BarcodeOffsetLeft, dpi);
                    double barcodeOffsetTop = ConvertFromMmToPixelDot(settings.BarcodeOffsetTop, dpi);

                    var imageBarCodeRaw = barcodeLib.Encode(type,
                        barcodeText,
                        barcodeLib.ForeColor, barcodeLib.BackColor, (int)barcodeW, (int)barcodeH);

                    Bitmap bitmapBarCode = new Bitmap(imageBarCodeRaw);
                    bitmapBarCode.SetResolution((int)dpi, (int)dpi);

                    //canvas.DrawImage(bitmapBarCode,
                    //            new PointF(
                    //                (int)(offsetLeft + marginLeft + barcodeOffsetLeft),
                    //                (int)(offsetTop + barcodeOffsetTop)));

                    // for debug only
                    //if (showRectMargin)
                    //{
                    //    canvas.DrawRectangle(
                    //        previewRectPen,
                    //        new Rectangle(
                    //            new Point(
                    //                (int)(offsetLeft + marginLeft + barcodeOffsetLeft),
                    //                (int)(offsetTop + barcodeOffsetTop)),
                    //            new Size(
                    //                (int)(barcodeW), 
                    //                (int)(barcodeH))));

                    //}
                    offsetTop += barcodeH + 2;

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
                                double offsetX = ConvertFromMmToPixelDot(blockSetting.OffsetX, dpi);
                                double offsetY = ConvertFromMmToPixelDot(blockSetting.OffsetY, dpi);
                                double blockWidth = ConvertFromMmToPixelDot(blockSetting.Width, dpi);
                                double blockHeight = ConvertFromMmToPixelDot(blockSetting.Height, dpi);
                                Font fontUsing = GetFont(settings.BarcodeBlockSettings[i].FontSetting, (float)10);
                                if (settings.BarcodeBlockSettings[i].FontSetting != null)
                                {
                                    leftIndent += ConvertFromMmToPixelDot(blockSetting.FontSetting.LeftIndent, dpi);
                                    rightIndent += ConvertFromMmToPixelDot(blockSetting.FontSetting.RightIndent, dpi);
                                }

                                SizeF stringSize = canvas.MeasureString(strDraw, fontUsing);

                                var rect = new Rectangle(
                                            new Point((int)(offsetLeft + marginLeft + offsetX), (int)(marginTop + offsetY)),
                                            new Size((int)blockWidth, (int)blockHeight));

                                canvas.DrawString(strDraw, fontUsing, new SolidBrush(Color.Black),
                                    rect,
                                    new StringFormat() { Alignment = blockSetting.FontSetting.Align, FormatFlags = StringFormatFlags.NoClip });

                                if (settings.BarcodeBlockSettings[i].ShowBorder)
                                {
                                    canvas.DrawRectangle(showBorderRectPen, rect);
                                }
                                else if (showRectMargin)
                                {
                                    //draw first line
                                    canvas.DrawRectangle(previewRectPen, rect);
                                }
                            }
                        }
                    }
                }

                canvas.Save();
            }

            return bmpOut;
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
                DPI = 203,
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
        /// <summary>
        /// Lấy hình barcode để đưa lên trang in --add by ThangVT
        /// </summary>
        /// <param name="barcodeWidthMm">độ rộng của hình barcdoe = mm</param>
        /// <param name="barcodeHeightMm">độ cao của hình barcode = mm</param>
        /// <param name="barcodePrint"></param>
        public byte[] AppendBarcodeColumn(int barcodeWidthMm, int barcodeHeightMm, string barcodePrint)
        {
            var settings = new BarcodeMultiZoneSetting()
            {
                PaperSizeW = barcodeWidthMm, // đo trên report ( propeties rồi chuyển từ inches sang mm)
                PaperSizeH = barcodeHeightMm,
                DPI = 203,
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
                var pidImage = BarcodeMultiZoneService.GetInstance().GenerateBitmapBarCode(settings, barcodePrint, null, false);
                using (MemoryStream ms = new MemoryStream())
                {
                    pidImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    pidImageRaw = ms.ToArray();
                }
            }
            return pidImageRaw;
        }
        //-------------------------------------------------------------------------------------------
        public void AppendBarcodeColumn(DataTable dtPrint, string columnName, BarcodeMultiZoneSetting settings, string barcodePrint)
        {
            if (dtPrint != null && settings != null)
            {
                var pidImage = BarcodeMultiZoneService.GetInstance().GenerateBitmapBarCode(settings, barcodePrint, null, false);
                byte[] pidImageRaw = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    pidImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    pidImageRaw = ms.ToArray();
                }
                DataColumn columnPIDImage = new DataColumn(columnName, typeof(byte[]));
                //Nếu chưa có column thì mới thêm vào Datatable
                if (dtPrint.Columns[columnName] == null)
                {
                    dtPrint.Columns.Add(columnPIDImage);
                }

                for (int i = 0; i < dtPrint.Rows.Count; i++)
                {
                    //dtPrint.Rows[i][columnPIDImage] = pidImageRaw;
                    dtPrint.Rows[i][columnName] = pidImageRaw;
                }
            }
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
                DPI = 203,
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

            if (settings != null)
            {
                var pidImage = BarcodeMultiZoneService.GetInstance().GenerateBitmapBarCode(settings, barcodePrint, null, false);
                using (MemoryStream ms = new MemoryStream())
                {
                    pidImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    pidImageRaw = ms.ToArray();
                }
            }
            return pidImageRaw;
        }
        /// <summary>
        /// Ghép 2 ảnh thành 1 ảnh
        /// </summary>
        /// <param name="img1"></param>
        /// <param name="img2"></param>
        /// <returns></returns>
        public Bitmap CreateBarcodeTwoImge(Bitmap img1, Bitmap img2, BarcodeMultiZoneSetting settings)
        {
            double dpi = Convert.ToInt32(settings.DPI);
            double barcodePageW = ConvertFromMmToPixelDot(settings.PaperSizeW, dpi);
            double barcodePageH = ConvertFromMmToPixelDot(settings.PaperSizeH, dpi);
            Bitmap bitmap = new Bitmap((int)barcodePageW * 2, (int)barcodePageH);
            bitmap.SetResolution((int)dpi, (int)dpi);
            using (var canvas = Graphics.FromImage(bitmap))
            {
                canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                canvas.DrawImage(img1,
                                 new Rectangle(0,
                                               0,
                                               img1.Width,
                                               img1.Height),
                                 new Rectangle(0,
                                               0,
                                               img1.Width,
                                               img1.Height),
                                 GraphicsUnit.Pixel);
                if (img2 != null)
                {
                    canvas.DrawImage(img2,
                                 new Rectangle(img2.Width,
                                              0,
                                              img2.Width,
                                               img2.Height),
                                 new Rectangle(0, 0,
                                               img2.Width,
                                              img2.Height),
                                 GraphicsUnit.Pixel);
                }
                canvas.Save();
            }
            return bitmap;
        }

        public Bitmap GenerateBitmapImage(BarcodeMultiZoneSetting settings, List<string> blockStringDisplays, string fontType = null)
        {

            double dpi = Convert.ToInt32(settings.DPI);

            //do rong mm cho tung chu khoang tu 2.75 - 3
            //double barcodeCharRatio = Convert.ToDouble(settings.MMPerChar); //number of char per mm

            double barcodePageW = ConvertFromMmToPixelDot(settings.PaperSizeW, dpi);
            double barcodePageH = ConvertFromMmToPixelDot(settings.PaperSizeH, dpi);

            double marginLeft = ConvertFromMmToPixelDot(settings.MarginLeft, dpi);
            double marginRight = ConvertFromMmToPixelDot(settings.MarginRight, dpi);
            double marginTop = ConvertFromMmToPixelDot(settings.MarginTop, dpi);
            double marginBottom = ConvertFromMmToPixelDot(settings.MarginBottom, dpi);

            int numberOfStampPerPage = settings.StampsPerPage;

            BarcodeLib.Barcode barcodeLib = new BarcodeLib.Barcode();
            barcodeLib.RotateFlipType = RotateFlipType.RotateNoneFlipNone;
            //            b.IncludeLabel = true;
            barcodeLib.LabelPosition = BarcodeLib.LabelPositions.BOTTOMLEFT;
            barcodeLib.Alignment = BarcodeLib.AlignmentPositions.CENTER;

            BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;

            Bitmap bmpOut = new Bitmap((int)barcodePageW, (int)barcodePageH);
            bmpOut.SetResolution((int)dpi, (int)dpi);

            using (Graphics canvas = Graphics.FromImage(bmpOut))
            {
                Pen showBorderRectPen = new Pen(Color.Black, 1);
                showBorderRectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                Pen previewRectPen = new Pen(Color.DarkRed, 1);
                previewRectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                canvas.FillRectangle(new SolidBrush(Color.White), 0, 0, (int)barcodePageW, (int)barcodePageH);

                canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                canvas.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                for (int stampIndex = 0; stampIndex < numberOfStampPerPage; stampIndex++)
                {
                    double offsetTop = marginTop;
                    double offsetLeft = CalculateStampLeft(barcodePageW, stampIndex, numberOfStampPerPage);
                    double stampSize = CalculateStampSize(barcodePageW, numberOfStampPerPage);




                    // draw barcode
                    double barcodeW = ConvertFromMmToPixelDot(settings.BarCodeWidth, dpi);
                    double barcodeH = ConvertFromMmToPixelDot(settings.BarCodeHeight, dpi);
                    double barcodeOffsetLeft = ConvertFromMmToPixelDot(settings.BarcodeOffsetLeft, dpi);
                    double barcodeOffsetTop = ConvertFromMmToPixelDot(settings.BarcodeOffsetTop, dpi);

                    //var imageBarCodeRaw = barcodeLib.Encode(type,
                    //    barcodeText,
                    //    barcodeLib.ForeColor, barcodeLib.BackColor, (int)barcodeW, (int)barcodeH);

                    //Bitmap bitmapBarCode = new Bitmap(imageBarCodeRaw);
                    //bitmapBarCode.SetResolution((int)dpi, (int)dpi);

                    //canvas.DrawImage(bitmapBarCode,
                    //            new PointF(
                    //                (int)(offsetLeft + marginLeft + barcodeOffsetLeft),
                    //                (int)(offsetTop + barcodeOffsetTop)));

                    offsetTop += barcodeH + 2;

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
                                double offsetX = ConvertFromMmToPixelDot(blockSetting.OffsetX, dpi);
                                double offsetY = ConvertFromMmToPixelDot(blockSetting.OffsetY, dpi);
                                double blockWidth = ConvertFromMmToPixelDot(blockSetting.Width, dpi);
                                double blockHeight = ConvertFromMmToPixelDot(blockSetting.Height, dpi);
                                Font fontUsing = GetFont(settings.BarcodeBlockSettings[i].FontSetting, (float)10, fontType);
                                if (settings.BarcodeBlockSettings[i].FontSetting != null)
                                {
                                    leftIndent += ConvertFromMmToPixelDot(blockSetting.FontSetting.LeftIndent, dpi);
                                    rightIndent += ConvertFromMmToPixelDot(blockSetting.FontSetting.RightIndent, dpi);
                                }

                                SizeF stringSize = canvas.MeasureString(strDraw, fontUsing);

                                var rect = new Rectangle(
                                            new Point((int)(offsetLeft + marginLeft + offsetX), (int)(marginTop + offsetY)),
                                            new Size((int)blockWidth, (int)blockHeight));

                                canvas.DrawString(strDraw, fontUsing, new SolidBrush(Color.Black),
                                    rect,
                                    new StringFormat() { Alignment = blockSetting.FontSetting.Align, FormatFlags = StringFormatFlags.NoClip });

                                if (settings.BarcodeBlockSettings[i].ShowBorder)
                                {
                                    canvas.DrawRectangle(showBorderRectPen, rect);
                                }

                            }
                        }
                    }
                }

                canvas.Save();
            }

            return bmpOut;
        }
    }
}
