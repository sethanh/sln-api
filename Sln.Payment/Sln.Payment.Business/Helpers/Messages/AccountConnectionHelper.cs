using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Sln.Payment.Business.Managers.Accounts;
using Sln.Payment.Business.Managers.Messages;
using Sln.Payment.Contract.Enums;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Helpers.Messages;

public class RequestOptions
{
    public AccountConnectionStatus Status { get; set; }
    public bool? IsSender { get; set; }
    public Guid? CurrentAccountId { get; set; }
}

public class AccountConnectionHelper
{
    public static bool IsGetAccountAccept(RequestOptions options, AccountConnection connection)
    {
        bool isConnectionAccepted = options.Status == AccountConnectionStatus.Accepted &&
                                    options.CurrentAccountId == connection.AccountRequestId;

        bool isConnectionWaitAndIsSender = options.Status == AccountConnectionStatus.Wait && options.IsSender == true;

        return isConnectionAccepted || isConnectionWaitAndIsSender;
    }

    public static bool IsGetAccountRequest(RequestOptions options, AccountConnection connection)
    {
        bool isConnectionAccepted = options.Status == AccountConnectionStatus.Accepted &&
                                    options.CurrentAccountId == connection.AccountAcceptId;

        bool isConnectionWaitAndIsNotSender = options.Status == AccountConnectionStatus.Wait &&
                                        options.IsSender == false;

        return isConnectionWaitAndIsNotSender || isConnectionAccepted;
    }
}
