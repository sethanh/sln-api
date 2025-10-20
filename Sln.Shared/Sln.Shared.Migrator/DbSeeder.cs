using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sln.Shared.Data.Abstractions;
using Sln.Shared.Migrator.Abstractions;
using Sln.Shared.Migrator.Stores;

namespace Sln.Shared.Migrator
{
    public static class DbSeeder
    {
        public static async Task Run<TDbContext, THistory, TKey>(IHost host, bool force = false)
            where TDbContext : DbContext
            where THistory : class, ISeederHistory<TKey>, new()
            where TKey : struct
        {

            if (!force)
            {
                var question = "Do you want to seed the database? (y/n)";
                Console.WriteLine(question);
                var answer = Console.ReadLine();
                Console.WriteLine($"You answered: {answer}");
                if (!string.Equals(answer?.Trim(), "y", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Skip seeding.");
                    return;
                }
            }

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var dbContext = services.GetRequiredService<TDbContext>();
            var historyStore = new EfSeederHistoryStore<TDbContext, THistory, TKey>(dbContext);

            var executedSeeders = new HashSet<string>(
                (await historyStore.GetExecutedSeedersAsync()).Select(x => x),
                StringComparer.OrdinalIgnoreCase
            );

            var assembly = Assembly.GetEntryAssembly() ?? throw new Exception("Cannot determine entry assembly.");

            // Lấy tất cả Seeder (ISeeder hoặc IOrderedSeeder)
            var seederTypes = assembly.GetTypes()
                .Where(t => typeof(ISeeder).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                .ToList();

            if (seederTypes.Count == 0)
            {
                Console.WriteLine("⚠️  No seeders found — skipping seeding.");
                return;
            }

            var seederInstances = seederTypes
                .Select(t =>
                {
                    if (ActivatorUtilities.CreateInstance(services, t) is not ISeeder instance)
                        throw new Exception($"Cannot create instance of {t.FullName}");

                    var order = (instance is IOrderedSeeder ordered) ? ordered.Order : int.MaxValue;
                    return new
                    {
                        Type = t,
                        Instance = instance,
                        Name = t.FullName ?? t.Name,
                        Order = order
                    };
                })
                .OrderBy(x => x.Order)
                .ToList();

            Console.WriteLine($"🔹 Found {seederInstances.Count} seeders.");

            foreach (var seeder in seederInstances)
            {
                if (executedSeeders.Contains(seeder.Name))
                {
                    Console.WriteLine($"⏩ Skip: {seeder.Name}");
                    continue;
                }

                Console.WriteLine($"▶ Running seeder: {seeder.Name} (Order: {(seeder.Order == int.MaxValue ? "none" : seeder.Order.ToString())})");
                try
                {
                    await seeder.Instance.Seed();
                    await historyStore.MarkAsExecutedAsync(seeder.Name);
                    Console.WriteLine($"✅ Completed: {seeder.Name}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error in {seeder.Name}: {ex.Message}");
                    throw;
                }
            }

            Console.WriteLine("🎉 All seeders completed.");
        }
    }
}