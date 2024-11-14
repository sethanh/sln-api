using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Accounts;

public class AccountDeleteRequest: IRequest
{
    public long Id { get; set; }
}