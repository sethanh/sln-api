using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialExpenditureDeleteRequest: IRequest
{
    public long Id { get; set; }
}