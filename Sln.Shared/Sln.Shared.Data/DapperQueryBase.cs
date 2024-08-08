using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using Sln.Shared.Data.Interfaces;

namespace Sln.Shared.Data
{
    public abstract class DapperQueryBase : IDapperQuery
    {
        public string? ConnectionString { get; set; }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(this.ConnectionString ?? "");
        }

        public T? QuerySingle<T>(string sql, object? param = null) where T : class
        {
            using var connection = GetConnection();
            connection.Open();
            var data = connection.QuerySingleOrDefault<T>(sql, param);
            return data;
        }

        public IEnumerable<T> Query<T>(string sql, object? param = null) where T : class
        {
            using var connection = GetConnection();
            connection.Open();
            var data = connection.Query<T>(sql, param);
            return data;
        }

        public T? QueryScalar<T>(string sql, object? param = null)
        {
            using var connection = GetConnection();
            connection.Open();
            var data = connection.ExecuteScalar<T>(sql, param);
            return data;
        }

        public SqlMapper.GridReader QueryMultiResults(string sql, object? param = null)
        {
            using var connection = GetConnection();
            connection.Open();
            var data = connection.QueryMultiple(sql, param);
            return data;
        }

        public string BuildSqlLikeCondition(string keyword, bool isSearchWildCard = true)
        {
            keyword = keyword.Replace("[", "[[]").Replace("%", "[%]");
            return isSearchWildCard ? "%" + keyword + "%" : keyword;
        }
    }
}