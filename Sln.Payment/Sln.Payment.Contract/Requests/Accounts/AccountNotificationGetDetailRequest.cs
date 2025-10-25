using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Accounts;

public class AccountNotificationGetDetailRequest : IRequest<AccountNotificationGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class AccountNotificationGetDetailResponse
{
    public required Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public Guid? ReferenceId { get; set; }
    public string? ReferenceObjectName { get; set; }
    public Guid? AccountId { get; set; }
    public string? BodyJson { get; set; }
    public DateTime? CreationTime { get; set; }
}
