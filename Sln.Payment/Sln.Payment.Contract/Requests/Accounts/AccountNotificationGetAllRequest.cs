using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Accounts;

public class AccountNotificationGetAllRequest : PaginationRequest, IRequest<AccountNotificationGetAllResponse>
{
}

public class AccountNotificationGetAllResponse : PaginationResponse<AccountNotificationGetAllResponseItem>
{
}

public class AccountNotificationGetAllResponseItem : AccountNotificationGetDetailResponse
{
}