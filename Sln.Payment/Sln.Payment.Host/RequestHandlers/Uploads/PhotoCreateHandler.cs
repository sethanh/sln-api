using MediatR;
using Sln.Payment.Contract.Requests.Uploads;
using Sln.Payment.Business.Services.Uploads;

namespace Sln.Payment.Host.RequestHandlers.Uploads;

public class PhotoCreateHandler(PhotoService photoService) : IRequestHandler<PhotoCreateRequest, PhotoCreateResponse>
{
    public Task<PhotoCreateResponse> Handle(PhotoCreateRequest request, CancellationToken cancellationToken)
    {
        return photoService.Create(request);
    }
}