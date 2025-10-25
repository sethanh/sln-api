using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Accounts;

public class AccountNotificationDeleteRequest: IRequest
{
    public Guid Id { get; set; }
}