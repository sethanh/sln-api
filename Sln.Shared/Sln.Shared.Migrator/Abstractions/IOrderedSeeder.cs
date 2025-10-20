namespace Sln.Shared.Migrator.Abstractions
{
    public interface IOrderedSeeder : ISeeder
    {
        public int Order { get; }
    }
}