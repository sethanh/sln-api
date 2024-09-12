using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class SectionTaskDeleteRequest: IRequest
{
    public long Id { get; set; }
}