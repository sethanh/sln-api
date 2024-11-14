using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Accounts;

public class AccountGetAllRequest : PaginationRequest, IRequest<AccountGetAllResponse>
{
}

public class AccountGetAllResponse : PaginationResponse<AccountGetAllResponseItem>
{
}

public class AccountGetAllResponseItem
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required DateTime CreationTime { get; set; }
}