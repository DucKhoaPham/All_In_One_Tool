using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using vLib.Services.Implementation.Help;

namespace vLib.Services.Implementation
{
    class ExcelService
    {
        public byte[] ExportToXlsx(DataTable datatableView, ExcelProperty excelModel)
        {
            using var stream = new MemoryStream();
            using (var workbook = new XLWorkbook())
            {
                //Dòng bắt đầu dữ liệu
                int starRow = 1;
                if (excelModel.listTitleDetail != null)
                {
                    starRow = excelModel.listTitleDetail.Count() + 1;
                }
                else if (excelModel.titles != null)
                {
                    starRow = excelModel.titles.Count() + 1;
                }
                string sheetName = datatableView.TableName;
                if (!String.IsNullOrEmpty(excelModel.sheetName))
                    sheetName = excelModel.sheetName.Trim();
                var workSheet = workbook.Worksheets.Add(sheetName);
                #region Xử lý dữ liệu
                #region Dữ liệu cơ bản
                int numCol = excelModel.haveStt ? datatableView.Columns.Count + 1 : datatableView.Columns.Count;
                if (excelModel.listColumnDetail == null)
                {
                    if (excelModel.columns != null)
                    {
                        datatableView = datatableView.DefaultView.ToTable(false, excelModel.columns);
                        numCol = excelModel.columns.Count();
                    }
                    if (excelModel.columnsReName.Any())
                    {
                        for (int i = 0; i < excelModel.columnsReName.Count(); i++)
                        {
                            datatableView.Columns[i].ColumnName = excelModel.columnsReName[i];
                        }
                    }
                    workSheet.Delete();
                    workSheet = workbook.Worksheets.Add(datatableView);
                    if (excelModel.columnsSize.Any())
                    {
                        for (int i = 0; i < excelModel.columnsSize.Count(); i++)
                        {
                            workSheet.Column(i + 1).Width = excelModel.columnsSize[i];
                        }
                    }
                    if (excelModel.haveStt)
                    {
                        workSheet.Column(1).InsertColumnsBefore(1);
                        workSheet.Cell(starRow-2,1).Value = "STT";
                        workSheet.Cell(starRow-2,1).Style.Alignment.WrapText = true;
                        workSheet.Cell(starRow-2,1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        workSheet.Cell(starRow-2,1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        workSheet.Cell(starRow-2,1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        workSheet.Cell(starRow-2,1).Style.Border.TopBorderColor = XLColor.Black;
                        workSheet.Cell(starRow-2,1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        workSheet.Cell(starRow-2,1).Style.Border.BottomBorderColor = XLColor.Black;
                        workSheet.Cell(starRow-2,1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        workSheet.Cell(starRow-2,1).Style.Border.LeftBorderColor = XLColor.Black;
                        workSheet.Cell(starRow-2,1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        workSheet.Cell(starRow-2,1).Style.Border.RightBorderColor = XLColor.Black;
                        workSheet.Cell(starRow-2,1).Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1);
                        workSheet.Cell(starRow-2,1).Style.Font.FontColor = XLColor.White;
                        workSheet.Cell(starRow-2,1).Style.Font.Bold = true;
                        workSheet.Column(1).Width = 5;
                        for (int i = 0; i < datatableView.Rows.Count; i++)
                        {
                            workSheet.Cell(starRow + i - 1,1).Value = (i+1).ToString();
                            workSheet.Cell(starRow + i - 1,1).Style.Alignment.WrapText = true;
                            workSheet.Cell(starRow + i - 1,1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            workSheet.Cell(starRow + i - 1,1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            workSheet.Cell(starRow + i - 1,1).Style.Border.TopBorderColor = XLColor.Black;
                            workSheet.Cell(starRow + i - 1,1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            workSheet.Cell(starRow + i - 1,1).Style.Border.BottomBorderColor = XLColor.Black;
                            workSheet.Cell(starRow + i - 1,1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            workSheet.Cell(starRow + i - 1,1).Style.Border.LeftBorderColor = XLColor.Black;
                            workSheet.Cell(starRow + i - 1,1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            workSheet.Cell(starRow + i - 1,1).Style.Border.RightBorderColor = XLColor.Black;

                        }
                    }
                        
                    if (starRow > 1)
                        workSheet.Row(1).InsertRowsAbove(starRow);
                    string colEnd = GetExcelColumnName(ExcelColumnNameToNumber("A") + (excelModel.haveStt?numCol: numCol-1));
                    var rangeData = workSheet.Range(string.Format("A{0}:{1}{2}", starRow == 1 ? starRow : starRow + 1, colEnd, (starRow == 1 ? starRow : starRow + 1) + datatableView.Rows.Count));
                    rangeData.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                    rangeData.Style.Border.TopBorderColor = XLColor.Black;
                    rangeData.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    rangeData.Style.Border.BottomBorderColor = XLColor.Black;
                    rangeData.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    rangeData.Style.Border.LeftBorderColor = XLColor.Black;
                    rangeData.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    rangeData.Style.Border.RightBorderColor = XLColor.Black;
                }
                #endregion
                #region Dữ liệu chi tiết
                else
                {
                    excelModel.columns = new string[excelModel.listColumnDetail.Count];
                    bool have_groupHeader = false;
                    for (int i = 0; i < excelModel.listColumnDetail.Count; i++)
                    {
                        excelModel.columns[i] = excelModel.listColumnDetail[i].keyName;
                        if (!String.IsNullOrEmpty(excelModel.listColumnDetail[i].groupHeaderText) && !have_groupHeader)
                            have_groupHeader = true;
                    }
                    datatableView = datatableView.DefaultView.ToTable(false, excelModel.columns);
                    numCol = excelModel.haveStt ? excelModel.columns.Count() + 1 : excelModel.columns.Count();
                    excelModel.listColumnDetail = excelModel.listColumnDetail.OrderBy(x => x.columnName).ToList();
                    string colStart = String.IsNullOrEmpty(excelModel.listColumnDetail[0].columnName) ? "A" : excelModel.listColumnDetail[0].columnName;
                    string colEnd = String.IsNullOrEmpty(excelModel.listColumnDetail[excelModel.listColumnDetail.Count - 1].columnName) ? GetExcelColumnName(ExcelColumnNameToNumber("A") + excelModel.listColumnDetail.Count - 1) : excelModel.listColumnDetail[excelModel.listColumnDetail.Count - 1].columnName;
                    string rangeData = string.Format("{0}{2}:{1}{3}", colStart, colEnd, 1, starRow + datatableView.Rows.Count - 1);
                    var rngNumbers = workSheet.Range(rangeData);
                    int stt = 1;
                    if (have_groupHeader)
                        starRow++;
                    int index = starRow + 1;
                    foreach (DataRow row in datatableView.Rows)
                    {
                        if (excelModel.haveStt)
                        {
                            if (index == starRow + 1)
                            {
                                var ws = workSheet.Range(string.Format(@"A{0}:A{1}", starRow, have_groupHeader?starRow - 1: starRow));
                                if (have_groupHeader)
                                    ws.Merge();
                                ws.Value = "STT";
                                ws.Style.Alignment.WrapText = true;
                                ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                ws.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                ws.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                ws.Style.Border.TopBorderColor = XLColor.Black;
                                ws.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Style.Border.BottomBorderColor = XLColor.Black;
                                ws.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Style.Border.LeftBorderColor = XLColor.Black;
                                ws.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Style.Border.RightBorderColor = XLColor.Black;
                                ws.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1);
                                ws.Style.Font.FontColor = XLColor.White;
                                ws.Style.Font.Bold = true;
                                workSheet.Column(1).Width = 5;
                            }
                            rngNumbers.Cell(index, 1).Value = stt.ToString();
                            rngNumbers.Cell(index, 1).Style.Alignment.WrapText = true;
                            rngNumbers.Cell(index, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            rngNumbers.Cell(index, 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            rngNumbers.Cell(index, 1).Style.Border.TopBorderColor = XLColor.Black;
                            rngNumbers.Cell(index, 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            rngNumbers.Cell(index, 1).Style.Border.BottomBorderColor = XLColor.Black;
                            rngNumbers.Cell(index, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            rngNumbers.Cell(index, 1).Style.Border.LeftBorderColor = XLColor.Black;
                            rngNumbers.Cell(index, 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            rngNumbers.Cell(index, 1).Style.Border.RightBorderColor = XLColor.Black;
                            for (int i = 0; i < excelModel.listColumnDetail.Count; i++)
                            {
                                if (index == starRow + 1)
                                {
                                    string getColName = GetExcelColumnName(i + 2);
                                    var ws = workSheet.Range(string.Format(@"{0}{1}:{2}{3}", getColName, starRow, getColName, starRow));
                                    if (have_groupHeader)
                                    {
                                        if (!String.IsNullOrEmpty(excelModel.listColumnDetail[i].groupHeaderText))
                                        {
                                            if (excelModel.listColumnDetail[i].groupHeaderText != "X")
                                            {
                                                for (int n = i + 1; n < excelModel.listColumnDetail.Count; n++)
                                                {
                                                    if (excelModel.listColumnDetail[n].groupHeaderText == excelModel.listColumnDetail[i].groupHeaderText)
                                                    {
                                                        excelModel.listColumnDetail[n].groupHeaderText = "X";
                                                        if (n == excelModel.listColumnDetail.Count - 1)
                                                        {
                                                            ws = workSheet.Range(string.Format(@"{0}{1}:{2}{3}", GetExcelColumnName(i + 2), starRow - 1, GetExcelColumnName(n + 2), starRow - 1));
                                                            ws.Merge();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ws = workSheet.Range(string.Format(@"{0}{1}:{2}{3}", GetExcelColumnName(i + 2), starRow - 1, GetExcelColumnName(n + 1), starRow - 1));
                                                        ws.Merge();
                                                    }
                                                }
                                                ws.Value = excelModel.listColumnDetail[i].groupHeaderText;
                                                ws.Style.Alignment.WrapText = true;
                                                ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                                ws.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                                ws.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                                ws.Style.Border.TopBorderColor = XLColor.Black;
                                                ws.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                                ws.Style.Border.BottomBorderColor = XLColor.Black;
                                                ws.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                                ws.Style.Border.LeftBorderColor = XLColor.Black;
                                                ws.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                                ws.Style.Border.RightBorderColor = XLColor.Black;
                                                ws.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1);
                                                ws.Style.Font.FontColor = XLColor.White;
                                                ws.Style.Font.Bold = true;
                                                ws = workSheet.Range(string.Format(@"{0}{1}:{2}{3}", getColName, starRow, getColName, starRow));
                                            }
                                        }
                                        else
                                        {
                                            ws = workSheet.Range(string.Format(@"{0}{1}:{2}{3}", getColName, starRow, getColName, starRow - 1));
                                            ws.Merge();
                                        }
                                    }
                                    ws.Value = String.IsNullOrEmpty(excelModel.listColumnDetail[i].headerText) ? excelModel.listColumnDetail[i].keyName : excelModel.listColumnDetail[i].headerText;
                                    ws.Style.Alignment.WrapText = true;
                                    ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    ws.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                    ws.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                    ws.Style.Border.TopBorderColor = XLColor.Black;
                                    ws.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                    ws.Style.Border.BottomBorderColor = XLColor.Black;
                                    ws.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                    ws.Style.Border.LeftBorderColor = XLColor.Black;
                                    ws.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                    ws.Style.Border.RightBorderColor = XLColor.Black;
                                    ws.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1);
                                    ws.Style.Font.FontColor = XLColor.White;
                                    ws.Style.Font.Bold = true;
                                    if (excelModel.listColumnDetail[i].widthCol != null)
                                    {
                                        workSheet.Column(i + 2).Width = excelModel.listColumnDetail[i].widthCol.Value;
                                    }

                                }
                                string valCell = row[excelModel.listColumnDetail[i].keyName] == null ? " " : row[excelModel.listColumnDetail[i].keyName].ToString().Replace("<b>", "").Replace("</b>", "");
                                switch (datatableView.Columns[excelModel.listColumnDetail[i].keyName].DataType.Name.ToLower().ToString())
                                {
                                    case "string":
                                        break;
                                    case "boolean":
                                        string check = "";
                                        try
                                        {
                                            string tmp = row[excelModel.listColumnDetail[i].keyName].ToString().ToLower();
                                            if (tmp == "1" || tmp == "true")
                                                check = "x";
                                            else check = "";
                                        }
                                        catch { }
                                        valCell = check;
                                        break;
                                    case "number":
                                        rngNumbers.Cell(index, i + 1).Style.NumberFormat.Format = "#,###";
                                        rngNumbers.Cell(index, i + 1).DataType = XLDataType.Number;
                                        break;
                                    case "decimal":
                                        rngNumbers.Cell(index, i + 1).Style.NumberFormat.Format = "#,##0.00";
                                        rngNumbers.Cell(index, i + 1).DataType = XLDataType.Number;
                                        break;
                                    case "date":
                                        DateTime ngay1 = new DateTime();
                                        try
                                        {
                                            ngay1 = Convert.ToDateTime(row[excelModel.listColumnDetail[i].keyName].ToString());
                                            valCell = ngay1.ToString("dd/MM/yyyy");
                                        }
                                        catch { }
                                        break;
                                    case "datetime":
                                        DateTime ngay2 = new DateTime();
                                        try
                                        {
                                            ngay2 = Convert.ToDateTime(row[excelModel.listColumnDetail[i].keyName].ToString());
                                            valCell = ngay2.ToString("dd/MM/yyyy hh:mm:ss");
                                        }
                                        catch { }
                                        break;
                                }
                                rngNumbers.Cell(index, i + 2).SetValue<string>(valCell);
                                rngNumbers.Cell(index, i + 2).Style.Font.FontColor = excelModel.listColumnDetail[i].color;
                                rngNumbers.Cell(index, i + 2).Style.Alignment.Horizontal = excelModel.listColumnDetail[i].alignH;
                                rngNumbers.Cell(index, i + 2).Style.Alignment.WrapText = true;
                                rngNumbers.Cell(index, i + 2).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                rngNumbers.Cell(index, i + 2).Style.Border.TopBorderColor = XLColor.Black;
                                rngNumbers.Cell(index, i + 2).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                rngNumbers.Cell(index, i + 2).Style.Border.BottomBorderColor = XLColor.Black;
                                rngNumbers.Cell(index, i + 2).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                rngNumbers.Cell(index, i + 2).Style.Border.LeftBorderColor = XLColor.Black;
                                rngNumbers.Cell(index, i + 2).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                rngNumbers.Cell(index, i + 2).Style.Border.RightBorderColor = XLColor.Black;
                                rngNumbers.Cell(index, i + 2).Style.Font.FontName = "Times New Roman";
                            }
                        }
                        else
                        {
                            for (int i = 0; i < excelModel.listColumnDetail.Count; i++)
                            {
                                if (index == starRow + 1)
                                {
                                    string getColName = GetExcelColumnName(i + 1);
                                    var ws = workSheet.Range(string.Format(@"{0}{1}:{2}{3}", getColName, starRow, getColName, starRow));
                                    if (have_groupHeader)
                                    {
                                        if (!String.IsNullOrEmpty(excelModel.listColumnDetail[i].groupHeaderText))
                                        {
                                            if (excelModel.listColumnDetail[i].groupHeaderText != "X")
                                            {
                                                for (int n = i + 1; n < excelModel.listColumnDetail.Count; n++)
                                                {
                                                    if (excelModel.listColumnDetail[n].groupHeaderText == excelModel.listColumnDetail[i].groupHeaderText)
                                                    {
                                                        excelModel.listColumnDetail[n].groupHeaderText = "X";
                                                        if (n == excelModel.listColumnDetail.Count - 1)
                                                        {
                                                            ws = workSheet.Range(string.Format(@"{0}{1}:{2}{3}", GetExcelColumnName(i + 1), starRow - 1, GetExcelColumnName(n + 1), starRow - 1));
                                                            ws.Merge();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ws = workSheet.Range(string.Format(@"{0}{1}:{2}{3}", GetExcelColumnName(i + 1), starRow - 1, GetExcelColumnName(n), starRow - 1));
                                                        ws.Merge();
                                                    }
                                                }
                                                ws.Value = excelModel.listColumnDetail[i].groupHeaderText;
                                                ws.Style.Alignment.WrapText = true;
                                                ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                                ws.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                                ws.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                                ws.Style.Border.TopBorderColor = XLColor.Black;
                                                ws.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                                ws.Style.Border.BottomBorderColor = XLColor.Black;
                                                ws.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                                ws.Style.Border.LeftBorderColor = XLColor.Black;
                                                ws.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                                ws.Style.Border.RightBorderColor = XLColor.Black;
                                                ws.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1);
                                                ws.Style.Font.FontColor = XLColor.White;
                                                ws.Style.Font.Bold = true;
                                                ws = workSheet.Range(string.Format(@"{0}{1}:{2}{3}", getColName, starRow, getColName, starRow));
                                            }
                                        }
                                        else
                                        {
                                            ws = workSheet.Range(string.Format(@"{0}{1}:{2}{3}", getColName, starRow, getColName, starRow - 1));
                                            ws.Merge();
                                        }
                                    }
                                    ws.Value = String.IsNullOrEmpty(excelModel.listColumnDetail[i].headerText) ? excelModel.listColumnDetail[i].keyName : excelModel.listColumnDetail[i].headerText;
                                    ws.Style.Alignment.WrapText = true;
                                    ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    ws.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                    ws.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                    ws.Style.Border.TopBorderColor = XLColor.Black;
                                    ws.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                    ws.Style.Border.BottomBorderColor = XLColor.Black;
                                    ws.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                    ws.Style.Border.LeftBorderColor = XLColor.Black;
                                    ws.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                    ws.Style.Border.RightBorderColor = XLColor.Black;
                                    ws.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1);
                                    ws.Style.Font.FontColor = XLColor.White;
                                    ws.Style.Font.Bold = true;
                                    if (excelModel.listColumnDetail[i].widthCol != null)
                                    {
                                        workSheet.Column(i + 1).Width = excelModel.listColumnDetail[i].widthCol.Value;
                                    }
                                }
                                string valCell = row[excelModel.listColumnDetail[i].keyName] == null ? " " : row[excelModel.listColumnDetail[i].keyName].ToString().Replace("<b>", "").Replace("</b>", "");
                                switch (datatableView.Columns[excelModel.listColumnDetail[i].keyName].DataType.Name.ToLower().ToString())
                                {
                                    case "string":
                                        break;
                                    case "boolean":
                                        string check = "";
                                        try
                                        {
                                            string tmp = row[excelModel.listColumnDetail[i].keyName].ToString().ToLower();
                                            if (tmp == "1" || tmp == "true")
                                                check = "x";
                                            else check = "";
                                        }
                                        catch { }
                                        valCell = check;
                                        break;
                                    case "number":
                                        rngNumbers.Cell(index, i + 1).Style.NumberFormat.Format = "#,###";
                                        rngNumbers.Cell(index, i + 1).DataType = XLDataType.Number;
                                        break;
                                    case "decimal":
                                        rngNumbers.Cell(index, i + 1).Style.NumberFormat.Format = "#,##0.00";
                                        rngNumbers.Cell(index, i + 1).DataType = XLDataType.Number;
                                        break;
                                    case "date":
                                        DateTime ngay1 = new DateTime();
                                        try
                                        {
                                            ngay1 = Convert.ToDateTime(row[excelModel.listColumnDetail[i].keyName].ToString());
                                            valCell = ngay1.ToString("dd/MM/yyyy");
                                        }
                                        catch { }
                                        break;
                                    case "datetime":
                                        DateTime ngay2 = new DateTime();
                                        try
                                        {
                                            ngay2 = Convert.ToDateTime(row[excelModel.listColumnDetail[i].keyName].ToString());
                                            valCell = ngay2.ToString("dd/MM/yyyy hh:mm:ss");
                                        }
                                        catch { }
                                        break;
                                }
                                rngNumbers.Cell(index, i + 1).SetValue<string>(valCell);
                                rngNumbers.Cell(index, i + 1).Style.Font.FontColor = excelModel.listColumnDetail[i].color;
                                rngNumbers.Cell(index, i + 1).Style.Alignment.Horizontal = excelModel.listColumnDetail[i].alignH;
                                rngNumbers.Cell(index, i + 1).Style.Alignment.WrapText = true;
                                rngNumbers.Cell(index, i + 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                rngNumbers.Cell(index, i + 1).Style.Border.TopBorderColor = XLColor.Black;
                                rngNumbers.Cell(index, i + 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                rngNumbers.Cell(index, i + 1).Style.Border.BottomBorderColor = XLColor.Black;
                                rngNumbers.Cell(index, i + 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                rngNumbers.Cell(index, i + 1).Style.Border.LeftBorderColor = XLColor.Black;
                                rngNumbers.Cell(index, i + 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                rngNumbers.Cell(index, i + 1).Style.Border.RightBorderColor = XLColor.Black;
                                rngNumbers.Cell(index, i + 1).Style.Font.FontName = "Times New Roman";
                            }
                        }
                        stt++;
                        index++;
                    }
                }

                #endregion
                #endregion

                #region Xử lý tiêu đề
                #region Tiêu đề chi tiết
                if (excelModel.listTitleDetail != null)
                {
                    foreach (var titleDetail in excelModel.listTitleDetail)
                    {
                        string colEndCell = GetExcelColumnName(ExcelColumnNameToNumber(titleDetail.columnName) + titleDetail.colMerge - 1);
                        var titleDetailCell = workSheet.Range(string.Format(@"{0}{1}:{2}{3}", titleDetail.columnName, titleDetail.rowIndex, colEndCell, titleDetail.rowIndex + titleDetail.rowMerge - 1));
                        titleDetailCell.Merge();
                        titleDetailCell.Value = titleDetail.value;
                        if (!string.IsNullOrEmpty(titleDetail.value) && titleDetail.value.Contains("<b>") && titleDetail.value.Contains("</b>"))
                        {
                            try
                            {
                                int indexStartBold = titleDetail.value.IndexOf("<b>");
                                int indexEndBold = titleDetail.value.IndexOf("</b>");
                                titleDetailCell.Value = titleDetail.value.Replace("<b>", "").Replace("</b>", "");
                                if (indexEndBold - indexStartBold - 3 > 0)
                                    titleDetailCell.Cell(1, 1).RichText.Substring(indexStartBold, indexEndBold - indexStartBold - 3).SetBold();
                            }
                            catch (Exception ex) { }
                        }
                        if (!string.IsNullOrEmpty(titleDetail.value) && titleDetail.value.Contains("<i>") && titleDetail.value.Contains("</i>"))
                        {
                            try
                            {
                                int indexStartBold = titleDetail.value.IndexOf("<i>");
                                int indexEndBold = titleDetail.value.IndexOf("</i>");
                                titleDetailCell.Value = titleDetail.value.Replace("<i>", "").Replace("</i>", "");
                                if (indexEndBold - indexStartBold - 3 > 0)
                                    titleDetailCell.Cell(1, 1).RichText.Substring(indexStartBold, indexEndBold - indexStartBold - 3).SetItalic();
                            }
                            catch (Exception ex) { }
                        }
                        titleDetailCell.Style.Font.FontName = "Times New Roman";
                        titleDetailCell.Style.Font.Bold = titleDetail.bold ?? true;
                        if (titleDetail.border ?? false)
                        {
                            titleDetailCell.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            titleDetailCell.Style.Border.TopBorderColor = XLColor.Black;
                            titleDetailCell.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            titleDetailCell.Style.Border.BottomBorderColor = XLColor.Black;
                            titleDetailCell.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            titleDetailCell.Style.Border.LeftBorderColor = XLColor.Black;
                            titleDetailCell.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            titleDetailCell.Style.Border.RightBorderColor = XLColor.Black;
                        }

                        titleDetailCell.Style.Alignment.Horizontal = titleDetail.alignH;
                        titleDetailCell.Style.Alignment.Vertical = titleDetail.alignV;
                        if (titleDetail.fontSize != null)
                            titleDetailCell.Style.Font.FontSize = titleDetail.fontSize.Value;
                        var titleDetailcol = workSheet.Column(titleDetail.columnName);
                        if (titleDetail.widthCol != null)
                        {
                            titleDetailCell.Style.Alignment.WrapText = true;
                            titleDetailcol.Width = titleDetail.widthCol.Value;
                        }
                        var titleDetailRow = workSheet.Row(titleDetail.rowIndex);
                        if (titleDetail.heightCol != null)
                        {
                            titleDetailRow.Height = titleDetail.heightCol.Value;
                        }
                        if (titleDetail.backgroundColor != null)
                        {
                            titleDetailCell.Style.Fill.BackgroundColor = titleDetail.backgroundColor;
                        }
                        titleDetailCell.Style.Font.FontColor = titleDetail.fontColor;
                    }
                }
                #endregion
                #region Tiêu đề cơ bản
                else if (excelModel.titles != null)
                {
                    for (int i = 1; i <= excelModel.titles.Count(); i++)
                    {
                        workSheet.Cell(i, 1).Value = excelModel.titles[i - 1];
                        workSheet.Range(i, 1, i, numCol).Merge().AddToNamed("Titles");
                        workSheet.Cell(i, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        workSheet.Cell(i, 1).Style.Font.SetBold();
                        workSheet.Cell(i, 1).Style.Font.SetFontSize(14);
                    }
                }
                #endregion
                #endregion

                #region Set data valid
                if (excelModel.listDataValid != null && excelModel.listDataValid.Any())
                {
                    foreach (var itemDataValid in excelModel.listDataValid)
                    {
                        IXLWorksheet wsvl = workbook.Worksheet(itemDataValid.sheetName);
                        int rowIndex = itemDataValid.rowStart;
                        foreach (var item in itemDataValid.listData)
                        {
                            string colEndCell = itemDataValid.colName;
                            var itemCell = wsvl.Range(string.Format(@"{0}{1}:{2}{3}", itemDataValid.colName, rowIndex, colEndCell, rowIndex));
                            itemCell.Value = item;
                            itemCell.Style.Font.FontName = "Times New Roman";
                            rowIndex = rowIndex + 1;
                        }
                        var RandeDataValid = wsvl.Range(string.Format(@"{0}{1}:{2}{3}", itemDataValid.colName, itemDataValid.rowStart, itemDataValid.colName, itemDataValid.rowStart + itemDataValid.listData.Count));
                        workSheet.Column(itemDataValid.colNameValid).SetDataValidation().List(RandeDataValid, true);
                    }
                }
                #endregion

                if(excelModel.adjustToContents)
                    workSheet.Columns().AdjustToContents();
                workSheet.PageSetup.PaperSize = excelModel.paperSize;
                workSheet.PageSetup.FitToPages(1, 0);
                workSheet.PageSetup.SetCenterHorizontally(excelModel.pageCenterHorizontally);
                workbook.SaveAs(stream);
            }
            return stream.ToArray();
        }
        /// <summary>
        /// Lấy tên cột excel từ vị trí
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <returns></returns>
        public string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
        /// <summary>
        /// Chuyển tên cột excel sang dạng số
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public int ExcelColumnNameToNumber(string columnName)
        {
            try
            {
                if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException("columnName");
                columnName = columnName.ToUpperInvariant();
                int sum = 0;
                for (int i = 0; i < columnName.Length; i++)
                {
                    sum *= 26;
                    sum += (columnName[i] - 'A' + 1);
                }
                return sum;
            }
            catch
            {
                return -1;
            }
        }
        public DataTable ToDataTable<T>(IList<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }
}
