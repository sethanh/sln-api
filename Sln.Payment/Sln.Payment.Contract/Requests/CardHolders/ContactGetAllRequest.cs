using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.CardHolders;

public class ContactGetAllRequest : PaginationRequest, IRequest<ContactGetAllResponse>
{
}

public class ContactGetAllResponse : PaginationResponse<ContactGetAllResponseItem>
{
}

public class ContactGetAllResponseItem:ContactGetDetailResponse
{

}