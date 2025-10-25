using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Accounts;

public class AccountNotificationCreateRequest : IRequest<AccountNotificationCreateResponse>
{
    public required string Name { get; set; }
}

public class AccountNotificationCreateResponse
{
    public required string Name { get; set; }
}
