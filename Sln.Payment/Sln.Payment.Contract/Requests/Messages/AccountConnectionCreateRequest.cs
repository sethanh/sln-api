using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Messages;

public class AccountConnectionCreateRequest : IRequest<AccountConnectionCreateResponse>
{
    public Guid? AccountRequestId { get; set; }
    public Guid? AccountAcceptId { get; set; }
}

public class AccountConnectionCreateResponse
{
    public Guid? AccountRequestId { get; set; }
    public Guid? AccountAcceptId { get; set; }
}
