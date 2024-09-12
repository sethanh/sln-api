using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialExpenditureGetDetailRequest : IRequest<FinancialExpenditureGetDetailResponse>
{
    public required long Id { get; set; }
}

public class FinancialExpenditureGetDetailResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}
