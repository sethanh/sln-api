using Microsoft.AspNetCore.SignalR;
using Sln.Publisher.Host.Hubs.Models;

namespace Sln.Publisher.Host.Hubs
{
    public class MeetingHub : Hub
    {
        // roomId -> list connections
        private static readonly Dictionary<string, List<UserConnection>> Rooms = new();
        // connectionId -> (userId, roomId)
        private static readonly Dictionary<string, UserConnection> Connections = new();

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (Connections.TryGetValue(Context.ConnectionId, out var uc))
            {
                if (Rooms.TryGetValue(uc.RoomId, out var list))
                {
                    list.RemoveAll(x => x.ConnectionId == Context.ConnectionId);
                    if (list.Count == 0) Rooms.Remove(uc.RoomId);
                }
                Connections.Remove(Context.ConnectionId);

                await Groups.RemoveFromGroupAsync(Context.ConnectionId, uc.RoomId);
                await Clients.Group(uc.RoomId).SendAsync("UserLeft", new { userId = uc.UserId });
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task JoinRoom(string roomId, string userId)
        {
            var uc = new UserConnection
            {
                ConnectionId = Context.ConnectionId,
                UserId = userId,
                RoomId = roomId
            };

            if (!Rooms.ContainsKey(roomId))
                Rooms[roomId] = new List<UserConnection>();

            // gửi danh sách người đã có cho người mới
            var existing = Rooms[roomId].Select(x => new { userId = x.UserId }).ToList();

            Rooms[roomId].Add(uc);
            Connections[Context.ConnectionId] = uc;

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);

            // gửi về client mới
            await Clients.Caller.SendAsync("ExistingParticipants", existing);

            // thông báo tới room: có người mới
            await Clients.GroupExcept(roomId, Context.ConnectionId)
                .SendAsync("UserJoined", new { userId });
        }

        // Signaling: offer/answer/candidate gửi theo userId, server định tuyến theo connectionId
        private string? ResolveConnectionId(string roomId, string toUserId)
        {
            if (!Rooms.ContainsKey(roomId)) return null;
            return Rooms[roomId].FirstOrDefault(x => x.UserId == toUserId)?.ConnectionId;
        }

        public async Task SendOffer(string roomId, string fromUserId, string toUserId, string sdp)
        {
            var toConn = ResolveConnectionId(roomId, toUserId);
            if (toConn != null)
            {
                await Clients.Client(toConn)
                    .SendAsync("ReceiveOffer", new { from = fromUserId, sdp });
            }
        }

        public async Task SendAnswer(string roomId, string fromUserId, string toUserId, string sdp)
        {
            var toConn = ResolveConnectionId(roomId, toUserId);
            if (toConn != null)
            {
                await Clients.Client(toConn)
                    .SendAsync("ReceiveAnswer", new { from = fromUserId, sdp });
            }
        }

        public async Task SendIceCandidate(string roomId, string fromUserId, string toUserId, object candidate)
        {
            var toConn = ResolveConnectionId(roomId, toUserId);
            if (toConn != null)
            {
                await Clients.Client(toConn)
                    .SendAsync("ReceiveIceCandidate", new { from = fromUserId, candidate });
            }
        }

        public async Task LeaveRoom(string roomId, string userId)
        {
            if (Connections.TryGetValue(Context.ConnectionId, out var uc))
            {
                if (Rooms.TryGetValue(roomId, out var list))
                {
                    list.RemoveAll(x => x.ConnectionId == Context.ConnectionId);
                    if (list.Count == 0) Rooms.Remove(roomId);
                }
                Connections.Remove(Context.ConnectionId);
            }

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);
            await Clients.Group(roomId).SendAsync("UserLeft", new { userId });
        }
    }
}