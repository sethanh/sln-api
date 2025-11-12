using Sln.Payment.Contract.Errors.Payments;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Payments;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Payment.Business.Services.Payments;

public class PaymentQrTransactionService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private PaymentQrTransactionManager PaymentQrTransactionManager => GetService<PaymentQrTransactionManager>();

    public Task<PaymentQrTransactionGetAllResponse> GetAll(PaymentQrTransactionGetAllRequest request)
    {
        var PaymentQrTransaction = PaymentQrTransactionManager.GetAll();

        var paginationResponse = PaginationResponse<PaymentQrTransaction>.Create(
            PaymentQrTransaction,
            request
        );

        return Task.FromResult(Mapper.Map<PaymentQrTransactionGetAllResponse>(paginationResponse));
    }

    public Task<PaymentQrTransactionGetDetailResponse> GetDetail(PaymentQrTransactionGetDetailRequest request)
    {
        var paymentQrTransaction = PaymentQrTransactionManager.FirstOrDefault(o => o.Id == request.Id);

        if (paymentQrTransaction == null)
        {
            throw new HttpNotFound(PaymentQrTransactionErrors.PAYMENT_QR_TRANSACTION_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<PaymentQrTransactionGetDetailResponse>(paymentQrTransaction));
    }

    public async Task<PaymentQrTransactionCreateResponse> Create(PaymentQrTransactionCreateRequest request)
    {
        var paymentQrTransaction = Mapper.Map<PaymentQrTransaction>(request);

        PaymentQrTransactionManager.Add(paymentQrTransaction);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<PaymentQrTransactionCreateResponse>(paymentQrTransaction);
    }

    public async Task<PaymentQrTransactionUpdateResponse> Update(PaymentQrTransactionUpdateRequest request)
    {
        var paymentQrTransaction = PaymentQrTransactionManager.FirstOrDefault(o => o.Id == request.Id);

        if (paymentQrTransaction == null)
        {
            throw new HttpBadRequest(PaymentQrTransactionErrors.PAYMENT_QR_TRANSACTION_NOT_FOUND);
        }

        // TODO: Update paymentQrTransaction properties

        var updatedPaymentQrTransaction = PaymentQrTransactionManager.Update(paymentQrTransaction);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<PaymentQrTransactionUpdateResponse>(updatedPaymentQrTransaction);
    }

    public async Task Delete(PaymentQrTransactionDeleteRequest request)
    {
        var paymentQrTransaction = PaymentQrTransactionManager.FirstOrDefault(o => o.Id == request.Id);

        if (paymentQrTransaction == null)
        {
            throw new HttpNotFound(PaymentQrTransactionErrors.PAYMENT_QR_TRANSACTION_NOT_FOUND);
        }

        PaymentQrTransactionManager.Delete(paymentQrTransaction);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
