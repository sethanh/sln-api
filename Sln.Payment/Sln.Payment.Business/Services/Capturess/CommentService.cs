using Sln.Payment.Contract.Errors.Capturess;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Capturess;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;

namespace Sln.Payment.Business.Services.Capturess;

public class CommentService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private CommentManager CommentManager => GetService<CommentManager>();

    public Task<CommentGetAllResponse> GetAll(CommentGetAllRequest request)
    {
        var Comment = CommentManager.GetAll();

        var paginationResponse = PaginationResponse<Comment>.Create(
            Comment,
            request
        );

        return Task.FromResult(Mapper.Map<CommentGetAllResponse>(paginationResponse));
    }

    public Task<CommentGetDetailResponse> GetDetail(CommentGetDetailRequest request)
    {
        var comment = CommentManager.FirstOrDefault(o => o.Id == request.Id);

        if (comment == null)
        {
            throw new HttpNotFound(CommentErrors.COMMENT_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<CommentGetDetailResponse>(comment));
    }

    public async Task<CommentCreateResponse> Create(CommentCreateRequest request)
    {
        var comment = Mapper.Map<Comment>(request);

        CommentManager.Add(comment);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<CommentCreateResponse>(comment);
    }

    public async Task<CommentUpdateResponse> Update(CommentUpdateRequest request)
    {
        var comment = CommentManager.FirstOrDefault(o => o.Id == request.Id);

        if(comment == null)
        {
            throw new HttpBadRequest(CommentErrors.COMMENT_NOT_FOUND);
        }

        // TODO: Update comment properties

        var updateComment = request.Adapt(comment);

        CommentManager.Update(updateComment);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<CommentUpdateResponse>(updateComment);
    }

    public async Task Delete(CommentDeleteRequest request)
    {
        var comment = CommentManager.FirstOrDefault(o => o.Id == request.Id);

        if (comment == null)
        {
            throw new HttpNotFound(CommentErrors.COMMENT_NOT_FOUND);
        }

        CommentManager.Delete(comment);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
