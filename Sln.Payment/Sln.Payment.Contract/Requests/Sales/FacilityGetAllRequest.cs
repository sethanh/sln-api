using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class FacilityGetAllRequest : PaginationRequest, IRequest<FacilityGetAllResponse>
{
}

public class FacilityGetAllResponse : PaginationResponse<FacilityGetAllResponseItem>
{
}

public class FacilityGetAllResponseItem : FacilityGetDetailResponse
{
}