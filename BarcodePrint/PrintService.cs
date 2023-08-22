using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace BarcodePrint
{
    public class PrintService
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private int _pageIndex = 0;
        private List<Bitmap> _listPageImage = new List<Bitmap>();
        private PrintDocument _printDoc = new PrintDocument();
        private PrintPreviewDialog _previewDialog = new PrintPreviewDialog();

        public PrintService(string printerName)
        {
            _printDoc.PrinterSettings.PrinterName = printerName;
            _printDoc.BeginPrint += printDoc_BeginPrint;
            _printDoc.EndPrint += printDoc_EndPrint;
            _printDoc.PrintPage += printDoc_PrintPage;

            _previewDialog.Document = _printDoc;
        }
        /// <summary>
        /// Tạo đối tương in với các cấu hình truyền vào
        /// </summary>
        /// <param name="printerName">Tên máy in</param>
        /// <param name="_WidthPaper">Chiều rộng khổ giấy</param>
        /// <param name="_HeightPaper">Chiều cao khổ giấy</param>
        public PrintService(string printerName,float _WidthPaper,float _HeightPaper,int dpi)
        {
            _printDoc.PrinterSettings.PrinterName = printerName;
            //_printDoc.DefaultPageSettings.PaperSize = new PaperSize("PRINT LIMS", (int)(_WidthPaper* 3.7795275591), (int)(_HeightPaper * 3.7795275591)); //Chuyển từ mm về Picxel
            //_printDoc.DefaultPageSettings.PrinterResolution.X = dpi;
            //_printDoc.DefaultPageSettings.PrinterResolution.Y = dpi;
            _printDoc.BeginPrint += printDoc_BeginPrint;
            _printDoc.EndPrint += printDoc_EndPrint;
            _printDoc.PrintPage += printDoc_PrintPage;
            _previewDialog.Document = _printDoc;
        }
        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(_listPageImage[_pageIndex], new Point(0,0));
            _pageIndex++;
            e.HasMorePages = (_pageIndex < _listPageImage.Count);
        }

        private void printDoc_EndPrint(object sender, PrintEventArgs e)
        {
            _pageIndex = 0;
        }

        private void printDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            _pageIndex = 0;
        }

        public void SetPages(List<Bitmap> listPageImage)
        {
            _listPageImage.Clear();
            _listPageImage.AddRange(listPageImage);
        }

        public void PrintPreview()
        {
            _previewDialog.ShowDialog();
        }

        public void Print()
        {
            _printDoc.Print();
        }
    }
}
