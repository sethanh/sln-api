using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialEpicGetDetailRequest : IRequest<FinancialEpicGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class FinancialEpicGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
