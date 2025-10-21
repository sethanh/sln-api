using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialOverviewGetAllRequest : PaginationRequest, IRequest<FinancialOverviewGetAllResponse>
{
}

public class FinancialOverviewGetAllResponse : PaginationResponse<FinancialOverviewGetAllResponseItem>
{
}

public class FinancialOverviewGetAllResponseItem
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}