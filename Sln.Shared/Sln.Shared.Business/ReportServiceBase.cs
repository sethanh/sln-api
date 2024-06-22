using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sln.Shared.Business.Abstractions;

namespace Sln.Shared.Business
{
    public abstract class ReportServiceBase : IReportService
    {
        public abstract Task<IEnumerable<T>> Query<T>(string sql, object? param = null, bool ignoreCache = false) where T : class;

        public abstract Task<T?> QuerySingle<T>(string sql, object? param = null, bool ignoreCache = false) where T : class;
    }
}