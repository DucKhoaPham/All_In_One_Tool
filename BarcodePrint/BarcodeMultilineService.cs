using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace BarcodePrint
{
    public class BarcodeMultilineService
    {
        private static BarcodeMultilineService _barcodeService = null;

        public const string DefaultSettingsFileName = @"Config\BarcodeMultilinePageSettings.xml";

        public static BarcodeMultilineService GetInstance()
        {
            if (_barcodeService == null)
            {
                _barcodeService = new BarcodeMultilineService();
            }

            return _barcodeService;
        }

        private BarcodeMultilineService()
        {
        }

        public void SaveSettings(BarcodeMultilinePageSetting settings, string fileName)
        {
            FileInfo file = new FileInfo(fileName);

            if(!Directory.Exists(file.DirectoryName))
            {
                Directory.CreateDirectory(file.DirectoryName);
            }

            using (FileStream fileStream = File.Create(fileName))
            {
                string data = BarcodeMultilinePageSetting.Serialize(settings);
                byte[] rawData = UTF8Encoding.UTF8.GetBytes(data);
                fileStream.Write(rawData, 0, rawData.Length);
            }
        }

        public BarcodeMultilinePageSetting LoadSettings(string fileName)
        {
            BarcodeMultilinePageSetting result = null;
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
                    result = BarcodeMultilinePageSetting.Deserialize(data);
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
            if(settings != null)
            {
                style = style | (settings.IsBold ? FontStyle.Bold : FontStyle.Regular);
                style = style | (settings.IsItalic ? FontStyle.Italic : FontStyle.Regular);
            }

            return style;
        }

        private Font GetFont(FontSetting settings, float generalFontSize)
        {
            Font font = new Font("Verdana",
                (settings != null ? (float)settings.FontSize : generalFontSize),
                GetFontStyle(settings),
                GraphicsUnit.World);

            return font;
        }

        private double ConvertFromMmToPixelDot(double valueMm, double dpi)
        {
            return (valueMm * dpi) / 25.4;
        }

        public Bitmap GenerateBitmapBarCode(BarcodeMultilinePageSetting settings, 
            string barcode, List<string> topPaneStringDisplays, List<string> sidePaneStringDisplays, 
            List<string> bottomPaneStringDisplays, 
            List<string> blockStringDisplays,
            bool showRectMargin)
        {
            if (topPaneStringDisplays != null && topPaneStringDisplays.Count > settings.TopPaneFontSettings.Count)
            {
                throw new Exception("Số lượng dòng hiển thị trên barcode lớn hơn số dòng định nghĩa.");
            }

            if (sidePaneStringDisplays != null && sidePaneStringDisplays.Count > settings.SidePaneFontSettings.Count)
            {
                throw new Exception("Số lượng dòng hiển thị bên cạnh barcode lớn hơn số dòng định nghĩa.");
            }

            if (bottomPaneStringDisplays != null && bottomPaneStringDisplays.Count > settings.BottomPaneFontSettings.Count)
            {
                throw new Exception("Số lượng dòng hiển thị bên cạnh barcode lớn hơn số dòng định nghĩa.");
            }

            double dpi = Convert.ToInt32(settings.DPI);

            //do rong mm cho tung chu khoang tu 2.75 - 3
            double barcodeCharRatio = Convert.ToDouble(settings.MMPerChar); //number of char per mm

            double barcodePageW = ConvertFromMmToPixelDot(settings.PaperSizeW, dpi);
            double barcodePageH = ConvertFromMmToPixelDot(settings.PaperSizeH, dpi);

            double marginLeft = ConvertFromMmToPixelDot(settings.MarginLeft, dpi);
            double marginRight = ConvertFromMmToPixelDot(settings.MarginRight, dpi);
            double marginTop = ConvertFromMmToPixelDot(settings.MarginTop, dpi);
            double marginBottom = ConvertFromMmToPixelDot(settings.MarginBottom, dpi);

            int numberOfStampPerPage = settings.StampsPerPage;

            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            b.RotateFlipType = RotateFlipType.RotateNoneFlipNone;
//            b.IncludeLabel = true;
            b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMLEFT;
            b.Alignment = BarcodeLib.AlignmentPositions.LEFT;

            BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;

            Bitmap bmpOut = new Bitmap((int)barcodePageW, (int)barcodePageH);
            bmpOut.SetResolution((int)dpi, (int)dpi);

            using (Graphics canvas = Graphics.FromImage(bmpOut))
            {
                Pen previewRectPen = new Pen(Color.DarkRed, 1);
                previewRectPen.DashStyle =  System.Drawing.Drawing2D.DashStyle.Dash;

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

                    // vẽ các dòng trên barcode
                    for(int i=0;i<topPaneStringDisplays.Count;i++)
                    {
                        var strDraw = topPaneStringDisplays[i];
                        double leftIndent = 0;
                        double rightIndent = 0;
                        Font fontUsing = GetFont(settings.TopPaneFontSettings[i], (float)settings.FontSize);
                        if (settings.TopPaneFontSettings[i] != null)
                        {
                            leftIndent += ConvertFromMmToPixelDot(settings.TopPaneFontSettings[i].LeftIndent, dpi);
                            rightIndent += ConvertFromMmToPixelDot(settings.TopPaneFontSettings[i].RightIndent, dpi);
                        }

                        SizeF stringSize = canvas.MeasureString(strDraw, fontUsing);
                        canvas.DrawString(strDraw, fontUsing,
                            new SolidBrush(Color.Black),
                            new RectangleF(
                                new PointF((float)(offsetLeft + marginLeft + leftIndent), (float)offsetTop),
                                new SizeF((float)(stampSize - marginLeft - marginRight - rightIndent - leftIndent), stringSize.Height - 2)),
                                (settings.TopPaneFontSettings[i] != null ?
                                    new StringFormat() { Alignment = settings.TopPaneFontSettings[i].Align } :
                                    new StringFormat() { Alignment = settings.HorizontalAlign }));

                        if (showRectMargin)
                        {
                            //draw first line
                            canvas.DrawRectangle(
                                previewRectPen,
                                new Rectangle(
                                    new Point((int)(offsetLeft + marginLeft + leftIndent), (int)offsetTop),
                                    new Size((int)(stampSize - marginLeft - marginRight - rightIndent - leftIndent), (int)(stringSize.Height - 2))));
                        }

                        offsetTop += stringSize.Height;
                    }

                    // draw barcode
                    double barcodeW = ConvertFromMmToPixelDot((double)barcodeText.Length * barcodeCharRatio, dpi);
                    double barcodeH = ConvertFromMmToPixelDot(settings.BarCodeHeight, dpi);

                    var imageBarCodeRaw = b.Encode(type,
                        barcodeText,
                        b.ForeColor, b.BackColor, (int)barcodeW, (int)barcodeH);

                    Bitmap bitmapBarCode = new Bitmap(imageBarCodeRaw);
                    bitmapBarCode.SetResolution((int)dpi, (int)dpi);

                    Rectangle sidePaneRect = new Rectangle();
                    Rectangle barcodePaneRect = new Rectangle();
                    switch (settings.BarcodeAlign)
                    {
                         case StringAlignment.Near:
                            canvas.DrawImage(bitmapBarCode,
                                new PointF((int)(offsetLeft + marginLeft), (int)offsetTop));

                            barcodePaneRect = new Rectangle(
                                (int)(offsetLeft + marginLeft),
                                (int)offsetTop,
                                (int)barcodeW, (int)barcodeH);

                            sidePaneRect = new Rectangle(
                                (int)(offsetLeft + marginLeft + barcodePaneRect.Width),
                                (int)offsetTop,
                                (int)(stampSize - barcodeW - marginLeft - marginRight), (int)barcodeH);

                            break;

                        case StringAlignment.Center:
                            canvas.DrawImage(bitmapBarCode,
                                new PointF(
                                    (float)(offsetLeft + marginLeft + ((stampSize - barcodeW - marginLeft - marginRight) / 2)),
                                    (float)offsetTop));

                            barcodePaneRect = new Rectangle(
                                (int)(offsetLeft + marginLeft + ((stampSize - barcodeW - marginLeft - marginRight) / 2)),
                                (int)offsetTop,
                                (int)barcodeW, (int)barcodeH);

                            sidePaneRect = new Rectangle(
                                barcodePaneRect.X + barcodePaneRect.Width,
                                (int)offsetTop,
                                (int)((stampSize - barcodeW - marginLeft - marginRight) / 2), (int)barcodeH);
                            break;

                        case StringAlignment.Far:
                            canvas.DrawImage(bitmapBarCode,
                                new PointF(
                                    (float)(offsetLeft + marginLeft + (stampSize - barcodeW - marginLeft - marginRight)), 
                                    (float)offsetTop));

                            sidePaneRect = new Rectangle(
                                (int)(offsetLeft + marginLeft),
                                (int)offsetTop,
                                (int)(stampSize - barcodeW - marginLeft - marginRight), (int)barcodeH);

                            barcodePaneRect = new Rectangle(
                                (int)(offsetLeft + marginLeft + sidePaneRect.Width),
                                (int)offsetTop,
                                (int)barcodeW, (int)barcodeH);

                            break;
                    }

                    // for debug only
                    if (showRectMargin)
                    {
                        canvas.DrawRectangle(
                            previewRectPen,
                            new Rectangle(
                                new Point((int)(offsetLeft + marginLeft), (int)offsetTop),
                                new Size((int)(stampSize - marginLeft - marginRight), (int)barcodeH)));

                        switch (settings.BarcodeAlign)
                        {
                            case StringAlignment.Near:

                                canvas.DrawRectangle(previewRectPen, barcodePaneRect);
                                canvas.DrawRectangle(previewRectPen, sidePaneRect);

                                break;
                            case StringAlignment.Center:
                                var centerPaneRect = barcodePaneRect;

                                var leftPaneRect = sidePaneRect;
                                leftPaneRect.X = (int)(offsetLeft + marginLeft);
                                leftPaneRect.Y = (int)offsetTop; 

                                var rightPaneRect = sidePaneRect;

                                canvas.DrawRectangle(previewRectPen, centerPaneRect);
                                canvas.DrawRectangle(previewRectPen, leftPaneRect);
                                canvas.DrawRectangle(previewRectPen, rightPaneRect);

                                break;
                            case StringAlignment.Far:
                                break;
                        }
                    }
                    offsetTop += barcodeH +2;

                    // vẽ dòng dưới barcode
                    for (int i = 0; i < bottomPaneStringDisplays.Count; i++)
                    {
                        var strDraw = bottomPaneStringDisplays[i];
                        double leftIndent = 0;
                        double rightIndent = 0;
                        Font fontUsing = GetFont(settings.BottomPaneFontSettings[i], (float)settings.FontSize);
                        if (settings.BottomPaneFontSettings[i] != null)
                        {
                            leftIndent += ConvertFromMmToPixelDot(settings.BottomPaneFontSettings[i].LeftIndent, dpi);
                            rightIndent += ConvertFromMmToPixelDot(settings.BottomPaneFontSettings[i].RightIndent, dpi);
                        }

                        SizeF stringSize = canvas.MeasureString(strDraw, fontUsing);
                        canvas.DrawString(strDraw, fontUsing,
                            new SolidBrush(Color.Black),
                            new RectangleF(
                                new PointF((float)(offsetLeft + marginLeft + leftIndent), (float)offsetTop),
                                new SizeF((float)(stampSize - marginLeft - marginRight - rightIndent - leftIndent), stringSize.Height - 2)),
                                (settings.BottomPaneFontSettings[i] != null ?
                                    new StringFormat() { Alignment = settings.BottomPaneFontSettings[i].Align } :
                                    new StringFormat() { Alignment = settings.HorizontalAlign }));

                        if (showRectMargin)
                        {
                            //draw first line
                            canvas.DrawRectangle(
                                previewRectPen,
                                new Rectangle(
                                    new Point((int)(offsetLeft + marginLeft + leftIndent), (int)offsetTop),
                                    new Size((int)(stampSize - marginLeft - marginRight - rightIndent - leftIndent), (int)(stringSize.Height - 2))));
                        }

                        offsetTop += stringSize.Height;
                    }

                    //vẽ dòng cạnh barcode
                    float offsetSide = 0;
                    for (int i = 0; i < sidePaneStringDisplays.Count; i++)
                    {
                        var strDraw = sidePaneStringDisplays[i];
                        double leftIndent = 0;
                        double rightIndent = 0;
                        Font fontUsing = GetFont(settings.SidePaneFontSettings[i], (float)settings.FontSize);
                        if (settings.SidePaneFontSettings[i] != null)
                        {
                            leftIndent += ConvertFromMmToPixelDot(settings.SidePaneFontSettings[i].LeftIndent, dpi);
                            rightIndent += ConvertFromMmToPixelDot(settings.SidePaneFontSettings[i].RightIndent, dpi);
                        }

                        SizeF stringSize = canvas.MeasureString(strDraw, fontUsing);
                        canvas.DrawString(strDraw, fontUsing,
                            new SolidBrush(Color.Black),
                            new RectangleF(

                                new PointF((float)(sidePaneRect.X + leftIndent), (float)sidePaneRect.Y + offsetSide),
                                new SizeF((float)(sidePaneRect.Width - rightIndent - leftIndent), stringSize.Height - 2)),
                                (settings.SidePaneFontSettings[i] != null ?
                                    new StringFormat() { Alignment = settings.SidePaneFontSettings[i].Align } :
                                    new StringFormat() { Alignment = settings.HorizontalAlign }));

                        if (showRectMargin)
                        {
                            //draw first line
                            canvas.DrawRectangle(
                                previewRectPen,
                                new Rectangle(
                                    new Point((int)(sidePaneRect.X + leftIndent), (int)sidePaneRect.Y + (int)offsetSide),
                                    new Size((int)(sidePaneRect.Width - rightIndent - leftIndent), (int)(stringSize.Height - 2))));
                        }

                        offsetSide += stringSize.Height;
                    }

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
                            Font fontUsing = GetFont(settings.BarcodeBlockSettings[i].FontSetting, (float)settings.FontSize);
                            if (settings.BarcodeBlockSettings[i].FontSetting != null)
                            {
                                leftIndent += ConvertFromMmToPixelDot(blockSetting.FontSetting.LeftIndent, dpi);
                                rightIndent += ConvertFromMmToPixelDot(blockSetting.FontSetting.RightIndent, dpi);
                            }

                            SizeF stringSize = canvas.MeasureString(strDraw, fontUsing);
                            canvas.DrawString(strDraw, fontUsing,
                                new SolidBrush(Color.Black),
                                new RectangleF(
                                    new PointF((float)(offsetLeft + marginLeft + leftIndent + offsetX),
                                        (float)(marginTop + offsetY + (blockHeight - (double)stringSize.Height) / 2)),
                                    new SizeF((float)(blockWidth), stringSize.Height - 2)),
                                    (blockSetting.FontSetting != null ?
                                        new StringFormat() { Alignment = blockSetting.FontSetting.Align } :
                                        new StringFormat() { Alignment = settings.HorizontalAlign }));

                            if (showRectMargin)
                            {
                                //draw first line
                                canvas.DrawRectangle(
                                    previewRectPen,
                                    new Rectangle(
                                        new Point((int)(offsetLeft + marginLeft + offsetX), (int)(marginTop + offsetY)),
                                        new Size((int)blockWidth, (int)blockHeight)));
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
