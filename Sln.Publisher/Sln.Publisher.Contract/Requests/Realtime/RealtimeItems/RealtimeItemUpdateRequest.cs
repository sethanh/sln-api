using MediatR;
using Sln.Publisher.Contract.Models;

namespace Sln.Publisher.Contract.Requests.Realtime.RealtimeItems;

public class RealtimeItemUpdateRequest : IRequest<RealtimeItemUpdateResponse>
{
    public string? ParentKey { get; set; }
    public required string Key { get; set; }
    public object? Data { get; set; }
}

public class RealtimeItemUpdateResponse: RealtimeItemBaseResponse
{
    
}
