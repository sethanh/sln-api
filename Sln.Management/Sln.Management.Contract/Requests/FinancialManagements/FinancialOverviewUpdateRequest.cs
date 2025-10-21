using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialOverviewUpdateRequest : IRequest<FinancialOverviewUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class FinancialOverviewUpdateResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
