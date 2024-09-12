using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialEpicCreateRequest : IRequest<FinancialEpicCreateResponse>
{
    public required string Name { get; set; }
}

public class FinancialEpicCreateResponse
{
    public required string Name { get; set; }
}
