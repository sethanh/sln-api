using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Messages;

public class AccountConnectionGetAllRequest : PaginationRequest, IRequest<AccountConnectionGetAllResponse>
{
}

public class AccountConnectionGetAllResponse : PaginationResponse<AccountConnectionGetAllResponseItem>
{
}

public class AccountConnectionGetAllResponseItem : AccountResponse
{
    
}