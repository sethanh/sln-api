using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class TaskManagementDeleteRequest: IRequest
{
    public Guid Id { get; set; }
}