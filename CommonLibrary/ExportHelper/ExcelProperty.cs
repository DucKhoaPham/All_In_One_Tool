using ClosedXML.Excel;
using System.Collections.Generic;

namespace vLib.Services.Implementation.Help
{
    public class ExcelProperty
    {
        public ExcelProperty()
        {
            columns = null;
            titles = null;
            columnsReName = null;
            haveStt = false;
            listColumnDetail = null;
            listTitleDetail = null;
            listDataValid = null;
            pageCenterHorizontally = true;
            adjustToContents = false;
        }
        /// <summary>
        /// Những cột select
        /// </summary>
        public string[] columns { get; set; }
        /// <summary>
        /// Size theo những cột select
        /// </summary>
        public double[] columnsSize { get; set; }
        /// <summary>
        /// Đặt tên những cột select
        /// </summary>
        public string[] columnsReName { get; set; }
        /// <summary>
        /// Tiêu đề cơ bản
        /// </summary>
        public string[] titles { get; set; }
        /// <summary>
        /// Có sử dụng cột STT
        /// </summary>
        public bool haveStt { get; set; }
        /// <summary>
        /// Tên sheet
        /// </summary>
        public string sheetName { get; set; }
        /// <summary>
        /// Tự động resize cột phù hợp với nội dung
        /// </summary>
        public bool adjustToContents { get; set; }
        /// <summary>
        /// List chi tiết cột
        /// </summary>
        public List<ColumnDetail> listColumnDetail { get; set; }
        /// <summary>
        /// List chi tiết tiêu đề
        /// </summary>
        public List<TitleDetail> listTitleDetail { get; set; }
        /// <summary>
        /// List chi tiết dữ liệu so sánh để valid dữ liệu chính
        /// </summary>
        public List<ExcelDataValid> listDataValid { get; set; }
        /// <summary>
        /// căn ngang giấy in
        /// </summary>
        public bool pageCenterHorizontally { get; set; }
        /// <summary>
        /// cỡ giấy
        /// </summary>
        public XLPaperSize paperSize { get; set; }
    }
    public class ColumnDetail
    {
        public ColumnDetail()
        {
            fontSize = 12;
            color = XLColor.Black;
        }
        /// <summary>
        /// Cột select
        /// </summary>
        public string keyName { get; set; }
        /// <summary>
        /// Tên cột
        /// </summary>
        public string headerText { get; set; }
        /// <summary>
        /// Tên cột excel (VD: A,B)
        /// </summary>
        public string columnName { get; set; }
        /// <summary>
        /// Độ rộng cột
        /// </summary>
        public double? widthCol { get; set; }
        /// <summary>
        /// Tên cột nhóm lại
        /// </summary>
        public string groupHeaderText { get; set; }
        /// <summary>
        /// In đậm
        /// </summary>
        public bool? bold { get; set; }
        /// <summary>
        /// Dùng border
        /// </summary>
        public bool? border { get; set; }
        public XLColor color { get; set; }
        public double? fontSize { get; set; }
        public XLAlignmentH alignHorizontal { get; set; }
        public XLAlignmentHorizontalValues alignH
        {
            get
            {
                switch (alignHorizontal)
                {
                    case XLAlignmentH.Center:
                        return XLAlignmentHorizontalValues.Center;
                    case XLAlignmentH.CenterContinuous:
                        return XLAlignmentHorizontalValues.CenterContinuous;
                    case XLAlignmentH.Distributed:
                        return XLAlignmentHorizontalValues.Distributed;
                    case XLAlignmentH.Fill:
                        return XLAlignmentHorizontalValues.Fill;
                    case XLAlignmentH.General:
                        return XLAlignmentHorizontalValues.General;
                    case XLAlignmentH.Justify:
                        return XLAlignmentHorizontalValues.Justify;
                    case XLAlignmentH.Right:
                        return XLAlignmentHorizontalValues.Right;
                    default:
                        return XLAlignmentHorizontalValues.Left;
                }
            }
            set
            {
                switch (value)
                {
                    case XLAlignmentHorizontalValues.Center:
                        alignHorizontal = XLAlignmentH.Center;
                        break;
                    case XLAlignmentHorizontalValues.CenterContinuous:
                        alignHorizontal = XLAlignmentH.CenterContinuous;
                        break;
                    case XLAlignmentHorizontalValues.Distributed:
                        alignHorizontal = XLAlignmentH.Distributed;
                        break;
                    case XLAlignmentHorizontalValues.Fill:
                        alignHorizontal = XLAlignmentH.Fill;
                        break;
                    case XLAlignmentHorizontalValues.General:
                        alignHorizontal = XLAlignmentH.General;
                        break;
                    case XLAlignmentHorizontalValues.Justify:
                        alignHorizontal = XLAlignmentH.Justify;
                        break;
                    case XLAlignmentHorizontalValues.Right:
                        alignHorizontal = XLAlignmentH.Right;
                        break;
                    default:
                        alignHorizontal = XLAlignmentH.Left;
                        break;
                }
            }
        }

    }
    public enum XLAlignmentH
    {
        Center,
        CenterContinuous,
        Distributed,
        Fill,
        General,
        Justify,
        Left,
        Right
    }
    public enum XLAlignmentV
    {
        Center,
        Distributed,
        Bottom,
        Justify,
        Top
    }

    public class TitleDetail
    {
        public TitleDetail()
        {
            fontSize = 14;
            backgroundColor = null;
            rowMerge = 1;
            colMerge = 1;
            fontColor = XLColor.Black;
        }
        /// <summary>
        /// Nội dung tiêu đề
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// Tên cột excel (VD: A,B)
        /// </summary>
        public string columnName { get; set; }
        /// <summary>
        /// Vị trí dòng
        /// </summary>
        public int rowIndex { get; set; }
        public double? widthCol { get; set; }
        public double? heightCol { get; set; }
        /// <summary>
        /// Số cột muốn merge trong excel
        /// </summary>
        public int colMerge { get; set; }
        /// <summary>
        /// Số dòng muốn merge trong excel
        /// </summary>
        public int rowMerge { get; set; }
        public bool? bold { get; set; }
        public bool? border { get; set; }
        public XLAlignmentH alignHorizontal { get; set; }
        public XLAlignmentV alignVertical { get; set; }
        public XLAlignmentHorizontalValues alignH
        {
            get
            {
                switch (alignHorizontal)
                {
                    case XLAlignmentH.Center:
                        return XLAlignmentHorizontalValues.Center;
                    case XLAlignmentH.CenterContinuous:
                        return XLAlignmentHorizontalValues.CenterContinuous;
                    case XLAlignmentH.Distributed:
                        return XLAlignmentHorizontalValues.Distributed;
                    case XLAlignmentH.Fill:
                        return XLAlignmentHorizontalValues.Fill;
                    case XLAlignmentH.General:
                        return XLAlignmentHorizontalValues.General;
                    case XLAlignmentH.Justify:
                        return XLAlignmentHorizontalValues.Justify;
                    case XLAlignmentH.Right:
                        return XLAlignmentHorizontalValues.Right;
                    default:
                        return XLAlignmentHorizontalValues.Left;
                }
            }
            set
            {
                switch (value)
                {
                    case XLAlignmentHorizontalValues.Center:
                        alignHorizontal = XLAlignmentH.Center;
                        break;
                    case XLAlignmentHorizontalValues.CenterContinuous:
                        alignHorizontal = XLAlignmentH.CenterContinuous;
                        break;
                    case XLAlignmentHorizontalValues.Distributed:
                        alignHorizontal = XLAlignmentH.Distributed;
                        break;
                    case XLAlignmentHorizontalValues.Fill:
                        alignHorizontal = XLAlignmentH.Fill;
                        break;
                    case XLAlignmentHorizontalValues.General:
                        alignHorizontal = XLAlignmentH.General;
                        break;
                    case XLAlignmentHorizontalValues.Justify:
                        alignHorizontal = XLAlignmentH.Justify;
                        break;
                    case XLAlignmentHorizontalValues.Right:
                        alignHorizontal = XLAlignmentH.Right;
                        break;
                    default:
                        alignHorizontal = XLAlignmentH.Left;
                        break;
                }
            }
        }
        public XLAlignmentVerticalValues alignV
        {
            get
            {
                switch (alignVertical)
                {
                    case XLAlignmentV.Top:
                        return XLAlignmentVerticalValues.Top;
                    case XLAlignmentV.Distributed:
                        return XLAlignmentVerticalValues.Distributed;
                    case XLAlignmentV.Bottom:
                        return XLAlignmentVerticalValues.Bottom;
                    case XLAlignmentV.Justify:
                        return XLAlignmentVerticalValues.Justify;
                    default:
                        return XLAlignmentVerticalValues.Center;
                }
            }
            set
            {
                switch (value)
                {
                    case XLAlignmentVerticalValues.Top:
                        alignVertical = XLAlignmentV.Top;
                        break;
                    case XLAlignmentVerticalValues.Distributed:
                        alignVertical = XLAlignmentV.Distributed;
                        break;
                    case XLAlignmentVerticalValues.Bottom:
                        alignVertical = XLAlignmentV.Bottom;
                        break;
                    case XLAlignmentVerticalValues.Justify:
                        alignVertical = XLAlignmentV.Justify;
                        break;
                    default:
                        alignVertical = XLAlignmentV.Center;
                        break;
                }
            }
        }
        public XLColor backgroundColor { get; set; }
        public XLColor fontColor { get; set; }
        public double? fontSize { get; set; }
    }

    public class ExcelDataValid
    {
        /// <summary>
        /// Tên cột select muốn kiểm tra dữ liệu
        /// </summary>
        public string colNameValid { get; set; }
        /// <summary>
        /// Tên cột excel
        /// </summary>
        public string colName { get; set; }
        /// <summary>
        /// Tên sheet valid
        /// </summary>
        public string sheetName { get; set; }
        public int rowStart { get; set; }
        public int rowValid { get; set; }
        public List<string> listData { get; set; }
    }
}
