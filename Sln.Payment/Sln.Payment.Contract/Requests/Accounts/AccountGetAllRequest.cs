using Sln.Shared.Contract.Models;
using MediatR;
using Sln.Payment.Contract.Requests.Messages;

namespace Sln.Payment.Contract.Requests.Accounts;

public class AccountGetAllRequest : PaginationRequest, IRequest<AccountGetAllResponse>
{
    public string? Email { get; set; }
}

public class AccountGetAllResponse : PaginationResponse<AccountResponse>
{
}