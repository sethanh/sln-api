using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialExpenditureUpdateRequest : IRequest<FinancialExpenditureUpdateResponse>
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}

public class FinancialExpenditureUpdateResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
}
