using Sln.Shared.Contract.Models;
using MediatR;
using Sln.Payment.Contract.Enums;
using Sln.Payment.Contract.Requests.Messages;

namespace Sln.Payment.Contract.Requests.Messages;

public class AccountConnectionGetAllRequest : PaginationRequest, IRequest<AccountConnectionGetAllResponse>
{
    public AccountConnectionStatus? Status { get; set; }
    public AccountAction? Action { get; set; }
}

public enum AccountAction
{
    Send = 0,
    receive = 1
}

public class AccountConnectionGetAllResponse : PaginationResponse<AccountConnectionGetAllResponseItem>
{
}

public class AccountConnectionGetAllResponseItem : AccountResponse
{
    public required Guid ConnectionId { get; set; }
    
}