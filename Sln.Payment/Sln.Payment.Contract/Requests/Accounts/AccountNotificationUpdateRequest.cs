using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Accounts;

public class AccountNotificationUpdateRequest : IRequest<AccountNotificationUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class AccountNotificationUpdateResponse :AccountNotificationGetDetailResponse
{
}
