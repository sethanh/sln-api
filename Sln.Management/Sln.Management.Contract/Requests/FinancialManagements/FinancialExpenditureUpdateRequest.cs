using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialExpenditureUpdateRequest : IRequest<FinancialExpenditureUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class FinancialExpenditureUpdateResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
