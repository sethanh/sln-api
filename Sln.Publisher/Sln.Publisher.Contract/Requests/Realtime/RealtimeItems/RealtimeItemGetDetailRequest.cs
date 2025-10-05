using Sln.Publisher.Contract.Models;
using MongoDB.Bson;
using MediatR;

namespace Sln.Publisher.Contract.Requests.Realtime.RealtimeItems;

public class RealtimeItemGetDetailRequest : IRequest<RealtimeItemGetDetailResponse>
{
    public string? ParentKey { get; set; }
    public required string Key { get; set; }
}

public class RealtimeItemGetDetailResponse: RealtimeItemBaseResponse
{
}
