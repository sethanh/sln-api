using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.Accounts;

public class AccountGetDetailRequest : IRequest<AccountGetDetailResponse>
{
    public required long Id { get; set; }
}

public class AccountGetDetailResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}
