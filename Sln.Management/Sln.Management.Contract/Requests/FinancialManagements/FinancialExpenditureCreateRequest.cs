using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialExpenditureCreateRequest : IRequest<FinancialExpenditureCreateResponse>
{
    public required string Name { get; set; }
}

public class FinancialExpenditureCreateResponse
{
    public required string Name { get; set; }
}
