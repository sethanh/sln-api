using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialExpenditureGetAllRequest : PaginationRequest, IRequest<FinancialExpenditureGetAllResponse>
{
}

public class FinancialExpenditureGetAllResponse : PaginationResponse<FinancialExpenditureGetAllResponseItem>
{
}

public class FinancialExpenditureGetAllResponseItem
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}