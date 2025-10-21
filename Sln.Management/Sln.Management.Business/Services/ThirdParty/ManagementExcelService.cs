using Microsoft.AspNetCore.Mvc;
using Sln.Shared.Common.Abstractions;

namespace Sln.Management.Business.Services.ThirdParty
{
    public class ManagementExcelService : OfficeExcelBase
    {
        public static FileStreamResult Export(MemoryStream workBookStream, string fileDownloadName)
        {
            var fileStreamResult = new FileStreamResult(workBookStream, "application/excel")
            {
                FileDownloadName = $"{NormalizeTableName(fileDownloadName)}_{Guid.NewGuid()}.xlsx"
            };
            return fileStreamResult;
        }
        
        public FileStreamResult ExportSingle<T>(
            string sheetName,
            List<T> data,
            string title,
            string subtitle,
            string? timeZone,
            List<string>? infoRows,
            string? tableName
        )
        {
            var workbook = CreateWorkbook();
            AddSheet(workbook, sheetName, data, title, subtitle, timeZone, infoRows, tableName);

            var workBookStream = WorkBoxToStream(workbook);

            return Export(workBookStream, tableName ?? $"{Guid.NewGuid()}");
        }
    }
}