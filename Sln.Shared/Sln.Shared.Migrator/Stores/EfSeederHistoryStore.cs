using Microsoft.EntityFrameworkCore;
using Sln.Shared.Data.Abstractions;

namespace Sln.Shared.Migrator.Stores
{
    public class EfSeederHistoryStore<TDbContext, THistory, TKey>(TDbContext dbContext) : ISeederHistoryStore
        where TDbContext : DbContext
        where THistory : class, ISeederHistory<TKey>, new()
        where TKey : struct
    {
        private readonly TDbContext _dbContext = dbContext;

        public async Task<IReadOnlyCollection<string>> GetExecutedSeedersAsync(CancellationToken cancellationToken = default)
        {
            var names = await _dbContext
                .Set<THistory>()
                .AsNoTracking()
                .Select(x => x.SeederName)
                .ToListAsync(cancellationToken);

            return new HashSet<string>(names, StringComparer.OrdinalIgnoreCase);
        }

        public async Task MarkAsExecutedAsync(string seederName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(seederName))
                throw new ArgumentNullException(nameof(seederName));

            _dbContext.Set<THistory>().Add(new THistory
            {
                SeederName = seederName,
                ExecutedAt = DateTime.UtcNow
            });

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException)
            {
                // Có thể do duplicate key => bỏ qua để idempotent
                _dbContext.ChangeTracker.Clear();
            }
        }

        public async Task<bool> TryMarkAsExecutedAsync(string seederName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(seederName))
                return false;

            _dbContext.Set<THistory>().Add(new THistory
            {
                SeederName = seederName,
                ExecutedAt = DateTime.UtcNow
            });

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (DbUpdateException)
            {
                _dbContext.ChangeTracker.Clear();
                return false;
            }
        }
    }
}