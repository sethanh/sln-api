using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Capturess;

public class PostLikeGetAllRequest : PaginationRequest, IRequest<PostLikeGetAllResponse>
{
}

public class PostLikeGetAllResponse : PaginationResponse<PostLikeGetAllResponseItem>
{
}

public class PostLikeGetAllResponseItem : PostLikeGetDetailResponse
{
}