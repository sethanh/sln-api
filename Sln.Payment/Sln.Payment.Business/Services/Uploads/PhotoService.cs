using Sln.Payment.Contract.Errors.Uploads;
using Sln.Payment.Contract.Requests.Uploads;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Uploads;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Microsoft.AspNetCore.Hosting;

namespace Sln.Payment.Business.Services.Uploads;

public class PhotoService(IServiceProvider serviceProvider, IWebHostEnvironment env) : PaymentApplicationService(serviceProvider)
{
    private PhotoManager PhotoManager => GetService<PhotoManager>();
    private readonly string _uploadPath = Path.Combine(env.WebRootPath ?? Path.Combine(env.ContentRootPath, "wwwroot"), "uploads");

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
        var file = request.File;
        if (file == null || file.Length == 0)
            throw new HttpBadRequest(PhotoErrors.FILE_EMPTY);

        var ext = Path.GetExtension(file.FileName);
        var permitted = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        if (!permitted.Contains(ext.ToLowerInvariant()))
            throw new HttpBadRequest(PhotoErrors.FILE_EXTENSION_NOT_ALLOWED);

        // Ensure folder exists
        if (!Directory.Exists(_uploadPath))
            Directory.CreateDirectory(_uploadPath);

        var fileName = $"{Guid.NewGuid()}{ext}";
        var filePath = Path.Combine(_uploadPath, fileName);
        var relativePath = Path.Combine("uploads", fileName).Replace("\\", "/");

        // Save file physically
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Create entity
        var photo = new Photo
        {
            FileName = fileName,
            RelativePath = relativePath,
            Size = file.Length,
            ContentType = file.ContentType ?? "application/octet-stream",
        };

        PhotoManager.Add(photo);
        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<PhotoCreateResponse>(photo);
    }

    public async Task<PhotoUpdateResponse> Update(PhotoUpdateRequest request)
    {
        var photo = PhotoManager.FirstOrDefault(o => o.Id == request.Id);

        if (photo == null)
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
            throw new HttpNotFound(PhotoErrors.PHOTO_NOT_FOUND);

        // Delete file from disk if exists
        var filePath = Path.Combine(_uploadPath, Path.GetFileName(photo.RelativePath));
        if (File.Exists(filePath))
            File.Delete(filePath);

        PhotoManager.Delete(photo);
        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
