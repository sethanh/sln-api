using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.Accounts;

public class AccountDeleteRequest: IRequest
{
    public long Id { get; set; }
}