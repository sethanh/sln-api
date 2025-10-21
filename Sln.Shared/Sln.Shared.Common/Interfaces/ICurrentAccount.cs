namespace Sln.Shared.Common.Interfaces
{
    public interface ICurrentAccount
    {
        public Guid? Id { get; set; }
        public string? Role { get; set; }

    }
}