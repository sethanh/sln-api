using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace Sln.Shared.Common.Extensions
{
    public static class XLCellExtensions
    {
        public static void SetCellValueFromObject(this IXLCell cell, object? val, string? format = null)
        {
            if (val == null)
            {
                cell.Value = string.Empty;
                return;
            }

            switch (val)
            {
                case DateTime dt:
                    cell.Value = dt;
                    if (!string.IsNullOrEmpty(format))
                        cell.Style.DateFormat.Format = format;
                    break;

                case int i:
                    cell.Value = i;
                    break;

                case long l:
                    cell.Value = l;
                    break;

                case float f:
                    cell.Value = f;
                    break;

                case double d:
                    cell.Value = d;
                    break;

                case decimal m:
                    cell.Value = (double)m; 
                    break;

                case bool b:
                    cell.Value = b;
                    break;

                default:
                    cell.Value = val.ToString();
                    break;
            }

            if (!string.IsNullOrEmpty(format) && !cell.Style.DateFormat.Format.Equals(format))
            {
                cell.Style.NumberFormat.Format = format;
            }
        }
    }
}