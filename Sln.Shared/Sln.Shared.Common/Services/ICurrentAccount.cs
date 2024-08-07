namespace Sln.Shared.Common.Services
{
    public interface ICurrentAccount
    {
        public long? Id { get; set; }
        public string? Role { get; set; }

    }
}