using Sln.Payment.Contract.Errors.Payments;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Payments;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Payment.Business.Services.Payments;

public class PaymentQrSettingService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private PaymentQrSettingManager PaymentQrSettingManager => GetService<PaymentQrSettingManager>();

    public Task<PaymentQrSettingGetAllResponse> GetAll(PaymentQrSettingGetAllRequest request)
    {
        var PaymentQrSetting = PaymentQrSettingManager.GetAll();

        var paginationResponse = PaginationResponse<PaymentQrSetting>.Create(
            PaymentQrSetting,
            request
        );

        return Task.FromResult(Mapper.Map<PaymentQrSettingGetAllResponse>(paginationResponse));
    }

    public Task<PaymentQrSettingGetDetailResponse> GetDetail(PaymentQrSettingGetDetailRequest request)
    {
        var paymentQrSetting = PaymentQrSettingManager.FirstOrDefault(o => o.Id == request.Id);

        if (paymentQrSetting == null)
        {
            throw new HttpNotFound(PaymentQrSettingErrors.PAYMENT_QR_SETTING_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<PaymentQrSettingGetDetailResponse>(paymentQrSetting));
    }

    public async Task<PaymentQrSettingCreateResponse> Create(PaymentQrSettingCreateRequest request)
    {
        var paymentQrSetting = Mapper.Map<PaymentQrSetting>(request);

        PaymentQrSettingManager.Add(paymentQrSetting);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<PaymentQrSettingCreateResponse>(paymentQrSetting);
    }

    public async Task<PaymentQrSettingUpdateResponse> Update(PaymentQrSettingUpdateRequest request)
    {
        var paymentQrSetting = PaymentQrSettingManager.FirstOrDefault(o => o.Id == request.Id);

        if (paymentQrSetting == null)
        {
            throw new HttpBadRequest(PaymentQrSettingErrors.PAYMENT_QR_SETTING_NOT_FOUND);
        }

        // TODO: Update paymentQrSetting properties

        var updatedPaymentQrSetting = PaymentQrSettingManager.Update(paymentQrSetting);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<PaymentQrSettingUpdateResponse>(updatedPaymentQrSetting);
    }

    public async Task Delete(PaymentQrSettingDeleteRequest request)
    {
        var paymentQrSetting = PaymentQrSettingManager.FirstOrDefault(o => o.Id == request.Id);

        if (paymentQrSetting == null)
        {
            throw new HttpNotFound(PaymentQrSettingErrors.PAYMENT_QR_SETTING_NOT_FOUND);
        }

        PaymentQrSettingManager.Delete(paymentQrSetting);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
