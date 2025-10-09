using Sln.Payment.Contract.Errors.Uploads;
using Sln.Payment.Contract.Requests.Uploads;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Uploads;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Payment.Business.Services.Uploads;

public class PhotoService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private PhotoManager PhotoManager => GetService<PhotoManager>();

    public Task<PhotoGetAllResponse> GetAll(PhotoGetAllRequest request)
    {
        var Photo = PhotoManager.GetAll();

        var paginationResponse = PaginationResponse<Photo>.Create(
            Photo,
            request
        );

        return Task.FromResult(Mapper.Map<PhotoGetAllResponse>(paginationResponse));
    }

    public Task<PhotoGetDetailResponse> GetDetail(PhotoGetDetailRequest request)
    {
        var photo = PhotoManager.FirstOrDefault(o => o.Id == request.Id);

        if (photo == null)
        {
            throw new HttpNotFound(PhotoErrors.PHOTO_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<PhotoGetDetailResponse>(photo));
    }

    public async Task<PhotoCreateResponse> Create(PhotoCreateRequest request)
    {
        var photo = Mapper.Map<Photo>(request);

        PhotoManager.Add(photo);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<PhotoCreateResponse>(photo);
    }

    public async Task<PhotoUpdateResponse> Update(PhotoUpdateRequest request)
    {
        var photo = PhotoManager.FirstOrDefault(o => o.Id == request.Id);

        if(photo == null)
        {
            throw new HttpBadRequest(PhotoErrors.PHOTO_NOT_FOUND);
        }

        // TODO: Update photo properties

        var updatedPhoto = PhotoManager.Update(photo);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<PhotoUpdateResponse>(updatedPhoto);
    }

    public async Task Delete(PhotoDeleteRequest request)
    {
        var photo = PhotoManager.FirstOrDefault(o => o.Id == request.Id);

        if (photo == null)
        {
            throw new HttpNotFound(PhotoErrors.PHOTO_NOT_FOUND);
        }

        PhotoManager.Delete(photo);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
