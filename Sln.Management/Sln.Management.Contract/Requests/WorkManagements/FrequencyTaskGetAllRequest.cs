using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class FrequencyTaskGetAllRequest : PaginationRequest, IRequest<FrequencyTaskGetAllResponse>
{
}

public class FrequencyTaskGetAllResponse : PaginationResponse<FrequencyTaskGetAllResponseItem>
{
}

public class FrequencyTaskGetAllResponseItem
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}