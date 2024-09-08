using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class ImportanceTaskDeleteRequest: IRequest
{
    public long Id { get; set; }
}