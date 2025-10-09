using MediatR;
using Sln.Payment.Contract.Requests.Uploads;
using Sln.Payment.Business.Services.Uploads;

namespace Sln.Payment.Host.RequestHandlers.Uploads;

public class PhotoUpdateHandler(PhotoService photoService) : IRequestHandler<PhotoUpdateRequest, PhotoUpdateResponse>
{
    public Task<PhotoUpdateResponse> Handle(PhotoUpdateRequest request, CancellationToken cancellationToken)
    {
        return photoService.Update(request);
    }
}