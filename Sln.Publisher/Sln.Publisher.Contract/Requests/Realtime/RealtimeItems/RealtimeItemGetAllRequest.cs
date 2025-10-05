using System.Dynamic;
using Sln.Publisher.Contract.Models;
using MongoDB.Bson;
using ThirdParty.Json.LitJson;
using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Publisher.Contract.Requests.Realtime.RealtimeItems;

public class RealtimeItemGetAllRequest : PaginationRequest, IRequest<RealtimeItemGetAllResponse>
{
    public string? ParentKey { get; set; }
}

public class RealtimeItemGetAllResponse : PaginationResponse<RealtimeItemGetAllResponseItem>
{
}

public class RealtimeItemGetAllResponseItem(): RealtimeItemBaseResponse
{
    
}