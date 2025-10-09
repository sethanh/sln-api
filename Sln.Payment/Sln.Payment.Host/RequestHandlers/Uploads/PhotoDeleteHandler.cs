using MediatR;
using Sln.Payment.Contract.Requests.Uploads;
using Sln.Payment.Business.Services.Uploads;

namespace Sln.Payment.Host.RequestHandlers.Uploads;

public class PhotoDeleteHandler(PhotoService photoService) : IRequestHandler<PhotoDeleteRequest>
{
    public Task Handle(PhotoDeleteRequest request, CancellationToken cancellationToken)
    {
        return photoService.Delete(request);
    }
}
