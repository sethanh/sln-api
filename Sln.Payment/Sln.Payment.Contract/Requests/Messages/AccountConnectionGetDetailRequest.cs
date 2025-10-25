using Sln.Shared.Contract.Models;
using MediatR;
using Sln.Payment.Contract.Enums;

namespace Sln.Payment.Contract.Requests.Messages;

public class AccountConnectionGetDetailRequest : IRequest<AccountConnectionGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class AccountConnectionGetDetailResponse
{
    public required Guid Id { get; set; }
    public Guid? AccountRequestId { get; set; }
    public Guid? AccountAcceptId { get; set; }
    public AccountResponse? AccountRequest { get; set; }
    public AccountResponse? AccountAccept { get; set; }
    public AccountConnectionStatus Status { get; set; }
}
