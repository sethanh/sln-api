using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Accounts;

public class AccountGetDetailRequest : IRequest<AccountGetDetailResponse>
{
    public required long Id { get; set; }
}

public class AccountGetDetailResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}
