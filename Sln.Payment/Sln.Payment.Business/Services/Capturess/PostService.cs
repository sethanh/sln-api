using Sln.Payment.Contract.Errors.Capturess;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Capturess;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;

namespace Sln.Payment.Business.Services.Capturess;

public class PostService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private PostManager PostManager => GetService<PostManager>();

    public Task<PostGetAllResponse> GetAll(PostGetAllRequest request)
    {
        var Post = PostManager.GetAll();

        var paginationResponse = PaginationResponse<Post>.Create(
            Post,
            request
        );

        return Task.FromResult(Mapper.Map<PostGetAllResponse>(paginationResponse));
    }

    public Task<PostGetDetailResponse> GetDetail(PostGetDetailRequest request)
    {
        var post = PostManager.FirstOrDefault(o => o.Id == request.Id);

        if (post == null)
        {
            throw new HttpNotFound(PostErrors.POST_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<PostGetDetailResponse>(post));
    }

    public async Task<PostCreateResponse> Create(PostCreateRequest request)
    {
        var post = Mapper.Map<Post>(request);

        PostManager.Add(post);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<PostCreateResponse>(post);
    }

    public async Task<PostUpdateResponse> Update(PostUpdateRequest request)
    {
        var post = PostManager.FirstOrDefault(o => o.Id == request.Id);

        if(post == null)
        {
            throw new HttpBadRequest(PostErrors.POST_NOT_FOUND);
        }

        // TODO: Update post properties

        var updatePost = request.Adapt(post);

        PostManager.Update(updatePost);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<PostUpdateResponse>(updatePost);
    }

    public async Task Delete(PostDeleteRequest request)
    {
        var post = PostManager.FirstOrDefault(o => o.Id == request.Id);

        if (post == null)
        {
            throw new HttpNotFound(PostErrors.POST_NOT_FOUND);
        }

        PostManager.Delete(post);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
