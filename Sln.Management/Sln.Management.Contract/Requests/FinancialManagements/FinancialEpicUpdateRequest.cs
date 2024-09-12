using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.FinancialManagements;

public class FinancialEpicUpdateRequest : IRequest<FinancialEpicUpdateResponse>
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}

public class FinancialEpicUpdateResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
}
