using MediatR;
using Sln.Payment.Contract.Requests.Uploads;
using Sln.Payment.Business.Services.Uploads;

namespace Sln.Payment.Host.RequestHandlers.Uploads;

public class PhotoGetAllHandler(PhotoService photoService) : IRequestHandler<PhotoGetAllRequest, PhotoGetAllResponse>
{
    public Task<PhotoGetAllResponse> Handle(PhotoGetAllRequest request, CancellationToken cancellationToken)
    {
        return photoService.GetAll(request);
    }
}
