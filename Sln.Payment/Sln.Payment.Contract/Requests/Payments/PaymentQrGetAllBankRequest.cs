using Sln.Shared.Contract.Models;
using MediatR;
using Sln.Payment.Contract.Values.VietQr;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrGetAllBankRequest : PaginationRequest, IRequest<PaymentQrGetAllBankResponse>
{
}

public class PaymentQrGetAllBankResponse : PaginationResponse<PaymentQrGetAllResponseItem>
{
}

public class PaymentQrGetAllBankResponseItem : BankInfoValue
{
}