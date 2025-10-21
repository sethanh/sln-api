using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.Accounts;

public class AccountGetAllRequest : PaginationRequest, IRequest<AccountGetAllResponse>
{
}

public class AccountGetAllResponse : PaginationResponse<AccountGetAllResponseItem>
{
}

public class AccountGetAllResponseItem
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateTime CreationTime { get; set; }
}