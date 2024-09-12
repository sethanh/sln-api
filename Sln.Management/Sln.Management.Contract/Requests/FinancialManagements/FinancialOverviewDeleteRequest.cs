using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialOverviewDeleteRequest: IRequest
{
    public long Id { get; set; }
}