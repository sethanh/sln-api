namespace Sln.Shared.Business.Abstractions;

public interface IReportService
{
    Task<T?> QuerySingle<T>(string sql, object? param = null, bool ignoreCache = false) where T : class;
    Task<IEnumerable<T>> Query<T>(string sql, object? param = null, bool ignoreCache = false) where T : class;
}
