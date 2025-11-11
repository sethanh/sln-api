using Sln.Shared.Contract.Models;
using MediatR;
using Sln.Payment.Contract.Enums;

namespace Sln.Payment.Contract.Requests.Messages;

public class AccountConnectionUpdateRequest : IRequest<AccountConnectionUpdateResponse>
{
    public required Guid Id { get; set; }
    public AccountConnectionStatus Status { get; set; }
}

public class AccountConnectionUpdateResponse : AccountConnectionGetDetailResponse
{
}
