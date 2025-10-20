using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Data.Abstractions
{
    public interface ISeederHistoryStore
    {
        /// <summary>
        /// Lấy danh sách tên các Seeder đã được chạy.
        /// </summary>
        Task<IReadOnlyCollection<string>> GetExecutedSeedersAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Đánh dấu Seeder đã chạy.
        /// </summary>
        Task MarkAsExecutedAsync(string seederName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cố gắng đánh dấu Seeder đã chạy (trả false nếu Seeder đã tồn tại).
        /// </summary>
        Task<bool> TryMarkAsExecutedAsync(string seederName, CancellationToken cancellationToken = default);
    }
}