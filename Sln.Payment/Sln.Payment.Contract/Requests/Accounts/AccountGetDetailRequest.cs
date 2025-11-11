using Sln.Shared.Contract.Models;
using MediatR;
using Sln.Payment.Contract.Requests.Messages;

namespace Sln.Payment.Contract.Requests.Accounts;

public class AccountGetDetailRequest : IRequest<AccountResponse>
{
    public required Guid Id { get; set; }
}


public class GoogleAccountGetDetailResponse
{
    public required Guid Id { get; set; }
    public string? Email { get; set; }
    public string? Picture { get; set; }
}


public class AccountGetDetailResponse : AccountResponse
{
    public GoogleAccountGetDetailResponse? GoogleAccount { get; set; }
}


public class CurrentAccountGetDetailRequest : IRequest<AccountGetDetailResponse>
{
}

