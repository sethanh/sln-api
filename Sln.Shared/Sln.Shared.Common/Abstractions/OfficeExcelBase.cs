using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClosedXML.Attributes;
using ClosedXML.Excel;
using ClosedXML.Graphics;
using OfficeOpenXml;
using Sln.Shared.Common.Attributes;
using Sln.Shared.Common.Extensions;
using Sln.Shared.Common.Interfaces;
using Sln.Shared.Common.Values;

namespace Sln.Shared.Common.Abstractions
{
    public abstract class OfficeExcelBase : IOfficeExcel
    {
        protected static void SetTableFormat(
            Type modelType,
            IXLTable table,
            List<string>? excludedSumColumns = null
        )
        {
            int columnIndex = 1;
            var properties = modelType.GetProperties();

            foreach (var property in properties)
            {
                var columnAttr = property.GetCustomAttribute<XLColumnAttribute>();
                var formatAttr = property.GetCustomAttribute<XLColumnFormatAttribute>();

                if (columnAttr == null || columnAttr.Ignore)
                    continue;

                bool isNumeric = property.PropertyType == typeof(decimal?) || property.PropertyType == typeof(decimal)
                    || property.PropertyType == typeof(int?) || property.PropertyType == typeof(int)
                    || property.PropertyType == typeof(long?) || property.PropertyType == typeof(long);

                if (isNumeric)
                {
                    table.Column(columnIndex).Style.NumberFormat.Format = "#,##0";

                    bool skipSum = excludedSumColumns?.Contains(property.Name) ?? false;
                    if (!skipSum)
                        table.Field(columnAttr.Header).TotalsRowFunction = XLTotalsRowFunction.Sum;
                }

                if (formatAttr != null)
                    table.Column(columnIndex).Style.NumberFormat.Format = formatAttr.Format;

                columnIndex++;
            }
        }

        protected static string GetSheetNameWorkSheet(string sheetName)
        {
            if (string.IsNullOrEmpty(sheetName))
                return sheetName;

            string sanitizedSheetName = Regex.Replace(sheetName, @"[\\/?*[\]:]", "");

            return sanitizedSheetName.Length > 31
                ? sanitizedSheetName[..30]
                : sanitizedSheetName;
        }

        public static string NormalizeTableName(string? tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                return "Table1";

            // 1. Trim khoảng trắng đầu cuối
            tableName = tableName.Trim();

            // 2. Thay khoảng trắng bằng dấu _
            tableName = Regex.Replace(tableName, @"\s+", "_");

            // 3. Loại bỏ ký tự đặc biệt, chỉ cho phép chữ, số, và _
            tableName = Regex.Replace(tableName, @"[^A-Za-z0-9_]", "");

            // 4. Nếu bắt đầu bằng số thì thêm "_" phía trước
            if (Regex.IsMatch(tableName, @"^\d"))
                tableName = "_" + tableName;

            // 5. Nếu rỗng sau khi xử lý → đặt mặc định
            if (string.IsNullOrEmpty(tableName))
                tableName = "Table1";

            // 6. Giới hạn 255 ký tự
            if (tableName.Length > 255)
                tableName = tableName.Substring(0, 255);

            return tableName;
        }

        protected static IXLWorksheet AddSheetInternal<T>(
            IXLWorkbook workbook,
            string sheetName,
            object data,
            string title,
            string subtitle,
            string timeZone,
            List<string>? infoRows,
            string? tableName
        )
        {
            var sheetNameWorkSheet = GetSheetNameWorkSheet(sheetName);
            var ws = workbook.Worksheets.Add(sheetNameWorkSheet);
            var validTableName = NormalizeTableName(tableName);

            int titleRow = 1;
            int subTitleRow = 2;
            int infoRow = 3;
            int currentRow = 3;

            // Title
            ws.Cell(titleRow, 1).Value = title;
            ws.Cell(titleRow, 1).Style.Font.Bold = true;
            ws.Cell(titleRow, 1).Style.Font.FontSize = 18;
            ws.Cell(titleRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell(titleRow, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // Subtitle
            ws.Cell(subTitleRow, 1).Value = subtitle;
            ws.Cell(subTitleRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell(subTitleRow, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // Additional information rows
            if (infoRows != null && infoRows.Count > 0)
            {
                foreach (var info in infoRows)
                {
                    currentRow++;
                    ws.Cell(currentRow, 1).Value = info;
                    ws.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Cell(currentRow, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                }
            }

            currentRow += 2;
            IXLTable table = null;

            if (data is List<T> listData)
            {
                table = ws.Cell(currentRow, 1).InsertTable(listData, validTableName);
                table.ShowTotalsRow = true;
                table.Field(0).TotalsRowLabel = "Total";

                if (listData.Count > 0)
                    SetTableFormat(typeof(T), table);
            }
            else if (data is DataTable dataTable)
            {
                table = ws.Cell(currentRow, 1).InsertTable(dataTable, validTableName);
                table.ShowTotalsRow = true;
                table.Field(0).TotalsRowLabel = "Total";
            }

            // Merge title & subtitle
            int mergeColCount = table?.ColumnCount() > 0 ? table.ColumnCount() : 1;
            ws.Range(titleRow, 1, titleRow, mergeColCount).Merge();
            ws.Range(subTitleRow, 1, subTitleRow, mergeColCount).Merge();

            if (infoRows != null && infoRows.Count > 0)
            {
                int rowPointer = infoRow;
                foreach (var _ in infoRows)
                {
                    ws.Range(rowPointer, 1, rowPointer, mergeColCount).Merge();
                    rowPointer++;
                }
            }

            int signRow = currentRow + (table?.RowCount() ?? 0) + 1;
            ws.Cell(signRow, 2).Value = "Export at:";
            ws.Cell(signRow, 2).Style.Font.Italic = true;
            ws.Cell(signRow, 3).SetValue(DateTime.UtcNow.LocalTime(timeZone)).Style.Font.Italic = true;

            ws.ShowGridLines = false;
            ws.Columns().AdjustToContents();

            return ws;
        }

        public virtual IXLWorksheet AddSheet<T>(
            IXLWorkbook workbook,
            string sheetName,
            List<T> data,
            string title,
            string subtitle,
            string? timeZone,
            List<string>? infoRows,
            string? tableName
        )
        {
            return AddSheetInternal<T>(workbook, sheetName, data, title, subtitle, timeZone ?? "UTC", infoRows, tableName);
        }

        public virtual MemoryStream WorkBoxToStream(XLWorkbook workbook)
        {
            var memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }

        public virtual XLWorkbook CreateWorkbook()
        {
            var loadOption = new LoadOptions();
            loadOption.GraphicEngine = new DefaultGraphicEngine("Times New Roman");
            var workbook = new XLWorkbook(loadOption);
            return workbook;
        }

        public static void ExportSheet<T>(
            ExcelPackage package,
            List<T> data,
            string sheetName
        )
        {
            var props = typeof(T).GetProperties()
                .Where(p => !p.GetCustomAttributes(typeof(XLColumnAttribute), true)
                    .OfType<XLColumnAttribute>()
                    .Any(a => a.Ignore))
                .Select(p => new
                {
                    Property = p,
                    Header = p.GetCustomAttributes(typeof(XLColumnAttribute), true)
                        .OfType<XLColumnAttribute>()
                        .FirstOrDefault()?.Header
                })
                .Where(p => !string.IsNullOrEmpty(p.Header))
                .ToList();

            var ws = package.Workbook.Worksheets.Add(sheetName);

            // Header
            for (int i = 0; i < props.Count; i++)
                ws.Cells[1, i + 1].Value = props[i].Header;

            // Data
            int rowIndex = 2;
            foreach (var item in data)
            {
                for (int colIndex = 0; colIndex < props.Count; colIndex++)
                    ws.Cells[rowIndex, colIndex + 1].Value = props[colIndex].Property.GetValue(item);

                rowIndex++;
            }
        }

        public static IXLWorksheet AddGenericSheet(
            IXLWorkbook workbook,
            string sheetName,
            List<GenericExportObject> data,
            string title,
            string subtitle,
            string? timeZone,
            List<string>? infoRows,
            string? tableName
        )
        {
            var sheetNameWorkSheet = GetSheetNameWorkSheet(sheetName);
            var ws = workbook.Worksheets.Add(sheetNameWorkSheet);
            var validTableName = NormalizeTableName(tableName);

            int titleRow = 1;
            int subTitleRow = 2;
            int infoRow = 3;
            int currentRow = 3;

            // Title
            ws.Cell(titleRow, 1).Value = title;
            ws.Cell(titleRow, 1).Style.Font.Bold = true;
            ws.Cell(titleRow, 1).Style.Font.FontSize = 18;
            ws.Cell(titleRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Subtitle
            ws.Cell(subTitleRow, 1).Value = subtitle;
            ws.Cell(subTitleRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Info rows
            if (infoRows != null && infoRows.Count > 0)
            {
                foreach (var info in infoRows)
                {
                    currentRow++;
                    ws.Cell(currentRow, 1).Value = info;
                    ws.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                }
            }

            currentRow += 2;

            IXLTable? table = null;

            if (data.Any())
            {
                // Lấy header từ keys của dictionary đầu tiên
                var headers = data.First().Columns.Keys.ToList();

                // Ghi header
                for (int i = 0; i < headers.Count; i++)
                {
                    ws.Cell(currentRow, i + 1).Value = headers[i];
                    ws.Cell(currentRow, i + 1).Style.Font.Bold = true;
                }

                // Ghi data
                int row = currentRow + 1;
                foreach (var rowData in data)
                {
                    int col = 1;
                    foreach (var header in headers)
                    {
                        if (rowData.Columns.TryGetValue(header, out var val))
                            ws.Cell(row, col).SetCellValueFromObject(val);
                        else
                            ws.Cell(row, col).SetCellValueFromObject(null);
                        col++;
                    }
                    row++;
                }

                // Tạo table
                var lastRow = currentRow + data.Count;
                var lastCol = headers.Count;
                var range = ws.Range(currentRow, 1, lastRow, lastCol);
                table = range.CreateTable(validTableName);
                table.ShowTotalsRow = true;
                table.Field(0).TotalsRowLabel = "Total";

                // Auto detect numeric columns để sum
                for (int i = 0; i < headers.Count; i++)
                {
                    var values = data.Select(d => d.Columns[headers[i]]).Where(v => v != null).ToList();
                    if (values.Count > 0 && values.All(v => IsNumericType(v!.GetType())))
                    {
                        table.Field(headers[i]).TotalsRowFunction = XLTotalsRowFunction.Sum;
                        table.Column(i + 1).Style.NumberFormat.Format = "#,##0";
                    }
                }
            }

            // Merge title/subtitle
            int mergeColCount = data.Any() ? data.First().Columns.Count : 1;
            ws.Range(titleRow, 1, titleRow, mergeColCount).Merge();
            ws.Range(subTitleRow, 1, subTitleRow, mergeColCount).Merge();

            if (infoRows != null && infoRows.Count > 0)
            {
                int rowPointer = infoRow;
                foreach (var _ in infoRows)
                {
                    ws.Range(rowPointer, 1, rowPointer, mergeColCount).Merge();
                    rowPointer++;
                }
            }

            // Footer export time
            int signRow = currentRow + (table?.RowCount() ?? 0) + 2;
            ws.Cell(signRow, 2).Value = "Export at:";
            ws.Cell(signRow, 3).Value = DateTime.UtcNow.LocalTime(timeZone ?? "UTC");

            ws.Columns().AdjustToContents();
            ws.ShowGridLines = false;

            return ws;
        }

        private static bool IsNumericType(Type type)
        {
            return type == typeof(byte) || type == typeof(sbyte) || type == typeof(short) || type == typeof(ushort) ||
                type == typeof(int) || type == typeof(uint) || type == typeof(long) || type == typeof(ulong) ||
                type == typeof(float) || type == typeof(double) || type == typeof(decimal);
        }
        
        private static string SplitCamelCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;

            return Regex.Replace(input, "([a-z])([A-Z])", "$1 $2");
        }
    }
}