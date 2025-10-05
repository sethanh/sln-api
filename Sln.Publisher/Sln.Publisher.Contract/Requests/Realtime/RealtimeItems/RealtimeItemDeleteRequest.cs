using System.Diagnostics.CodeAnalysis;
using Sln.Publisher.Contract.Models;
using MediatR;
using MongoDB.Bson;

namespace Sln.Publisher.Contract.Requests.Realtime.RealtimeItems;

public class RealtimeItemDeleteRequest: IRequest<RealtimeItemRemoveResponse>
{
    public RealtimeItemDeleteRequest()
    {
    }

    [SetsRequiredMembers]
    public RealtimeItemDeleteRequest(string key)
    {
        Key = key;
    }

    public required string Key { get; set; }
}
public class RealtimeItemRemoveResponse:  RealtimeItemBaseResponse
{
}