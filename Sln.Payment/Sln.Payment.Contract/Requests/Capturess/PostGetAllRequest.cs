using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Capturess;

public class PostGetAllRequest : PaginationRequest, IRequest<PostGetAllResponse>
{
}

public class PostGetAllResponse : PaginationResponse<PostGetAllResponseItem>
{
}

public class PostGetAllResponseItem : PostGetDetailResponse
{
}