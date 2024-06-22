using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;

namespace Sln.Shared.Data.Abstractions
{
    public interface IDapperQuery
    {
        T? QuerySingle<T>(string sql, object? param = null) where T : class;
        IEnumerable<T> Query<T>(string sql, object? param = null) where T : class;
        T? QueryScalar<T>(string sql, object? param = null);
        SqlMapper.GridReader QueryMultiResults(string sql, object? param = null);
        string BuildSqlLikeCondition(string keyword, bool isSearchWildCard = true);
    }
}