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

namespace QrCodePrint
{
    public static class QrCodePrintHelper
    { 
        public static void PrintPreview(QrCodeZoneSetting settings, string printerName, string barcodePrint, List<string> blockStrings, short copies = 1)
        {
            using (PrintDocument _printDoc = new PrintDocument())
            {
                _printDoc.PrinterSettings.PrinterName = printerName;
                _printDoc.PrinterSettings.Copies = copies;
                _printDoc.PrintPage += delegate (object sender1, PrintPageEventArgs e)
                {
                    double ratio = _printDoc.DefaultPageSettings.PrintableArea.Width / settings.PaperSizeW;
                    QrCodeZoneService.GetInstance().Draw(settings, ratio, e.Graphics, barcodePrint, blockStrings, false);
                };

                using (PrintPreviewDialog _previewDialog = new PrintPreviewDialog())
                {
                    _previewDialog.Document = _printDoc;
                    _previewDialog.ShowDialog();
                }
            }
        }

        public static void Print(QrCodeZoneSetting settings, string printerName, string barcodePrint, List<string> blockStrings, short copies = 1)
        {
            using (PrintDocument _printDoc = new PrintDocument())
            {
                _printDoc.PrinterSettings.PrinterName = printerName;
                _printDoc.PrinterSettings.Copies = copies;
                _printDoc.PrintPage += delegate (object sender1, PrintPageEventArgs e)
                {
                    QrCodeZoneService.GetInstance().Draw(settings, settings.Zoom, e.Graphics, barcodePrint, blockStrings, false);
                };
                _printDoc.Print();
            }
        }
    }
}
