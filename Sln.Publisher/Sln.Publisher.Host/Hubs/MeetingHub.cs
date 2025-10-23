using Microsoft.AspNetCore.SignalR;
using Sln.Publisher.Host.Hubs.Models;
using System.Collections.Concurrent;

namespace Sln.Publisher.Host.Hubs
{
    public class MeetingHub : Hub
    {
        private static readonly ConcurrentDictionary<string, List<UserConnection>> Rooms = new();
        private static readonly ConcurrentDictionary<string, UserConnection> Connections = new();
        private static readonly ConcurrentDictionary<string, object> RoomLocks = new();

        private static object GetRoomLock(string roomId) =>
            RoomLocks.GetOrAdd(roomId, _ => new object());

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (Connections.TryGetValue(Context.ConnectionId, out var uc))
            {
                RemoveFromRoom(uc.RoomId, Context.ConnectionId);

                await Groups.RemoveFromGroupAsync(Context.ConnectionId, uc.RoomId);

                await Clients.Group(uc.RoomId).SendAsync("UserLeft", new { userId = uc.UserId });
                await BroadcastParticipants(uc.RoomId);
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

            var roomLock = GetRoomLock(roomId);
            lock (roomLock)
            {
                var list = Rooms.GetOrAdd(roomId, _ => new List<UserConnection>());

                list.Add(uc);

                Connections[Context.ConnectionId] = uc;
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);

            var existing = GetParticipantIds(roomId, excludeConnectionId: null);
            await Clients.Caller.SendAsync("ExistingParticipants", existing.Select(id => new { userId = id }).ToList());

            await Clients.GroupExcept(roomId, Context.ConnectionId)
                .SendAsync("UserJoined", new { userId });

            await BroadcastParticipants(roomId);
        }

        public async Task LeaveRoom(string roomId, string userId)
        {
            if (Connections.TryGetValue(Context.ConnectionId, out var uc))
            {
                RemoveFromRoom(roomId, Context.ConnectionId);
                Connections.TryRemove(Context.ConnectionId, out _);
            }

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);

            await Clients.Group(roomId).SendAsync("UserLeft", new { userId });
            await BroadcastParticipants(roomId);
        }

        public async Task SendOffer(string roomId, string fromUserId, string toUserId, string sdp)
        {
            foreach (var toConn in ResolveConnectionIds(roomId, toUserId))
            {
                await Clients.Client(toConn).SendAsync("ReceiveOffer", new { from = fromUserId, sdp });
            }
        }

        public async Task SendAnswer(string roomId, string fromUserId, string toUserId, string sdp)
        {
            foreach (var toConn in ResolveConnectionIds(roomId, toUserId))
            {
                await Clients.Client(toConn).SendAsync("ReceiveAnswer", new { from = fromUserId, sdp });
            }
        }

        public async Task SendIceCandidate(string roomId, string fromUserId, string toUserId, object candidate)
        {
            foreach (var toConn in ResolveConnectionIds(roomId, toUserId))
            {
                await Clients.Client(toConn).SendAsync("ReceiveIceCandidate", new { from = fromUserId, candidate });
            }
        }

        private IEnumerable<string> ResolveConnectionIds(string roomId, string toUserId)
        {
            if (!Rooms.TryGetValue(roomId, out var list)) yield break;

            List<UserConnection> snapshot;
            lock (GetRoomLock(roomId))
            {
                snapshot = list.ToList();
            }

            foreach (var it in snapshot.Where(x => x.UserId == toUserId))
                yield return it.ConnectionId;
        }

        private static List<string> GetParticipantIds(string roomId, string? excludeConnectionId)
        {
            if (!Rooms.TryGetValue(roomId, out var list)) return new List<string>();

            IEnumerable<UserConnection> snapshot;
            lock (GetRoomLock(roomId))
            {
                snapshot = list.ToList();
            }

            var q = snapshot;
            if (!string.IsNullOrEmpty(excludeConnectionId))
                q = q.Where(x => x.ConnectionId != excludeConnectionId);

            return q.Select(x => x.UserId).Distinct().ToList();
        }

        private void RemoveFromRoom(string roomId, string connectionId)
        {
            if (!Rooms.TryGetValue(roomId, out var list)) return;

            lock (GetRoomLock(roomId))
            {
                list.RemoveAll(x => x.ConnectionId == connectionId);
                if (list.Count == 0)
                {
                    Rooms.TryRemove(roomId, out _);
                    RoomLocks.TryRemove(roomId, out _);
                }
            }

            Connections.TryRemove(connectionId, out _);
        }

        private async Task BroadcastParticipants(string roomId)
        {
            var participants = GetParticipantIds(roomId, excludeConnectionId: null);
            await Clients.Group(roomId).SendAsync("ParticipantsChanged",
                participants.Select(id => new { userId = id }).ToList());
        }
    }
}