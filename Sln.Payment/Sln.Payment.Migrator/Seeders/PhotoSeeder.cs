using Sln.Payment.Data;
using Sln.Payment.Data.Entities;
using Sln.Shared.Migrator.Abstractions;

namespace Sln.Payment.Migrator.Seeders;

public class PhotoSeeder(PaymentDbContext PaymentDbContext) : IOrderedSeeder
{
    public int Order => 1;

    public async Task Seed()
    {
        var photoSet = PaymentDbContext.Set<Photo>();

        var newPhoto= new Photo()
        {
            FileName = "photo1.jpg",
            RelativePath = "/images/photo1.jpg",
            Size = 2048,
            ContentType = "image/jpeg"
        };

        await photoSet.AddAsync(newPhoto);

        await PaymentDbContext.SaveChangesAsync();
    }
}