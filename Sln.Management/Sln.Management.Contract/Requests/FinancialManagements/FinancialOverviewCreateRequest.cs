using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialOverviewCreateRequest : IRequest<FinancialOverviewCreateResponse>
{
    public required string Name { get; set; }
}

public class FinancialOverviewCreateResponse
{
    public required string Name { get; set; }
}
