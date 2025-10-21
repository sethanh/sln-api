using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.Accounts;

public class AccountCreateRequest : IRequest<AccountCreateResponse>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}

public class AccountCreateResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
