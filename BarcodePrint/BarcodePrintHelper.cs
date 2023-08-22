using System;
using System.Collections.Generic;
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
    public static class BarcodePrintHelper
    { 
        public static void PrintPreview(BarcodeMultiZoneSetting settings, string printerName, string barcodePrint, List<string> blockStrings, short copies = 1)
        {
            using (PrintDocument _printDoc = new PrintDocument())
            {
                _printDoc.PrinterSettings.PrinterName = printerName;
                _printDoc.PrinterSettings.Copies = copies;
                _printDoc.PrintPage += delegate (object sender1, PrintPageEventArgs e)
                {
                    var image = BarcodeMultiZoneService.GetInstance().GenerateBitmapBarCode(
                        settings, barcodePrint, blockStrings, false);

                    e.Graphics.DrawImage(image, new Point(0, 0));
                };

                using (PrintPreviewDialog _previewDialog = new PrintPreviewDialog())
                {
                    _previewDialog.Document = _printDoc;
                    _previewDialog.ShowDialog();
                }
            }
        }

        //public static void Print(BarcodeMultiZoneSetting settings, string printerName, string barcodePrint, List<string> blockStrings, short copies = 1)
        //{
        //    using (PrintDocument _printDoc = new PrintDocument())
        //    {
        //        _printDoc.PrinterSettings.PrinterName = printerName;
        //        _printDoc.PrinterSettings.Copies = copies;
        //        _printDoc.PrintPage += delegate (object sender1, PrintPageEventArgs e)
        //        {
        //            double ratio = _printDoc.DefaultPageSettings.PrintableArea.Width / settings.PaperSizeW;
        //            BarcodeMultiZoneService.GetInstance().Draw(settings, ratio, e.Graphics, barcodePrint, blockStrings, false);
        //        };
        //        _printDoc.Print(); 
        //    }
        //}

        public static void Print(BarcodeMultiZoneSetting settings, string printerName, string barcodePrint, List<string> blockStrings, short copies = 1)
        {
            using (PrintDocument _printDoc = new PrintDocument())
            {
                _printDoc.PrinterSettings.PrinterName = printerName;
                _printDoc.PrinterSettings.Copies = copies;
                _printDoc.PrintPage += delegate (object sender1, PrintPageEventArgs e)
                {
                    var image = BarcodeMultiZoneService.GetInstance().GenerateBitmapBarCode(
                        settings, barcodePrint, blockStrings, false);

                    e.Graphics.DrawImage(image, new Point(0, 0));
                };
                _printDoc.Print();
            }
        }
        /// <summary>
        /// Hàm hin ảnh
        /// </summary>
        /// <param name="img">Anh can in</param>
        /// <param name="printerName">May in</param>
        /// <param name="copies">So luong</param>
        public static void PrintImg(List<Bitmap> bitmapPages, string printerName, float _WidthPaper, float _HeightPaper,int dpi)
        {
            if (bitmapPages.Count > 0)
            {
                PrintService printService = new PrintService(printerName, _WidthPaper, _HeightPaper, dpi);
                printService.SetPages(bitmapPages);
                printService.Print();
            }
            else
            {
                MessageBox.Show("Không có trang để in.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        /// Hàm hin ảnh
        /// </summary>
        /// <param name="img">Anh can in</param>
        /// <param name="printerName">May in</param>
        /// <param name="copies">So luong</param>
        public static void PrintImg(Bitmap bitmapPages, string printerName,int copy)
        {
            using (PrintDocument _printDoc = new PrintDocument())
            {
                _printDoc.PrinterSettings.PrinterName = printerName;
                _printDoc.PrinterSettings.Copies = Convert.ToInt16(copy);
                _printDoc.PrintPage += delegate (object sender1, PrintPageEventArgs e)
                {
                    e.Graphics.DrawImage(bitmapPages, new Point(0, 0));
                };
                _printDoc.Print();
            }
        }
        //tạo tạm 1 hàm in không tạo barcode lên giấy in
        public static void PrintNotBarcode(BarcodeMultiZoneSetting settings, string printerName, string barcodePrint, List<string> blockStrings, short copies = 1)
        {
            using (PrintDocument _printDoc = new PrintDocument())
            {
                _printDoc.PrinterSettings.PrinterName = printerName;
                _printDoc.PrinterSettings.Copies = copies;
                _printDoc.PrintPage += delegate (object sender1, PrintPageEventArgs e)
                {
                    var image = BarcodeMultiZoneService.GetInstance().GenerateBitmapBarCodeNotShowBarcode(
                        settings, barcodePrint, blockStrings, false);

                    e.Graphics.DrawImage(image, new Point(0, 0));
                };
                _printDoc.Print();
            }
        }
    }
}
