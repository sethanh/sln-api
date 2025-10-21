using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialOverviewGetDetailRequest : IRequest<FinancialOverviewGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class FinancialOverviewGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
