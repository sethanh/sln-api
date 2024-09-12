using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialEpicDeleteRequest: IRequest
{
    public long Id { get; set; }
}