using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialEpicGetAllRequest : PaginationRequest, IRequest<FinancialEpicGetAllResponse>
{
}

public class FinancialEpicGetAllResponse : PaginationResponse<FinancialEpicGetAllResponseItem>
{
}

public class FinancialEpicGetAllResponseItem
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}