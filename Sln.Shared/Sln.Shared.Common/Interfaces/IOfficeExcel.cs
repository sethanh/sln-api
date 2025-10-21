using ClosedXML.Excel;
using OfficeOpenXml;

namespace Sln.Shared.Common.Interfaces
{
    public interface IOfficeExcel
    {
        IXLWorksheet AddSheet<T>(
            IXLWorkbook workbook,
            string sheetName,
            List<T> data,
            string title,
            string subtitle,
            string timZone,
            List<string>? infoRows,
            string? tableName
        );

        MemoryStream WorkBoxToStream(XLWorkbook workbook);

        XLWorkbook CreateWorkbook();

        static abstract void ExportSheet<T>(
            ExcelPackage package,
            List<T> data,
            string sheetName
        );
    }
}