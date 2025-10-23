namespace Sln.Publisher.Host.Hubs.Models
{
    public class UserConnection
    {
        public string ConnectionId { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string RoomId { get; set; } = default!;
    }
}