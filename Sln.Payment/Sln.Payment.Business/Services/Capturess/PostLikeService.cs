using Sln.Payment.Contract.Errors.Capturess;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Capturess;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;

namespace Sln.Payment.Business.Services.Capturess;

public class PostLikeService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private PostLikeManager PostLikeManager => GetService<PostLikeManager>();

    public Task<PostLikeGetAllResponse> GetAll(PostLikeGetAllRequest request)
    {
        var PostLike = PostLikeManager.GetAll();

        var paginationResponse = PaginationResponse<PostLike>.Create(
            PostLike,
            request
        );

        return Task.FromResult(Mapper.Map<PostLikeGetAllResponse>(paginationResponse));
    }

    public Task<PostLikeGetDetailResponse> GetDetail(PostLikeGetDetailRequest request)
    {
        var postLike = PostLikeManager.FirstOrDefault(o => o.Id == request.Id);

        if (postLike == null)
        {
            throw new HttpNotFound(PostLikeErrors.POST_LIKE_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<PostLikeGetDetailResponse>(postLike));
    }

    public async Task<PostLikeCreateResponse> Create(PostLikeCreateRequest request)
    {
        var postLike = Mapper.Map<PostLike>(request);

        PostLikeManager.Add(postLike);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<PostLikeCreateResponse>(postLike);
    }

    public async Task<PostLikeUpdateResponse> Update(PostLikeUpdateRequest request)
    {
        var postLike = PostLikeManager.FirstOrDefault(o => o.Id == request.Id);

        if(postLike == null)
        {
            throw new HttpBadRequest(PostLikeErrors.POST_LIKE_NOT_FOUND);
        }

        // TODO: Update postLike properties

        var updatePostLike = request.Adapt(postLike);

        PostLikeManager.Update(updatePostLike);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<PostLikeUpdateResponse>(updatePostLike);
    }

    public async Task Delete(PostLikeDeleteRequest request)
    {
        var postLike = PostLikeManager.FirstOrDefault(o => o.Id == request.Id);

        if (postLike == null)
        {
            throw new HttpNotFound(PostLikeErrors.POST_LIKE_NOT_FOUND);
        }

        PostLikeManager.Delete(postLike);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
