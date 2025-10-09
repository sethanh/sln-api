using MediatR;
using Sln.Payment.Contract.Requests.Uploads;
using Sln.Payment.Business.Services.Uploads;

namespace Sln.Payment.Host.RequestHandlers.Uploads;

public class PhotoGetDetailHandler(PhotoService photoService) : IRequestHandler<PhotoGetDetailRequest, PhotoGetDetailResponse>
{
    public Task<PhotoGetDetailResponse> Handle(PhotoGetDetailRequest request, CancellationToken cancellationToken)
    {
        return photoService.GetDetail(request);
    }
}
