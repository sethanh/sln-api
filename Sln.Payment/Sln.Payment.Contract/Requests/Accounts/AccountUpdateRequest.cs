using MediatR;
using Sln.Payment.Contract.Requests.Messages;

namespace Sln.Payment.Contract.Requests.Accounts;

public class AccountUpdateRequest : IRequest<AccountUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Password { get; set; }
    public Guid? PhotoId { get; set; }
}

public class AccountUpdateResponse : AccountResponse
{

}
