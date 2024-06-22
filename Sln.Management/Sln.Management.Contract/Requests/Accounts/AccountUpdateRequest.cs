using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.Accounts;

public class AccountUpdateRequest : IRequest<AccountUpdateResponse>
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}

public class AccountUpdateResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
}
