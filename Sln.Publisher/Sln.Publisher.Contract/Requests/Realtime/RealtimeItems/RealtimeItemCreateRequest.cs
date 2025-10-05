using System.Dynamic;
using Sln.Publisher.Contract.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ThirdParty.Json.LitJson;
using MediatR;

namespace Sln.Publisher.Contract.Requests.Realtime.RealtimeItems;

public class RealtimeItemCreateRequest : IRequest<RealtimeItemCreateResponse>
{
    public string? ParentKey { get; set; }
    public required string Key { get; set; }
    public object? Data { get; set; }
    public bool IsBypassCheckExist { get; set; } = false;
}

public class RealtimeItemCreateResponse(): RealtimeItemBaseResponse
{
}
