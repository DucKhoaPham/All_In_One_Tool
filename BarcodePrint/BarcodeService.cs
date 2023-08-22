using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace BarcodePrint
{
    public class BarcodeService
    {
        private static BarcodeService _barcodeService = null;

        public const string DefaultSettingsFileName = "PageSettings.xml";

        public static BarcodeService GetInstance()
        {
            if (_barcodeService == null)
            {
                _barcodeService = new BarcodeService();
            }

            return _barcodeService;
        }

        private BarcodeService()
        {
        }

        public void SaveSettings(BarcodePageSetting settings, string fileName)
        {
            using (FileStream fileStream = File.Create(fileName))
            {
                string data = BarcodePageSetting.Serialize(settings);
                byte[] rawData = UTF8Encoding.UTF8.GetBytes(data);
                fileStream.Write(rawData, 0, rawData.Length);
            }
        }

        public BarcodePageSetting LoadSettings(string fileName)
        {
            BarcodePageSetting result = null;
            if (File.Exists(fileName))
            {
                using (TextReader readFileStream = new StreamReader(fileName))
                {
                    string data = readFileStream.ReadToEnd();
                    result = BarcodePageSetting.Deserialize(data);
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

        public Bitmap GenerateBitmapBarCode(BarcodePageSetting settings, 
            string barcode, string firstLineBarLabel, string secondLineBarLabel, string sideLabel, 
            bool showRectMargin = false, 
            string description = null)
        {
            double dpi = Convert.ToInt32(settings.DPI);

            //do rong mm cho tung chu khoang tu 2.75 - 3
            double barcodeCharRatio = Convert.ToDouble(settings.MMPerChar); //number of char per mm

            double barcodePageW = ConvertFromMmToPixelDot(settings.PaperSizeW, dpi);
            double barcodePageH = ConvertFromMmToPixelDot(settings.PaperSizeH, dpi);

            double marginLeft = ConvertFromMmToPixelDot(settings.MarginLeft, dpi);
            double marginRight = ConvertFromMmToPixelDot(settings.MarginRight, dpi);
            double marginTop = ConvertFromMmToPixelDot(settings.MarginTop, dpi);
            double marginBottom = ConvertFromMmToPixelDot(settings.MarginBottom, dpi);

            //float fontSize = (float)settings.FontSize;
            //Font fontUse = new Font("Verdana", fontSize, FontStyle.Regular, GraphicsUnit.World);
            Font fontFirstLine = GetFont(settings.FirstLineFontSetting, (float)settings.FontSize);
            Font fontSecondLine = GetFont(settings.SecondLineFontSetting, (float)settings.FontSize);
            Font fontDescriptionLine = GetFont(settings.DescriptionFontSetting, (float)settings.FontSize);
            Font fontSideText = GetFont(settings.SideFontSetting, (float)settings.FontSize);

            //StringFormat stringFormatGeneral = new StringFormat();
            //stringFormatGeneral.Alignment = settings.HorizontalAlign;

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

                SizeF stringSize = new SizeF();

                string strDraw = string.Empty;

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

                    strDraw = firstLineBarLabel;
                    double leftIndent1st = 0;
                    double leftIndent2nd = 0;
                    double leftIndentDesc = 0;
                    double rightIndent1st = 0;
                    double rightIndent2nd = 0;
                    double rightIndentDesc = 0;
                    if(settings.FirstLineFontSetting != null) 
                    {
                        leftIndent1st += ConvertFromMmToPixelDot(settings.FirstLineFontSetting.LeftIndent, dpi);
                        rightIndent1st += ConvertFromMmToPixelDot(settings.FirstLineFontSetting.RightIndent, dpi);
                    }

                    if (settings.SecondLineFontSetting != null)
                    {
                        leftIndent2nd += ConvertFromMmToPixelDot(settings.SecondLineFontSetting.LeftIndent, dpi);
                        rightIndent2nd += ConvertFromMmToPixelDot(settings.SecondLineFontSetting.RightIndent, dpi);
                    }

                    if (settings.DescriptionFontSetting != null)
                    {
                        leftIndentDesc += ConvertFromMmToPixelDot(settings.DescriptionFontSetting.LeftIndent, dpi);
                        rightIndentDesc += ConvertFromMmToPixelDot(settings.DescriptionFontSetting.RightIndent, dpi);
                    }

                    stringSize = canvas.MeasureString(strDraw, fontFirstLine);
                    canvas.DrawString(strDraw, fontFirstLine,
                        new SolidBrush(Color.Black),
                        new RectangleF(
                            new PointF((float)(offsetLeft + marginLeft + leftIndent1st), (float)offsetTop),
                            new SizeF((float)(stampSize - marginLeft - marginRight - rightIndent1st - leftIndent1st), stringSize.Height - 2)),
                            (settings.FirstLineFontSetting != null ? 
                                new StringFormat() { Alignment = settings.FirstLineFontSetting.Align} :
                                new StringFormat() { Alignment = settings.HorizontalAlign}));

                    if (showRectMargin)
                    {
                        //draw first line
                        canvas.DrawRectangle(
                            previewRectPen,
                            new Rectangle(
                                new Point((int)(offsetLeft + marginLeft + leftIndent1st), (int)offsetTop),
                                new Size((int)(stampSize - marginLeft - marginRight - rightIndent1st - leftIndent1st), (int)(stringSize.Height - 2))));
                    }

                    offsetTop += stringSize.Height;
                    strDraw = secondLineBarLabel;
                    stringSize = canvas.MeasureString(strDraw, fontSecondLine);
                    canvas.DrawString(strDraw, fontSecondLine,
                        new SolidBrush(Color.Black),
                        new RectangleF(
                            new PointF((float)(offsetLeft + marginLeft + leftIndent2nd), (float)offsetTop),
                            new SizeF((float)(stampSize - marginLeft - marginRight - rightIndent2nd - leftIndent2nd), stringSize.Height - 2)),
                            (settings.SecondLineFontSetting != null ? 
                                new StringFormat() { Alignment = settings.SecondLineFontSetting.Align} :
                                new StringFormat() { Alignment = settings.HorizontalAlign}));

                    if (showRectMargin)
                    {
                        canvas.DrawRectangle(
                            previewRectPen,
                            new Rectangle(
                                new Point((int)(offsetLeft + marginLeft + leftIndent2nd), (int)offsetTop),
                                new Size((int)(stampSize - marginLeft - marginRight - rightIndent2nd - leftIndent2nd), (int)(stringSize.Height - 2))));
                    }

                    double barcodeW = ConvertFromMmToPixelDot((double)barcodeText.Length * barcodeCharRatio, dpi);
                    double barcodeH = ConvertFromMmToPixelDot(settings.BarCodeHeight, dpi);

                    var imageBarCodeRaw = b.Encode(type,
                        barcodeText,
                        b.ForeColor, b.BackColor, (int)barcodeW, (int)barcodeH);

                    Bitmap bitmapBarCode = new Bitmap(imageBarCodeRaw);
                    bitmapBarCode.SetResolution((int)dpi, (int)dpi);

                    offsetTop += stringSize.Height;

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
                    strDraw = string.IsNullOrEmpty(description) ? barcodeText : description;
                    stringSize = canvas.MeasureString(strDraw, fontDescriptionLine);
                    canvas.DrawString(strDraw, fontDescriptionLine,
                        new SolidBrush(Color.Black),
                        new RectangleF(
                            new PointF((float)(offsetLeft + marginLeft + leftIndentDesc), (float)offsetTop),
                            new SizeF((float)(stampSize - marginLeft - marginRight - rightIndentDesc - leftIndentDesc), stringSize.Height - 2)),
                        (settings.DescriptionFontSetting != null ? 
                                new StringFormat() { Alignment = settings.DescriptionFontSetting.Align} :
                                new StringFormat() { Alignment = settings.HorizontalAlign}));

                    var bottomRectangle = new Rectangle(
                        new Point((int)(offsetLeft + marginLeft + leftIndentDesc), (int)offsetTop),
                        new Size((int)(stampSize - marginLeft - marginRight - rightIndentDesc - leftIndentDesc), (int)(stringSize.Height - 2)));
                    if (showRectMargin)
                    {
                        canvas.DrawRectangle(
                            previewRectPen, bottomRectangle);
                    }

                    strDraw = sideLabel;
                    stringSize = canvas.MeasureString(strDraw, fontSideText);
                    canvas.DrawString(strDraw, fontSideText,
                        new SolidBrush(Color.Black),
                        sidePaneRect,
                        (settings.SideFontSetting != null ?
                            new StringFormat() { Alignment = settings.SideFontSetting.Align } :
                            new StringFormat() { Alignment = settings.HorizontalAlign }));
                }

                canvas.Save();
            }

            return bmpOut;
        }
    }
}
