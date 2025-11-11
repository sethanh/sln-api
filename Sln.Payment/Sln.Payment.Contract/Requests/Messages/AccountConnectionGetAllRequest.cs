using Sln.Shared.Contract.Models;
using MediatR;
using Sln.Payment.Contract.Enums;
using Sln.Payment.Contract.Requests.Messages;

namespace Sln.Payment.Contract.Requests.Messages;

public class AccountConnectionGetAllRequest : PaginationRequest, IRequest<AccountConnectionGetAllResponse>
{
    public required AccountConnectionStatus Status { get; set; }
    public bool? IsSender { get; set; }
}

public class AccountConnectionGetAllResponse : PaginationResponse<AccountConnectionGetAllResponseItem>
{
}

public class AccountConnectionGetAllResponseItem : AccountResponse
{
    public required Guid ConnectionId { get; set; }
}