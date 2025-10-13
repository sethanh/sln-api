using Sln.Payment.Contract.Errors.Payments;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Payments;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Newtonsoft.Json;
using Sln.Payment.Contract.Values.VietQr;
using Mapster;

namespace Sln.Payment.Business.Services.Payments;

public class PaymentQrService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private PaymentQrManager PaymentQrManager => GetService<PaymentQrManager>();

    public Task<PaymentQrGetAllResponse> GetAll(PaymentQrGetAllRequest request)
    {
        var PaymentQr = PaymentQrManager.GetAll()
            .Where(c => c.CreatedId == CurrentAccount.Id);

        var paginationResponse = PaginationResponse<PaymentQr>.Create(
            PaymentQr,
            request
        );

        return Task.FromResult(Mapper.Map<PaymentQrGetAllResponse>(paginationResponse));
    }

    public Task<PaymentQrGetDetailResponse> GetDetail(PaymentQrGetDetailRequest request)
    {
        var paymentQr = PaymentQrManager.FirstOrDefault(o => o.Id == request.Id);

        if (paymentQr == null)
        {
            throw new HttpNotFound(PaymentQrErrors.PAYMENT_QR_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<PaymentQrGetDetailResponse>(paymentQr));
    }

    public async Task<PaymentQrCreateResponse> Create(PaymentQrCreateRequest request)
    {
        var paymentQr = Mapper.Map<PaymentQr>(request);

        PaymentQrManager.Add(paymentQr);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<PaymentQrCreateResponse>(paymentQr);
    }

    public async Task<PaymentQrUpdateResponse> Update(PaymentQrUpdateRequest request)
    {
        var paymentQr = PaymentQrManager.FirstOrDefault(o => o.Id == request.Id);

        if (paymentQr == null)
        {
            throw new HttpBadRequest(PaymentQrErrors.PAYMENT_QR_NOT_FOUND);
        }

        // TODO: Update paymentQr properties

        var updatedPaymentQr = request.Adapt(paymentQr);
        PaymentQrManager.Update(updatedPaymentQr);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<PaymentQrUpdateResponse>(updatedPaymentQr);
    }

    public async Task Delete(PaymentQrDeleteRequest request)
    {
        var paymentQr = PaymentQrManager.FirstOrDefault(o => o.Id == request.Id);

        if (paymentQr == null)
        {
            throw new HttpNotFound(PaymentQrErrors.PAYMENT_QR_NOT_FOUND);
        }

        PaymentQrManager.Delete(paymentQr);

        await UnitOfWork.SaveChangesAsync();
        return;
    }

    public static async Task<List<BankInfoValue>> GetAllBankInfoAsync()
    {
        var banksInfo = new List<BankInfoValue>();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("https://api.vietqr.io/v2/banks"))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();

                BankInfoResponse body;

                try
                {
                    body = JsonConvert.DeserializeObject<BankInfoResponse>(apiResponse)!;

                    if (body == null || body.Data == null || body.Data.Count == 0)
                    {
                        return banksInfo;
                    }

                    banksInfo.AddRange(body.Data);
                }
                catch
                {
                    return banksInfo;
                }
            }
        }

        return banksInfo;
    }

    public async Task<PaymentQrGetAllBankResponse> GetAllBank(PaymentQrGetAllBankRequest request)
    {
        var banks = await GetAllBankInfoAsync();

        var paginationResponse = PaginationResponse<BankInfoValue>.Create(
            banks,
            request
        );

        return Mapper.Map<PaymentQrGetAllBankResponse>(paginationResponse);
    }


    public static string GetPaymentQr(
        PaymentQrGetQrRequest request
        )
    {
        if (request.AccountNo == null)
        {
            return null;
        }

        var imageUrl = $"https://img.vietqr.io/image/{request.BinCode}-{request.AccountNo}-compact2.png?amount={request.Amount}&addInfo={request.Description}&accountName={request.AccountName}";

        return imageUrl;
    }

    public Task<PaymentQrGetQrResponse> GetQr(PaymentQrGetQrRequest request)
    {
        var qr = GetPaymentQr(request);
        var response = new PaymentQrGetQrResponse
        {
            QrCode = qr
        };

        return Task.FromResult(response);
    }
}
